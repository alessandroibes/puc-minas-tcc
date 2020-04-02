import { Component, OnInit } from "@angular/core";
import { RNC } from '../models/rnc';
import { IncidenteService } from '../incidentes.service';
import { StatusRNC } from '../models/status';

@Component({
    selector: 'app-listar-incidentes',
    templateUrl: './listar-incidentes.component.html'
})
export class ListarIncidentesComponent implements OnInit {

    rncs: RNC[];

    constructor(private incidenteService: IncidenteService) { }

    ngOnInit() {
        this.incidenteService.getRNC().subscribe(result => {
            this.rncs = result as RNC[];
        });
    }

    getRNCStatusType(cod: number): any {
        return StatusRNC[cod];
    }
}
