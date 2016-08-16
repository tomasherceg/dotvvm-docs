## Comments

You can have client-side or server-side comments in your `.dothtml` files

 Client-side comment - will appear in generated html files

```DOTHTML
 <!-- client comment -->
```

 Server-side comment - won't appear in generated html files

```DOTHTML
<%-- server comment --%>
```

 You can also put server-side comments between attributes

```DOTHTML
<dot:GridView DataSource="{value: Source}" <%-- server comment in attributes--%> class="table">
    <Columns>
        <dot:GridViewTemplateColumn HeaderText="" CssClass="center button-column">
            <ContentTemplate>
                <dot:LinkButton Click="{command:  _root.Click}" <%-- server comment in attributes--%> class="button">
                </dot:LinkButton>
            </ContentTemplate>
        </dot:GridViewTemplateColumn>
    </Columns>
</dot:GridView>
```
