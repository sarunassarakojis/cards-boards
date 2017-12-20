import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TextPostInputComponent } from './text-post-input.component';

describe('TextPostInputComponent', () => {
  let component: TextPostInputComponent;
  let fixture: ComponentFixture<TextPostInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TextPostInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TextPostInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
