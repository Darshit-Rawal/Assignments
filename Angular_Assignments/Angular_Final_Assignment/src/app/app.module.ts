import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { TableComponent } from './table/table.component';
import { NavigationComponent } from './navigation/navigation.component';
import { CompanyService } from './shared/Services/company.service';
import { EditCompanyComponent } from './edit-company/edit-company.component';
import { HttpClientModule } from '@angular/common/http';
import { ShortenPipe } from './shared/Pipes/shorten.pipe';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import { ErrorHandlerComponent } from './error-handler/error-handler.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TableComponent,
    NavigationComponent,
    EditCompanyComponent,
    ShortenPipe,
    CompanyDetailsComponent,
    ErrorHandlerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  providers: [CompanyService],
  bootstrap: [AppComponent],
  entryComponents: [ CompanyDetailsComponent ],
})
export class AppModule { }
