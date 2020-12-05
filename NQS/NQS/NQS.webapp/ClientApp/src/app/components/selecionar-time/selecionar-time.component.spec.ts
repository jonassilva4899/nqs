import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelecionarTimeComponent } from './selecionar-time.component';

describe('SelecionarTimeComponent', () => {
  let component: SelecionarTimeComponent;
  let fixture: ComponentFixture<SelecionarTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelecionarTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelecionarTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
