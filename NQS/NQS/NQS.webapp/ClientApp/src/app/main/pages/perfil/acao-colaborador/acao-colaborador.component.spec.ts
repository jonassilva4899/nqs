import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcaoColaboradorComponent } from './acao-colaborador.component';

describe('AcaoColaboradorComponent', () => {
  let component: AcaoColaboradorComponent;
  let fixture: ComponentFixture<AcaoColaboradorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcaoColaboradorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcaoColaboradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
