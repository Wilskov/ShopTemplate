import { Component, OnInit } from '@angular/core';
import { Product } from './_models/product';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';
import { ProductsService } from './_services/products.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

    title = 'Shop Command';

    constructor(private accountService: AccountService, private productsService : ProductsService) { }

    ngOnInit(): void {
        this.setCurrentUser();
/*         this.setCurrentProduct();
 */
    }

    setCurrentUser() {
        const userString = localStorage.getItem('user');

        if (!userString) return;

        const user: User = JSON.parse(userString);
        this.accountService.setCurrentUser(user);
    }

    setCurrentProduct() {
        const productString = localStorage.getItem('product');

        if (!productString) return;

        const product: Product = JSON.parse(productString);
        this.productsService.setCurrentProduct(product);
    }
}
