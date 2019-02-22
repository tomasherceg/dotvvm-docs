## Sample 5: HTML sanitization

All HTML passed into `Tooltip` by default goes through throught Bootsraps HTML sanitizer.  
HTML sanitizer filters out all non whitelisted tags and attributes.  
[List of allowed tags and attributes.](https://getbootstrap.com/docs/4.3/getting-started/javascript/#sanitizer)  

To disable HTML sanitization you must set `AllowHtmlSanitization` to false.

>Without sanitization you could have bee volnurable to XSS attacks.