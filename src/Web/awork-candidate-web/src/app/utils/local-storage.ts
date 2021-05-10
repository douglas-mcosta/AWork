export class LocalStorageUtils {

  getUser(): any {
    return JSON.parse(localStorage.getItem("awork.user") || "");
  }

  getFirstNameUser(): string{
    return this.getUser().firstName || '';
  }
  getUserId(): string{
    return this.getUser().userId || '';
  }

  getEmailUser(): string{
    return this.getUser().email || '';
  }

  saveLocalDataUser(response: any) {
    this.saveTokenUser(response.accessToken);
    this.saveUser(response.userToken);    
  }

  clearLocalDataUser() {
    localStorage.removeItem("awork.token");
    localStorage.removeItem("awork.user");
  }

  getTokenUser(): string | null {

    return localStorage.getItem("awork.token")
  }

  saveTokenUser(token: string) {
    localStorage.setItem("awork.token",token);
  }
  saveUser(user: string){
    localStorage.setItem("awork.user",JSON.stringify(user));
  }
}
