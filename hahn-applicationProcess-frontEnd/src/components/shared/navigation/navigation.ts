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
    this.router = router;
    console.log(this.router);
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
