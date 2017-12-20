import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PollPostInputComponent } from './poll-post-input.component';

describe('PollPostInputComponent', () => {
  let component: PollPostInputComponent;
  let fixture: ComponentFixture<PollPostInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PollPostInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PollPostInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
