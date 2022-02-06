import { Component, Input, OnInit } from '@angular/core';
import { Post } from 'src/app/Services/Estructura/post';
import { PostService } from 'src/app/Services/Rest/PostService';

@Component({
  selector: 'app-post-element',
  templateUrl: './post-element.component.html',
  styleUrls: ['./post-element.component.scss']
})
export class PostElementComponent implements OnInit {
  @Input() post: Post = new Post();

  constructor(private postService: PostService) { }

  ngOnInit(): void {
  }

  deleted(idPost: number) {
    this.postService.delete(idPost).subscribe(
      (response: any) => console.log(response),
      (error: any) => console.log(error)
    );
  }

}
