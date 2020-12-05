import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurarTermometroComponent } from './configurar-termometro.component';

describe('ConfigurarTermometroComponent', () => {
  let component: ConfigurarTermometroComponent;
  let fixture: ComponentFixture<ConfigurarTermometroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfigurarTermometroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigurarTermometroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
