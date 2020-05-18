import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListeDocteurComponent } from './listeDocteur.component';

describe('ListeDocteurComponent', () => {
  let component: ListeDocteurComponent;
  let fixture: ComponentFixture<ListeDocteurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ListeDocteurComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListeDocteurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
