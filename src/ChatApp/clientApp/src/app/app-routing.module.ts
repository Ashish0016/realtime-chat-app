import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatAppComponent } from './components/chat-app/chat-app.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'chat-app',
    pathMatch: 'full'
  },
  {
    component: ChatAppComponent,
    path: 'chat-app'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
