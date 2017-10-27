# MVC Introduction

## Topics
- [x] What Is MVC?
- [x] ASP.NET Specifics.
- [x] Project Structure
- [x] Routing Conventions
- [x] Passing a typed model to the view.

## Future Topics (not covered in this presentation)
- [ ] Data Binding
- [ ] templates
- [ ] Views

## useful References
- Basic C# References: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/
- C# Coding Conventions: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions
- Getting started with MVC: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started


## What is MVC?
    MVC (Model, View, Controller) is a design pattern that compartmentalizes the design of an application
    in to three distict parts. 
### Model
    The Model is the Data. This data should represent all the data and bussiness logic needed to solve
    the particular problem you are working on. Now there is a whole world of how to store and manage this data.
    For the pourposes of this training we will not be disscussing those items. We will mostly be disscussing
    view models to reduce the scope of the disscussion. It still is important to know that you shouldn't be doing 
    buissiness logic in your controller.
### View
    This is what the end user will see and interact with. The view displays the data and makes
    requests back to the controller to manipulate the data. Note that the view shouldn't directly
    work with the model.
### Controller
    The Controller is what connects the dots between the View and the model. The Controller handles requests
    In the form of URL's from the user and uses that to manpulate the model. Business logic should not happen in the controller,
    this should happen in the model. Again for this disscision we will be using hard coded view models back at the controller. 
    Typically you would actually go out to the model or the database and get the data you want and translate it to a view
    model. However, this is outside the scope of this training.

### How Components Interact with eachother
    
    ![] (Pictures/mvc-architecrture)
    Figure 1: How the various MVC components interact.

    ![] (Pictures/request-handling-in-mvc)
    figure 2: Request handling in C# MVC

    Source: http://www.tutorialsteacher.com/mvc/mvc-architecture

### Advantages of MVC.
    - Ease of Development
    - Makes parellel development easy.
    - Seperating logic makes resulting code simpler.
    - Testing testing testing. Seperating components makes writing clear simple unit test simple.

Though MVC is a Great Arictecture type. It can't solve every problem. Additionally there are a bunch of different
variations on MVC.

## ASP.NET MVC Specifics

### Model

The Models in ASP.NET MVC are just C# models similar to the one shown below.

```C#
    public class ClassViewModel
    {
        //keeps track of a unique id. Useful when we want to store this information in a database.
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
stay tunned. Also there maybe future lectures on the entity frame work
which allows for easy storage of your data in a database.

### View

In ASP.NET MVC The view is a Razor page. Razor is a templeting engine and has lots of
handy features. But razor is essentially a mix of HTML and C# (Hense .cshtml). We will also talk about templating however this will be in a future Lecture. Shown below is one of the views from am empty MCV Template. Make note its really Important how you manage
your view names and location in the file system. This will become clear once we get to talking about routing.

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
namespace MVCTraining.Controllers
{
    public class ClassesController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Classes
        public ActionResult Index()
        {
            return View(db.Classes.ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,identifier,courseName,instructor")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@class);
        }
    }
}
```
### Controller simatics

Note that you should group your controllers by what actions they repersent.
For instnace if you have a controller that deals with users you should call it
Users. Your names should be descriptive.

Also notice that each function represents and action you can take that pertains to the
data that controller represents. You sould also make these names descriptive. For instance
if you have an edit personal info for a page you should call the action for that function
edit. Addtionally, note that each controller returns an actionResult. This actionResult can
be an HTML page, partial (Part of an HTML page), JSON, A document such as PDF or word and a ton
of other options. Mostly your controllers will return HTML but its important to note that it can
return other types of items as well.

Note: The Syntax for inheritence in C# is as follows
```C#
    public class ChildCLass : ParentClass {...}
```

If you are unfamiliar with object oriented programing view link shown bellow.

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/object-oriented-programming

## Project Structure

    If you want to explor the basic project structure Open the MVCTraining.sln file in Visual Studio.

### Models
    Models go in the the model file as a convention. However there are many other ways to organize models.
### Views
    To take full advantage of the default routing you should name your view the same as the name of the
    action you plan to use to return that view. You should also place that in a subfolder of the views directory
    that has the same name. This becomes really important as it makes routeing really simple.
### Controllers
    Controllers go in the controller folder. This makes life way easier when it comes time to do routeing do this and you will spend next to no time doing the routeing as every thing is already there waiting for you. You may need to make minor ajustments to the default routing but generally you can piggie back off the degault routeing.

## Routing Conventions
 - Convential Routing
 - Atribute Routing

### Routing Table
Regardless of what type of routeing convention you use you are simply adding entries into a routeing table. The application
then takes that rounte and tries to match it to one of the entries in the routing table. It will then preform the action listed
in the first entry it finds in the table that matches.

