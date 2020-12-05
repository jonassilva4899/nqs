import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesTimeComponent } from './detalhes-time.component';

describe('DetalhesTimeComponent', () => {
  let component: DetalhesTimeComponent;
  let fixture: ComponentFixture<DetalhesTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhesTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
