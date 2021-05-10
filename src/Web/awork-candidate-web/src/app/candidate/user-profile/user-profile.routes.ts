import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CandidateResolve } from "./services/candidate.resolve";
import { ProfileComponent } from "./profile/profile.component";
import { UserProfileAppComponent } from "./user-profile.app.component";
import { UserProfileGuard } from "./services/user-profile.guard";

const userProfileRoutesConfig: Routes = [

    { path: '' , component: UserProfileAppComponent, 
    children: [
        { 
            path: '', component: ProfileComponent,
            resolve:{ candidate: CandidateResolve},
            canActivate: [UserProfileGuard],
            data: [{ claim : {type: 'Candidate',value:'R'}}]
        }
    ]}
];

@NgModule({
    imports: [RouterModule.forChild(userProfileRoutesConfig)],
    exports: [RouterModule],
})
export class UserProfileRoutingModule{}