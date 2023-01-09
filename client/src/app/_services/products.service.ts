import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/product';

@Injectable({
    providedIn: 'root'
})
export class ProductsService {

    private currentProductSource = new BehaviorSubject<Product | null>(null);
    currentProduct$ = this.currentProductSource.asObservable();
    baseUrl = environment.apiUrl

    constructor(private http: HttpClient) { }

    getProducts() : Observable<Product[]>{
        console.log("service enter");
        return this.http.get<Product[]>(this.baseUrl + 'products')
    }

    getProductId() : Observable<Product> {
       return this.http.get<Product>(this.baseUrl + 'product/id')
    }

    addProduct(model: any) {
        return this.http.post<Product>(this.baseUrl + 'product', model).pipe(
            map((response: Product) => {
                const product = response;
                if (product) {
                    localStorage.setItem('product', JSON.stringify(product));
                    this.currentProductSource.next(product);
                }
            })
        );
    }
 
  /*   removeProduct() {
        localStorage.removeItem('product');
        this.currentProductSource.next(null);
    } *///TODO: check if it is necessary to implement this method

    updateProduct(model: any) {
        return this.http.put<Product>(this.baseUrl + 'product/id', model)
    }

    deleteProduct(id: number) {
        return this.http.delete(this.baseUrl + 'product/id')
    }

    setCurrentProduct(product: Product) {
        this.currentProductSource.next(product);
    }
}