### Conventional Routing
    In convential routing you manually enter routes into the routing table.
    This approches the problem as a generally case first then more specific routes you would like to handle. For instance to set up a routing table you might use the code shown below. Generally you won't need to make a ton of edits to the routing table if you
    stick to convetions. Sticking to conventions will allow you to take advantage of the default routing. However, There may be
    special cases you need to deal with so its important to know that you can deal with special cases in the RegisterRoutes function.

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
By useing paramater defaults we can specify what the default value for that URL is if a value is not provided. For instnace:
 "someController" would really give us
 "someContrller/Index" because if no value is proved for actino it replaces it with 
 the default value (index).

calling MapRoute adds a new entry to the routing table.
note the order in which these enteries are added matters as its just going to use the first route that matches the URL.
For instance in the example above if we put the special controller after the default controller it will never get run because it will always use the default case. So you want to put special cases before more general cases.

### Why the default case works

```C#
    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
```
Consider the code above. This works beacuse its looking for a controller in the first url paramater. If there is a value it looks for this controller and runs the default value if no value is provided for the action. If a value is provided for the action it goes to the controller and tries to find the action. The last paramater id is optional. For some items that require an id you will get a 401 error if you don't provide an id.

This routing convention is why you want to place the controller in the controller file in the solution because other wise it will not find your controller. Also you will want to name each action in your controller after the action you are taking.

### Show demo where we use convention based routing to serve our app.

For this section look in the RouteConfig.cs File in the App_Start folder
in the Visual Basic Solution.



### Atribute Routing

Atribute routing also makes entries to the routing table however it allows us to do this
closer to the action that this route represents.

An example of Attribute routeting is shown below.

```C#
         // GET: Classes
        [Route("Classes/Index")]
        public ActionResult Index()
        {
            return View(db.Classes.ToList());
        }
```

### Atribute Routing and Paramaters.
Like conventional routing atribute routing also allows us to
set up a paramater for the URL that we can use in the controller.

```C#
     // GET: Classes/Details/5
        [Route("Classes/Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }
```
This allows us to pass paramaters to our action in our controllers.

Notice we can also add constraints to a paramater so a route will require
the paramater to be a certain data type. We can also specify optional
paramaters using the ?.

```C#
    [Route("Classes/Details/{id:int})]

    [Route("Classes/Details/{id?})]
```

You can also set a prefix for a controller.

```C#
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        [Route("Index)] //Route: Users/Index
        public ActionResult Index(){
            return View(db.Users.ToList());
        }
        ...
    }
```

This allows you to group like actions together with out having to add it
to each individual actions route.

You can also specify names and orders for routes using Atribute routing.
One thing to keep in mind when using Atribute routing is that order still matters.
```C#
[RoutePrefix("Users")]
public class HomeController : Controller
{

    [Route("Index", Name="UsersIndex, Order = 2)]
    public ActionResult Index() {...}

    [Route("{id}", Name = "UsersDetails", Order = 1)]
    public ActionResult Details(int id) {...}

}
```

If we look at the example above the route of "/Users/Index" We will get an error. This is because it matches
the user details route which is of a higher order. If you do not specify an order the order which the enteries are entereed into the routeing table in the order they apear.

We can solve the error above either by changing the order or by adding a constraint to the UserDetails route.


You can also specify a default route for the application

```C#
    [Route("~/")] //this is the default action for the entire application.
    [Route("")] //specifies default route for route prefix.
```

### Atribute Routing Demo

For this demo go to the StudentsController the attribute routes will be commented out.
You will also need to go to the the route config page and comment out the convention based
routing.

### Convention Routing vs Atribute Routing

Convention based routeing is less flexible however for most MVC applications if you follow
the naming conventions you get the routing for free.

However Atribute routing is much more flexible and for larger applications may be preferable to
Convention based routing because all the routes will be near the actions that the represent.

In the end it really comes down to preference.

## Passing your model to your view and generating your first web page.

### quick demo showing a controller passing a view.

Go to the Classes Controller and view the action for Details. You will notice the following code.

```C#
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }
```
You will notice we are getting a single Class model (like we saw earlier) and
passing it to the view.

If you go to the view for Classes/Details you will see the following razor page:

``` cshtml
    @model MVCTraining.Models.Class

@{
    ViewBag.Title = "Details";
}

<h2>Details</h2>

<div>
    <h4>Class</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(model => model.identifier)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.identifier)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.courseName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.courseName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.instructor)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.instructor)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", new { id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
```

The most important thing to note here is that we are able to pass a typed model to the view
we don't have to pass a JSON object or a generic object.

## Sources
https://msdn.microsoft.com/en-us/library/dd381412(v=vs.108).aspx
https://exceptionnotfound.net/attribute-routing-vs-convention-routing/
http://www.tutorialsteacher.com/mvc/mvc-architecture
