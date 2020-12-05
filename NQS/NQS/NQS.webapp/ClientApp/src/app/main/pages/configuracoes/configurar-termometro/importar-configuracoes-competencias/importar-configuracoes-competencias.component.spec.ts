import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportarConfiguracoesCompetenciasComponent } from './importar-configuracoes-competencias.component';

describe('ImportarConfiguracoesCompetenciasComponent', () => {
  let component: ImportarConfiguracoesCompetenciasComponent;
  let fixture: ComponentFixture<ImportarConfiguracoesCompetenciasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImportarConfiguracoesCompetenciasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportarConfiguracoesCompetenciasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
