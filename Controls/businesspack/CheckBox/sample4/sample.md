## Real World Sample

The total price is calculated by summing of all `CheckedValues` and is updated after any change by `Changed` event.

Because the collection holds floats instead of strings, we have to use the `{value: 0.5}` binding instead of just `"0.5"` so the value is treated as a number and not as a string.