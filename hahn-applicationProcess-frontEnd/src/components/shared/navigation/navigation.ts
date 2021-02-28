import { I18N } from "aurelia-i18n";
import { inject } from "aurelia-dependency-injection";
import { RouterConfiguration, Router, NavModel } from "aurelia-router";
import { PLATFORM } from "aurelia-pal";

@inject(I18N, RouterConfiguration, Router)
export class Navigation {
  i18n: I18N;
  router: Router;

  constructor(i18n: I18N, config: RouterConfiguration, router: Router) {
    this.i18n = i18n;
    this.configureRouter(config, router);

    console.log(this.router);
  }

  configureRouter(config: RouterConfiguration, router: Router): void {
    console.log('herer');
    
    config.title = "Aurelia";
    config.map([
      {
        route: "assets",
        name: "list_assets",
        moduleId: PLATFORM.moduleName(
          "components/asset/list-assets/list-assets"
        ),
        nav: true,
        title: "List of assets",
      },
      {
        route: "assets/:id/details",
        name: "details_assets",
        moduleId: PLATFORM.moduleName(
          "components/asset/asset-details/asset-details"
        ),
        nav: false,
        title: "Details of assets",
      },
      {
        route: "assets/new",
        name: "new_asset",
        moduleId: PLATFORM.moduleName("components/asset/new-asset/new-asset"),
        nav: true,
        title: "New asset",
      },
    ]);

    console.log(router);
    this.router = router;
  }

  setLocale(locale: string): void {
    console.log(locale);
    this.i18n.setLocale(locale);
  }

  getNavElementTitle(row: NavModel) {
    console.log(row.config.name);
    return `nav:${row.config.name.replace('-', '_')}`
  }
}
