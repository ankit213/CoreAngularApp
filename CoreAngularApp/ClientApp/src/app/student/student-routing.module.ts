import { NgModule , ModuleWithProviders } from '@angular/core';
import { Routes , RouterModule } from '@angular/router';
import {  StudentComponent } from '../student/student.component';
import { StudentListComponent } from '../student/student-list/student-list.component';
import { StudentEditComponent } from './student-edit/student-edit.component';
import { AuthenticationService } from "../shared/authentication.service";

const routes: Routes = [{
    path: '',
    component: StudentComponent,
     data: {
      title: 'Student'
    },
    canActivate : [AuthenticationService],
    children: [
        { path: 'list', component: StudentListComponent, data: { title: 'Student List' }, canActivate: [AuthenticationService]}
    ]}
];

export const studentRouting: ModuleWithProviders = RouterModule.forChild(routes);
