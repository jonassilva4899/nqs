import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditaPerfilClienteComponent } from './edita-perfil-cliente.component';

describe('EditaPerfilClienteComponent', () => {
  let component: EditaPerfilClienteComponent;
  let fixture: ComponentFixture<EditaPerfilClienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditaPerfilClienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditaPerfilClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
