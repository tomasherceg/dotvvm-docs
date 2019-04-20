## Sample 7: HTML sanitization

All HTML passed into `Popover` by default goes through Bootstrap HTML sanitizer. It filters out all non-whitelisted tags and attributes.  

[List of allowed tags and attributes](https://getbootstrap.com/docs/4.3/getting-started/javascript/#sanitizer)  

To disable HTML sanitization, set `AllowHtmlSanitization` to `false`.

> Make sure the template is safe and cannot enable anyone to make a XSS attack.