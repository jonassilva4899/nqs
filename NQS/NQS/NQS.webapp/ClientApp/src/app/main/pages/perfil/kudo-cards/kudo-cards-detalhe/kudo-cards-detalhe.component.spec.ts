import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KudoCardsDetalheComponent } from './kudo-cards-detalhe.component';

describe('KudoCardsDetalheComponent', () => {
  let component: KudoCardsDetalheComponent;
  let fixture: ComponentFixture<KudoCardsDetalheComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KudoCardsDetalheComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KudoCardsDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
