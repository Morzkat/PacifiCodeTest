import { DialogService } from "aurelia-dialog";
import { autoinject } from "aurelia-framework";
import { inject } from "aurelia-dependency-injection";
import { HttpClient, Interceptor, json } from "aurelia-fetch-client";

import { HttpResponse } from "../models/http-response";
import * as environment from "./../../../../config/environment.json";
import { HttpErrorDialog } from "../dialogs/error-dialog/http-error-dialog";

@inject(DialogService)
@autoinject
export class HttpService {
  dialogService: DialogService = null;
  httpClient: HttpClient = null;

  constructor(dialogService: DialogService) {
    this.dialogService = dialogService;
    this.httpClient = new HttpClient().configure((client) => {
      client.withBaseUrl(environment.assetsApi);
      client.withInterceptor(new HttpInterceptors(this.dialogService));
    });
    console.log(dialogService);
  }

  get<T>(endpoint: string): Promise<HttpResponse<T>> {
    return this.httpClient
      .fetch(`${endpoint}`)
      .then((response) => response.json());
  }

  post<T, X>(endpoint: string, body: X): Promise<HttpResponse<T>> {
    return this.httpClient
      .post(`${endpoint}`, json(body))
      .then((response) => response.json());
  }
}

export class HttpInterceptors implements Interceptor {
  dialogService: DialogService = null;
  constructor(dialogService: DialogService) {
    this.dialogService = dialogService;
    console.log(dialogService);
  }

  request(message) {
    console.log("request: ", message);
    return message;
  }

  async response(response: Response) {
    if (response.status < 200 || response.status > 299 ) {
      const result = await response.json();
      this.dialogService
        .open({ viewModel: HttpErrorDialog, model: result.errors, lock: false })
        .whenClosed((response) => {
          if (!response.wasCancelled) {
            // this.resetForm();
          }
        });
      throw response;
    }

    return response;
  }
}
