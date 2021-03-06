// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  urlServiceV1: "https://localhost:5001/api/v1/",
  urlCandidateV1: "https://localhost:44334/api/v1/",
  urlIdentity: "https://localhost:44371/api/",
  googleMapAddress: "https://www.google.com/maps/embed/v1/place?key=AIzaSyAP0WKpL7uTRHGKWyakgQXbW6FUhrrA5pE&q=" 
};
