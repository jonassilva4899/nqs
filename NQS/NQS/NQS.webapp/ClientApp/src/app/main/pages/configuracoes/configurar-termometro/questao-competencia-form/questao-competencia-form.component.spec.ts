import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestaoCompetenciaFormComponent } from './questao-competencia-form.component';

describe('QuestaoCompetenciaFormComponent', () => {
  let component: QuestaoCompetenciaFormComponent;
  let fixture: ComponentFixture<QuestaoCompetenciaFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestaoCompetenciaFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestaoCompetenciaFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
