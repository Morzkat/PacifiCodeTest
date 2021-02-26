import {DialogController} from 'aurelia-dialog';
  
  export class ResetAssetFormDialog {
    static inject = [DialogController];
    controller = null;

    constructor(controller: DialogController){
      this.controller = controller;
    }
  }
  

  