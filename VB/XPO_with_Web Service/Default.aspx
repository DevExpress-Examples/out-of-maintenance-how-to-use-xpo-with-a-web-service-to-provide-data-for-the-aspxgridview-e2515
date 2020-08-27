<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<%@ Register assembly="DevExpress.Xpo.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Xpo" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" 
		DataSourceID="xds" KeyFieldName="Oid">
		<Columns>

            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True" ShowDeleteButton="True"/>

			<dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="1">
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn FieldName="PhoneNumber" VisibleIndex="2">
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn FieldName="DefaultAddress!Key" VisibleIndex="3">
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataDateColumn FieldName="CreatedOn" ReadOnly="True" 
				VisibleIndex="4">
			</dx:GridViewDataDateColumn>
			<dx:GridViewDataTextColumn FieldName="DisplayName" VisibleIndex="5" 
				ReadOnly="True">
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="6">
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn FieldName="WebSite" VisibleIndex="7">
			</dx:GridViewDataTextColumn>
		</Columns>
	</dx:ASPxGridView>

	<dx:XpoDataSource ID="xds" runat="server" TypeName="ContactManagement.Company">
	</dx:XpoDataSource>
	<div>

	</div>
	</form>
</body>
</html>