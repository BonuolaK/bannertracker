
Partial Class LoginPage
    Inherits System.Web.UI.Page
    Private Function IsUserValid() As Boolean

        Try
            Dim username As String = CType(txtUserName.Text, String)
            Dim password As String = CType(txtPassword.Text, String)

            Dim msg As String() = DAL.AuthenticateUser(username)
            If msg(1) <> username Then
                Return False
            Else
                If msg(4) = "" Then
                    Dim hashedPassword As String = getpassword(txtPassword.Text + msg(3))
                    If hashedPassword = msg(2) Then
                        Session("FIRSTLOGIN") = True
                        Dim msg1 As String() = DAL.GetLoginUserDetails(msg(0))
                        Session("USERID") = msg1(0)
                        Session("USERNAME") = msg1(1)
                        Session("FIRSTNAME") = msg1(2)
                        Session("LASTNAME") = msg1(3)
                        Session("COMPANYID") = msg1(4)
                        Session("COMPANY") = msg1(5)
                        Session("ROLEID") = msg1(6)
                        sectionFirst.Style.Add("display", "block")
                        sectionForgot.Style.Add("display", "none")
                        sectionlogin.Style.Add("display", "none")
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Dim hashedPassword As String = getpassword(txtPassword.Text + msg(3))
                    If hashedPassword = msg(2) Then
                        Dim msg1 As String() = DAL.GetLoginUserDetails(msg(0))
                        Session("USERID") = msg1(0)
                        Session("USERNAME") = msg1(1)
                        Session("FIRSTNAME") = msg1(2)
                        Session("LASTNAME") = msg1(3)
                        Session("COMPANYID") = msg1(4)
                        Session("COMPANY") = msg1(5)
                        Session("ROLEID") = msg1(6)
                        Return True
                    Else
                        Return False
                    End If
                End If






            End If

        Catch ex As Exception

            Return False
        End Try

    End Function
    'Private Function IsCompanyValid() As Boolean

    '    Try
    '        If Session("ROLEID") = 1 Then
    '            Return True
    '        Else
    '            Dim today As DateTime = DateTime.Now()
    '            Dim msg As String = DAL.AuthenticateCompany(Session("COMPANYID"))

    '            If today >= msg Then
    '                Return False
    '            Else
    '                Return True
    '            End If
    '        End If




    '    Catch ex As Exception

    '        Return False
    '    End Try

    'End Function



    Protected Sub BtnLogin_ServerClick(sender As Object, e As EventArgs) Handles BtnLogin.Click
        diverror.Style.Add("display", "none")
        errormsg.InnerHtml = ""

        Session.Clear()
        Try

            If Page.IsValid Then
                If txtPassword.Text <> "" And txtUserName.Text <> "" Then
                    If IsUserValid() = True Then
                        'If IsCompanyValid() = True Then
                        If IsNothing(Session("FIRSTLOGIN")) Then
                            If Session("ROLEID") = 1 Or Session("ROLEID") = 2 Or Session("ROLEID") = 3 Or Session("ROLEID") = 4 Or Session("ROLEID") = 5 Then
                                Dim msg As String = DAL.UpdateLastLogin(Session("USERID"))
                                Page.Response.Redirect("Dashboard.aspx", False)
                           
                            End If

                        Else

                        End If
                        'Else
                        '    diverror.Visible = True
                        '    serrUsername.Text = "Your company account has expired, please contact administrator to re-suscribe"
                        '    serrUsername.Visible = True
                        'End If

                    Else
                        diverror.Style.Add("display", "block")
                        errormsg.InnerHtml = "<strong>Error!</strong> Invalid Username or Password"


                    End If
                End If

            End If
        Catch ex As Exception
            diverror.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
            
        End Try

    End Sub

    'Protected Sub BtnUpdatePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdatePassword.Click
    '    Try
    '        Dim i As Integer
    '        If CheckPassword() = True Then
    '            i = DAL.updatePassword(txtUserName.Text, TxtNewPassword.Text)

    '            Session("FIRSTLOGIN") = Nothing
    '            Response.Redirect("Station.aspx")
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Function CheckPassword() As Boolean
    '    If TxtNewPassword.Text <> txtPassword.Text Then
    '        If TxtNewPassword.Text = TxtNewPassword2.Text Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Else
    '        Return False
    '    End If
    'End Function

    Function ValidatePassword(ByVal pwd As String,
    Optional ByVal minLength As Integer = 6,
    Optional ByVal numUpper As Integer = 1,
    Optional ByVal numNumbers As Integer = 1) As Boolean

        ' Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above"

        ' Check the length.
        If Len(pwd) < minLength Then Return False
        ' Check for minimum number of occurrences.
        If upper.Matches(pwd).Count < numUpper Then Return False
        If number.Matches(pwd).Count < numNumbers Then Return False
        Return True
    End Function
    Private Function getpassword(ByVal password As String) As String

        Dim sha1 = System.Security.Cryptography.SHA1.Create()
        Dim inputBytes = Encoding.ASCII.GetBytes(password)
        Dim hash = sha1.ComputeHash(inputBytes)

        Dim sb = New StringBuilder()
        For i = 0 To hash.Length - 1
            sb.Append(hash(i).ToString("X2"))
        Next
        Return sb.ToString()

    End Function
    Protected Sub BtnSubmitNew_Click(sender As Object, e As EventArgs) Handles BtnSubmitNew.Click

        If ValidatePassword(txtpassword2.Text) = True Then
            If Session("FIRSTLOGIN") = True Then
                Dim userGuid As Guid = System.Guid.NewGuid()
                Dim hashedPassword As String = getpassword(txtpassword2.Text + userGuid.ToString())

                Dim msg As String = DAL.UpdatePassword(hashedPassword, userGuid, Session("USERID"))
                If msg <> 0 Then
                    If Session("ROLEID") = 1 Or Session("ROLEID") = 2 Or Session("ROLEID") = 3 Or Session("ROLEID") = 4 Or Session("ROLEID") = 5 Then
                        Dim msg1 As String = DAL.UpdateLastLogin(Session("USERID"))
                        Page.Response.Redirect("Dashboard.aspx", False)

                    End If

                Else
                    divnewerr.Visible = True
                    LblNewerr.Visible = True
                    LblNewerr.InnerHtml = "<strong>Error!</strong> Please try again."
                End If

            End If


        Else
            divnewerr.Visible = True
            LblNewerr.Visible = True
            LblNewerr.InnerHtml = "<strong>Error!</strong> Password must be greater than 6 characters and should include a capital letter and one digit"
        End If
       
    End Sub

    Protected Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        divforgotErr.Visible = False
        LblForgotErr.Visible = False
        LblForgotErr.InnerHtml = ""
        If txtResetUser.Text <> "" Then
            Dim msg As String = DAL.validateUserName(txtResetUser.Text)
            If msg <> "0" Then
                If msg <> "" Then
                    'sendmail
                    Else
                    divforgotErr.Visible = True
                    LblForgotErr.Visible = True
                    LblForgotErr.InnerHtml = "<strong>Error!</strong> Invalid User"
                End If
            End If


            Else
            divforgotErr.Visible = True
            LblForgotErr.Visible = True
            LblForgotErr.InnerHtml = "<strong>Error!</strong> Make sure you fill in your email address"
            End If

            '    If TxtForgetEmail.Text <> "" Then
            '        Dim msg As String = DAL.validateUserName(TxtForgetEmail.Text)
            '        If msg <> "0" Then
            '            If msg <> "" Then
            '                Dim userGuid As Guid = System.Guid.NewGuid()
            '                Dim hashedPassword As String = getpassword("Mynewpassword1" + userGuid.ToString())
            '                Dim msg1 As String() = DAL.ForgotPassword(TxtForgetEmail.Text, hashedPassword, userGuid)
            '                If msg1 IsNot Nothing Then
            '                    Try
            '                        Dim Smtp_Server As New SmtpClient
            '                        Dim e_mail As New MailMessage()
            '                        Smtp_Server.UseDefaultCredentials = False
            '                        Smtp_Server.Credentials = New Net.NetworkCredential("bonuolaadewale@gmail.com", "kzymatickennyb")
            '                        Smtp_Server.Port = 587
            '                        Smtp_Server.EnableSsl = True
            '                        Smtp_Server.Host = "smtp.gmail.com"
            '                        e_mail = New MailMessage()
            '                        e_mail.From = New MailAddress("bonuolaadewale@gmail.com")
            '                        e_mail.To.Add("bonuolaadewale@yahoo.com")
            '                        e_mail.Subject = "Native Optedia"
            '                        e_mail.IsBodyHtml = False
            '                        e_mail.Body = "Good Day " & msg1(0) & vbCrLf & "Your password has been succesfully reset" & vbCrLf & _
            '                            "Please follow this link " & "www.optedia.com/LoginPage.aspx" & " and login with your email address, your new password is Mynewpassword1" & vbCrLf & _
            '                            "You will be prompted to change this password to any preferred password immediately after your first login attempt with this password" & vbCrLf & vbCrLf & vbCrLf & _
            '                            "Thank You" & vbCrLf & _
            '                            "Native Optedia Team"
            '                        Smtp_Server.Send(e_mail)
            '                        diverror.Visible = True
            '                        serrUsername.Visible = True
            '                        serrUsername.Text = "Please check your email address for new password and steps to access Optedia"
            '                        txtUserName.Text = TxtForgetEmail.Text
            '                        TxtForgetEmail.Text = ""
            '                    Catch error_t As Exception

            '                    End Try
            '                End If
            '            Else
            '                diverror.Visible = True
            '                serrUsername.Visible = True
            '                serrUsername.Text = "Please check if your email address is correct"
            '            End If
            '        End If

            '    Else

            '        diverror.Visible = True
            '        serrUsername.Visible = True
            '        serrUsername.Text = "Make sure you fill in your email address"
            '    End If
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Clear()
            'ddlquestion.DataSource = DAL.selectQuestions()
            'ddlquestion.DataBind()
            'Dim newItem As New ListItem("Select chosen question", "0")
            'ddlquestion.Items.Add(newItem)
            'ddlquestion.SelectedValue = 0

            'ddlQuestion2.DataSource = DAL.selectQuestions()
            'ddlQuestion2.DataBind()
            'Dim newItem1 As New ListItem("Select preferred question", "0")
            'ddlQuestion2.Items.Add(newItem1)
            'ddlQuestion2.SelectedValue = 0
        End If
    End Sub
End Class
