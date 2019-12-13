## Sample 8: Monitoring of parent element removal

`AutoCloseMonitoringDepth` allows to set how many the ancestors would be monitored for removal. When element removal is detected than the popover is closed.  
When `AutoCloseMonitoringDepth` is set to 1 than removal of popover source element or removal of its parent element would be detected. When set to 2 than removal of parent of this parent element would also trigger popover close.

Setting `AutoCloseMonitoringDepth` to too high number might negatively affect performance on some pages.