import { OnInit, Component, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControlName } from '@angular/forms';
import { ValidationMessages, DisplayMessage, GenericValidator } from '../../core/generic-form-validation';
import { Observable, fromEvent, merge } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { RNCService } from '../services/rnc.service';
import { RNC } from '../models/rnc';
import { AlertService } from '../../core/services/alert.service';
import { Gravidade } from '../models/gravidade';
import { Causa } from '../models/causa';
import { Acao } from '../models/acao';
import { Alert } from '../../core/models/alert';
import { Guid } from 'guid-typescript';

@Component({
    selector: 'manter-rnc',
    templateUrl: './manter-rnc.component.html'
})
export class ManterRNCComponent implements OnInit, AfterViewInit {
    submitted = false;
    loading = false;

    rncForm: FormGroup;
    formResult: string = '';
    id: string;
    rnc: RNC;
    classificacao = [];
    gravidades: Gravidade[];
    causas: Causa[];
    acoes: Acao[];
    alerts: Alert[];

    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    validationMessages: ValidationMessages;
    genericValidator: GenericValidator;
    displayMessage: DisplayMessage = {};
    mudancasNaoSalvas: boolean;

    constructor(private fb: FormBuilder,
        private route: ActivatedRoute,
        private rncService: RNCService,
        private alertService: AlertService) {
        this.classificacao = [
            { value: '1', label: 'Já Ocorrido' },
            { value: '2', label: 'Oportunidade de Melhoria' },
            { value: '3', label: 'Não Conformidade' }
        ]

        this.validationMessages = {
            ocorrencia: {
                required: 'O campo Ocorrência é obrigatório',
                minlength: 'O campo Ocorrência deve ter no mínino 5 caracteres',
                maxlength: 'O campo Ocorrência deve ter no máximo 200 caracteres'
            },
            descricao: {
                minlength: 'O campo Descrição deve ter no mínino 5 caracteres',
                maxlength: 'O campo Descrição deve ter no máximo 1000 caracteres'
            }
        };

        this.genericValidator = new GenericValidator(this.validationMessages);
    }

    ngOnInit(): void {
        this.rncService.getGravidade().subscribe(result => {
            this.gravidades = result as Gravidade[];
        }, error => {
            console.log(error);
            this.alertService.error(error.error.errors[0]);
        });

        this.rncService.getCausa().subscribe(result => {
            this.causas = result as Causa[];
        }, error => {
            console.log(error);
            this.alertService.error(error.error.errors[0]);
        });

        this.rncService.getAcao().subscribe(result => {
            this.acoes = result as Acao[];
        }, error => {
            console.log(error);
            this.alertService.error(error.error.errors[0]);
        });

        let definido: boolean = false;
        this.id = this.route.snapshot.paramMap.get("id");
        if (this.id == null) {
            // criar
        }
        else {
            this.rncService.getRNCPorId(this.id)
                .subscribe(
                    result => {
                        this.rnc = result as RNC;

                        if (this.rnc) {
                            definido = true;
                            this.rncForm = this.fb.group({
                                ocorrencia: [this.rnc.ocorrencia, [Validators.required, Validators.minLength(5), Validators.maxLength(200)]],
                                descricao: [this.rnc.descricao, [Validators.minLength(5), Validators.maxLength(1000)]],
                                classificacao: [this.rnc.classificacao ? this.rnc.classificacao : null],
                                gravidade: [this.rnc.gravidade ? this.rnc.gravidade.id : null],
                                causa: [this.rnc.causa ? this.rnc.causa.id : null],
                                acao: [this.rnc.acao ? this.rnc.acao.id : null],
                                prazo: ['']
                            });
                        }
                    }, error => {
                        console.log(error);
                        this.alertService.error(error.error.errors[0]);
                    });
        }

        if (!definido) {
            this.rncForm = this.fb.group({
                ocorrencia: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(200)]],
                descricao: [null, [Validators.minLength(5), Validators.maxLength(1000)]],
                classificacao: [null],
                gravidade: [null],
                causa: [null],
                acao: [null],
                prazo: [1]
            });
        }
    }

    ngAfterViewInit(): void {
        let controlBlurs: Observable<any>[] = this.formInputElements
            .map((FormControl: ElementRef) => fromEvent(FormControl.nativeElement, 'blur'));

        merge(...controlBlurs).subscribe(() => {
            this.displayMessage = this.genericValidator.processarMensagem(this.rncForm);
            this.mudancasNaoSalvas = true;
        });
    }

    get f() { return this.rncForm.controls; }

    onSubmit() {
        try {
            if (this.rncForm.dirty && this.rncForm.valid) {
                this.loading = true;
                if (this.rnc == null) {
                    this.rnc = new RNC();
                }
                this.rnc.ocorrencia = this.f.ocorrencia.value;
                this.rnc.descricao = this.f.descricao.value;
                this.rnc.classificacao = this.f.classificacao.value;
                this.rnc.status = 1;
                this.rnc.gravidade = this.gravidades.find(g => g.id == this.f.gravidade.value);
                this.rnc.causa = this.causas.find(g => g.id == this.f.causa.value);
                this.rnc.acao = this.acoes.find(g => g.id == this.f.acao.value);
                let prazoCalculado = Date.now();
                // 86400000 milessegundos corresponde a 1 dia
                if (this.f.prazo.value) {
                    prazoCalculado = prazoCalculado + (this.f.prazo.value * 86400000);
                    this.rnc.prazo = new Date(prazoCalculado);
                } else {
                    prazoCalculado = prazoCalculado + 86400000;
                    this.rnc.prazo = new Date(prazoCalculado);
                }
                if (this.id == null) {
                    this.rnc.id = Guid.EMPTY;
                    this.criarRNC();
                }
                else {
                    this.atualizarRNC();
                }
            } else {
                // não submeteu
            }
        } catch (e) {
            this.loading = false;
            this.alerts = Array.from([{ type: 'danger', message: 'Erro ao tentar salvar RNC.' }]);
            console.log('Erro na aplicação: ' + e)
        }
    }

    criarRNC() {
        this.rncService.addRNC(this.rnc).subscribe(result => {
            this.loading = false;
            this.alerts = Array.from([{ type: 'success', message: 'Nova RNC criada com sucesso!' }]);
            this.rncForm.reset();
        }, error => {
            this.loading = false;
            this.alerts = Array.from([{ type: 'danger', message: error }]);
        });
    }

    atualizarRNC() {

    }

    closeAlert(alert: Alert) {
        this.alerts.splice(this.alerts.indexOf(alert), 1);
    }

    clearAlerts() {
        this.alerts = [];
    }
}
