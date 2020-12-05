import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KudoCardsListaComponent } from './kudo-cards-lista.component';

describe('KudoCardsListaComponent', () => {
  let component: KudoCardsListaComponent;
  let fixture: ComponentFixture<KudoCardsListaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KudoCardsListaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KudoCardsListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
