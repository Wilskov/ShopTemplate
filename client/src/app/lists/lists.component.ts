import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Product } from '../_models/product';
import { ProductsService } from '../_services/products.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {

  @Output() removeProduct = new EventEmitter();

  currentProduct$: Observable<Product | null> = of(null);
  model: any = {};
  products: any = [];

  //TODO remove component and create the same in products/productCardShop
  constructor(public productsService: ProductsService) { }

  ngOnInit(): void {
  }
  
  remove() {
    this.removeProduct.emit(false);
}
}
