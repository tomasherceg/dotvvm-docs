## Postback Handlers

Imagine you have a button in your page which removes some data. In many cases you may want to display a confirmation dialog before the action will be taken.
This is when you need a **postback handler**.

In general, the postback handler is a mechanism which allow to intercept a postback on any control event and execute your own custom logic before the postback
is made. It is even possible to dismiss the postback at all.

You can attach a postback handler to any control using the `PostBack.Handlers` property.  

```DOTHTML
<dot:Button Text="Submit" Click="{command: Submit()}">
    <PostBack.Handlers>
        <dot:ConfirmPostBackHandler Message="Are you really want to submit the form?" />
    </PostBack.Handlers>
</dot:Button>
```

The `ConfirmPostBackHandler` will be applied to all events on the `Button` control and displays a confirmation box before the postback will take place.
If the user declines the confirmation, the postback will not be executed.

If the control has multiple events and you need to apply the handler only on one event, you can use the `EventName` property to specify the event 
to which the handler will be attached. If the `EventName` property is not specified, the handler is applied to all events of the control.

You can add multiple handlers in the collection. They will chain in the same order they were specified.

The default `ConfirmPostBackHandler` provides the basic confirmation functionality using the javascript `confirm` function, but it doesn't provide
a nice user experience. However, the postback handlers are extensible and it is not difficult to write your own confirmation dialog logic.
You can find more information about that in the [/docs/tutorials/control-development-creating-custom-postback-handlers](Creating Custom Postback Handlers) tutorial.
