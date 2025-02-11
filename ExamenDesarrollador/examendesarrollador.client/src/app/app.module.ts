import { HttpClientModule, provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { provideRouter, RouterModule } from '@angular/router';
import { CatalogoComponent } from './Pages/catalogo/catalogo.component';
import { ProductosComponent } from './Pages/productos/productos.component';
import { HeaderComponent } from './Layout/header/header.component';
import { ClientesComponent } from './Pages/clientes/clientes.component';
import { SucursalesComponent } from './Pages/sucursales/sucursales.component';
import { DividerComponent } from './Components/divider/divider.component';
import { ImageUploaderComponent } from './Components/image-uploader/image-uploader.component';
@NgModule({
  declarations: [
    AppComponent,    
    LoginComponent, CatalogoComponent, ProductosComponent, HeaderComponent, ClientesComponent, SucursalesComponent, DividerComponent, ImageUploaderComponent, 
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule,
    AppRoutingModule,    
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'catalogo', component: CatalogoComponent },
      { path: 'Productos', component: ProductosComponent },
      { path: 'Clientes', component: ClientesComponent },
      { path: 'Sucursales', component: SucursalesComponent },
      { path: '**', pathMatch: 'full', redirectTo: 'catalogo' }
    ]),    
  ],
  providers: [
    provideHttpClient() 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
