import { Component, OnInit } from '@angular/core';
 
import { Insurrance } from '../../model/Insurrance';
import { InsurranceService } from '../../services/Insurrance.service';
import { TiposCubrimiento }         from '../../model/TiposCubrimiento';
import { TiposCubrimientoService }  from '../../services/TiposCubrimiento.service';

@Component({
  selector: 'app-insurrances',
  templateUrl: './insurrances.component.html',
  styleUrls: ['./insurrances.component.css']
})
export class InsurrancesComponent implements OnInit {
  Insurrances: Insurrance[];
  tiposCubrimientos: TiposCubrimiento[];
 
  constructor(private insurrancesService: InsurranceService,
    private tiposCubrimientoService: TiposCubrimientoService) { }
 
  ngOnInit() {
    this.getInsurrances();
    this.getTiposCubrimiento();
  }
 
  getInsurrances(): void {
    this.insurrancesService.getInsurrances()
    .subscribe(Insurrances => this.Insurrances = Insurrances);
  }
  getTiposCubrimiento(): void {
    this.tiposCubrimientoService.getTiposCubrimientos()
    .subscribe(tiposCubrimientos => this.tiposCubrimientos = tiposCubrimientos);
  }
 
  add(name: string, descripcion: string,idTipoCubrimiento: number,cobertura: number,inicioVigenciaPoliza: Date,
    periodoCobertura: number,precioPoliza: number,tipoRiesgo: number): void {
    name = name.trim();
    if (!name) { return; }
    this.insurrancesService.addInsurrance({ Nombre:name, id:0, descripcion: descripcion, TiposCubrimiento: {id:idTipoCubrimiento},
      cobertura: cobertura,inicioVigenciaPoliza: inicioVigenciaPoliza, periodoCobertura: periodoCobertura,
      precioPoliza: precioPoliza,tipoRiesgo: tipoRiesgo } as Insurrance)
      .subscribe(insurrance => {
        this.Insurrances.push(insurrance);
      });
  }
 
  delete(insurrance: Insurrance): void {
    this.Insurrances = this.Insurrances.filter(h => h !== insurrance);
    this.insurrancesService.deleteInsurrance(insurrance).subscribe();
  }
 
}