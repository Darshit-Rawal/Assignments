import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { Company } from "../Models/company.model";
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class CompanyService{

  private api = "http://localhost:3000";
  companyChanged = new Subject<Company[]>();
  private companies!: Company[];

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private client: HttpClient){}


  getCompanies(): Observable<Company[]>{
    return this.client.get<Company[]>(this.api+'/company')
    .pipe(
      retry(1)
    )
  }

  getCompany(id: number): Observable<Company>{
    return this.client.get<Company>(this.api+ '/company/'+id)
    .pipe(
      retry(1)
    )
  }

  create(company: Company): Observable<Company>{
    company.totalBranch = company.companyBranch.length;
    return this.client.post<Company>(this.api+'/company/', JSON.stringify(company), this.httpOptions)
    .pipe(
      retry(1)
    )
  }

  put(id: number, company: Company): Observable<Company>{
    company.totalBranch = company.companyBranch.length;
    return this.client.put<Company>(this.api + '/company/' + id, JSON.stringify(company), this.httpOptions);
  }

  delete(id: number){
    return this.client.delete<Company>(this.api + '/company/'+id)
    .pipe(
      retry(1)
    )
  }


}
