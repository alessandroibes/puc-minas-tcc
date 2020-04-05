import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'detalhar-rnc-modal',
    templateUrl: './detalhar-rnc-modal.component.html'
})
export class DetalharRNCModalComponent {
    @Input() rnc;

    constructor(public activeModal: NgbActiveModal) { }
}
