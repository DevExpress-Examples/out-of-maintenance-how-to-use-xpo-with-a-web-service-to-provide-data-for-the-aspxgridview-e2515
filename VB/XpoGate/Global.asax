<%@ Application Language="vb" %>

<script runat="server">

	Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		Dim conn As String = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString(Server.MapPath("~\App_Data\ContactManagement.mdb"))
		Application("provider") = DevExpress.Xpo.XpoDefault.GetConnectionProvider(conn, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists)
	End Sub

	Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
		'  Code that runs on application shutdown

	End Sub

	Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when an unhandled error occurs

	End Sub

	Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when a new session is started

	End Sub

	Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when a session ends. 
		' Note: The Session_End event is raised only when the sessionstate mode
		' is set to InProc in the Web.config file. If session mode is set to StateServer 
		' or SQLServer, the event is not raised.

	End Sub

</script>