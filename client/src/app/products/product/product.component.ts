import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from 'src/app/_services/products.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
 /*  @Input() product: any; */
  product : any = {};
  
  constructor(public productsService: ProductsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    console.log("product.component = enter")
    this.route.snapshot.paramMap.get('id');
    this.productsService.getProductId().subscribe(
        product => this.product = product.id);
      
  }

  // TODO implement this function
  addProduct() {
    return;
  }


}
