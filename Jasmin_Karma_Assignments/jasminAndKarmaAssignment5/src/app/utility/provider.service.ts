import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProviderService {

  constructor() { }

  getValue(){
    return 'Example Value';
  }

  getNumber(){
    return 21;
  }

  getObservable() {
    return of('Example Observable');
  }

  getPromise() {
    return Promise.resolve('Example Promise');
  }

  getObservableWithDelay() {
    return of('observable with delay').pipe(
      delay(10)
    );
  }
}
