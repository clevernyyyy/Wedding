﻿Public Class SiteMaster
    Inherits MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With { _
                 .HttpOnly = True, _
                 .Value = _antiXsrfTokenValue _
            }
            If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                responseCookie.Secure = True
            End If
            Response.Cookies.[Set](responseCookie)
        End If

        'Master Redirect to Login, Must have all login information
        Dim Userpkg As UserPackage = GetUserPackage()
        If 0 Then
            If Debugger.IsAttached OrElse HttpContext.Current.Session("lHomeRun") = True Then
                'Continue Redirect to Default Page
            ElseIf String.IsNullOrWhiteSpace(Userpkg.UserInformation.cAuthorization) OrElse _
                String.IsNullOrWhiteSpace(Userpkg.UserInformation.cUserName) OrElse _
                String.IsNullOrWhiteSpace(Userpkg.UserInformation.iUserIdentifier) OrElse _
                IsNothing(Userpkg.UserInformation.nUserID) OrElse _
                Not Debugger.IsAttached Then
                Response.Redirect("/Forms/Standard/UnderConstruction.aspx")
                'Response.Redirect("/Account/Login.aspx")
            Else
                Response.Redirect("/Forms/Standard/UnderConstruction.aspx")
            End If
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
        Else
            ' Validate the Anti-XSRF token
            If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Url.AbsoluteUri.Contains("Default") Then
            mnuLeft.Visible = True
            mnuVendors.Visible = False
            mnuRight.Visible = True
        ElseIf Request.Url.AbsoluteUri.Contains("Vendors") Then
            mnuLeft.Visible = False
            mnuVendors.Visible = True
            mnuRight.Visible = True
        Else
            mnuLeft.Visible = False
            mnuVendors.Visible = False
            mnuRight.Visible = False
        End If

    End Sub

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Context.GetOwinContext().Authentication.SignOut()
    End Sub

End Class