import { Component, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { MatDialog } from '@angular/material';

// import { JiraFormComponent } from 'app/components/jira-form/jira-form.component';

@Component({
  selector: 'app-integracao-jira',
  templateUrl: './integracao-jira.component.html',
  styleUrls: ['./integracao-jira.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class IntegracaoJiraComponent implements OnInit {

    @Input() configuracao: any;

    constructor(
        private _matDialog: MatDialog,
    ) { }

    ngOnInit(): void{
    }

    adicionaConexaoJira(): void {
        // this._matDialog.open(JiraFormComponent, {
        //     autoFocus: false,
        //     width: '80vw',
        //     maxHeight: '100vh',
        //     data: {

        //     },
        // });
    }

}
