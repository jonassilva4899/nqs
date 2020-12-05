import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelecionarTemaComponent } from './selecionar-tema.component';

describe('SelecionarTemaComponent', () => {
  let component: SelecionarTemaComponent;
  let fixture: ComponentFixture<SelecionarTemaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelecionarTemaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelecionarTemaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
