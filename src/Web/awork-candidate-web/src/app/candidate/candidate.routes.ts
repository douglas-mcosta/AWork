import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CandidateAppComponent } from "./candidate.app.component";

const candidateRoutesConfig: Routes = [
  {
    path: "",
    component: CandidateAppComponent,
    children: [
      {
        path: "user-profile",
        loadChildren: () =>
          import("./user-profile/user-profile.module").then(
            (m) => m.UserProfileModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(candidateRoutesConfig)],
  exports: [RouterModule],
})
export class CandidateRoutingModule {}
