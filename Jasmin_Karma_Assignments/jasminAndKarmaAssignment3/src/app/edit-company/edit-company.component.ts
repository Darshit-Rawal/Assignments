import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Company } from '../shared/Models/company.model';
import { CompanyService } from '../shared/Services/company.service';

@Component({
  selector: 'app-edit-company',
  templateUrl: './edit-company.component.html',
  styleUrls: ['./edit-company.component.css']
})
export class EditCompanyComponent implements OnInit {

  Arr = Array;
  CompanyForm!: FormGroup;
  id!: number;
  editMode = false;
  company!: Company;


  constructor(private companyService:CompanyService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params
      .subscribe(
        (param: Params) => {
          this.id = +param['id'];
          this.editMode = !isNaN(+param['id']);
          this.InitForm();
        }
      );
  }

  getControl() {
    return (this.CompanyForm.get('companyBranch') as FormArray).controls;
  }

  onAddBranch() {
    (<FormArray>this.CompanyForm.get('companyBranch')).push(
      new FormGroup({
        'branchid': new FormControl(null, Validators.required),
        'branchName': new FormControl(null, Validators.required),
        'address': new FormControl(null, Validators.required)
      })
    );
  }

  onDeleteBranch(index: number) {
    (<FormArray>this.CompanyForm.get('companyBranch')).removeAt(index);
  }


  onCancel() {
    this.CompanyForm.reset();
  }

  onSubmit() {
    if (this.editMode) {
      this.companyService.put(this.id, this.CompanyForm.value)
        .subscribe(() => {
          console.log("Company edited!!");
        });
      // this.CompanyForm.reset();
    } else {
      this.companyService.create(this.CompanyForm.value)
        .subscribe(() => {
          console.log("Company Created!");
        });
        // this.CompanyForm.reset();
    }
    this.router.navigate([""], {relativeTo: this.route})
  }

  private InitForm(){
    let email = '';
    let name ='';
    let totalEmployee = '';
    let address = '';
    let isCompanyActive = true;
    let companyBranch = new FormArray([]);

    if(this.editMode){
      this.companyService.getCompany(this.id).subscribe(
        (data: Company) => {
          this.company = data;
          name = this.company.name;
          email = this.company.email;
          totalEmployee = ''+this.company.totalEmployee;
          address = this.company.address;
          isCompanyActive = this.company.isCompanyActive;
          if(this.company['companyBranch']){
            for(let branch of this.company.companyBranch){
              companyBranch.push(
                new FormGroup({
                  branchid: new FormControl(branch.branchid, Validators.required),
                  branchName: new FormControl(branch.branchName, Validators.required),
                  address: new FormControl(branch.address, Validators.required)
                })
              )
            }
          }
          this.CompanyForm = new FormGroup({
            'email': new FormControl(email, [Validators.required, Validators.email]),
            'name': new FormControl(name, Validators.required),
            'totalEmployee': new FormControl(totalEmployee, Validators.required),
            'address': new FormControl(address, Validators.required),
            'isCompanyActive': new FormControl(isCompanyActive),
            'companyBranch': companyBranch
          });

        }
      );

    }

    this.CompanyForm = new FormGroup({
      'email': new FormControl(email, [Validators.required, Validators.email]),
      'name': new FormControl(name, Validators.required),
      'totalEmployee': new FormControl(totalEmployee, Validators.required),
      'address': new FormControl(address, Validators.required),
      'isCompanyActive': new FormControl(isCompanyActive),
      'companyBranch': companyBranch
    });
  }

}
