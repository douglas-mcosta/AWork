import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AcademicEducation } from 'app/candidate/models/academic-education';

@Component({
  selector: 'app-academic-education',
  templateUrl: './academic-education.component.html',
  styleUrls: ['./academic-education.component.css']
})
export class AcademicEducationComponent implements OnInit {

  academicEducation: AcademicEducation[] = [];

  constructor(private router: ActivatedRoute) {

    this.academicEducation = this.router.snapshot.data['candidate'];
   }

  ngOnInit(): void {
  }

}
