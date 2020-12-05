import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricoPerfilClienteComponent } from './historico-perfil-cliente.component';

describe('HistoricoPerfilClienteComponent', () => {
  let component: HistoricoPerfilClienteComponent;
  let fixture: ComponentFixture<HistoricoPerfilClienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoricoPerfilClienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoricoPerfilClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
