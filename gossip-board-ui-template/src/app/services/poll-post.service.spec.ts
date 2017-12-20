import { TestBed, inject } from '@angular/core/testing';

import { PollPostService } from './poll-post.service';

describe('PollPostService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PollPostService]
    });
  });

  it('should be created', inject([PollPostService], (service: PollPostService) => {
    expect(service).toBeTruthy();
  }));
});
