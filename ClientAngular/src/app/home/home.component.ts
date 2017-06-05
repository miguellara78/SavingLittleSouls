import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./css/animate.css','./css/font-awesome.css','./css/Grid.css','./css/latofonts.css','./css/main.css','./css/Site.css','./css/queries.css']
})
export class HomeComponent implements OnInit {
  pets: any = [
    {name: 'Molly', tag: '123456', age: 3, gender: 'female', type: 'dog', weight: 3, color: 'Brown/Black', breed: 'Yorkie',imagePath: 'http://www.lillehei-yorkies.co.za/wp-content/uploads/2013/06/MILA-BOY-SMALL-3-600x500.jpg'},
    {name: 'Molly', tag: '123456', age: 3, gender: 'female', type: 'dog', weight: 3, color: 'Brown/Black', breed: 'Yorkie',imagePath: 'http://www.lillehei-yorkies.co.za/wp-content/uploads/2013/06/MILA-BOY-SMALL-3-600x500.jpg'},
    {name: 'Molly', tag: '123456', age: 3, gender: 'female', type: 'dog', weight: 3, color: 'Brown/Black', breed: 'Yorkie',imagePath: 'http://www.lillehei-yorkies.co.za/wp-content/uploads/2013/06/MILA-BOY-SMALL-3-600x500.jpg'},
    {name: 'Molly', tag: '123456', age: 3, gender: 'female', type: 'dog', weight: 3, color: 'Brown/Black', breed: 'Yorkie',imagePath: 'http://www.lillehei-yorkies.co.za/wp-content/uploads/2013/06/MILA-BOY-SMALL-3-600x500.jpg'}
  ];

  constructor() { }

  ngOnInit() {
  }

}
