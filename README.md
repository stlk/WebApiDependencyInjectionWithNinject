WebApiDependencyInjectionWithNinject
====================================

Example of using ninject with ASP.NET Web API

http://rousek.name/blog/injecting-dependecies-into-web-api-action-filters

What these files do?
--------------------

- DefaultFilterProvider.cs - takes care of injecting depencies to Action Filters
- NinjectDependencyResolver.cs and NinjectDependencyScope.cs - takes care of injecting depencies to Controllers
- IocConfig.cs - example configuration