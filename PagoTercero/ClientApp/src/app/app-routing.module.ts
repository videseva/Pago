import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { TerceroRegistroComponent } from './Pagos/tercero-registro/tercero-registro.component';
import { TerceroConsultaComponent } from './Pagos/tercero-consulta/tercero-consulta.component';

const routes: Routes = [
  {
    path: '',
    component: TerceroRegistroComponent, 
    pathMatch: 'full'
  },
  {
    path: 'terceroRegistro',
    component: TerceroRegistroComponent,
  },
  {
    path: 'terceroConsulta',
    component: TerceroConsultaComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]

})
export class AppRoutingModule { }
