## Postback Handlers

Imagine you have a button in your page which removes some data. In many cases, you need to display a confirmation dialog before the data are deleted.
This is a situation when you need a **postback handler**.

In general, the postback handler is a mechanism which allow to intercept a postback on any control event and execute your own custom logic before the postback
is made. It is even possible to cancel the postback at all.

You can attach a postback handler to any control using the `PostBack.Handlers` property.  

```DOTHTML
<dot:Button Text="Submit" Click="{command: Submit()}">
    <PostBack.Handlers>
        <dot:ConfirmPostBackHandler Message="Do you really want to submit the form?" />
    </PostBack.Handlers>
</dot:Button>
```

The `ConfirmPostBackHandler` is a built-in handler which displays the default javascript confirmation box. In the example, this handler is applied to all events on the `Button` control.
If the user declines the confirmation, the postback won't be initiated.

If the control has multiple events and you need to apply the handler only on a specific event, you can use the `EventName` property. 
If the `EventName` property is not specified, the handler is applied to all events the control can make.

You can add multiple handlers in the collection. They will chain in the exact same order they were specified.

The default `ConfirmPostBackHandler` provides the basic confirmation functionality using the javascript `confirm` function, but it doesn't provide
a nice user experience. However, the postback handler mechanism is extensible and it is not difficult to write your own confirmation dialog logic.
You can find more information about that in the [Creating Custom Postback Handlers](/docs/tutorials/control-development-creating-custom-postback-handlers/{branch}) tutorial.
