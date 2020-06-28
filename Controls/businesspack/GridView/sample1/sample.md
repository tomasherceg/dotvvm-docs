## Sample 1: Basic Usage

The `DataSource` property expects `BusinessPackDataSet<T>` object which contains all necessary information about the data presented by the control.

The `Columns` collection specifies all columns in the control.

The `HeaderText` property of the column defines the text displayed in the column header.

### Column Types

The `<bp:GridViewTextColumn>` renders a text, numeric or date values in the cell. The `Value` expression specifies the property to be rendered.
The `FormatString` property specifies the format of the value (for numeric and date columns).

The `<bp:GridViewTemplateColumn>` renders a specified template in the grid cell.

