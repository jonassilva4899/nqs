import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaTimesComponent } from './lista-times.component';

describe('ListaTimesComponent', () => {
  let component: ListaTimesComponent;
  let fixture: ComponentFixture<ListaTimesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaTimesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaTimesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
