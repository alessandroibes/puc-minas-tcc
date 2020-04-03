import { Component, OnInit } from "@angular/core";
import { RNC } from '../models/rnc';
import { RNCService } from '../services/rnc.service';
import { StatusRNC } from '../models/status';

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
        return StatusRNC[cod];
    }
}
