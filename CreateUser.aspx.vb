Imports System.Data.SqlClient
Imports System.Net.Mail
Partial Class CreateUser
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("ROLEID") = 5 Then
                divcomp.Visible = True
                DdlCompany.DataSource = DAL.SelectCompany()
                DdlCompany.DataBind()
                Dim newitem As New ListItem("Please Select", "0")
                DdlCompany.Items.Add(newitem)
                DdlCompany.SelectedValue = 0
                gvUser.DataSource = DAL.SelectUsers()
                gvUser.DataBind()
                divrole.Visible = True
                ddlRole.DataSource = DAL.SelectRole()
                ddlRole.DataBind()
                ddlRole.Items.Add(newitem)
                ddlRole.SelectedValue = 0
            ElseIf Session("ROLEID") = 2 Then
                gvUser.DataSource = DAL.SelectUsersbyCompanyID(Session("COMPANYID"))
                gvUser.DataBind()
                If Session("ROLEID") = 2 Then
                    divadmin.Visible = True
                End If
            Else

                Response.Redirect("LoginPage.aspx")

            End If

           
        Else
            If IsNothing(Session("ROLEID")) = True Then
                Response.Redirect("LoginPage.aspx")
            End If
        End If

     


    End Sub
    Private Function getrole() As Integer
        Dim role As Integer = Nothing
        If Session("ROLEID") = 5 Then

            role = ddlRole.SelectedValue



        ElseIf Session("ROLEID") = 2 Then
            If CbAdmin.Checked = True Then
                role = 2
            Else
                role = 1
            End If
      
        End If
        Return role
    End Function
    Private Function RandomString(r As Random) As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New StringBuilder
        Dim cnt As Integer = r.Next(7, 11)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function


    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""

        BtnSubmit.Text = "Please wait..."
        BtnSubmit.Enabled = False



        Try
            If TxtFirstName.Text <> "" And TxtLastName.Text <> "" And TxtUserName.Text <> "" Then
                If Session("ROLEID") = 5 Then
                    If DdlCompany.SelectedValue <> 0 And ddlRole.SelectedValue <> 0 Then
                        Dim userGuid As Guid = System.Guid.NewGuid()
                        Dim r As New Random
                        Dim hashedPassword As String = getpassword(RandomString(r) + userGuid.ToString())
                        Dim msg As Integer = DAL.InsertUser(TxtFirstName.Text, TxtLastName.Text, DdlCompany.SelectedValue, TxtUserName.Text, getrole(), hashedPassword, userGuid, LblUserID.Text)
                        If msg <> 0 Then
                            gvUser.DataSource = DAL.SelectUsers()
                            gvUser.DataBind()
                            If LblUserID.Text = "0" Then

                                divsuccess.Attributes("class") = "alert alert-success"
                                divsuccess.Style.Add("display", "block")
                                errormsg.InnerHtml = "<strong>Success!</strong> New user successfully created"

                            Else
                                divsuccess.Attributes("class") = "alert alert-success"
                                divsuccess.Style.Add("display", "block")
                                errormsg.InnerHtml = "<strong>Success!</strong> User information updated."
                            End If
                            clear()
                        End If
                    Else
                        divsuccess.Attributes("class") = "alert alert-danger"
                        divsuccess.Style.Add("display", "block")
                        errormsg.InnerHtml = "<strong>Error!</strong> Please fill in all fields"
                    End If
                ElseIf Session("ROLEID") = 2 Then
                    Dim userGuid As Guid = System.Guid.NewGuid()
                    Dim r As New Random
                    Dim hashedPassword As String = getpassword(RandomString(r) + userGuid.ToString())
                    Dim msg As Integer = DAL.InsertUser(TxtFirstName.Text, TxtLastName.Text, Session("COMPANYID"), TxtUserName.Text, getrole(), hashedPassword, userGuid, LblUserID.Text)
                    If msg <> 0 Then
                        gvUser.DataSource = DAL.SelectUsersbyCompanyID(Session("COMPANYID"))
                        gvUser.DataBind()
                        If LblUserID.Text = "0" Then
                            divsuccess.Attributes("class") = "alert alert-success"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Success!</strong> New user successfully created"
                        Else
                            divsuccess.Attributes("class") = "alert alert-success"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Success!</strong> User information updated."
                        End If
                        clear()
                    End If
                End If

            Else
                divsuccess.Attributes("class") = "alert alert-danger"
                divsuccess.Style.Add("display", "block")
                errormsg.InnerHtml = "<strong>Error!</strong> Please fill in all fields"
            End If
            BtnSubmit.Text = "Submit"
            BtnSubmit.Enabled = True

        Catch ex As Exception
            BtnSubmit.Text = "Submit"
            BtnSubmit.Enabled = True
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong>Error encountered, please try again"
        End Try
        ResetDataTablesPlugin()


    End Sub
    Private Sub clear()
        If Session("ROLEID") = 5 Then
            TxtFirstName.Text = ""
            TxtLastName.Text = ""
            TxtUserName.Text = ""
            LblUserID.Text = "0"
            DdlCompany.SelectedValue = 0
            ddlRole.SelectedValue = 0
        ElseIf Session("ROLEID") = 2 Then
            TxtFirstName.Text = ""
            TxtLastName.Text = ""
            TxtUserName.Text = ""
            LblUserID.Text = "0"
            CbAdmin.Checked = False
        Else
            TxtFirstName.Text = ""
            TxtLastName.Text = ""
            TxtUserName.Text = ""
            LblUserID.Text = "0"
        End If
    End Sub
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
   
    Protected Sub gvUser_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvUser.RowCommand
        clear()
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        Try
                Dim Userid As Integer
                Dim dr As String() = Nothing
                Dim e_ As Integer = e.CommandArgument()
                Dim rowe = gvUser.Rows(e_)
                If CType(e.CommandSource, LinkButton).ID = "imgDelete" Then
                Dim label As Control = TryCast(gvUser.Rows(rowe.RowIndex).FindControl("LblID"), Label)
                    Dim lbl As Label = DirectCast(label, Label)
                    Userid = lbl.Text
                    DAL.DeleteUserByID(Userid)
                    If Session("ROLEID") = 5 Then
                        gvUser.DataSource = DAL.SelectUsers()
                        gvUser.DataBind()
                    Else
                        gvUser.DataSource = DAL.SelectUsersbyCompanyID(Session("COMPANYID"))
                        gvUser.DataBind()
                    End If

                ElseIf CType(e.CommandSource, LinkButton).ID = "btnEdit" Then
                    Dim label As Control = TryCast(gvUser.Rows(rowe.RowIndex).FindControl("LblID"), Label)
                    Dim lbl As Label = DirectCast(label, Label)
                    Userid = lbl.Text
                    dr = DAL.SelectUserbyid(Userid)
                    If dr IsNot Nothing Then
                        If Session("ROLEID") = 5 Then
                            TxtFirstName.Text = dr(2)
                            TxtLastName.Text = dr(3)
                            TxtUserName.Text = dr(1)
                            DdlCompany.SelectedValue = dr(4)
                            ddlRole.SelectedValue = dr(5)
                            LblUserID.Text = Userid
                        Else
                            TxtFirstName.Text = dr(2)
                            TxtLastName.Text = dr(3)
                            TxtUserName.Text = dr(1)
                        LblUserID.Text = Userid
                        If Session("ROLEID") = 2 Then
                            If dr(5) = "1" Then
                                CbAdmin.Checked = False
                            ElseIf dr(5) = "2" Then
                                CbAdmin.Checked = True
                            End If
                        End If
                        End If
                    End If

                End If

            Catch ex As Exception
                'tblShowError.Visible = True
                'lblShowError.Text = ex.Message
            End Try
       
        ResetDataTablesPlugin()
       

    End Sub


    'Private Sub sendemail()
    '    Try
    '        Dim Smtp_Server As New SmtpClient
    '        Dim e_mail As New MailMessage()
    '        Smtp_Server.Host = "mail.optedia.com"
    '        Smtp_Server.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
    '        Smtp_Server.Credentials = New System.Net.NetworkCredential("info@[optedia].com", "WEarenative")
    '        'Smtp_Server.UseDefaultCredentials = False
    '        'Smtp_Server.Credentials = New Net.NetworkCredential("bonuolaadewale@gmail.com", "kzymatic")
    '        'Smtp_Server.Port = 587
    '        'Smtp_Server.EnableSsl = True
    '        'Smtp_Server.Host = "smtp.gmail.com"

    '        e_mail = New MailMessage()
    '        e_mail.From = New MailAddress("info@optedia.com")
    '        e_mail.To.Add("bonuolaadewale@yahoo.com")
    '        e_mail.Subject = "Native Optedia"
    '        e_mail.IsBodyHtml = False
    '        e_mail.Body = "Good Day " & tbFirstName.Text & " " & tbLastName.Text & vbCrLf & "You have been created as a new user on the Optedia software." & vbCrLf & _
    '            "Please follow this link " & "www.optedia.com/LoginPage.aspx" & " and login with your email address, your default password is Mynewpassword1" & vbCrLf & _
    '            "You will be prompted to change this password to any preferred password immediately after your first login attempt." & vbCrLf & vbCrLf & vbCrLf & _
    '            "Thank You" & vbCrLf & _
    '            "Native Optedia Team"
    '        Smtp_Server.Send(e_mail)


    '    Catch error_t As Exception

    '    End Try

    'End Sub

    Private Sub ResetDataTablesPlugin()

        Dim builder As New StringBuilder()

        builder.Append("<script type='text/javascript'>")
        builder.Append("fnClickRedraw();")
        builder.Append("</script>")
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "fnClickRedraw", builder.ToString(), False)

    End Sub

   
End Class
