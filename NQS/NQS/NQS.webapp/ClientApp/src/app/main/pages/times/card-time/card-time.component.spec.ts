import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardTimeComponent } from './card-time.component';

describe('CardTimeComponent', () => {
  let component: CardTimeComponent;
  let fixture: ComponentFixture<CardTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
