import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmaDeleteComponent } from './confirma-delete.component';

describe('ConfirmaDeleteComponent', () => {
  let component: ConfirmaDeleteComponent;
  let fixture: ComponentFixture<ConfirmaDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmaDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmaDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
