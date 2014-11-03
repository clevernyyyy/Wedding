<Serializable()> _
Public Class Connection
    Public Property cnnStr As String
    Public ReadOnly Property cnnSQL As System.Data.SqlClient.SqlConnection
        Get
            Return New SqlClient.SqlConnection(Me.cnnStr)
        End Get
    End Property


    Public Sub New()
        'Dim oNC As New NICOCipher.NICOCrypt
        'Dim cnnstr As String

        Me.cnnStr = System.Configuration.ConfigurationManager.AppSettings.Get("clev")

        'Me.cnnStr = oNC.NICO_RijndaelManaged_Decrypt(ConfigurationManager.AppSettings.Item("FNOLSQLCnn"))
    End Sub

End Class
