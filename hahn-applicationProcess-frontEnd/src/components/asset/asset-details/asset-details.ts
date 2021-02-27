import { inject } from "aurelia-dependency-injection";
import { Asset } from "resources/shared/models/asset";
import { HttpService } from "resources/shared/services/http-service";

@inject(HttpService)
export class AssetDetails {
  asset: Asset;
  httpService: HttpService;

  constructor(httpService: HttpService) {
    this.httpService = httpService;
    this.getAssetById(1);
  }

  getAssetById(id: number): void {
    this.httpService.get<Asset>(`assets/${1}`).then((result) => {
      this.asset = {
        id: result.payload.id,
        assetName: result.payload.assetName,
        broken: result.payload.broken,
        countryOfDepartment: result.payload.countryOfDepartment,
        department: result.payload.department,
        emailAdressOfDepartment: result.payload.emailAdressOfDepartment,
        purchaseDate: result.payload.purchaseDate,
      };
      console.log(this.asset.purchaseDate)
      console.log(result.payload.purchaseDate)
    });
  }
}
