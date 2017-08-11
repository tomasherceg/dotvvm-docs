### Sample 1: Basic Usage

The `Text` property is binding value of input.

The `Mask` property expects some string input, which defines the data for the control.

The `Placeholder` property works as placeholder on input element.

The `IsTextValid` property informs if the MaskedTextBox is valid. If `Text` is empty, the value is true (empty `Text` is valid).

#### Default Definitions

If you do not use binding on property `Definitions`, like in this example, MaskedTextBox uses default `Definitions` from these definitions chars:
	'9' => \d
	'a' => [A-Za-z]
	'A' => [A-Za-z]
	'w' => [a-zA-Z0-9]

