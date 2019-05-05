The `MaskedTextBox` control allows to force the entered value to exactly match the specified `Mask`. 

The mask is composed from patterns and hard-coded characters. All patterns are verified against regular expressions on client-side and server-side.

You are free to use the default patterns, specify your own `Patterns`, or use `AdditionalPatterns` to mix your own patters with the default. The default patterns are:

* `0` - Digit. Accepts any digit between 0 and 9.
* `9` - Digit or space. Accepts any digit between 0 and 9 or space.
* `#` - Digit, space, plus or minus. Accepts any digit between 0 and 9, space, and allows also the + (plus) and - (minus) signs.
* `L` - Letter. Restricts the input to a-z and A-Z letters. This rule is equivalent to [a-zA-Z] in regular expressions. 
* `?` - Letter or space. Restricts the input to letters a-z and A-Z and spaces. This rule is equivalent to [a-zA-Z\s] in regular expressions.
* `&` - Character. Accepts any character except a space. The rule is equivalent to \S in regular expressions.
* `C` - Character or space. Accepts any character. The rule is equivalent to `.` in regular expressions.
* `A` - Alphanumeric. Accepts letters and digits only.
* `a` - Alphanumeric or space. Accepts only letters, digits, and spaces.