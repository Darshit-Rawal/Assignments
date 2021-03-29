import { Component, Input, OnInit } from '@angular/core';
import { Company } from '../shared/Models/company.model';
import { CompanyService } from '../shared/Services/company.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css']
})
export class CompanyDetailsComponent implements OnInit {

  @Input() companyid!: number;
  company!: Company;
  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.loadCompany(this.companyid);
  }

  loadCompany(index: number) {
    return this.companyService.getCompany(index)
      .subscribe((data) => {
        this.company = data;
      })
  }
}
