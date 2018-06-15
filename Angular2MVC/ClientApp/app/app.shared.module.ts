import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';
//import { ToastrModule } from 'toastr-ng2';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { ContactComponent } from './components/contact/contact.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        ContactComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        //ToastrModule.forRoot(),
        InputTextModule, DataTableModule, ButtonModule, DialogModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'contact', pathMatch: 'full' },
            { path: 'contact', component: ContactComponent },
            { path: '**', redirectTo: 'contact' }
        ])
    ]
})
export class AppModuleShared {
}
