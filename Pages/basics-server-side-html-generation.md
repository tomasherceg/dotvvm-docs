## Server-Side HTML Generation and SEO

**DotVVM** uses javascript libraries to do the job, but don't worry. It won't make your site SEO-unfriendly.
You only have to be little careful and use server rendering.

### PostBack.Update property
Do you know `<asp:UpdatePanel>` control is ASP.NET WebForms? It allowed to replace part of the page with another content on postback. 
We have something similar in DotVVM. It is not a control, it is a property you can apply to almost any element!

```DOTHTML
<div PostBack.Update="true">
...
</div>
```

When **PostBack.Update** is specified, the HTML code rendered by the control is sent to the client on postback and the content is 
replaced in the page. You'll need to use this property when you use server-side rendering.


### Server-Side Rendering
Most controls allow to use the **RenderSettings.Mode** property. There are two possible values of the property - **Client** (default) and **Server**.

In the **Client** mode, the bindings are translated to the Knockout expressions and all the magic is done on the client.

In the **Server** mode all bindings which render the texts or attribute values, are evaluated on the server and written directly in the HTML.
Also, the **Repeater** or **GridView** controls will render each row directly into the HTML output.
If you want anything to be read by search engines and crawlers (e.g. you write an e-shop, blog or magazine), just enable the server rendering.


_Please note that even if you use Server mode for everything, the application won't be fully functional then the client has the javascript disabled. 
The page content can be displayed without javascript if the whole page renders in the server mode. But even in the server side mode, you won't be 
able to do a postback without javascript enabled._

