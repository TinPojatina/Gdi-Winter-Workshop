import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormRecord, FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table'
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DataTableComponent } from './data-table/data-table.component';
import { SensorTableComponent } from './sensor-table/sensor-table.component';
import { TypeTableComponent } from './type-table/type-table.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    declarations: [
        AppComponent,
        DataTableComponent,
        SensorTableComponent,
        TypeTableComponent
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        MatTableModule,
        FormsModule,
        BrowserAnimationsModule
    ]
})

export class AppModule { }
