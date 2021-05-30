import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import { EditCompanyComponent } from './edit-company/edit-company.component';
import { ErrorHandlerComponent } from './error-handler/error-handler.component';
import { TableComponent } from './table/table.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: TableComponent },
  { path: 'add', component: EditCompanyComponent },
  { path: ':id/edit', component: EditCompanyComponent },
  { path: '**', component: ErrorHandlerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
