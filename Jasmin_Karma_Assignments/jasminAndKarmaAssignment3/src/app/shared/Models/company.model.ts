import { Branch } from "./branch.model";

export class Company{
  constructor(
    public id:number,
    public email:string,
    public name: string,
    public totalEmployee: number,
    public address: string,
    public isCompanyActive: boolean,
    public totalBranch: number,
    public companyBranch: Branch[]
    ){

  }
}
