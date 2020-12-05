import { TestBed } from '@angular/core/testing';

import { HomeTimeService } from './home-time.service';

describe('HomeTimeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HomeTimeService = TestBed.get(HomeTimeService);
    expect(service).toBeTruthy();
  });
});
