import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from 'src/app/Services/Estructura/post';
import { PostService } from 'src/app/Services/Rest/PostService';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  posts: Post[] = [];
  newPost: Post = new Post;
  constructor(private route: ActivatedRoute, private postService: PostService) { }

  ngOnInit(): void {
    this.listar();
  }

  listar() {
    this.postService.get(1).subscribe(
      (response: Post[]) => {
        this.posts = response;
      },
      (error: any) => { console.log(error) });
  }

  create() {
    this.newPost.usuarioId = 1;
    this.postService.create(this.newPost).subscribe(
      (response: any) => { console.log(response);this.listar(); },
      (error: any) => { console.log(error) }
    );
  }

}
