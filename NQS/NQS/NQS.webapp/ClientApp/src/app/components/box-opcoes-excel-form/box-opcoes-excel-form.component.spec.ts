import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BoxOpcoesExcelFormComponent } from './box-opcoes-excel-form.component';

describe('MovimentacaoCapacityFormComponent', () => {
  let component: BoxOpcoesExcelFormComponent;
  let fixture: ComponentFixture<BoxOpcoesExcelFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoxOpcoesExcelFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BoxOpcoesExcelFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
