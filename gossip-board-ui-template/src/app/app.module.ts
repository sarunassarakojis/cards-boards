import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppComponent} from './app.component';
import {LoginFormComponent} from './components/login-form/login-form.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {
  MdButtonModule,
  MdCardModule,
  MdCheckboxModule,
  MdIconModule,
  MdInputModule,
  MdListModule,
  MdMenuModule,
  MdProgressSpinnerModule,
  MdSnackBarModule,
  MdTabsModule,
  MdToolbarModule,
  MdTooltipModule
} from '@angular/material';
import {UserService} from './services/user.service';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule, Routes} from '@angular/router';
import {RegisterFormComponent} from './components/register-form/register-form.component';
import {TextPostListComponent} from './components/text-post-list/text-post-list.component';
import {TextPostService} from './services/text-post.service';
import {TextPostInputComponent} from './components/text-post-input/text-post-input.component';
import {PollPostListComponent} from './components/poll-post-list/poll-post-list.component';
import {PollPostService} from './services/poll-post.service';
import {PollPostInputComponent} from './components/poll-post-input/poll-post-input.component';
import {HomeComponent} from './components/home/home.component';
import {UserComponent} from './components/user/user.component';
import {ChangePasswordFormComponent} from './components/change-password-form/change-password-form.component';
import {MediaPostService} from './services/media-post.service';
import {MediaPostInputComponent} from './components/media-post-input/media-post-input.component';
import {MediaPostListComponent} from './components/media-post-list/media-post-list.component';
import {UserDetailService} from './services/user-detail.service';

const appRoutes: Routes = [
  {path: 'login', component: LoginFormComponent},
  {path: 'register', component: RegisterFormComponent},
  {path: 'home', component: HomeComponent},
  {path: 'user', component: UserComponent},
  {path: '', redirectTo: 'home', pathMatch: 'full'} // default page
];

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RegisterFormComponent,
    TextPostListComponent,
    TextPostInputComponent,
    PollPostListComponent,
    PollPostInputComponent,
    HomeComponent,
    HomeComponent,
    UserComponent,
    ChangePasswordFormComponent,
    MediaPostInputComponent,
    MediaPostListComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MdListModule,
    MdTooltipModule,
    MdIconModule,
    MdInputModule,
    MdButtonModule,
    MdCardModule,
    MdCheckboxModule,
    MdTabsModule,
    MdToolbarModule,
    MdMenuModule,
    MdProgressSpinnerModule,
    ReactiveFormsModule,
    MdSnackBarModule
  ],
  providers: [
    UserService,
    TextPostService,
    PollPostService,
    MediaPostService,
    UserDetailService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
