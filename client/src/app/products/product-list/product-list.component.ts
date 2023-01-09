import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from 'src/app/_models/product';
import { ProductsService } from 'src/app/_services/products.service';


@Component({
    selector: 'app-product-list',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    @Input() product: any;
    @Output() removeProduct = new EventEmitter();
    model: any = {};
     currentProduct$: Observable<Product | null> = of(null);
     
    products: any = [];
   
    constructor(public productsService: ProductsService) { }

    ngOnInit(): void {
        this.productsService.getProducts().subscribe(
           products => this.products = products);
    }

    getProducts() {
        this.productsService.getProducts().subscribe({
            next: _ => this.getProducts(),
            error: error => {
                console.log('====================================');
                console.log(error);
                console.log('====================================');
            }
        });
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
