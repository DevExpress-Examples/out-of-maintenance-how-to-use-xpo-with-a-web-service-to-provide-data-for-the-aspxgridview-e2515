Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Services

' TODO: change MyWebDataSource namespace to match the published service's namespace
<WebServiceBinding(Namespace := WebServiceAttribute.DefaultNamespace)> _
Friend Class MyWebDataStore
	Inherits DevExpress.Xpo.WebServiceDataStore
	Public Sub New(ByVal url As String)
		MyBase.New(url, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists)
	End Sub
End Class

