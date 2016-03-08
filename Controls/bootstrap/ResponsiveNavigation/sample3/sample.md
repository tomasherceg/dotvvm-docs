### Sample 3: Fixed ResponsiveNavigation and alignation of Items

The ResponsiveNavigation has `FixedTo` property that controls if ResponsiveNavigation would be fixed to *Top* or *Bottom* of the screen (or fixed to *Nothing*).

Items Inside ResponsiveNavigation can be aligned to left or right by putting items into `LeftAlignedItemsTemplate` or `RightAlignedItemsTemplate`.   
When you are using other items than `<bs:NavigationItem>` (DropDownButton,...) you **HAVE TO** put them in `LeftAlignedItemsTemplate` or `RightAlignedItemsTemplate`.    

When using only  `<bs:NavigationItem>` that you want Left aligned you don't have to place them into those templates, those items will be aligned to the left automatically when placed outside those templates.