import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CriaTimeFormComponent } from './cria-time-form.component';

describe('CriaTimeFormComponent', () => {
  let component: CriaTimeFormComponent;
  let fixture: ComponentFixture<CriaTimeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CriaTimeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CriaTimeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
