import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SupplierService } from '../../services/supplier.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-supplier',
  standalone: false,
  templateUrl: './add-supplier.component.html',
  styleUrls: ['./add-supplier.component.css']
})
export class AddSupplierComponent implements OnInit {
  supplierForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private supplierService: SupplierService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.supplierForm = this.fb.group({
      companyCode: ['', [Validators.required]],
      companyName: ['', [Validators.required]],
      telephoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]]
    });
  }

  addSupplier() {
    if (this.supplierForm.valid) {
      const supplier = this.supplierForm.value;
      this.supplierService.addSupplier(supplier).subscribe(() => {
        this.supplierForm.reset();
        this.router.navigate(['/suppliers']);
      });
    }
  }
}
