#Region "Packages"
<Serializable()> _
Public Class Package
    Public WhereNow As New WhereNow
End Class
#End Region

#Region "User Package"
<Serializable()> _
Public Class UserPackage
    Public UserInformation As New UserInformation

End Class

#Region "UserInformation"
<Serializable()> _
Public Class UserInformation
    Public cAuthorization As String
    Public nUserID As Integer
    Public iUserIdentifier As String
    Public cUserName As String

End Class
#End Region

#End Region

#Region "WhereNow"
<Serializable()> _
Public Class WhereNow
    Public Property nID As Integer
    Public Property cContent As String
    Public Property dInception As Date
    Public Property dExpiration As Date
    Public Property cLocation As String
    Public Property cImage As String
    Public Property nDay As Integer
End Class

#End Region