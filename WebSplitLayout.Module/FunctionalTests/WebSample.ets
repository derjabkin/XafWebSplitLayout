;#DropDB WebSplitLayoutEasyTest

#Application WebSplitLayout.Web

*Action Navigation(User)

*ProcessRecord
 User Name = [DomainUserName]

*Action Edit 
 
*FillForm
 User Name = Test User
 
*Action Cancel

*CheckFieldValues
 User Name = [DomainUserName]

