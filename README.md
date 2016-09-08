# App Usage Application
Tracking application usage with APIs

## Application Proposal

- Have a web application (aka. **portal**) to manage the registered applications and to check the usage statistics in reports (tables with counters) and dashboards; (**In development**)
- Have a workstation service (aka. **client service**) which will report to an API, the usage time of a previously registered application; (**TBD**)
- Have a REST API to serve both the **portal** and the **client service**, to help the register management, to serve the statistcs to the reports and dashboards, and to receive/send information to the client service. (**In development**)

## Application architecture

The main application architecture is separated in 4 basic layers to minimally obey the [Key Design Principles of Software Architecture](https://msdn.microsoft.com/en-us/library/ee658124.aspx?f=255&MSPPError=-2147217396) and the [SOLID principles](http://butunclebob.com/ArticleS.UncleBob.PrinciplesOfOod)
- Key Design Principles of Software architecture
  - Separation of concerns (SoC);
  - Single Responsability principle (SRP);
  - Principle of Least Knowledge (LoD - Law of Demeter);
  - Don't repeat yourself (DRY);
  - Minimize upfront design.
- SOLID Principles
  - **S**RP -> Single Responsability Principle
  - **O**CP -> Open Closed Principle
  - **L**SP -> Liskov Substitution Principle
  - **I**SP -> Interface Segregation Principle
  - **D**IP -> Dependency **Inversion** Principle

### Application layers

1. Presentation
2. Application
3. Business
4. Infrastructure

#### 1. Presentation

In this layer we have the projects that interact directly with any kind of client (machine or user). This is the layer which is exposed to the world, so we will have at least 3 projects here. The **REST API**, the **Portal** and the **Client Service**.

#### 2. Application

In this layer we have the application hub, which serve as a business aggregator and as a interface to the presentation layer.
Here all the business services can talk to each other, to separate their logic and give the responses to the presentation layer.

#### 3. Business

Here relies on the business logic of each domain of the project. Each domain only knows about himself and his business rules.

#### 4. Infrastructure

Here we can find the generic and infrastructural (network, dependency injection, data connection, logging, settings, ...) logic that helps the other layers to do their work.

## Instalation for development and evolution

- Use VSCode or VS2015.3
- Clone the git repository
- Navigate on console to the root Web project folder
- Run on console `npm install` to restore the npm packages
- Run on console `bower install` to restore the bower packages
- Open the solution on VS2015.3 or on VSCode
- Build the solution to restore the nuget packages
  - Build the solution **again** to restore any package which can be missing
- Run the application on your prefered browser
  - Common urls: 
    - Web: http://[yourhost]:[your**WEB**port]/
    - API: http://[yourhost]:[your**API**port]/swagger/


## Technologies and a few design patterns used

- [.NET Framework 4.6.1](https://msdn.microsoft.com/en-us/library/w0x726c2(v=vs.110).aspx) (WebAPI)
  - [Nuget](https://www.nuget.org/)
    - [WebAPI v2](http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api)
    - [IoC + Dependency Injection](http://www.martinfowler.com/articles/injection.html#FormsOfDependencyInjection)
      - [Unity 4](https://msdn.microsoft.com/en-us/library/dn223671(v=pandp.30).aspx)
    - [Entity Framework 6.1.3](https://github.com/aspnet/EntityFramework6)
      - [LocalDb v12.0](https://technet.microsoft.com/en-us/library/hh245842(v=sql.120).aspx)
      - [Migrations](https://msdn.microsoft.com/en-us/data/jj591621.aspx)
    - [ETW Tracing](https://msdn.microsoft.com/en-us/library/ms751538(v=vs.110).aspx)
    - [Swagger](http://swagger.io/)
      - [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle)
    - [Repository + Unit Of Work](http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
    - [Domain-driven design (DDD)](https://en.wikipedia.org/wiki/Domain-driven_design)
    - [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)
 
- [.NET Core](https://docs.microsoft.com/en-us/dotnet/) (Portal)
  - [angular2](https://angular.io/)
  - [jquery](https://jquery.com)
  - [bootstrap](http://getbootstrap.com/)
  - [bower](https://bower.io/)
    - [startbootstrap-sb-admin2](https://github.com/BlackrockDigital/startbootstrap-sb-admin2)
    - [font-awesome](http://fontawesome.io/)
  - [gulp](http://gulpjs.com/)
  - [npm](https://www.npmjs.com/)
    - [angular2](https://www.npmjs.com/package/angular2)
    - [gulp-typescript](https://www.npmjs.com/package/gulp-typescript) (typescript builder)
    - [gulp-concat](https://www.npmjs.com/package/gulp-concat)
    - [gulp-cssmin](https://www.npmjs.com/package/gulp-cssmin)
    - [gulp-uglify](https://www.npmjs.com/package/gulp-uglify)
    - [rimraf](https://www.npmjs.com/package/rimraf)
    - [jquery](https://www.npmjs.com/package/jquery)
    - [bootstrap](https://www.npmjs.com/package/bootstrap)
    - [es6-shim](https://www.npmjs.com/package/es6-shim)
    - [rxjs](https://www.npmjs.com/package/rxjs)
    - [systemjs](https://www.npmjs.com/package/systemjs)
    - [zone.js](https://www.npmjs.com/package/zone.js)


#### Notes
(*) This application is developed for entertainment and research purpose. So it will keep changing and growing while I have time and curiosity to learn more and improve the application.

(**) Feel free to create issues and request changes if it makes sense on the application proposal.

(***) This code and applications are under [GPL3 license](https://www.gnu.org/licenses/gpl-3.0.html).

TBD = To be developed.