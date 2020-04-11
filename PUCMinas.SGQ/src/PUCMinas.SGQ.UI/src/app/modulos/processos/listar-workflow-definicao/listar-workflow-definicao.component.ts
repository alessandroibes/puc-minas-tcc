import { Component, OnInit } from "@angular/core";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { DetalharWorkflowDefinicaoComponent } from '../detalhar-workflow-definicao/detalhar-workflow-definicao.component';

import { ProcessoService } from '../services/processo.service';

import { WorkflowDefinicao } from '../models/workflowdefinicao';

@Component({
    selector: 'listar-workflow-definicao',
    templateUrl: './listar-workflow-definicao.component.html'
})
export class ListarWorkflowDefinicaoComponent implements OnInit {
    wds: WorkflowDefinicao[];

    constructor(private processoService: ProcessoService, private modalService: NgbModal) { }

    ngOnInit() {
        this.processoService.getWorflowDefinicao().subscribe(result => {
            this.wds = result as WorkflowDefinicao[];
        });
    }

    detalhesModal(wd: WorkflowDefinicao) {
        const modalRef = this.modalService.open(DetalharWorkflowDefinicaoComponent);
        modalRef.componentInstance.wd = wd;
    }
}
