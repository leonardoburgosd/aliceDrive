import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilesComponent } from './pages/files/files.component';
import { PrincipalComponent } from './pages/principal/principal.component';
import { AuthComponent } from './pages/auth/auth.component';
import { FileComponent } from './components/file/file.component';
import { PostComponent } from './pages/post/post.component';
import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { ViewFileComponent } from './pages/view-file/view-file.component';
import { ErrorPageComponent } from './pages/error-page/error-page.component';

@NgModule({
  declarations: [
    AppComponent,
    FilesComponent,
    PrincipalComponent,
    AuthComponent,
    FileComponent,
    PostComponent,
    BreadcrumbComponent,
    ViewFileComponent,
    ErrorPageComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
