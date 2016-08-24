# Web.Playground

This Solution contains an assortment of web projects (MVC, REST, OWN Self-Host) to demonstrate various techniques used

## Projects

### Kendo.LESS
*(not included in solution)*
 
Intially this project was just a demo for how to use CSS Preprocessors for Kendo UI. There's some good stuff, including signalr usage in the project - but - it's based on AdventureWorks and decided the Playground project was better suited to handle the examples

### Playground

This is the primary web application that features the use of Gulp, CSS preprocessors, KendoUI and much more. It's based on a skeleton SSDT project taken from my hockey team application.

* SSDT Integration
** Seeding data
** Indirection for release processing
** Single click publishing
* Repository pattern
* Gulp
* LESS compilation
* Single Page Application
* SignalR
* Bower
* Node Package Manager
* LESS stylesheets
* Mapper inversion
* CRUD Principals
* web.config indirection
* Module Revealing Pattern in Javascript

#### Up and running

1. Open the solution
2. In the Solution Explorer, right-click the package.json file and select "Restore Packages"
3. Right-click the bower.json file and select "Restore Packages"
4. Go to View -> Other Windows -> Task Runner Explorer
5. Open the Task Runner Explorer and make sure the Playground project is selected
 * If it reports an error - click the refresh button (It errored because the NPM packages from step 2 weren't restored yet)
6. Double-click the "css" task
7. Double-click the "js" task
8. In the Solution Explorer, go to DATA -> PlaygroundDb -> _publish
9. Double-click the LOCAL.publish.xml file.
 * Feel free to change anything you'd like - just ensure you also change it in the sql.config in the Playground project 
