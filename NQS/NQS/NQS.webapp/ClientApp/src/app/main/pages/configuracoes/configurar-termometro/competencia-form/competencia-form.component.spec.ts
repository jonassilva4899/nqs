import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetenciaFormComponent } from './competencia-form.component';

describe('CompetenciaFormComponent', () => {
  let component: CompetenciaFormComponent;
  let fixture: ComponentFixture<CompetenciaFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetenciaFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetenciaFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
