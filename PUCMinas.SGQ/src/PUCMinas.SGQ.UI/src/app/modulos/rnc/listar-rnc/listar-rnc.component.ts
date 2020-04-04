import { Component, OnInit } from "@angular/core";
import { RNC } from '../models/rnc';
import { RNCService } from '../services/rnc.service';

@Component({
    selector: 'listar-rnc',
    templateUrl: './listar-rnc.component.html'
})
export class ListarRNCComponent implements OnInit {

    rncs: RNC[];

    constructor(private rncService: RNCService) { }

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
}
