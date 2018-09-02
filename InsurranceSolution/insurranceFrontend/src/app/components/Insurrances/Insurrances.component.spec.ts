import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsurrancesComponent } from './Insurrances.component';

describe('InsurrancesComponent', () => {
  let component: InsurrancesComponent;
  let fixture: ComponentFixture<InsurrancesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsurrancesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsurrancesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
