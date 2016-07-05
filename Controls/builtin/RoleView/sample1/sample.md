### Sample 1: RoleView

The RoleView control has a `Roles` property that holds specific roles in information system separated by comma.

You can set content for users authenticated as one of the specified roles (eq. admin, customer...) in  `IsMemberTemplate` and content for users that are not authentificated as one of the specified roles in `IsNotMemberTemplate`.

In the `HideNonAuthenticatedUsers` property you can specify whether will `IsNotMemberTemplate` be rendered for non authenticated users. Default value is true.

NOTE: This is done on server side so users can`t access these templates or roles in system.