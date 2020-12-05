import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaAcaoColaboradorComponent } from './lista-acao-colaborador.component';

describe('ListaAcaoColaboradorComponent', () => {
  let component: ListaAcaoColaboradorComponent;
  let fixture: ComponentFixture<ListaAcaoColaboradorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaAcaoColaboradorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaAcaoColaboradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
