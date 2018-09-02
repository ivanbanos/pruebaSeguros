import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
 
import { Insurrance }         from '../Insurrance';
import { InsurranceService }  from '../Insurrance.service';
 
@Component({
  selector: 'app-Insurrance-detail',
  templateUrl: './Insurrance-detail.component.html',
  styleUrls: [ './Insurrance-detail.component.css' ]
})
export class InsurranceDetailComponent implements OnInit {
  @Input() insurrance: Insurrance;
 
  constructor(
    private route: ActivatedRoute,
    private insurranceService: InsurranceService,
    private location: Location
  ) {}
 
  ngOnInit(): void {
    this.getInsurrance();
  }
 
  getInsurrance(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.insurranceService.getInsurrance(id)
      .subscribe(insurrance => this.insurrance = insurrance);
  }
 
  goBack(): void {
    this.location.back();
  }
 
 save(): void {
    this.insurranceService.updateInsurrance(this.insurrance)
      .subscribe(() => this.goBack());
  }
}