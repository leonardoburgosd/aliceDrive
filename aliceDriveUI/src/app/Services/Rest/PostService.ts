import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class PostService {
    private api: string;
    constructor(private httpClient: HttpClient) {
        this.api = 'http://192.168.8.10/alicedrive/back/api/';
    }

}