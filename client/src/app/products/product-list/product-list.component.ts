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
/*     @Input() product: any;
 */    
    
    currentProduct$: Observable<Product | null> = of(null);
    model: any = {};
    products: any = [];
   
    constructor(public productsService: ProductsService) { }

    ngOnInit(): void {
        this.getProducts();
        this.currentProduct$ = this.productsService.currentProduct$;
    }

    getProducts() {
        this.productsService.getProducts().subscribe({
            next: products => this.products = products,
            error: error => {
                console.log(error);
            }
        });
    }
//TODO test
/*     addProduct() {
        this.productsService.addProduct(this.model).subscribe({
            next: _ => this.productsService.setCurrentProduct(this.model),
            error: error => {
                console.log(error);
            }
        });
    } */

    



}
