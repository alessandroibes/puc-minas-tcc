import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'detalhar-workflow-definicao',
    templateUrl: './detalhar-workflow-definicao.component.html'
})
export class DetalharWorkflowDefinicaoComponent {
    @Input() wd;

    constructor(public activeModal: NgbActiveModal) { }
}
