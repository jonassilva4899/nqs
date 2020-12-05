import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalMappingComponent } from './personal-mapping.component';

describe('PersonalMappingComponent', () => {
  let component: PersonalMappingComponent;
  let fixture: ComponentFixture<PersonalMappingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonalMappingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
