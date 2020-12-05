import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaQuestoesCompetenciaComponent } from './lista-questoes-competencia.component';

describe('ListaQuestoesCompetenciaComponent', () => {
  let component: ListaQuestoesCompetenciaComponent;
  let fixture: ComponentFixture<ListaQuestoesCompetenciaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaQuestoesCompetenciaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaQuestoesCompetenciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
