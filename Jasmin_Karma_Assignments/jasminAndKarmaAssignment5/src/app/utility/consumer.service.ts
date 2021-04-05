import { Injectable } from '@angular/core';
import { ProviderService } from './provider.service';

@Injectable({
  providedIn: 'root'
})
export class ConsumerService {
  provider: ProviderService = new ProviderService();

  constructor() { }

  getString() {
    return 'Example Value';
  }

  getNumber() {
    return 21;
  }

  getExampleValue() {
    return this.provider.getValue();
  }

  getExampleNumber() {
    return this.provider.getNumber();
  }

  getPromise() {
    return this.provider.getPromise();
  }

  getObservableWithDelay() {
    return this.provider.getObservableWithDelay();
  }
}
