# MVC Introduction

## Topics
- [x] What Is MVC?
- [x] ASP.NET Specifics.
- [x] Project Structure
- [x] Routing Conventions
- [x] Itro To views

## Future Topics (not covered in this presentation)
- [ ] Data Binding
- [ ] templates
- [ ] Views


## What is MVC?
    MVC (Model, View, Controller) is a design pattern that compartmentalizes the design of an application
    in to three distict parts. 
### Model
    The Model is the Data. This data should represent all the data and bussiness logic needed to solve
    the particular problem you are working on.
### View
    This is what the end user will see and interact with. The view displays the data and makes
    requests back to the controller to manipulate the data. Note that the view shouldn't directly
    work with the model.
### Controller
    The Controller is what connects the dots between the View and the model. The Controller handles requests
    from the user and uses that to manpulate the model. Business logic should not happen in the controller,
    this should happen in the model.
### How Components Inter Act with eachother
    
    ![] (Pictures/mvc-architecrture)
    Figure 1: How the various MVC components interact.

    ![] (Pictures/request-handling-in-mvc)
    figure 2: Request handling in C# MVC

    Source: http://www.tutorialsteacher.com/mvc/mvc-architecture

### Advantages of MVC.
    - Ease of Development
    - Makes parellel development easy.
    - Seperating logic makes resulting code simpler.

Though MVC is a Great Arictecture type. It can't solve every problem.

## ASP.NET MVC Specifics

### Model

The Models in ASP.NET MVC are just C# models similar to the one shown below.

```C#
    public class Class
    {
        //keeps track of a unique id. Useful later when binding data
        // and trying to query data.
        public int ID { get; set; }
        //Two lets and three digits that identifies what the class is ie: CS 325
        public string identifier { get; set; } 
        //The course name
        public string courseName { get; set; }
        //who is teaching the class.
        public string instructor { get; set; }
    }    
```

In ASP.NET There are all sorts of cool things you can do with the models that
allow you tons of flexibility. However this is a topic for a future lecture so
stay tunned (data binding).

### View

In ASP.NET MVC The view is a Razor page. Razor is a templeting engine and has lots of
handy features. But razor is essentially a mix of HTML and C# (Hense .cshtml). We will also talk about templating however this will be in a future Lecture. Shown below is one of the views from am empty MCV Template.

```cshtml
 @{
    ViewBag.Title = "Home Page";
}

<div class="jumbotron">
    <h1>ASP.NET</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="http://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Getting started</h2>
        <p>
            ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
            enables a clean separation of concerns and gives you full control over markup
            for enjoyable, agile development.
        </p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301865">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301867">Learn more &raquo;</a></p>
    </div>
</div>
```

Important note:

```cshtml
    @{
        //if you put @{} You can put any c# you want inside the curly braces.
        //I will show you how this will come in handy later.
    }
```

### Controller.

Shown Below is a typical example of a very simple controller. This example came from the Empty ASP.NET MVC template.

```C#
     public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
```
Note: The Syntax for inheritence in C# is as follows

```C#
    public class ChildCLass : ParentClass {...}
```

If you are unfermiller with object oriented programing view link shown bellow.

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/object-oriented-programming

## Project Structure

### Models

### Views

### Controllers

## Routing Conventions
 - Convential Routing
 - Atribute Routing

### Routing Table
Regardless of what type of routeing convention you use you are simply adding entries into a routeing table. 

### Conventional Routing
    In convential routing you manually enter routes into the routing table.
    This approches the problem as a generally case first then more specific routes you would like to handle. For instance to set up a routing table you might use the code below:

```C#
    public static void RegisterRoutes(RouteCollection routes){
        
        //ignore this tokanized structure and process the URL normally.
        routes.IgnoreRoute("resource.axd/{*pathInfo}");

        routes.MapRoute(
            name: "Special",
            url: "Special/{id},
            defaults: new {controller = "Home", action = "Index", id = UrlParaqmter.Optional}
        ); // Route: /Special/12

        //general Routes.    
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new {controller = "Home", action = "Index", id = UrlPatameter.optional}
        ); //Route: /Home/Index/12

        
    }
```
The MapRoute function:
```C#
    routes.MapRoute(
        name: //name of the route,
        url: //URL Pattern
        defaults: new {//Paramater defaults}      
    );
```
By useing paramater defaults you are saying that the paramaters in the url for the routing need to match the defaults.

calling MapRoute adds a new entry to the routing table.
note the order in which these enteries are added maters as you can have
entries overlap. If that happens the one that is first in the routing list will be called.

### Show demo where we use convention based routing to serve our app.




### Atribute Routing

## Passing your model to your view and generating your first web page.

### Creating Your View (real Quick)

### Rendering your view in the Controller (With model)

### Checking your work.