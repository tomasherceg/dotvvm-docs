With no `Text` or an inner content specified, the control renders just the checkbox.

```DOTHTML
<input type="checkbox" data-bind="..." />
```


If there is a `Text` or an inner content, the label is rendered around the checkbox.

```DOTHTML
<label>
  <input type="checkbox" data-bind="..." />
  Text or inner content
</label>
```