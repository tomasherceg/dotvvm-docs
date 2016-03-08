This control renders an unordered list with hyperlinks in list items.
The First, Previous, Next and Last link contents can be templated using the `FirstPageTemplate`, `PreviousPageTemplate`, `NextPageTemplate` and `LastPageTemplate`.

```DOTHTML
<ul>
  <li><a href="...">&raquo;&raquo;</a></li>
  <li><a href="...">&raquo;</a></li>
  
  <li><a href="...">1</a></li>
  <li><a href="...">2</a></li>
  <li>3</li>
  <li><a href="...">4</a></li>
  <li><a href="...">5</a></li>

  <li><a href="...">&laquo;</a></li>
  <li><a href="...">&laquo;&laquo;</a></li>
</ul>
```