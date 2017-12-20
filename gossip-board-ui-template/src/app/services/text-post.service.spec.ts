import { TestBed, inject } from '@angular/core/testing';

import { TextPostService } from './text-post.service';

describe('TextPostService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TextPostService]
    });
  });

  it('should be created', inject([TextPostService], (service: TextPostService) => {
    expect(service).toBeTruthy();
  }));
});
