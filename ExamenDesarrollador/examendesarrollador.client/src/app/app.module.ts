import { HttpClientModule, provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { provideRouter, RouterModule } from '@angular/router';
import { ProductosComponent } from './Pages/productos/productos.component';
import { HeaderComponent } from './Layout/header/header.component';
import { ClientesComponent } from './Pages/clientes/clientes.component';
import { SucursalesComponent } from './Pages/sucursales/sucursales.component';
import { DividerComponent } from './Components/divider/divider.component';
import { ImageUploaderComponent } from './Components/image-uploader/image-uploader.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { SearchProductsComponent } from './Components/search-product/search-products.component';
import { CarritoComponent } from './pages/carrito/carrito.component';
import { CatalogoComponent } from './Pages/catalogo/catalogo.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { SearchClientComponent } from './Dialogs/search-client/search-client.component';
import { SearchShopComponent } from './Dialogs/search-shop/search-shop.component';


@NgModule({
  declarations: [
    AppComponent,    
    LoginComponent, CatalogoComponent, ProductosComponent, HeaderComponent, ClientesComponent, SucursalesComponent, DividerComponent, ImageUploaderComponent,
    SearchProductsComponent, CarritoComponent, SearchClientComponent, SearchShopComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'catalogo', component: CatalogoComponent },
      { path: 'Productos', component: ProductosComponent },
      { path: 'Clientes', component: ClientesComponent },
      { path: 'Sucursales', component: SucursalesComponent },
      { path: 'Carrito', component: CarritoComponent },
      { path: '**', pathMatch: 'full', redirectTo: 'catalogo' }
    ]),    
  ],
  providers: [
    provideHttpClient(),
    provideAnimationsAsync() 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
