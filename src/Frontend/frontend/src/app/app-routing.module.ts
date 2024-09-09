import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CdbInvestmentCalculatorComponent } from './cdb-investment-calculator/cdb-investment-calculator.component';

export const routes: Routes = [
  { path: 'cdb-investment-calculator', component: CdbInvestmentCalculatorComponent },
  { path: '', redirectTo: '/cdb-investment-calculator', pathMatch: 'full' }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
