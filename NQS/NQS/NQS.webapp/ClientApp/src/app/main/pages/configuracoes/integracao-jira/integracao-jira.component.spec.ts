import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IntegracaoJiraComponent } from './integracao-jira.component';

describe('IntegracaoJiraComponent', () => {
  let component: IntegracaoJiraComponent;
  let fixture: ComponentFixture<IntegracaoJiraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IntegracaoJiraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IntegracaoJiraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
