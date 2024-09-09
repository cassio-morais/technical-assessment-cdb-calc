import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CdbInvestmentCalculatorComponent } from './cdb-investment-calculator.component';

describe('CdbInvestmentCalculatorComponent', () => {
  let component: CdbInvestmentCalculatorComponent;
  let fixture: ComponentFixture<CdbInvestmentCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CdbInvestmentCalculatorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CdbInvestmentCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
