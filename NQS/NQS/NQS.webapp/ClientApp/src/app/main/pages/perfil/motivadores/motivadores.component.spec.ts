import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MotivadoresComponent } from './motivadores.component';

describe('MotivadoresComponent', () => {
  let component: MotivadoresComponent;
  let fixture: ComponentFixture<MotivadoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MotivadoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MotivadoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
