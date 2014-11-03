<Serializable()>
Public Class Enumerations
    Enum enmUserType
        InternalAdministrator = 1
        ExternalAdministrator = 2
        InternalUser = 3
        ExternalUser = 4
        InternalReadOnly = 5
        ExternalReadOnly = 6
    End Enum
    Enum enmAuthorization
        'this is the "User Level" Enumration that is set on login for each user as the "UserPackage.UserInformation.cAuthorization"
        Administrator = 1
        InHouseUser = 2
        GeneralAgent = 3
        Producer = 4
        Insured = 5
    End Enum
    Public Enum enmServer
        Develop = 1
        Test = 2
        Live = 3
    End Enum
End Class