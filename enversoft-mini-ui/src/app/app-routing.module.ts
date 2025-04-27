import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { SuppliersGridComponent } from './components/suppliers-grid/suppliers-grid.component';
import { AddSupplierComponent } from './components/add-supplier/add-supplier.component';

const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'suppliers', component: SuppliersGridComponent },
  { path: 'add-supplier', component: AddSupplierComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
