import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardMembrosTimeComponent } from './card-membros-time.component';

describe('CardMembrosTimeComponent', () => {
  let component: CardMembrosTimeComponent;
  let fixture: ComponentFixture<CardMembrosTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardMembrosTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardMembrosTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
