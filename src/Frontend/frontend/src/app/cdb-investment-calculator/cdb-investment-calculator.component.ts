import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from '../../environment';

interface CdbInvestmentRequest{
  initialAmount: number | null;
  months: number | null;
}

interface CdbInvestmentResponse{
  grossIncome: string | null;
  netIncome: string | null;
}

@Component({
  selector: 'app-cdb-investment-calculator',
  templateUrl: './cdb-investment-calculator.component.html',
  styleUrl: './cdb-investment-calculator.component.css'
})
export class CdbInvestmentCalculatorComponent {
  private baseUrl = environment.baseUrl

  constructor(private http: HttpClient) {}
  
  cdbInvestmentRequest: CdbInvestmentRequest = {
    initialAmount: 1,
    months: 1
  };

  cdbInvestmentResponse : CdbInvestmentResponse = {
    grossIncome: null,
    netIncome: null
  };

  calculateInvestment() {

    // ok, maybe this is not the clever way to do this
    if(this.cdbInvestmentRequest.initialAmount == null 
      || this.cdbInvestmentRequest.initialAmount == undefined 
      || this.cdbInvestmentRequest.initialAmount < 1 ){
        alert('O valor inicial deve ser positivo e o prazo maior que 1 mês.');
        return;
    }

    if(this.cdbInvestmentRequest.months == null 
      || this.cdbInvestmentRequest.months == undefined 
      || this.cdbInvestmentRequest.months < 1 ){
        alert('O valor inicial deve ser positivo e o prazo maior que 1 mês.');
        return;
    }

    const url = `${this.baseUrl}/calculator/cdb`
    this.http.post<any>(url, this.cdbInvestmentRequest)
      .subscribe({
        next: (response) => {
          this.cdbInvestmentResponse.grossIncome = response.grossIncome;
          this.cdbInvestmentResponse.netIncome = response.netIncome;
        },
        error: (error) =>   console.error('Erro no cálculo do investimento', error),
        complete: () => console.info('complete')}); 
  }
}
