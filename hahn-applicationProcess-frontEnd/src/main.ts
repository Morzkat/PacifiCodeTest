import { Aurelia } from "aurelia-framework";
import * as environment from "../config/environment.json";
import { PLATFORM } from "aurelia-pal";
import { I18N, Backend, TCustomAttribute } from "aurelia-i18n";

export function configure(aurelia: Aurelia): void {
  aurelia.use
    .standardConfiguration()
    .plugin(PLATFORM.moduleName("aurelia-validation"))
    .plugin(PLATFORM.moduleName("aurelia-dialog"))
    .plugin(PLATFORM.moduleName("aurelia-i18n"), (instance) => {
      const aliases = ["t", "i18n"];
      // add aliases for 't' attribute
      TCustomAttribute.configureAliases(aliases);

      // register backend plugin
      instance.i18next.use(Backend);

      // adapt options to your needs (see http://i18next.com/docs/options/)
      // make sure to return the promise of the setup method, in order to guarantee proper loading
      return instance.setup({
        // backend: {                                  // <-- configure backend settings
        //   loadPath: './locales/{{lng}}/{{ns}}.json', // <-- XHR settings for where to get the files from
        //   parse: (data) => {console.log(data)},
        // },
        resources: {
          en: {
            btn:{
              cancel:"Cancel",
            ok:"Ok",
            },
            reset_form:{
              title:"Reset Asset",
              message:"Are you sure want to reset form?"
            },
            nav:{
              list_assets: "List of assets",
              new_asset: "Add new assets",
            },
            list_asset: {
              title: "List of assets",
              new_asset_btn:"Add new asset",
              col_id:"Id",
              col_asset_name:"Asset Name",
              col_country:"Country",
              col_department:"Department",
              col_email:"Email",
              col_purchase_date:"Purchase Date",
              col_broken:"Broken",
            },
            new_asset: {
              title: "Add new assets",
              save_btn:"Save",
              reset_btn:"Reset"
            },
            details_asset: {
              title: "Details of assets",
            },
          },
          es: {
           btn:{
            cancel:"Cancelar",
            ok:"Ok",
           },
            reset_form:{
              title:"Limpiar el formulario",
              message:"Estas seguro que quieres limpiar el formulario?"
            },
            nav:{
              list_assets: "Lista de assets",
              new_asset: "Agregar un nuevo assets",
            },
            list_asset: {
              title: "Lista de assets",
              new_asset_btn:"Agregar nuevo asset",
              col_id:"Id",
              col_asset_name:"Nombre del Asset",
              col_country:"Ciudad",
              col_department:"Departamento",
              col_email:"Correo",
              col_purchase_date:"Día de compra",
              col_broken:"Esta roto?",
            },
            new_asset: {
              title: "Agregar nuevo assets",
              save_btn:"Guardar",
              reset_btn:"Limpiar"
            },
            details_asset: {
              title: "Detalles del assets",
            },
          },
        },
        attributes: aliases,
        lng: "en",
        fallbackLng: "en",
        debug: true,
      });
    })
    .feature(PLATFORM.moduleName("resources/index"));

  aurelia.use.developmentLogging(environment.debug ? "debug" : "warn");

  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName("aurelia-testing"));
  }

  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName("app")));
}
