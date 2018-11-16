
Partial Class CreateCompany
    Inherits System.Web.UI.Page

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("ROLEID") = 5 Then
                ddlRole.DataSource = DAL.SelectCompanyRole()
                ddlRole.DataBind()
                gvexisting.DataSource = DAL.SelectCompany()
                gvexisting.DataBind()
                Dim newlistitem As New ListItem("Please Select", "0")
                ddlRole.Items.Add(newlistitem)
                ddlRole.SelectedValue = 0
                BtnPublishers.Style.Add("display", "none")
                BtnAll.Style.Add("display", "none")
                BtnClients.Style.Add("display", "none")
            ElseIf Session("ROLEID") = 2 Then
                gvexisting.DataSource = DAL.SelectAllNonAgencies(Session("COMPANYID"))
                gvexisting.DataBind()
                ddlRole.DataSource = DAL.SelectCompanyRoleAsAgency()
                ddlRole.DataBind()
                Dim newlistitem As New ListItem("Please Select", "0")
                ddlRole.Items.Add(newlistitem)
                ddlRole.SelectedValue = 0
            End If
        Else
            If IsNothing(Session("ROLEID")) = True Then
                Response.Redirect("LoginPage.aspx")
            End If
        End If
    End Sub

    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Try
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "none")
            errormsg.InnerHtml = ""

            BtnSubmit.Text = "Please wait..."
            BtnSubmit.Enabled = False

            If TxtName.Text <> "" And ddlRole.SelectedValue <> 0 Then
                If Session("ROLEID") = 5 Then
                    Dim msg As String = DAL.InsertCompany(LblCompanyID.Text, TxtName.Text, ddlRole.SelectedValue)
                    If msg <> 0 Then
                        gvexisting.DataSource = DAL.SelectCompany()
                        gvexisting.DataBind()
                        divsuccess.Attributes("class") = "alert alert-success"
                        divsuccess.Style.Add("display", "block")
                        If LblCompanyID.Text = "0" Then
                            errormsg.InnerHtml = "<strong>Success!</strong> Company was successfully added."
                        Else
                            errormsg.InnerHtml = "<strong>Success!</strong> Company was successfully updated."
                        End If
                        clear()
                    Else
                        divsuccess.Attributes("class") = "alert alert-danger"
                        divsuccess.Style.Add("display", "block")
                        errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
                        clear()
                    End If
                ElseIf Session("ROLEID") = 2 Then
                    If ddlRole.SelectedValue = 3 Then
                        Dim msg As String = DAL.InsertClient(LblCompanyID.Text, TxtName.Text, ddlRole.SelectedValue, Session("COMPANYID"))
                        If msg <> 0 Then
                            gvexisting.DataSource = DAL.SelectAllNonAgencies(Session("COMPANYID"))
                            gvexisting.DataBind()
                            divsuccess.Attributes("class") = "alert alert-success"
                            divsuccess.Style.Add("display", "block")
                            If LblCompanyID.Text = "0" Then
                                errormsg.InnerHtml = "<strong>Success!</strong> Client was successfully added."
                            Else
                                errormsg.InnerHtml = "<strong>Success!</strong> Client was successfully edited."
                            End If
                            clear()
                        Else
                            clear()
                            divsuccess.Attributes("class") = "alert alert-danger"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
                        End If
                    Else
                        If TxtUrl.Text <> "" Then
                            Dim msg As String = DAL.InsertPublisher(LblCompanyID.Text, TxtName.Text, Session("COMPANYID"), ddlurltype.SelectedValue + TxtUrl.Text)
                            If msg <> 0 Then
                                gvexisting.DataSource = DAL.SelectAllNonAgencies(Session("COMPANYID"))
                                gvexisting.DataBind()
                                divsuccess.Attributes("class") = "alert alert-success"
                                divsuccess.Style.Add("display", "block")
                                If LblCompanyID.Text = "0" Then
                                    errormsg.InnerHtml = "<strong>Success!</strong> Publisher was successfully added."
                                Else
                                    errormsg.InnerHtml = "<strong>Success!</strong> Publisher was successfully edited."
                                End If
                                clear()
                            Else
                                clear()
                                divsuccess.Attributes("class") = "alert alert-danger"
                                divsuccess.Style.Add("display", "block")
                                errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
                            End If
                        Else
                            divsuccess.Attributes("class") = "alert alert-danger"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Error!</strong> Please fill all fields."
                        End If
                       
                    End If

                End If

            Else

                divsuccess.Attributes("class") = "alert alert-danger"
                divsuccess.Style.Add("display", "block")
                errormsg.InnerHtml = "<strong>Error!</strong> Please fill all fields."

            End If
            BtnSubmit.Text = "Submit"
            BtnSubmit.Enabled = True

        Catch ex As Exception

            BtnSubmit.Text = "Submit"
            BtnSubmit.Enabled = True
            clear()
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."

        End Try
        ResetDataTablesPlugin()
    End Sub
    Private Sub clear()
        TxtName.Text = ""
        TxtUrl.Text = ""
        ddlurltype.SelectedValue = "http://"
        ddlRole.SelectedValue = 0
        LblCompanyID.Text = "0"
        LblUserID2.Text = "0"
        TxtFirstName.Text = ""
        TxtLastName.Text = ""
        TxtUserName.Text = ""
        ddlRole.Enabled = True
        BtnPublishers.CssClass = "btn btn-sm btn-default"
        BtnAll.CssClass = "btn btn-sm btn-default active"
        BtnClients.CssClass = "btn btn-sm btn-default"

    End Sub

    Protected Sub BtnSubmitUser_Click(sender As Object, e As EventArgs) Handles BtnSubmitUser.Click
        divsuccessUser.Attributes("class") = "alert alert-danger"
        divsuccessUser.Style.Add("display", "none")
        errmsguser.InnerHtml = ""
        Try
            If TxtFirstName.Text <> "" And TxtLastName.Text <> "" And TxtUserName.Text <> "" And LblCompanyID2.Text <> "0" And LblRoleID.Text <> "0" Then
                If Session("ROLEID") = 2 Then
                    Dim userGuid As Guid = System.Guid.NewGuid()
                    Dim r As New Random
                    Dim hashedPassword As String = getpassword(RandomString(r) + userGuid.ToString())
                    Dim msg As Integer = DAL.InsertUser(TxtFirstName.Text, TxtLastName.Text, LblCompanyID2.Text, TxtUserName.Text, LblRoleID.Text, hashedPassword, userGuid, LblUserID2.Text)
                    If msg <> 0 Then
                        gvUser.DataSource = DAL.SelectUsersbyCompanyID(LblCompanyID2.Text)
                        gvUser.DataBind()
                        If LblUserID2.Text = "0" Then
                            divsuccessUser.Attributes("class") = "alert alert-success"
                            divsuccessUser.Style.Add("display", "block")
                            errmsguser.InnerHtml = "<strong>Success!</strong> New user successfully created"
                            mpuser.Show()
                        Else
                            divsuccessUser.Attributes("class") = "alert alert-success"
                            divsuccessUser.Style.Add("display", "block")
                            errmsguser.InnerHtml = "<strong>Success!</strong> User information updated."
                            mpuser.Show()
                        End If
                        clear()
                    End If
                End If
            Else
                divsuccessUser.Attributes("class") = "alert alert-danger"
                divsuccessUser.Style.Add("display", "block")
                errmsguser.InnerHtml = "<strong>Error!</strong> Please fill in all fields"
                mpuser.Show()
            End If
        Catch ex As Exception
            divsuccessUser.Attributes("class") = "alert alert-danger"
            divsuccessUser.Style.Add("display", "block")
            errmsguser.InnerHtml = "<strong>Error!</strong>Error encountered, please try again"
            mpuser.Show()
        End Try
    End Sub
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
        divsuccessUser.Attributes("class") = "alert alert-danger"
        divsuccessUser.Style.Add("display", "none")
        errmsguser.InnerHtml = ""
        Try
            Dim Userid As Integer
            Dim dr As String() = Nothing
            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvUser.Rows(e_)
            If CType(e.CommandSource, LinkButton).ID = "imgDeleteUser" Then
                Dim label As Control = TryCast(gvUser.Rows(rowe.RowIndex).FindControl("LblUserID"), Label)
                Dim lbl As Label = DirectCast(label, Label)
                Userid = lbl.Text
                DAL.DeleteUserByID(Userid)
                If Session("ROLEID") = 2 Then
                    gvUser.DataSource = DAL.SelectUsersbyCompanyID(LblCompanyID2.Text)
                    gvUser.DataBind()
                    mpuser.Show()
                End If

            ElseIf CType(e.CommandSource, LinkButton).ID = "btnEditUser" Then
                Dim label As Control = TryCast(gvUser.Rows(rowe.RowIndex).FindControl("LblUserID"), Label)
                Dim lbl As Label = DirectCast(label, Label)
                Userid = lbl.Text
                dr = DAL.SelectUserbyid(Userid)
                If dr IsNot Nothing Then
                    If Session("ROLEID") = 2 Then
                        TxtFirstName.Text = dr(2)
                        TxtLastName.Text = dr(3)
                        TxtUserName.Text = dr(1)
                        LblCompanyID2.Text = dr(4)
                        LblRoleID.Text = dr(5)
                        LblUserID2.Text = Userid
                        mpuser.Show()
                    End If
                End If

            End If

        Catch ex As Exception
            'tblShowError.Visible = True
            'lblShowError.Text = ex.Message
        End Try
    End Sub
    Protected Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        gvexisting.DataSource = DAL.SelectAllNonAgencies(Session("COMPANYID"))
        gvexisting.DataBind()
        BtnPublishers.CssClass = "btn btn-sm btn-default"
        BtnAll.CssClass = "btn btn-sm btn-default active"
        BtnClients.CssClass = "btn btn-sm btn-default"
    End Sub
    Protected Sub BtnClients_Click(sender As Object, e As EventArgs) Handles BtnClients.Click
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        gvexisting.DataSource = DAL.SelectAgencyorPublisher(3, Session("COMPANYID"))
        gvexisting.DataBind()
        BtnPublishers.CssClass = "btn btn-sm btn-default"
        BtnAll.CssClass = "btn btn-sm btn-default"
        BtnClients.CssClass = "btn btn-sm btn-default active"
    End Sub
    Protected Sub BtnPublishers_Click(sender As Object, e As EventArgs) Handles BtnPublishers.Click
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        gvexisting.DataSource = DAL.SelectAgencyorPublisher(4, Session("COMPANYID"))
        gvexisting.DataBind()
        BtnPublishers.CssClass = "btn btn-sm btn-default active"
        BtnAll.CssClass = "btn btn-sm btn-default"
        BtnClients.CssClass = "btn btn-sm btn-default"
    End Sub
    Protected Sub gvexisting_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvexisting.RowCommand
        Try
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "none")
            errormsg.InnerHtml = ""
            Dim Compid As Integer
            Dim dr As String() = Nothing
            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvexisting.Rows(e_)
            If CType(e.CommandSource, LinkButton).ID = "btnEdit" Then
                Dim label As Control = TryCast(gvexisting.Rows(rowe.RowIndex).FindControl("LblExistingID"), Label)
                Dim lbl As Label = DirectCast(label, Label)
                Compid = lbl.Text
                If rowe.Cells(3).Text = "Client" Then
                    Dim msg As String() = DAL.SelectPublishersandClientsbyID(3, Compid)
                    If msg IsNot Nothing Then
                        TxtName.Text = msg(1)
                        LblCompanyID.Text = msg(0)
                        ddlRole.SelectedValue = 3
                        ddlRole.Enabled = False
                        divurl.Visible = False


                    End If
                Else
                    Dim msg As String() = DAL.SelectPublishersandClientsbyID(4, Compid)
                    If msg IsNot Nothing Then
                        TxtName.Text = msg(1)
                        LblCompanyID.Text = msg(0)
                        ddlRole.SelectedValue = 4
                        ddlRole.Enabled = False
                        divurl.Visible = True
                        Dim url As String() = msg(3).ToString.Split("/")
                        If url(0) = "http:" Then
                            ddlurltype.SelectedValue = "http://"
                        Else
                            ddlurltype.SelectedValue = "https://"
                        End If
                        TxtUrl.Text = url(2)
                    End If
                End If


            ElseIf CType(e.CommandSource, LinkButton).ID = "imgCreateUser" Then
                Dim label As Control = TryCast(gvexisting.Rows(rowe.RowIndex).FindControl("LblExistingID"), Label)
                Dim lbl As Label = DirectCast(label, Label)
                Compid = lbl.Text
                clear()
                LblCompanyID2.Text = Compid
                LblRoleID.Text = "3"
                mpuser.Show()
                divsuccessUser.Attributes("class") = "alert alert-danger"
                divsuccessUser.Style.Add("display", "none")
                errmsguser.InnerHtml = ""
                userheader.InnerText = "Create User for " + rowe.Cells(2).Text
                gvUser.DataSource = DAL.SelectUsersbyCompanyID(Compid)
                gvUser.DataBind()
            ElseIf CType(e.CommandSource, LinkButton).ID = "imgDelete" Then
                Dim label As Control = TryCast(gvexisting.Rows(rowe.RowIndex).FindControl("LblExistingID"), Label)
                Dim lbl As Label = DirectCast(label, Label)
                Compid = lbl.Text
                If rowe.Cells(3).Text = "Client" Then
                    DAL.DeleteClient(Compid)

                Else
                    DAL.DeletePublisher(Compid)
                End If
                If Session("ROLEID") = 2 Then
                    gvexisting.DataSource = DAL.SelectAllNonAgencies(Session("COMPANYID"))
                    gvexisting.DataBind()
                End If
            End If

        Catch ex As Exception
            gvexisting.DataSource = DAL.SelectAllNonAgencies(Session("COMPANYID"))
            gvexisting.DataBind()
            BtnPublishers.CssClass = "btn btn-sm btn-default"
            BtnAll.CssClass = "btn btn-sm btn-default active"
            BtnClients.CssClass = "btn btn-sm btn-default"
        End Try
        ResetDataTablesPlugin()



    End Sub
    Protected Sub gvexisting_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvexisting.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If e.Row.Cells(3).Text = "Publisher" Then
                    e.Row.Cells(7).FindControl("imgCreateUser").Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        If TxtSearch.Text <> "" Then
            gvexisting.DataSource = DAL.SelectSearchCompany(Session("COMPANYID"), TxtSearch.Text)
            gvexisting.DataBind()
            BtnPublishers.CssClass = "btn btn-sm btn-default"
            BtnAll.CssClass = "btn btn-sm btn-default active"
            BtnClients.CssClass = "btn btn-sm btn-default"
        End If
    End Sub

    Protected Sub ddlRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRole.SelectedIndexChanged
        If ddlRole.SelectedValue <> 0 Then
            If ddlRole.SelectedValue = 4 Then
                divurl.Visible = True
            Else
                divurl.Visible = False
            End If
        Else
            divurl.Visible = False
        End If
    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs)
        mpuser.Hide()


    End Sub

    'Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
    '    gvexisting.PageIndex = e.NewPageIndex
    '    gvexisting.DataBind()


    'End Sub
    Private Sub ResetDataTablesPlugin()

        Dim builder As New StringBuilder()

        builder.Append("<script type='text/javascript'>")
        builder.Append("fnClickRedraw();")
        builder.Append("</script>")
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "fnClickRedraw", builder.ToString(), False)

    End Sub
End Class
