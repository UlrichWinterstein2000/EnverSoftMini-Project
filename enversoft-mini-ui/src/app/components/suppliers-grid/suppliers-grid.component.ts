import { Component, OnInit } from '@angular/core';
import { Supplier, SupplierService } from '../../services/supplier.service';
import { SearchFilterPipe } from '../../search-filter.pipe'; 
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table'; 
import { FormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-suppliers-grid',
  standalone: true,  
  templateUrl: './suppliers-grid.component.html',
  styleUrls: ['./suppliers-grid.component.css'],
  imports: [
    MatFormFieldModule, 
    MatInputModule,    
    MatTableModule,     
    FormsModule,        
    SearchFilterPipe   
  ]
})
export class SuppliersGridComponent implements OnInit {
  displayedColumns: string[] = ['companyCode', 'companyName', 'telephoneNumber', 'delete'];
  suppliers: Supplier[] = [];
  searchText = '';

  constructor(private supplierService: SupplierService) { }

  ngOnInit(): void {
    this.supplierService.getAllSuppliers().subscribe((data) => {
      this.suppliers = data;
    });
  }

  deleteSupplier(id: number): void {
    this.supplierService.deleteSupplier(id).subscribe(() => {
      this.suppliers = this.suppliers.filter(supplier => supplier.id !== id); 
    });
  }
}
