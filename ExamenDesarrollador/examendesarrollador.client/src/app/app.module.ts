import { HttpClientModule, provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Pages/login/login.component';
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
import { AuthGuard } from './Services/Authentication/auth.guard';
import { RegisterComponent } from './Pages/register/register.component';


@NgModule({
  declarations: [
    AppComponent,    
    LoginComponent, CatalogoComponent, ProductosComponent, HeaderComponent, ClientesComponent, SucursalesComponent, DividerComponent, ImageUploaderComponent,
    SearchProductsComponent, CarritoComponent, SearchClientComponent, SearchShopComponent, RegisterComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: 'catalogo', component: CatalogoComponent, canActivate: [AuthGuard] },
      { path: 'Productos', component: ProductosComponent, canActivate: [AuthGuard] },
      { path: 'clientes', component: ClientesComponent, canActivate: [AuthGuard] },
      { path: 'sucursales', component: SucursalesComponent, canActivate: [AuthGuard] },
      { path: 'Carrito', component: CarritoComponent, canActivate: [AuthGuard] },      
      { path: 'login', component: LoginComponent },
      { path: 'registro', component: RegisterComponent },
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
