import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaPostInputComponent } from './media-post-input.component';

describe('MediaPostInputComponent', () => {
  let component: MediaPostInputComponent;
  let fixture: ComponentFixture<MediaPostInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MediaPostInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MediaPostInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
