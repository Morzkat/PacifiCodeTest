import { inject } from "aurelia-dependency-injection";
import { I18N } from "aurelia-i18n";
import { Asset } from "resources/shared/models/asset";
import { HttpService } from "resources/shared/services/http-service";

@inject(HttpService, I18N)
export class ListAssets {
  assets: Asset[];
  httpService: HttpService;
  i18n: I18N;

  constructor(httpService: HttpService, i18n: I18N) {
    this.i18n = i18n;
    this.httpService = httpService;
    this.getAssets();
  }

  getAssets() {
    this.httpService.get<Asset[]>(`assets`).then((result) => {
      this.assets = result.payload;
    });
  }
}
