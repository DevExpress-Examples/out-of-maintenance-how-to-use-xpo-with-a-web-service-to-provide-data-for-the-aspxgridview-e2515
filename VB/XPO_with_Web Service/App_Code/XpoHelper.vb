Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata


Public NotInheritable Class XpoHelper


	Private Sub New()
	End Sub
	Public Shared Function GetNewSession() As Session
		Return New Session(DataLayer)
	End Function

	Public Shared Function GetNewUnitOfWork() As UnitOfWork
		Return New UnitOfWork(DataLayer)

	End Function

	Private ReadOnly Shared lockObject As Object = New Object()

	Private Shared fDataLayer As IDataLayer
	Private Shared ReadOnly Property DataLayer() As IDataLayer
		Get
			If fDataLayer Is Nothing Then
				SyncLock lockObject
					fDataLayer = GetDataLayer()
				End SyncLock
			End If
			Return fDataLayer
		End Get
	End Property

	Private Shared Function GetDataLayer() As IDataLayer
		XpoDefault.Session = Nothing

		Dim ds As New InMemoryDataStore()
		Dim dict As XPDictionary = New ReflectionDictionary()
		dict.GetDataStoreSchema(GetType(ContactManagement.Company).Assembly)

		Dim serviceUrl As String = "http://localhost:51455/XpoGate/MyXpoService.asmx"
		Return New ThreadSafeDataLayer(dict, New MyWebDataStore(serviceUrl))
	End Function

End Class
