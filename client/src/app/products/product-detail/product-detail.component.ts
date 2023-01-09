import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from 'src/app/_models/product';
import { ProductsService } from 'src/app/_services/products.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  @Output() removeProduct = new EventEmitter();

  model: any = {};
  currentProduct$: Observable<Product | null> = of(null);

  constructor(public productsService: ProductsService) { }

  ngOnInit(): void {
      this.currentProduct$ = this.productsService.currentProduct$;
  }

  addProduct() {
    this.productsService.addProduct(this.model).subscribe({
        next: _ => this.productsService.setCurrentProduct(this.model),
        error: error => {
            console.log('====================================');
            console.log(error);
            console.log('====================================');
        }
    });
}

remove() {
    this.removeProduct.emit(false);
}
}
