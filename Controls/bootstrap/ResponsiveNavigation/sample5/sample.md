### Sample 5: Collapsing into button on small screens

It's possible to collapse ResponsiveNavigation into button when it cannot fit the screen. 
To do so you have to the change value of `AllowCollapsingToButton` property to *true*.

Optionally, you can set your own content of the collapsed button by putting in into `CollapsedButtonTemplate` template. 
If `CollapsedButtonTemplate` is empty or not set the standard button will be rendered.