import { TestBed } from '@angular/core/testing';
import { ConsumerService } from './consumer.service';

import { StringUtilityService } from './string-utility.service';

describe('StringUtilityService', () => {
  let stringUtility: StringUtilityService;
  let dataService: ConsumerService;
  let spy: any;

  beforeEach(async () => {
    dataService = new ConsumerService();
    stringUtility = new StringUtilityService(dataService);
  });

  it('should create an instance', () => {
    expect(new StringUtilityService(new ConsumerService())).toBeTruthy();
  });

  it('toUpperCase should convert to uppercase string', () => {
    // Arrange
    spy = spyOn(dataService, 'getString').and.returnValue(
      'Example Value'
    );

    // Act
    stringUtility.getStringData();
    stringUtility.toUpperCase();

    // Assert
    expect(stringUtility.stringData).toEqual('EXAMPLE VALUE');
    expect(dataService.getString).toHaveBeenCalled();
  });

  it('toLowerCase should convert to lowercase string', () => {
    // Arrange
    spy = spyOn(dataService, 'getString').and.returnValue(
      'EXAMPLE VALUE'
    );

    // Act
    stringUtility.getStringData();
    stringUtility.toLowerCase();

    // Assert
    expect(stringUtility.stringData).toEqual('example value');
    expect(dataService.getExampleValue).toHaveBeenCalled();
  });

  it('trimSpaces should trim spaces', () => {
    // Assert
    expect(stringUtility.trimSpaces('  Example Value  ')).toEqual('Example Value');
  });

  it('toUpperCase should not do anything if string is empty', () => {
    // Act
    stringUtility.toUpperCase();

    // Assert
    expect(stringUtility.stringData).toEqual('');
  });

  it('toLowerCase should not do anything if string is empty', () => {
    // Act
    stringUtility.toLowerCase();

    // Assert
    expect(stringUtility.stringData).toEqual('');
  });
});
