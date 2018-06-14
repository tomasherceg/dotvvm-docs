# Localization Presenter

> This feature is new in **DotVVM 2.0**.

Localizable presenter is a mechanism which detects and sets the correct culture before the HTTP request is processed, so all methods (including async/await calls which may use different threads) use the same culture consistently.

The `LocalizablePresenter` is a class which accepts two functions - the first one can detect the culture from the [Request Context](/docs/tutorials/basics-request-context/{branch}), the second one invokes the presenter which will process the page.

The class provides two factory methods which create an instance of the localization presenter:

* `BasedOnParameter` uses a route parameter to persist the culture name.
* `BasedOnQuery` uses a query string parameter to persist the culture name.