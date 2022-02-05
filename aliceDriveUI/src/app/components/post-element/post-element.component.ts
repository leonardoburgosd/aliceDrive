import { Component, Input, OnInit } from '@angular/core';
import { Post } from 'src/app/Services/Estructura/post';

@Component({
  selector: 'app-post-element',
  templateUrl: './post-element.component.html',
  styleUrls: ['./post-element.component.scss']
})
export class PostElementComponent implements OnInit {
  @Input() post:Post = new Post();

  constructor() { }

  ngOnInit(): void {
  }

}
