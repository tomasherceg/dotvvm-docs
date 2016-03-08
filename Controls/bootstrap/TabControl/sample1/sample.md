### Sample 1: Basic TabControl

Each tab is represented by `<bs:TabItem>`.

TabItem have `HeaderTemplate` and `ContentTemplate`.  
The `HeaderTemplate` contains content of the header and the `ContentTemplate` contains content of the tab.

The `IsActive` property controls whether the tab will be defaultly selected.   
When no tab has `IsActive` property set to true, than the first tab will be set as active.