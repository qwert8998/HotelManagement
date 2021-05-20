import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustdetailComponent } from './custdetail.component';

describe('CustdetailComponent', () => {
  let component: CustdetailComponent;
  let fixture: ComponentFixture<CustdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
