import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KudoCardsCardComponent } from './kudo-cards-card.component';

describe('KudoCardsCardComponent', () => {
  let component: KudoCardsCardComponent;
  let fixture: ComponentFixture<KudoCardsCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KudoCardsCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KudoCardsCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
