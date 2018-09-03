
import { TiposCubrimiento }         from 'src/app/model/TiposCubrimiento';

export class Insurrance {
  id: number;
  Nombre: string;
  descripcion: string;
  TiposCubrimiento: TiposCubrimiento;
  cobertura: number;
  inicioVigenciaPoliza: Date;
  periodoCobertura: number;
  precioPoliza: number;
  tipoRiesgo: number;
}