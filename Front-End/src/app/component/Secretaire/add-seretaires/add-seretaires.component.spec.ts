import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSeretairesComponent } from './add-seretaires.component';

describe('AddSeretairesComponent', () => {
  let component: AddSeretairesComponent;
  let fixture: ComponentFixture<AddSeretairesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddSeretairesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSeretairesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
