import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDocteurComponent } from './adddocteur.component';

describe('AddDocteurComponent', () => {
  let component: AddDocteurComponent;
  let fixture: ComponentFixture<AddDocteurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AddDocteurComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDocteurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
