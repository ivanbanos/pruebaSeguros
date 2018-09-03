import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
 
import { Insurrance }               from '../../model/Insurrance';
import { InsurranceService }        from '../../services/Insurrance.service';
import { TiposCubrimiento }         from '../../model/TiposCubrimiento';
import { TiposCubrimientoService }  from '../../services/TiposCubrimiento.service';
 
@Component({
  selector: 'app-Insurrance-detail',
  templateUrl: './Insurrance-detail.component.html',
  styleUrls: [ './Insurrance-detail.component.css' ]
})
export class InsurranceDetailComponent implements OnInit {
  @Input() insurrance: Insurrance;
  tiposCubrimientos: TiposCubrimiento[];
 
  constructor(
    private route: ActivatedRoute,
    private insurranceService: InsurranceService,
    private tiposCubrimientoService: TiposCubrimientoService,
    private location: Location
  ) {}
 
  ngOnInit(): void {
    this.getInsurrance();
    this.getTiposCubrimiento();
  }
 
  getInsurrance(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.insurranceService.getInsurrance(id)
      .subscribe(insurrance => this.insurrance = insurrance);
  }

  getTiposCubrimiento(): void {
    this.tiposCubrimientoService.getTiposCubrimientos()
    .subscribe(tiposCubrimientos => this.tiposCubrimientos = tiposCubrimientos);
  }
 
  goBack(): void {
    this.location.back();
  }
 
 save(): void {
    this.insurranceService.updateInsurrance(this.insurrance)
      .subscribe(() => this.goBack());
  }
}