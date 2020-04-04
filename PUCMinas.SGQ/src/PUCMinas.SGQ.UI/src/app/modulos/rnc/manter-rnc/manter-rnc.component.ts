import { OnInit, Component, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormControlName } from '@angular/forms';
import { ValidationMessages, DisplayMessage, GenericValidator } from '../../core/generic-form-validation';
import { Observable, fromEvent, merge } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { RNCService } from '../services/rnc.service';
import { RNC } from '../models/rnc';
import { AlertService } from '../../core/services/alert.service';
import { Gravidade } from '../models/gravidade';
import { Causa } from '../models/causa';
import { Acao } from '../models/acao';

@Component({
    selector: 'manter-rnc',
    templateUrl: './manter-rnc.component.html'
})
export class ManterRNCComponent implements OnInit, AfterViewInit {
    submitted = false;
    rncForm: FormGroup;
    formResult: string = '';
    id: string;
    rnc: RNC;
    classificacao = [];
    gravidades: Gravidade[];
    causas: Causa[];
    acoes: Acao[];

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
                                gravidade: [this.rnc.gravidadeId ? this.rnc.gravidadeId : null],
                                causa: [this.rnc.causaId ? this.rnc.causaId : null],
                                acao: [this.rnc.acaoId ? this.rnc.acaoId : null]
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
                descricao: ['', [Validators.minLength(5), Validators.maxLength(1000)]],
                classificacao: [null],
                gravidade: [null],
                causa: [null],
                acao: [null]
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

    onSubmit() {

    }
}
