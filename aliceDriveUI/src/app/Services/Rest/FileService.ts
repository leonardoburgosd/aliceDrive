import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Files } from '../Estructura/files';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    }),
};


@Injectable({
    providedIn: 'root'
})
export class FileService {
    private api: string;
    constructor(private httpClient: HttpClient) {
        this.api = 'http://192.168.8.10/alicedrive/back/api/';
        //this.api = 'http://192.168.8.10/alicedriveDev/back/api/';
        //this.api = 'https://localhost:44344/api/';
    }

    createDisk(file: Files): any {
        return this.httpClient.post(this.api + "archives/", file);
    }

    getDisk(): any {
        return this.httpClient.get(this.api + "archives");
    }

    createArchive(file: Files, base: string): any {
        return this.httpClient.post(this.api + "archives/" + base, file);
    }

    getChildren(base: string): any {
        return this.httpClient.get(this.api + 'files/' + base);
    }

    async upload(file: File, baseId: string): Promise<any> {
        const formData: FormData = new FormData();
        formData.append('file', file);
        formData.append('fileBase', baseId);
        formData.append('FileNombre', file.name);
        formData.append('FileSize', file.size.toString());
        formData.append('FileType', file.type);
        return await this.httpClient.post(this.api + "files", formData).toPromise();
    }

    getShortFiles(baseId: string): any {
        return this.httpClient.get(this.api + "files/download/" + baseId);
    }

}
