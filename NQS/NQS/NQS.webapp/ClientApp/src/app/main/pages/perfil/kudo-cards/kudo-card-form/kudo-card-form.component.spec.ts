import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KudoCardFormComponent } from './kudo-card-form.component';

describe('KudoCardFormComponent', () => {
  let component: KudoCardFormComponent;
  let fixture: ComponentFixture<KudoCardFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KudoCardFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KudoCardFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
