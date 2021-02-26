import {DialogService} from 'aurelia-dialog';
import {inject} from 'aurelia-dependency-injection';
import { Asset } from 'resources/shared/models/asset';
import { HttpService } from 'resources/shared/services/http-service';
import { BootstrapFormRenderer } from 'resources/shared/render/bootstrap-form-render';
import { ResetAssetFormDialog } from './dialogs/reset-form-dialog/reset-asset-form-dialog';
import { Validator, ValidateEvent, validateTrigger, ValidationController, ValidationControllerFactory, ValidationRules } from 'aurelia-validation';
import { HttpResponse } from 'resources/shared/models/http-response';

@inject(ValidationControllerFactory, Validator, DialogService, HttpService)
export class AssetForm {
  asset: Asset;
  
  formIsValid: boolean;
  canResetForm: Map<string,string>;
  
  validator: Validator = null;
  controller: ValidationController = null;
  
  httpService: HttpService = null;
  dialogService: DialogService = null;
  

  constructor(controllerFactory: ValidationControllerFactory, validator: Validator, dialogService: DialogService, httpService: HttpService) {
    this.asset = new Asset()
    this.formIsValid = false;
    this.canResetForm =  new Map<string,string>();
    this.validator = validator;
    
    this.dialogService = dialogService;
    this.httpService = httpService;

    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapFormRenderer());
    this.controller.validateTrigger = validateTrigger.changeOrBlur;
    this.controller.subscribe(event => this.validateForm(event));

  }
  
  async submit() {
    const formResult = await this.controller.validate({object: this.asset});
    if(!formResult.valid)
      return;

    this.httpService.post('Assets',this.asset)
    .then((response: HttpResponse) => { 
      console.log(response.title)
      // this.resetForm();
      // console.log(response); 
    }).catch(error => {
      console.log(error)
    });
  }

  validateForm(event: ValidateEvent): void {
    console.log(event)
    if(event.instruction && this.asset[event.instruction.propertyName]?.length > 0) 
      this.canResetForm.set(event.instruction?.propertyName, this.asset[event.instruction?.propertyName] );
    else
      this.canResetForm.delete(event.instruction?.propertyName);

      this.validator.validateObject(this.asset)
      .then(results => this.formIsValid = results.every(result => result.valid));
  }

  openDialog(): void {
    this.dialogService.open({ viewModel: ResetAssetFormDialog, model: null, lock: false })
      .whenClosed(response => {
        if (!response.wasCancelled) {
          this.resetForm();
        }
    });
  }
  resetForm(): void {
    console.log('form reset');
    this.controller.reset();
    this.asset = undefined;
  }

}
