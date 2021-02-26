import { ValidationRules } from "aurelia-validation";

  export class Asset {
    id:number;
    assetName: string;
    department: string;
    countryOfDepartment: string;
    purchaseDate: string;
    broken: boolean;
    emailAdressOfDepartment: string;
  }
  
  ValidationRules
    .ensure((a: Asset) => a.assetName)
      .displayName('Asset Name')
      .required()
      .minLength(5)
      .withMessage('Asset Name must have at least 5 characters')
    .ensure((a: Asset) => a.department)
      .required()
    .ensure((a: Asset) => a.countryOfDepartment)
      .required()
    .ensure((a: Asset) => a.purchaseDate)
      .required()
      .satisfies((date: string) => new Date().getFullYear() - new Date(date).getFullYear() < 1 )
      .withMessage('The purchase date cannot be older than one year.')
    .ensure((a: Asset) => a.emailAdressOfDepartment)
      .required()
      .email()
    .ensure((a: Asset) => a.broken)
      .required()
    .on(Asset);

  
  
