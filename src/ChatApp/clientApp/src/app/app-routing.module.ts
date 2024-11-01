import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatAppComponent } from './components/chat-app/chat-app.component';
import { AuthGuard } from 'src/core/guards/auth.guard';
import { AuthRedirectGuard } from 'src/core/guards/auth-redirect.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthRedirectGuard],
    loadChildren: () => import('./components/authentication/authentication.module')
      .then(m => m.AuthenticationModule)
  },
  {
    path: 'chat',
    canActivate: [AuthGuard],
    loadChildren: () => import('./components/chat/chat.module').then(m => m.ChatModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
