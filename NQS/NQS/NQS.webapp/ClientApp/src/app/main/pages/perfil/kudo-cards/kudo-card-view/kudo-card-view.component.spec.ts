import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KudoCardViewComponent } from './kudo-card-view.component';

describe('KudoCardViewComponent', () => {
  let component: KudoCardViewComponent;
  let fixture: ComponentFixture<KudoCardViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KudoCardViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KudoCardViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
