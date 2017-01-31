## Server-Side HTML Generation and SEO

**DotVVM** uses javascript libraries to do the job, but don't worry. It won't make your site SEO-unfriendly.
You only have to be little careful and use server rendering where appropriate.

### Server-Side Rendering

Most controls and all HTML elements can specify the `RenderSettings.Mode` property. 

In the `Client` mode (default), the bindings are translated to the Knockout expressions and evaluated on the client.

In the `Server` mode, all value bindings in text (e.g. `<p RenderSettings.Mode="Server">{{value: Text}}</p>`), [Literal](/docs/controls/builtin/Literal/{branch})s
and [HtmlLiteral](/docs/controls/builtin/HtmlLiteral/{branch})s are rendered directly in the HTML.

Also, the [Repeater](/docs/controls/builtin/Repeater/{branch}) and [GridView](/docs/controls/builtin/GridView/{branch}) controls will render 
each row directly into the HTML output, not just render a template which is instantiated by the javascript code. The `RenderSettings.Mode` propety is inherited to the child elements.

> Even if you use Server mode for everything, the application won't be fully functional if the client has the javascript disabled. 
> The page texts and content can be displayed without javascript if the whole page renders in the server mode. But even in the server side mode, you won't be 
> able to do a postback without javascript enabled and many things won't work (e.g. the `Visible` property, validation etc.).



### PostBack.Update property

If you render some text or table directly in the HTML, sometimes you may need to regenerate and replace the HTML code during the postback.  
That's why we have the `PostBack.Update` property.

```DOTHTML
<div PostBack.Update="true">
...
</div>
```

If the `PostBack.Update` is used, the HTML code rendered by the control is sent to the client on every postback and the content is 
replaced in the page. You'll need to use this property when you use server-side rendering.
