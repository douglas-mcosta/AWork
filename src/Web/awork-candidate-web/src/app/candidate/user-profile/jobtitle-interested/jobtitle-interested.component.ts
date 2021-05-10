import { AfterViewInit, Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { JobTitleInterested } from 'app/candidate/models/job-interesteds';
import { PersonService } from 'app/candidate/services/person.service';
import { Dropdown } from 'app/models/drop-down';
import { DropdownService } from 'app/services/dropdown.service';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-jobtitle-interested',
  templateUrl: './jobtitle-interested.component.html',
  styleUrls: ['./jobtitle-interested.component.css']
})
export class JobtitleInterestedComponent implements OnInit, AfterViewInit {

  jobTitleInterestedForm: FormGroup;
  jobTitleInteresteds: JobTitleInterested[];
  occupationArea$: Observable<Dropdown[]>;
  jobTitle: Dropdown[];
  personId: string = "";

  constructor(private route: ActivatedRoute,
              private modalService: NgbModal,
              private dropDown: DropdownService,
              private fb: FormBuilder,
              private personService: PersonService,
              private toast: ToastrService) {
                this.personId = this.route.snapshot.data["candidate"].id;
               }
 

  ngOnInit(): void {

    this.jobTitleInterestedForm = this.fb.group({
      occupationArea: ["", Validators.required],
      jobTitleId: [{value:'',disabled: true}, Validators.required]
    });

    this.occupationArea$ = this.dropDown.OccupationAreaDropdown$;
         this.jobTitleInteresteds = this.route.snapshot.data['candidate'].jobTitleInteresteds;
  }

  ngAfterViewInit(): void {
    this.occupationAreaForm().valueChanges
    .subscribe(() => {

      this.dropDown.OccupationDropdown(this.occupationAreaForm().value).toPromise()
      .then((result: Dropdown[]) =>  this.jobTitle = result);
      this.jobTitleForm().enable();
    });
  }

  addJobTitleInterested(){

    if(!this.jobTitleInterestedForm.dirty && !this.jobTitleInterestedForm.valid) return;
    var job: JobTitleInterested = Object.assign({},job,this.jobTitleInterestedForm.value);
    job.personId = this.personId;
    job.isDefault = false;
    this.personService.addJobTitleInterested(job)
    .subscribe(
      (success) => this.successAddJobTitleInterested(success),
      (fail) => this.fail(fail)
    );

  }

  successAddJobTitleInterested(jobTitleInterested: JobTitleInterested){
    console.log(jobTitleInterested);
    console.log(this.jobTitleInteresteds)
    this.toast.success("Cargo de interesse adicionado.", "Sucesso");
        
    this.jobTitleInteresteds.push(jobTitleInterested);
    this.modalService.dismissAll();
    
  }

  confirmDeleteJobTitleInterested(jobTitleInteresteds: JobTitleInterested){
     Swal.fire({
      title: "Tem certeza?",
      text: "O cargo de interesse será excluído.",
      icon: "error",
      confirmButtonColor: "#d33",
      showCancelButton: true,
      showConfirmButton: true,
    }).then((result) => {
      if (result.isConfirmed) {
        this.deleteJobTitleInterested(jobTitleInteresteds);
      }
    });
  }

  deleteJobTitleInterested(jobTitleInterested: JobTitleInterested){

    this.personService.deleteJobTitleInterested(jobTitleInterested.id)
    .subscribe(
      () => this.successDelete(jobTitleInterested),
      (fail) => this.fail(fail)
      );
  }

  successDelete(jobTitleInterested: JobTitleInterested){
    let index = this.jobTitleInteresteds.indexOf(jobTitleInterested);
    this.jobTitleInteresteds.splice(index,1);

    Swal.fire({
      title: "Deletado!",
      text: "O cargo de interesse foi excluído com sucesso",
      icon: "success",
      timer: 1500,
      showConfirmButton: false,
    });
  }


  ChangeFavoriteJobTitleInterested(jobTitleInterested: JobTitleInterested){
    jobTitleInterested.isDefault = true;
    this.personService.updateJobTitleInterestedFavorite(jobTitleInterested)
    .subscribe(
      (success) => this.success(success),
      (fail) => this.fail(fail)
    )
  }

  success(jobtitleInteresteds: JobTitleInterested[]){
    this.toast.success("Cargo de interesse atualizado.", "Sucesso");
    this.jobTitleInteresteds = jobtitleInteresteds;
  }
  fail(fail: any) {
    let erros = fail.error?.errors;
    erros.forEach((erro) => this.toast.error(erro.mensagem, "Opa :("));
  }

  occupationAreaForm(): AbstractControl{
    return this.jobTitleInterestedForm.get('occupationArea');
  }
  jobTitleForm(): AbstractControl{
    return this.jobTitleInterestedForm.get('jobTitleId');
  }
  openModel(content){

    this.modalService.open(content);
  }

  
}
