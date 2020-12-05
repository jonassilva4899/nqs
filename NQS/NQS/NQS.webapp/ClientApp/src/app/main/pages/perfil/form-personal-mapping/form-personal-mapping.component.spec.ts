import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormPersonalMappingComponent } from './form-personal-mapping.component';

describe('FormPersonalMappingComponent', () => {
  let component: FormPersonalMappingComponent;
  let fixture: ComponentFixture<FormPersonalMappingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormPersonalMappingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormPersonalMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
