### Sample 1: Basic Usage

The `ModalDialog control` has `HeaderText` property for setting title text of modal window.

Content of modal header and body is specified inside `HeaderTemplate` and `ContentTemplate` properties. 
For footer of modal window use `FooterTemplate` element. Only `ContentTemplate`is required.

The `ModalDialog` control can be opened with button with `data-toggle` set to *modal* and `data-target` set to ID of `ModalDialog` which you want to open.