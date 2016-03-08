With no `Text` or an inner content specified, the control renders just the radio button.

```DOTHTML
<input type="radio" data-bind="..." />
```


If there is a `Text` or an inner content, the label is rendered around the radio button.

```DOTHTML
<label>
  <input type="radio" data-bind="..." />
  Text or inner content
</label>
```