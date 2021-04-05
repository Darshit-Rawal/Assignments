import { Injectable } from '@angular/core';
import { ConsumerService } from './consumer.service';

@Injectable({
  providedIn: 'root'
})
export class StringUtilityService {

  consumerSerive!: ConsumerService;
  stringData: string = '';

  constructor(
    private data:ConsumerService
  ) {
    this.consumerSerive = data;
   }

  getStringData() {
    this.stringData = this.consumerSerive.getString();
  }

  toUpperCase() {
    this.stringData = this.stringData.toUpperCase();
  }

  toLowerCase() {
    this.stringData = this.stringData.toLowerCase();
  }

  trimSpaces(str: string) {
    return str.trim();
  }

}
