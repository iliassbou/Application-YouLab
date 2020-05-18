import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLaborantinComponent } from './add-laborantin.component';

describe('AddLaborantinComponent', () => {
  let component: AddLaborantinComponent;
  let fixture: ComponentFixture<AddLaborantinComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddLaborantinComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLaborantinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
