Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Xpo

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private session As Session = XpoHelper.GetNewSession()


	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		xds.Session = session
	End Sub

End Class
