import { Component, OnInit } from "@angular/core";
import { RNC } from '../models/rnc';
import { RNCService } from '../services/rnc.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DetalharRNCModalComponent } from '../detalhar-rnc/detalhar-rnc-modal.component';

@Component({
    selector: 'listar-rnc',
    templateUrl: './listar-rnc.component.html'
})
export class ListarRNCComponent implements OnInit {
    rncs: RNC[];

    constructor(private rncService: RNCService, private modalService: NgbModal) { }

    ngOnInit() {
        this.rncService.getRNC().subscribe(result => {
            this.rncs = result as RNC[];
        });
    }

    getRNCStatusType(cod: number): any {
        switch (cod) {
            case 1:
                return "Aberta";
            case 2:
                return "Aguardando Confirmação";
            case 3:
                return "Aguardando Correção";
            case 4:
                return "Resolvida";
        }
    }

    detalhesModal(rnc: RNC) {
        const modalRef = this.modalService.open(DetalharRNCModalComponent);
        modalRef.componentInstance.rnc = rnc;
    }
}
