import { Component, OnInit } from "@angular/core";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

import { DetalharWorkflowDefinicaoComponent } from '../detalhar-workflow-definicao/detalhar-workflow-definicao.component';

import { ProcessoService } from '../services/processo.service';
import { IdentityService } from 'src/app/identity/services/identity.service';

import { WorkflowDefinicao } from '../models/workflowdefinicao';
import { User } from 'src/app/identity/models/user';
import { Workflow } from '../models/workflow';

@Component({
    selector: 'listar-workflow-definicao',
    templateUrl: './listar-workflow-definicao.component.html'
})
export class ListarWorkflowDefinicaoComponent implements OnInit {
    currentUser: User;
    wds: WorkflowDefinicao[];

    constructor(private processoService: ProcessoService,
        private modalService: NgbModal,
        private identityService: IdentityService,
        private router: Router) {
        this.identityService.currentUser.subscribe(x => this.currentUser = x);
    }

    ngOnInit() {
        this.processoService.getWorflowDefinicao().subscribe(result => {
            this.wds = result as WorkflowDefinicao[];
        });
    }

    detalhesModal(wd: WorkflowDefinicao) {
        const modalRef = this.modalService.open(DetalharWorkflowDefinicaoComponent);
        modalRef.componentInstance.wd = wd;
    }

    criarWorkflow(id: string) {
        this.processoService.criarWorkflow(id).subscribe(result => {
            let workflow = result as Workflow;
            this.router.navigate(['run-workflow/' + workflow.id]);
        }, error => {
        });
    }
}
