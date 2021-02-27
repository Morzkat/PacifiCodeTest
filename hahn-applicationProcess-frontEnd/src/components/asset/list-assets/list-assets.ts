import { inject } from "aurelia-dependency-injection";
import { Asset } from "resources/shared/models/asset";
import { HttpService } from "resources/shared/services/http-service";

@inject(HttpService)
export class ListAssets {
  assets: Asset[];
  httpService: HttpService;

  constructor(httpService: HttpService) {
    this.httpService = httpService;
    this.getAssets();
  }

  getAssets() {
    this.httpService.get<Asset[]>(`assets`).then((result) => {
      this.assets = result.payload;

      console.log(this.assets);
    });
  }
}
