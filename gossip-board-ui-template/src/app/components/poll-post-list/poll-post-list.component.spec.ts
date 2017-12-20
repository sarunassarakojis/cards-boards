import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PollPostListComponent } from './poll-post-list.component';

describe('PollPostListComponent', () => {
  let component: PollPostListComponent;
  let fixture: ComponentFixture<PollPostListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PollPostListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PollPostListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
