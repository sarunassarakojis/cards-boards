import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaPostListComponent } from './media-post-list.component';

describe('MediaPostListComponent', () => {
  let component: MediaPostListComponent;
  let fixture: ComponentFixture<MediaPostListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MediaPostListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MediaPostListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
