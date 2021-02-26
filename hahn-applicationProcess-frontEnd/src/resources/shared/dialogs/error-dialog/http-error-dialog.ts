import { DialogController } from "aurelia-dialog";

export class HttpErrorDialog {
  static inject = [DialogController];
  controller = null;
  errors = [];

  constructor(controller: DialogController) {
    this.controller = controller;
  }

  activate(errors) {
    for (const key of Object.keys(errors)) {
      const _error = errors[key];
      this.errors.push({ key, errors: _error });
    }
  }

  humanize(word: string): string {
    return word.split(/(?=[A-Z])/).join(" ");
  }
}
