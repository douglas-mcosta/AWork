import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { LocalStorageUtils } from 'app/utils/local-storage';

@Injectable()
export class AccountGuard implements CanActivate{

    localStorageUtils: LocalStorageUtils = new LocalStorageUtils();
    
    constructor(private router: Router){}
    
    canActivate(): boolean{

        if(this.localStorageUtils.getTokenUser()){
            this.router.navigate(['/home']);
        }
        return true;
    }
}
