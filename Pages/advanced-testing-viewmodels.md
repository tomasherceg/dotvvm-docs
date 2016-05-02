## Testing ViewModels

Viewmodels can be easily tested. In your test, just create an instance
of the viewmodel, set the property values, call a method and verify that the results 
are correct.

In the following example, you can see how easily the viewmodel can be tested.

```CSHARP
[TestMethod]
public void NormalTest()
{
    var viewModel = new SampleViewModel()
    {
        FirstName = "Humphrey",
        LastName = "Appleby"
    };

    var userName = viewModel.GenerateUserName();
    Assert.AreEqual("applebyh", userName);
}
```

### Mocking the Context

The only problem in **DotVVM** is when the viewmodel uses the `DotvvmRequestContext` fratures. 
We need to mock this object to provide all services to the tested method.

DotVVM contains a prepared mock class `TestDotvvmRequestContext`. You can set all properties you need
(Configuration, Route, Parameters, Query, OwinContext, ModelState, ResourceManager etc., but they are all optional).

In the test, you may need to verify e.g. whether the viewmodel method has redirected to some URL, or
whether it returned a file, failed on the model validation etc. The methods `InterruptRequest`, 
`RedirectTo*`, `RedirectPermanentTo*`, `FailOnInvalidModelState` and `ReturnFile` throw the `DotvvmInterruptRequestException`.
This exception includes a reason why the request was interrupted and a `CustomData` parameter which holds e.g. the
URL where the viewmodel action tried to redirect.

Here you can see a test case that verifies the viewmodel has built the proper route.

```CSHARP
[TestMethod]
public void NormalTest()
{
    var configuration = DotvvmConfiguration.CreateDefault();
    configuration.Routes.Add("ArticleDetail", "article/{Id}/{Title}", "article.dothtml", null);
    var viewModel = new SampleViewModel()
    {
        Context = new TestDotvvmRequestContext()
        {
            Configuration = configuration,
            ApplicationHostPath = "myApp"      // This tells the DotVVM that the application runs in a virtual directory, e.g. on the URL "http://somedomain.com/myApp/"
        }
    };
    
    try
    {
        var article = new ArticleDTO() { Id = 1, Title = "DotVVM is the best framework" };
        viewModel.RedirectToArticle(article);
    }
    catch (DotvvmInterruptRequestException ex)
    {
        Assert.AreEqual(InterruptReason.Redirect, ex.InterruptReason);
        Assert.AreEqual("/myApp/article/1/dotvvm-is-the-best-framework");
        return;
    }
    Assert.Fail("A redirect should have been performed!");
}
```