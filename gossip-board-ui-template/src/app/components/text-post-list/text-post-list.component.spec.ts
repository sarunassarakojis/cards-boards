import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TextPostListComponent } from './text-post-list.component';

describe('TextPostListComponent', () => {
  let component: TextPostListComponent;
  let fixture: ComponentFixture<TextPostListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TextPostListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TextPostListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
