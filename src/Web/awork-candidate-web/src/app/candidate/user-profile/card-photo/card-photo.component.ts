import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Person } from "app/candidate/models/person";

@Component({
  selector: "app-card-photo",
  templateUrl: "./card-photo.component.html",
  styleUrls: ["./card-photo.component.css"],
})
export class CardPhotoComponent implements OnInit {
  
  @Input()
  person: Person = new Person();  
  jobTitleInteresteds: string = "";
  summary: string = "";
  constructor(private modalService: NgbModal) {
  }

  ngOnInit(): void {
    this.jobTitleInteresteds = this.person.jobTitleInteresteds.filter(x=>x.isDefault)[0].jobTitleName;
  }

  editSummary(){

  }

  openModal(content){
    this.modalService.open(content);
  }
}
