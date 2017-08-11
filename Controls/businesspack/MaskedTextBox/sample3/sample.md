### Sample 3: Replace Definitions

The `Definitions` property expects `Dictionary<char, MaskDefinitionItem>`, where the key is definition char and `MaskDefinitionItem` contains property `JavaScriptRegEx` and `CSharpRegEx`.

Sometimes you do not want default definitions, becasue you do not need these chars as hardcoded chars. If you have `Definitions` binding, it will replace default definitions and you are free to use only your own definitions.
In this case `Definitions` contains only these definition chars ('c' => \w,'n' => \d).

