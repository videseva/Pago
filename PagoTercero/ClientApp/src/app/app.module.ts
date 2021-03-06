import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TerceroRegistroComponent } from './Pagos/tercero-registro/tercero-registro.component';
import { AppRoutingModule } from './app-routing.module';
import { TerceroService} from'../app/services/tercero.service';
import { from } from 'rxjs';
import { TerceroConsultaComponent } from './Pagos/tercero-consulta/tercero-consulta.component';
import { PagoTerceroRegistroComponent } from './Pagos/pago-tercero-registro/pago-tercero-registro.component';
import { FiltroTerceroPipe } from './pipe/filtro-tercero.pipe';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TerceroRegistroComponent,
    TerceroConsultaComponent,
    PagoTerceroRegistroComponent,
    FiltroTerceroPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
], { relativeLinkResolution: 'legacy' }),
    AppRoutingModule
  ],
  providers: [TerceroService],
  bootstrap: [AppComponent]
})
export class AppModule { }
