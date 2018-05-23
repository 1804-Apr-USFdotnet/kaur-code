import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";

@NgModule({
    imports: [],         // other modules this module needs something from
    declarations: [
        AppComponent
    ],                   // all the components and other directives in this module
    exports: [],         // all the components etc. we want to expose to other modules
    providers: [],       // for injecting services
    bootstrap: [
        AppComponent
    ]                    // our root/entry point component, AppComponent usually
})
export class AppModule { }
