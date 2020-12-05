import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionaMembroFormComponent } from './adiciona-membro-form.component';

describe('AdicionaMembroFormComponent', () => {
  let component: AdicionaMembroFormComponent;
  let fixture: ComponentFixture<AdicionaMembroFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionaMembroFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionaMembroFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
