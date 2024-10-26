import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatAppComponent } from './components/chat-app/chat-app.component';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./components/authentication/authentication.module')
      .then(m => m.AuthenticationModule)
  },
  {
    path: 'chat-app',
    component: ChatAppComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
