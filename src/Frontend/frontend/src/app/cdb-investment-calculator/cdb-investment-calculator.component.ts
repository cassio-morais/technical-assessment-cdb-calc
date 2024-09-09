import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from '../../environment';

@Component({
  selector: 'app-cdb-investment-calculator',
  templateUrl: './cdb-investment-calculator.component.html',
  styleUrl: './cdb-investment-calculator.component.css'
})
export class CdbInvestmentCalculatorComponent {
  initialAmount: number | null = null;
  months: number | null = null;
  grossIncome: number | null = null;
  netIncome: number | null = null;
  private baseUrl = environment.baseUrl

  constructor(private http: HttpClient) {}

  calculateInvestment() {
    if (this.initialAmount && this.months) {
      const payload = {
        initialAmount: this.initialAmount,
        months: this.months
      };

      const url = `${this.baseUrl}/calculator/cdb`
      this.http.post<any>(url, payload)
        .subscribe({
          next: (response) => {
            this.grossIncome = response.grossIncome;
            this.netIncome = response.netIncome;
          },
          error: (error) =>   console.error('Erro no cálculo do investimento', error),
          complete: () => console.info('complete')});
    }
  }
}
