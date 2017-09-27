# MVC Introduction

## Presentation starts with a breif Powerpoint presentation on what MVC is.

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
stay tunned.

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

(Repalce with Link for Object Oriented tutorial)

