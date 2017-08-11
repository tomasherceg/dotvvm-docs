### Sample 2: AdditionalDefinitions

The `AdditionalDefinitions` property expects `Dictionary<char, MaskDefinitionItem>`, where the key is definition char and `MaskDefinitionItem` contains property JavaScriptRegEx and CSharpRegex.

`AdditionalDefinitions` add definitions ('1' => [0-1],'2' => \d) to `Definitions`. In this case `Definitions` contain default definitions plus `AdditionalDefinitions`.

