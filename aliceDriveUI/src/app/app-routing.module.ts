import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthComponent } from './pages/auth/auth.component';
import { ErrorPageComponent } from './pages/error-page/error-page.component';
import { FilesComponent } from './pages/files/files.component';
import { PostComponent } from './pages/post/post.component';
import { PrincipalComponent } from './pages/principal/principal.component';
import { ViewFileComponent } from './pages/view-file/view-file.component';

const routes: Routes = [
  {path:'',component:AppComponent},
  {path:'auth',component:AuthComponent},
  {path:'',component:PrincipalComponent, children:[
    { path: 'post', component: PostComponent },
    { path: 'file', component: FilesComponent },
    { path: 'file/:baseId', component: FilesComponent},
    { path: 'viewfile/:baseId', component: ViewFileComponent},
    {path:'**',component:ErrorPageComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
