import { RouterConfiguration, Router } from "aurelia-router";
import { PLATFORM } from "aurelia-pal";

export class App {
  router: Router;
  configureRouter(config: RouterConfiguration, router: Router): void {
    config.title = "Aurelia";
    config.map([
      {
        route: "assets",
        name: "list-assets",
        moduleId: PLATFORM.moduleName(
          "components/asset/list-assets/list-assets"
        ),
        nav: true,
        title: "List of assets",
      },
      {
        route: "assets/:id/details",
        name: "details-assets",
        moduleId: PLATFORM.moduleName(
          "components/asset/asset-details/asset-details"
        ),
        nav: false,
        title: "Details of assets",
      },
      {
        route: "assets/new",
        name: "new-asset",
        moduleId: PLATFORM.moduleName("components/asset/new-asset/new-asset"),
        nav: true,
        title: "New asset",
      },
    ]);
    this.router = router;
  }
}
