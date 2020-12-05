import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditaAcaoColaboradorComponent } from './edita-acao-colaborador.component';

describe('EditaAcaoColaboradorComponent', () => {
  let component: EditaAcaoColaboradorComponent;
  let fixture: ComponentFixture<EditaAcaoColaboradorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditaAcaoColaboradorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditaAcaoColaboradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
