
Partial Class Brand
    Inherits System.Web.UI.Page

    Protected Sub gvBrand_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gvBrand.DataSource = DAL.SelectBrand(Session("COMPANYID"))
            gvBrand.DataBind()
            ddlClient.DataSource = DAL.SelectClient(Session("COMPANYID"))
            ddlClient.DataBind()
            Dim newItem As New ListItem("Please Select", "0")
            ddlClient.Items.Add(newItem)
            ddlClient.SelectedValue = 0
        End If
       
    End Sub
    Protected Sub gvBrand_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvBrand.RowCommand

        clear()
        Try
            Dim Userid As Integer
            Dim dr As String() = Nothing
            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvBrand.Rows(e_)
            If CType(e.CommandSource, LinkButton).ID = "imgDelete" Then
                Dim label As Control = TryCast(gvBrand.Rows(rowe.RowIndex).FindControl("LblID"), Label)
                Dim lbl As Label = DirectCast(label, Label)

                Userid = lbl.Text
                DAL.DeleteBrand(Userid)
                gvBrand.DataSource = DAL.SelectBrand(Session("COMPANYID"))
                gvBrand.DataBind()
            ElseIf CType(e.CommandSource, LinkButton).ID = "btnEdit" Then
                Dim label As Control = TryCast(gvBrand.Rows(rowe.RowIndex).FindControl("LblID"), Label)
                Dim lbl As Label = DirectCast(label, Label)

                Userid = lbl.Text
                dr = DAL.SelectBrandbyID(Userid)
                If dr IsNot Nothing Then
                    TxtName.Text = dr(1)
                    ddlClient.SelectedValue = dr(2)
                    LblBrandID.Text = Userid
                End If

            End If

        Catch ex As Exception

        End Try
        ResetDataTablesPlugin()
    End Sub
    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Try
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "none")
            errormsg.InnerHtml = ""
            BtnSubmit.Text = "Please wait..."
            BtnSubmit.Enabled = False

            If ddlClient.SelectedValue <> 0 Then


                If TxtName.Text <> "" Then

                    Dim msg As String = DAL.InsertBrand(LblBrandID.Text, TxtName.Text, ddlClient.SelectedValue, Session("COMPANYID"))
                    If msg <> 0 Then
                        gvBrand.DataSource = DAL.SelectBrand(Session("COMPANYID"))
                        gvBrand.DataBind()
                        divsuccess.Attributes("class") = "alert alert-success"
                        divsuccess.Style.Add("display", "block")
                        If LblBrandID.Text = "0" Then
                            errormsg.InnerHtml = "<strong>Success!</strong> Brand was successfully added."
                        Else
                            errormsg.InnerHtml = "<strong>Success!</strong> Brand was successfully updated."
                        End If

                        TxtName.Text = ""
                        LblBrandID.Text = "0"
                        ddlClient.SelectedValue = 0

                    Else
                        divsuccess.Attributes("class") = "alert alert-danger"
                        divsuccess.Style.Add("display", "block")
                        errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
                        LblBrandID.Text = "0"
                        ddlClient.SelectedValue = 0
                        TxtName.Text = ""
                    End If
                Else
                    divsuccess.Attributes("class") = "alert alert-danger"
                    divsuccess.Style.Add("display", "block")
                    errormsg.InnerHtml = "<strong>Error!</strong> Please fill in a brand name."
                    LblBrandID.Text = "0"
                End If
            Else
                divsuccess.Attributes("class") = "alert alert-danger"
                divsuccess.Style.Add("display", "block")
                errormsg.InnerHtml = "<strong>Error!</strong> Please select a client."
                LblBrandID.Text = "0"
            End If

            BtnSubmit.Text = "Submit"
            BtnSubmit.Enabled = True

        Catch ex As Exception

            BtnSubmit.Text = "Submit"
            BtnSubmit.Enabled = True
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
            LblBrandID.Text = "0"
            TxtName.Text = ""
        End Try
        ResetDataTablesPlugin()
    End Sub
    Private Sub clear()
        TxtName.Text = ""
        LblBrandID.Text = "0"
        ddlClient.SelectedValue = 0
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
    End Sub

    Private Sub ResetDataTablesPlugin()

        Dim builder As New StringBuilder()

        builder.Append("<script type='text/javascript'>")
        builder.Append("fnClickRedraw();")
        builder.Append("</script>")
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "fnClickRedraw", builder.ToString(), False)

    End Sub
End Class
