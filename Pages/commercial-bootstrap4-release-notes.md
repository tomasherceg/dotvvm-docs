# Release notes

## 2.1.0
### First stable ( non-preview ) release.

* **Package updates**
    * Dotvvm upgraded to **2.1.0**
    * Bootstrap upgraded to **4.3.1**

* **New controls**
    * [```Spinner```](https://www.dotvvm.com/docs/controls/bootstrap4/Spinner)
    * [```Toast```](https://www.dotvvm.com/docs/controls/bootstrap4/Toast)

* **Changes to existing controls**
    * **Carousel**
        * Added *ImageAlternateTextBinding* property
    * **CheckBox**
        * **BREAKING CHANGE** : enum *BootstrapFormStyle* used in *FormControlStyle* property renamed to *CheckBoxStyle*
    * **CheckBoxFormGroup**
        * **BREAKING CHANGE** : enum *BootstrapFormStyle* used in *FormControlStyle* property renamed to *CheckBoxStyle*
    * **GridView**
        * Added *Border* property
        * Added *Caption* property
        * **BREAKING CHANGE** : Boolean *IsResponsive* property was replaced by *MaximumScreenSizeBeforeScrollBarShows* enum
    * **ListGroup**
        * Added *Type* property
        * Added *MaximumScreenSizeBeforeChangeToVertical* property
    * **ModalDialog**
        * Added *ScrollableContent* property
        * Added new XL *Size*
    * **Popover**
        * Added *AllowHtmlSanitization* property
    * **ResponsiveNavigation**
        * **BREAKING CHANGE** : enum *ResponsiveNavigationBreakpoins* used in *MaximumScreenSizeBeforeCollapse* property was renamed to *ResponsiveBreakpoints*
    * **Tooltip**
        * Added *AllowHtmlSanitization* propery
        
## 2.0.0-preview02-final
* **New controls**
  * [```CollapsiblePanel```](https://www.dotvvm.com/docs/controls/bootstrap4/CollapsiblePanel)
  * [```ComboBoxFormGroup```](https://www.dotvvm.com/docs/controls/bootstrap4/ComboBoxFormGroup)
  * [```DateTimePickerFormGroup```](https://www.dotvvm.com/docs/controls/bootstrap4/DateTimePickerFormGroup)
  * [```RadioButtonFormGroup```](https://www.dotvvm.com/docs/controls/bootstrap4/RadioButtonFormGroup)
  * [```TextBoxFormGroup```](https://www.dotvvm.com/docs/controls/bootstrap4/TextBoxFormGroup)

* **Changes to existing controls**
    * Every items control (```Accordion```, ```NavigationBar```, etc.) now accepts any child control which implements given interface instead of one concrete implementation (```IAccordionItem``` instead of ```AccordionItem```).

## 2.0.0-preview01-final
* First release of Bootstrap 4 controls