import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListeLaborantinsComponent } from './liste-laborantins.component';

describe('ListeLaborantinsComponent', () => {
  let component: ListeLaborantinsComponent;
  let fixture: ComponentFixture<ListeLaborantinsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListeLaborantinsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListeLaborantinsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
