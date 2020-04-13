import { Component, OnInit } from "@angular/core";

import { ProcessoService } from '../services/processo.service';

import { Workflow } from '../models/workflow';
import { IdentityService } from 'src/app/identity/services/identity.service';
import { User } from 'src/app/identity/models/user';

@Component({
    selector: 'listar-workflow-andamento',
    templateUrl: './listar-workflow-andamento.component.html'
})
export class ListarWorkflowAndamentoComponent implements OnInit {
    currentUser: User;
    wfs: Workflow[];

    constructor(private processoService: ProcessoService,
        private identityService: IdentityService) {
        this.identityService.currentUser.subscribe(x => this.currentUser = x);
    }

    ngOnInit() {
        this.processoService.getWorflowEmAndamento().subscribe(result => {
            this.wfs = result as Workflow[];
        });
    }
}
