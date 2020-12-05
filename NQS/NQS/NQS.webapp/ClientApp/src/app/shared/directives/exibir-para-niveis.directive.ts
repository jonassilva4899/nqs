import { Directive, Input, OnInit, TemplateRef, ViewContainerRef, OnChanges, SimpleChanges } from '@angular/core';
import { NivelPermissao } from '@models/Permissoes';
import { Usuario } from '@models/Usuario';

@Directive({
  selector: '[exibirParaNiveis]',
})
export class ExibirParaNiveisDirective implements OnInit, OnChanges {

    usuario: Usuario;

    private _exibirParaNiveis: NivelPermissao[];
    @Input()
    set exibirParaNiveis(value: NivelPermissao[]) {
        this._exibirParaNiveis = value;
    }

    private _ouSeTeamLeader: string[]; // ids times
    @Input()
    set exibirParaNiveisOuSeTeamLeader(value: string[]) {
        this._ouSeTeamLeader = value;
    }

    private _ouSeTeamMember: string; // id time
    @Input()
    set exibirParaNiveisOuSeTeamMember(value: string) {
        this._ouSeTeamMember = value;
    }

    private _ouSeMesmaPessoa: string; // id pessoa
    @Input()
    set exibirParaNiveisOuSeMesmaPessoa(value: string) {
        this._ouSeMesmaPessoa = value;
    }

    private _else: TemplateRef<any>;
    @Input()
    set exibirParaNiveisElse(value: TemplateRef<any>) {
        this._else = value;
    }

    constructor(
        private templateRef?: TemplateRef<any>,
        private viewContainer?: ViewContainerRef
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
    }

    ngOnInit(): void {
        // this.exibir();
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.exibir();
    }

    exibir(): void {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));

        this.viewContainer.clear();

        if (this.temPermissao) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        }
        else if (this._else) {
            this.viewContainer.createEmbeddedView(this._else);
        }
    }

    get temPermissao(): boolean {
        if (!this.usuario) {
            return false;
        }

        const exibirParaNiveis = this._exibirParaNiveis.includes(this.usuario.roleEnum);
        const usuarioFazParteDoTime = this.usuario.idsTimes.includes(this._ouSeTeamMember);
        const usuarioMesmaPessoa = this.usuario.idPessoa === this._ouSeMesmaPessoa;

        const usuarioLiderDoTime = this._ouSeTeamLeader && this.usuario.idsTimes.some(
                (id) => this._ouSeTeamLeader.includes(id)
            ) && this.usuario.roleEnum === NivelPermissao.TeamLeader;

        if (exibirParaNiveis ||
            (this._ouSeTeamLeader && usuarioLiderDoTime) ||
            (this._ouSeTeamMember && usuarioFazParteDoTime) ||
            (this._ouSeMesmaPessoa && usuarioMesmaPessoa)) {
            return true;
        }

        return false;
    }

}
