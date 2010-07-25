Windows Forms MVP
=================

This code provides a quick experiment I did in building a Model View Presenter framework for windows forms applications, that was based around the use of an IoC container (Castle Windsor).

The aim of this code base was to provide a simple and extensible framework for building composite applications, with the individual components leveraging the MVP pattern.

This code was experimental, and has never been used to build an actual product as far as I know.

Getting Started
------------------
The library is broken down into a number of parts:

 * AddIns - providing a basic Add in framework.
 * Commands - reusable commands which can be bound to parts of the user interface.
 * Docking - support for dockable windows etc.
 * EventPublisher - a basic synchronous message bus to be used by the applications various componenets, allowing for decoupling.
 * Menus - support for extensible menus, where various plugins can insert items into menus/nested menus as they are built (or even replace existing items).
 * Presenter - basic framework for Views and Presenters.
 * Shell - Application shell, used to host the basic layout of an application.
 
Not all features are complete.  And at current I have no intention to continue working on this codebase.

Should you use this code?
-------------------------

I would suggest no - If you need to build a composite windows forms application (and can't just use WPF) - then I would suggest doing it from scratch, and focusing on the specific problems you have - this library might provide useful thought-starters, but it's built in rather opinionated manor.

Key resources you will need if building your own these days:

* [Build your own CAB series from Jeremy D. Miller][1]
* [Synchronous message bus, as used in say MVC Contrib][2]
* [IObservable/IObserver in the .Net Framework 4.0][3]

  [1]: http://codebetter.com/blogs/jeremy.miller/archive/2007/07/25/the-build-your-own-cab-series-table-of-contents.aspx
  [2]: http://mvccontrib.codeplex.com/
  [3]: http://channel9.msdn.com/shows/Going+Deep/Kim-Hamilton-and-Wes-Dyer-Inside-NET-Rx-and-IObservableIObserver-in-the-BCL-VS-2010/