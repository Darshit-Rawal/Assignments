import { HttpClient } from '@angular/common/http';
import { AfterViewChecked, AfterViewInit, Component, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { data } from 'jquery';
import { Subscription } from 'rxjs';
import { Company } from '../shared/Models/company.model';
import { CompanyService } from '../shared/Services/company.service';
import { CompanyDetailsComponent } from "../company-details/company-details.component";

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  companies!: Company[];
  subscription!: Subscription;

  constructor(private companyService: CompanyService,
    private router: Router,
    private modelService: NgbModal) { }

  ngOnInit(): void {
    this.loadCompanies();
  }


  loadCompanies(){
    return this.companyService.getCompanies().subscribe(
      (data: {}) => {
        this.companies = data as Company[];
      }
    );
  }

  openModel(index: number) {
    const modelRef = this.modelService.open(CompanyDetailsComponent);
    modelRef.componentInstance.companyid = index;
  }
  
  onDelete(index: number) {
    this.companyService.delete(index)
      .subscribe(() => {
        console.log("Company Deleted");
    })
  }
}
