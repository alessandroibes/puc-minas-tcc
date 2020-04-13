import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { GenericValidator } from '../../core/generic-form-validation';
import { ActivatedRoute } from '@angular/router';
import { RNCService } from '../services/rnc.service';
import { RNC } from '../models/rnc';
import { Gravidade } from '../models/gravidade';
import { Causa } from '../models/causa';
import { Acao } from '../models/acao';
import { Guid } from 'guid-typescript';
import { BaseCadastroComponent } from '../../core/base/base-cadastro.component';

@Component({
    selector: 'manter-rnc',
    templateUrl: './manter-rnc.component.html'
})
export class ManterRNCComponent extends BaseCadastroComponent implements OnInit {
    id: string;
    rnc: RNC;
    classificacao = [];
    gravidades: Gravidade[];
    causas: Causa[];
    acoes: Acao[];

    constructor(private fb: FormBuilder,
        private route: ActivatedRoute,
        private rncService: RNCService) {
        super()

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
        this.id = this.route.snapshot.paramMap.get("id");
        try {
            this.carregarGravidades();
            this.carregarCausas();
            this.carregarAcoes();
            this.carregarRNCs();
        } catch (e) {
            this.alerts = Array.from([{ type: 'danger', message: 'Erro ao tentar carregar o formulário.' }]);
            console.log('Erro na aplicação: ' + e)
        }
    }

    onSubmit() {
        try {
            if (this.formulario.dirty && this.formulario.valid) {
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
                if (this.id == null) {
                    this.rnc.dataOcorrencia = new Date();
                }
                let dataOcorrencia = new Date(this.rnc.dataOcorrencia).getTime();
                // 86400000 milessegundos corresponde a 1 dia
                if (this.f.prazo.value) {
                    dataOcorrencia = dataOcorrencia + (this.f.prazo.value * 86400000);
                    this.rnc.prazo = new Date(dataOcorrencia);
                } else {
                    dataOcorrencia = dataOcorrencia + 86400000;
                    this.rnc.prazo = new Date(dataOcorrencia);
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

            this.formulario.reset();
            this.limparFormulario();
        } catch (e) {
            this.loading = false;
            this.alerts = Array.from([{ type: 'danger', message: 'Erro ao tentar salvar RNC.' }]);
            console.log('Erro na aplicação: ' + e)
        }
    }

    carregarGravidades() {
        this.rncService.getGravidade().subscribe(result => {
            this.gravidades = result as Gravidade[];
        }, error => {
            this.alerts = Array.from([{ type: 'danger', message: error }]);
        });
    }

    carregarCausas() {
        this.rncService.getCausa().subscribe(result => {
            this.causas = result as Causa[];
        }, error => {
            this.alerts = Array.from([{ type: 'danger', message: error }]);
        });
    }

    carregarAcoes() {
        this.rncService.getAcao().subscribe(result => {
            this.acoes = result as Acao[];
        }, error => {
            this.alerts = Array.from([{ type: 'danger', message: error }]);
        });
    }

    carregarRNCs() {
        let definido: boolean = false;
        if (this.id != null) { // Alterar
            this.rncService.getRNCPorId(this.id)
                .subscribe(
                    result => {
                        this.rnc = result as RNC;
                        if (this.rnc) {
                            definido = true;
                            let p = new Date(this.rnc.prazo).getTime();
                            let o = new Date(this.rnc.dataOcorrencia).getTime();
                            let num = Number.parseInt(((p - o) / 86400000).toString());
                            this.formulario = this.fb.group({
                                ocorrencia: [this.rnc.ocorrencia, [Validators.required, Validators.minLength(5), Validators.maxLength(200)]],
                                descricao: [this.rnc.descricao, [Validators.minLength(5), Validators.maxLength(1000)]],
                                classificacao: [this.rnc.classificacao ? this.rnc.classificacao : null],
                                gravidade: [this.rnc.gravidade ? this.rnc.gravidade.id : null],
                                causa: [this.rnc.causa ? this.rnc.causa.id : null],
                                acao: [this.rnc.acao ? this.rnc.acao.id : null],
                                prazo: [num]
                            });
                        }
                    }, error => {
                        this.alerts = Array.from([{ type: 'danger', message: error }]);
                    });
        }

        if (!definido) {
            this.limparFormulario();
        }
    }

    limparFormulario() {
        this.formulario = this.fb.group({
            ocorrencia: [null, [Validators.required, Validators.minLength(5), Validators.maxLength(200)]],
            descricao: [null, [Validators.minLength(5), Validators.maxLength(1000)]],
            classificacao: [null],
            gravidade: [null],
            causa: [null],
            acao: [null],
            prazo: [1]
        });
    }

    criarRNC() {
        this.rncService.addRNC(this.rnc).subscribe(result => {
            this.loading = false;
            this.alerts = Array.from([{ type: 'success', message: 'Nova RNC criada com sucesso!' }]);
        }, error => {
            this.loading = false;
            this.alerts = Array.from([{ type: 'danger', message: error }]);
        });
    }

    atualizarRNC() {
        this.rncService.updateRNC(this.rnc, this.id).subscribe(result => {
            this.loading = false;
            this.alerts = Array.from([{ type: 'success', message: 'RNC alterada com sucesso!' }]);
        }, error => {
            this.loading = false;
            this.alerts = Array.from([{ type: 'danger', message: error }]);
        });
    }
}
