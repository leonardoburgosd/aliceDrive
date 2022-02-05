import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Post } from '../Estructura/post';

@Injectable({
    providedIn: 'root'
})
export class PostService {
    private api: string;
    constructor(private httpClient: HttpClient) {
        this.api = 'http://192.168.8.10/alicedrive/back/api/posts';
    }

    get(usuarioId:number):any{
        return this.httpClient.get(this.api+'/'+usuarioId);
    }

    create(post:Post):any{
        return this.httpClient.post(this.api,post);
    }
}
