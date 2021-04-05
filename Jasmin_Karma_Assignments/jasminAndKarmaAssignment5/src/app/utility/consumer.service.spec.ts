import { TestBed } from '@angular/core/testing';

import { ConsumerService } from './consumer.service';

describe('ConsumerService', () => {
  let service: ConsumerService;
  let spy: any;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConsumerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getstring should return string', () => {
    expect(service.getString()).toBe('Example Value');
  });

  it('getNumber should return number', () => {
    expect(service.getNumber()).toBe(21);
  });

  it('getExample value should retun string value', () => {
    spy = spyOn(service.provider, 'getValue').and.returnValue(
      'Example Value'
    );

    expect(service.getString()).toEqual('Example Value');
    expect(service.provider.getValue).toHaveBeenCalled();
  });

  it('getSampleNumber should return value', () => {
    spy = spyOn(service.provider, 'getNumber').and.returnValue(
      21
    );
    expect(service.getNumber()).toEqual(21);
    expect(service.provider.getNumber).toHaveBeenCalled();
  });
});
