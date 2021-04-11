import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
//import { RegisterComponent } from './register';

const routes: Routes = [
    { path: '', component: HomeComponent },
    //{ path: 'login', component: LoginComponent },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const AppRoutingModule = RouterModule.forRoot(routes);