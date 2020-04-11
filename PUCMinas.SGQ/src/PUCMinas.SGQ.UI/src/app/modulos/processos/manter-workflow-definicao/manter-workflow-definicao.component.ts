import { Component, OnInit } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { BaseCadastroComponent } from '../../core/base/base-cadastro.component';

import { ProcessoService } from '../services/processo.service';

import { WorkflowDefinicao } from '../models/workflowdefinicao';
import { PassoDefinicao } from '../models/passodefinicao';
import { GenericValidator } from '../../core/generic-form-validation';

@Component({
    selector: 'manter-workflow-definicao',
    templateUrl: './manter-workflow-definicao.component.html'
})
export class ManterWorkflowDefinicaoComponent extends BaseCadastroComponent implements OnInit {
    id: string;

    constructor(private fb: FormBuilder,
        private route: ActivatedRoute,
        private processoService: ProcessoService) {
        super()

        this.validationMessages = {
            nome: {
                required: 'O campo Nome é obrigatório',
                minlength: 'O campo Nome deve ter no mínino 5 caracteres',
                maxlength: 'O campo Nome deve ter no máximo 100 caracteres'
            },
            titulo: {
                required: 'O campo Nome é obrigatório',
                minlength: 'O campo Descrição deve ter no mínino 5 caracteres',
                maxlength: 'O campo Descrição deve ter no máximo 100 caracteres'
            }
        };

        this.genericValidator = new GenericValidator(this.validationMessages);
    }

    ngOnInit(): void {
        this.id = this.route.snapshot.paramMap.get("id");
        try {
            this.carregarWorkflow();
        } catch (e) {
            this.alerts = Array.from([{ type: 'danger', message: 'Erro ao tentar carregar o formulário.' }]);
            console.log('Erro na aplicação: ' + e)
        }
    }

    onSubmit(wd: any) {
        console.log(wd);
    }

    carregarWorkflow() {
        let definido: boolean = false;
        if (this.id != null) { // Alterar
            this.processoService.getWorflowDefinicaoPorId(this.id)
                .subscribe(
                    result => {
                        let wd = result as WorkflowDefinicao;
                        if (wd) {
                            definido = true;
                            this.formulario = this.fb.group({
                                nome: [wd.nome, [Validators.required, Validators.minLength(5), Validators.maxLength(100)]],
                                passos: this.carregarPassos(wd.passosDefinicao)
                            });
                        }
                    }, error => {
                        this.alerts = Array.from([{ type: 'danger', message: error }]);
                    });
        }

        if (!definido) {
            this.formulario = this.fb.group({
                nome: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]],
                passos: this.fb.array([
                    this.iniciarPasso(),
                ])
            });
        }
    }

    carregarPassos(passos: PassoDefinicao[]): FormArray {
        let control = <FormArray>this.formulario.controls['passos'];
        control.clear();
        for (let passo of passos) {
            control.push(this.fb.group({
                titulo: [passo.titulo, [Validators.required, Validators.minLength(5), Validators.maxLength(100)]],
                descricao: [passo.descricao]
            }));
        }
        return control;
    }

    iniciarPasso() {
        return this.fb.group({
            titulo: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]],
            descricao: ['']
        });
    }

    adicionarPasso() {
        const control = <FormArray>this.formulario.controls['passos'];
        control.push(this.iniciarPasso());
    }

    removerPasso(i: number) {
        const control = <FormArray>this.formulario.controls['passos'];
        control.removeAt(i);
    }
}
