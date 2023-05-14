import { Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { LOCATION_INITIALIZED } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { firstValueFrom } from 'rxjs';

// AoT requires an exported function for factories
export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient);
}

export function ApplicationInitializerFactory(
  translate: TranslateService, injector: Injector) {
  return async () => {
    await injector.get(LOCATION_INITIALIZED, Promise.resolve(null));

    let defaultLang: string;
    if(!localStorage['lang']) defaultLang = translate.getBrowserLang();
    else defaultLang = localStorage['lang'];
    
    translate.addLangs(['en', 'hu']);
    translate.setDefaultLang(defaultLang);
    try {
        await firstValueFrom(translate.use(defaultLang.match(/en|hu/) ? defaultLang : 'en'), { defaultValue: 'en' });
    } catch (err) {
      console.log(err);
    }
  };
}