/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { QuickPanelNotificationService } from './quick-panel-notification.service';

describe('Service: QuickPanelNotification', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuickPanelNotificationService]
    });
  });

  it('should ...', inject([QuickPanelNotificationService], (service: QuickPanelNotificationService) => {
    expect(service).toBeTruthy();
  }));
});
