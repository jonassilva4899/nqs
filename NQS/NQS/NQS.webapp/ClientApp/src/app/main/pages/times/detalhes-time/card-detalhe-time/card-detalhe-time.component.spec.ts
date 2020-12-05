import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardDetalheTimeComponent } from './card-detalhe-time.component';

describe('CardDetalheTimeComponent', () => {
  let component: CardDetalheTimeComponent;
  let fixture: ComponentFixture<CardDetalheTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardDetalheTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardDetalheTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
