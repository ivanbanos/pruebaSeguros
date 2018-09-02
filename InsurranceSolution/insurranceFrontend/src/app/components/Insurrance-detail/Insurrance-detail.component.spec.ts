import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsurranceDetailComponent } from './Insurrance-detail.component';

describe('InsurranceDetailComponent', () => {
  let component: InsurranceDetailComponent;
  let fixture: ComponentFixture<InsurranceDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsurranceDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsurranceDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
