import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelecionarOrganizacaoComponent } from './selecionar-organizacao.component';

describe('SelecionarOrganizacaoComponent', () => {
  let component: SelecionarOrganizacaoComponent;
  let fixture: ComponentFixture<SelecionarOrganizacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelecionarOrganizacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelecionarOrganizacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
