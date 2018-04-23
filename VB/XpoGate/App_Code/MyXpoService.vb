Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB


''' <summary>
''' Summary description for MyXpoService
''' </summary>
<WebService(Namespace := WebServiceAttribute.DefaultNamespace), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class MyXpoService
	Inherits System.Web.Services.WebService
	Public Sub New()
	End Sub
	<WebMethod> _
	Public Function ModifyData(ParamArray ByVal dmlStatements() As ModificationStatement) As ModificationResult
		Dim provider As IDataStore = CType(Application("provider"), IDataStore)
		Return provider.ModifyData(dmlStatements)
	End Function
	<WebMethod> _
	Public Function SelectData(ParamArray ByVal selects() As SelectStatement) As SelectedData
		Dim provider As IDataStore = CType(Application("provider"), IDataStore)
		Return provider.SelectData(selects)
	End Function
	<WebMethod> _
	Public Function UpdateSchema(ByVal dontCreateIfFirstTableNotExist As Boolean, ParamArray ByVal tables() As DBTable) As UpdateSchemaResult
		' do nothing (do not allow DB schema updates via a public Web service)
		Return UpdateSchemaResult.SchemaExists
	End Function
	<WebMethod> _
	Public Function GetAutoCreateOption() As AutoCreateOption
		Return AutoCreateOption.SchemaAlreadyExists
	End Function
End Class
