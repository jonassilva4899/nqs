import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditaPerfilTimeComponent } from './edita-perfil-time.component';

describe('EditaPerfilTimeComponent', () => {
  let component: EditaPerfilTimeComponent;
  let fixture: ComponentFixture<EditaPerfilTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditaPerfilTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditaPerfilTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
