import { Pipe, PipeTransform } from '@angular/core';
import { Tercero } from '../Pagos/models/tercero';


@Pipe({
  name: 'filtroTercero'
})
export class FiltroTerceroPipe implements PipeTransform {

  transform(terceros: Tercero[], searchText : string): any {
    if(searchText == null) return terceros;
    return terceros.filter(p=> p.nombre.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
  }

}
