Imports System.Data

Partial Class Overview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("ROLEID") = 2 Or Session("ROLEID") = 1 Then
                ddlClient.DataSource = DAL.SelectClient(Session("COMPANYID"))
                ddlClient.DataBind()
                Dim newItem As New ListItem("Select Client", "0")
                ddlClient.Items.Add(newItem)
                ddlClient.SelectedValue = 0
                gvoverview.DataSource = DAL.GetOverviewOfOngoingCampaigns(ddlClient.SelectedValue, TxtSearch.Text.Trim, Session("COMPANYID"))
                gvoverview.DataBind()
                strongagency.Visible = False

            ElseIf Session("ROLEID") = 3 Then
                Dim msg As DataTable = DAL.GetOverviewOfClientOngoingCampaigns(TxtSearch.Text.Trim, Session("COMPANYID"))
                gvoverview.DataSource = msg

                gvoverview.DataBind()

                Dim msg2 As String() = DAL.SelectClientbyID(Session("COMPANYID"))
                If msg2 IsNot Nothing Then
                    strongagency.InnerText = "Agency: " & msg2(3)
                End If

                ddlClient.Visible = False
                BtnSearchclient.Visible = False

            End If

        End If
    End Sub

    Protected Sub gvoverview_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvoverview.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cntrl As Control = e.Row.FindControl("LblStatus")
            Dim LblStatus As Label = cntrl
            Dim cntrl1 As Control = e.Row.FindControl("BtnPurge")
            Dim BtnPurge As LinkButton = cntrl1
            Dim cntrl2 As Control = e.Row.FindControl("BtnEdit")
            Dim BtnEdit As LinkButton = cntrl2
            Dim cntrl3 As Control = e.Row.FindControl("BtnDownloadCode")
            Dim BtnDownloadCode As LinkButton = cntrl3
            Dim cntrl4 As Control = e.Row.FindControl("BtnReports")
            Dim BtnReports As LinkButton = cntrl4
            Dim cntrl5 As Control = e.Row.FindControl("BtnInvoice")
            Dim BtnInvoice As LinkButton = cntrl5
            If Session("ROLEID") = 2 Then
                If LblStatus.Text = "1" Then
                    LblStatus.Text = "Awaiting schedule"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "2" Then
                    LblStatus.Text = "Awaiting schedule approval"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "3" Then
                    LblStatus.Text = "Schedule rejected"
                    LblStatus.ForeColor = Drawing.Color.Red
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "4" Then
                    LblStatus.Text = "Schedule approved"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "5" Then
                    LblStatus.Text = "Awaiting approval by client"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "6" Then
                    LblStatus.Text = "Approved by client"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "7" Then
                    BtnDownloadCode.Visible = True
                    LblStatus.Text = "Ongoing"
                    LblStatus.ForeColor = Drawing.Color.Green
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "0" Then
                    LblStatus.Text = "Ended"
                    LblStatus.ForeColor = Drawing.Color.Red
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Un-Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-arrow-right'></i>"
                End If
            ElseIf Session("ROLEID") = 1 Then
                If LblStatus.Text = "1" Then
                    LblStatus.Text = "Awaiting schedule"
                    BtnEdit.Text = "Edit"
                    BtnEdit.ToolTip = "Edit campaign"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "2" Then
                    LblStatus.Text = "Awaiting schedule approval"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "3" Then
                    LblStatus.Text = "Schedule rejected"
                    LblStatus.ForeColor = Drawing.Color.Red
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "4" Then
                    LblStatus.Text = "Schedule approved"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "5" Then
                    LblStatus.Text = "Awaiting approval by client"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "6" Then
                    LblStatus.Text = "Approved by client"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "7" Then
                    BtnDownloadCode.Visible = True
                    LblStatus.Text = "Ongoing"
                    LblStatus.ForeColor = Drawing.Color.Green
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-trash-o'></i>"
                ElseIf LblStatus.Text = "0" Then
                    LblStatus.ForeColor = Drawing.Color.Red
                    LblStatus.Text = "Ended"
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                    BtnPurge.ToolTip = "Un-Purge Campaign"
                    BtnPurge.Text = "<i class='fa fa-arrow-right'></i>"
                End If
            ElseIf Session("ROLEID") = 3 Then
                If LblStatus.Text = "5" Or LblStatus.Text = "6" Or LblStatus.Text = "7" Then

                    If LblStatus.Text = "5" Then
                        LblStatus.Text = "Awaiting your approval"
                    ElseIf LblStatus.Text = "6" Then
                        LblStatus.Text = "Approved"
                    ElseIf LblStatus.Text = "7" Then
                        LblStatus.Text = "Ongoing"
                        LblStatus.ForeColor = Drawing.Color.Blue
                    End If

                    BtnEdit.Visible = True
                    BtnEdit.Text = "Details"
                    BtnEdit.ToolTip = "View campaign details"
                Else
                    LblStatus.Text = "Awaiting Schedule"
                    BtnEdit.Visible = False
                End If
                BtnDownloadCode.Visible = False
                BtnInvoice.Visible = False

            End If
            If e.Row.Cells(8).Text <> "N/A" Then
                If Date.Now > CDate(e.Row.Cells(8).Text) Then
                    LblStatus.ForeColor = Drawing.Color.Green
                    LblStatus.Text = "Completed"
                End If
            End If
        End If
    End Sub
    Protected Sub gvoverview_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvoverview.RowCommand
        Try

            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvoverview.Rows(e_)

            If CType(e.CommandSource, LinkButton).ID = "btnEdit" Then
                Dim cntrl As Control = rowe.FindControl("LblID")
                Dim LblID As Label = cntrl
                Dim cntrl1 As Control = rowe.FindControl("LblStatus")
                Dim LblStatus As Label = cntrl1
                If Session("ROLEID") = 1 Then
                    If LblStatus.Text = "Awaiting schedule" Then
                        If CInt(rowe.Cells(4).Text) > 0 Then
                            Response.Redirect("Approval.aspx?ID=" + LblID.Text)
                        Else
                            Response.Redirect("ModifyCampaign.aspx?ID=" + LblID.Text)
                        End If
                    Else
                        Response.Redirect("Approval.aspx?ID=" + LblID.Text)
                    End If
                ElseIf Session("ROLEID") = 2 Then
                    Response.Redirect("Approval.aspx?ID=" + LblID.Text)
                ElseIf Session("ROLEID") = 3 Then
                    Response.Redirect("Approval.aspx?ID=" + LblID.Text)

                End If


            ElseIf CType(e.CommandSource, LinkButton).ID = "BtnPurge" Then
                Dim cntrl As Control = rowe.FindControl("LblID")
                Dim LblID As Label = cntrl
                'write purge codeResponse.Redirect("CreateCampaign.aspx?ID=" + LblID.Text)
            ElseIf CType(e.CommandSource, LinkButton).ID = "BtnDownloadCode" Then
                Dim cntrl As Control = rowe.FindControl("LblID")
                Dim LblID As Label = cntrl
                Response.Redirect("DownloadCode.aspx?Id=" + LblID.Text)
            ElseIf CType(e.CommandSource, LinkButton).ID = "BtnReports" Then
                Dim cntrl As Control = rowe.FindControl("LblID")
                Dim LblID As Label = cntrl
                Response.Redirect("Reports.aspx?ID=" + LblID.Text)
            End If



        Catch ex As Exception

        End Try

    End Sub

    Protected Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click
        If Session("ROLEID") = 2 Or Session("ROLEID") = 1 Then
            gvoverview.DataSource = DAL.GetOverviewOfAllCampaigns(ddlClient.SelectedValue, TxtSearch.Text.Trim, Session("COMPANYID"))
            gvoverview.DataBind()
            BtnOngoing.CssClass = "btn btn-sm btn-default"
            BtnAll.CssClass = "btn btn-sm btn-default active"
            BtnEnded.CssClass = "btn btn-sm btn-default"
        ElseIf Session("ROLEID") = 3 Then
            gvoverview.DataSource = DAL.GetOverviewOfAllClientCampaigns(TxtSearch.Text.Trim, Session("COMPANYID"))
            gvoverview.DataBind()
            BtnOngoing.CssClass = "btn btn-sm btn-default"
            BtnAll.CssClass = "btn btn-sm btn-default active"
            BtnEnded.CssClass = "btn btn-sm btn-default"
        End If
        ResetDataTablesPlugin()
    End Sub

    Protected Sub BtnSearchclient_Click(sender As Object, e As EventArgs) Handles BtnSearchclient.Click
        If ddlClient.SelectedValue <> 0 Then
            gvoverview.DataSource = DAL.GetOverviewByClientID(Session("COMPANYID"), ddlClient.SelectedValue)
            gvoverview.DataBind()
            BtnOngoing.CssClass = "btn btn-sm btn-default"
            BtnEnded.CssClass = "btn btn-sm btn-default"
            BtnAll.CssClass = "btn btn-sm btn-default active"
        End If
        ResetDataTablesPlugin()
    End Sub

    Protected Sub BtnEnded_Click(sender As Object, e As EventArgs) Handles BtnEnded.Click
        If Session("ROLEID") = 2 Or Session("ROLEID") = 1 Then
            gvoverview.DataSource = DAL.GetOverviewOfEndedCampaigns(ddlClient.SelectedValue, TxtSearch.Text.Trim, Session("COMPANYID"))
            gvoverview.DataBind()
            BtnOngoing.CssClass = "btn btn-sm btn-default"
            BtnEnded.CssClass = "btn btn-sm btn-default active"
            BtnAll.CssClass = "btn btn-sm btn-default"
        ElseIf Session("ROLEID") = 3 Then
            gvoverview.DataSource = DAL.GetOverviewOfClientEndedCampaigns(TxtSearch.Text.Trim, Session("COMPANYID"))
            gvoverview.DataBind()
            BtnOngoing.CssClass = "btn btn-sm btn-default"
            BtnEnded.CssClass = "btn btn-sm btn-default active"
            BtnAll.CssClass = "btn btn-sm btn-default"
        End If
        ResetDataTablesPlugin()
    End Sub

    Protected Sub BtnOngoing_Click(sender As Object, e As EventArgs) Handles BtnOngoing.Click
        If Session("ROLEID") = 2 Or Session("ROLEID") = 1 Then
            gvoverview.DataSource = DAL.GetOverviewOfOngoingCampaigns(ddlClient.SelectedValue, TxtSearch.Text.Trim, Session("COMPANYID"))
            gvoverview.DataBind()
            BtnEnded.CssClass = "btn btn-sm btn-default"
            BtnOngoing.CssClass = "btn btn-sm btn-default active"
            BtnAll.CssClass = "btn btn-sm btn-default"
        ElseIf Session("ROLEID") = 3 Then
            gvoverview.DataSource = DAL.GetOverviewOfClientOngoingCampaigns(TxtSearch.Text.Trim, Session("COMPANYID"))
            gvoverview.DataBind()
            BtnEnded.CssClass = "btn btn-sm btn-default"
            BtnOngoing.CssClass = "btn btn-sm btn-default active"
            BtnAll.CssClass = "btn btn-sm btn-default"
        End If
        ResetDataTablesPlugin()
    End Sub

    Protected Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        If TxtSearch.Text <> "" Then
            If Session("ROLEID") = 2 Or Session("ROLEID") = 1 Then
                gvoverview.DataSource = DAL.SelectSearchCampaign(Session("COMPANYID"), TxtSearch.Text)
                gvoverview.DataBind()
                BtnOngoing.CssClass = "btn btn-sm btn-default"
                BtnEnded.CssClass = "btn btn-sm btn-default"
                BtnAll.CssClass = "btn btn-sm btn-default active"
                ddlClient.SelectedValue = 0
            ElseIf Session("ROLEID") = 3 Then
                gvoverview.DataSource = DAL.SelectClientSearchCampaign(Session("COMPANYID"), TxtSearch.Text)
                gvoverview.DataBind()
                BtnOngoing.CssClass = "btn btn-sm btn-default"
                BtnEnded.CssClass = "btn btn-sm btn-default"
                BtnAll.CssClass = "btn btn-sm btn-default active"
                ddlClient.SelectedValue = 0
            End If
            ResetDataTablesPlugin()
        End If
    End Sub

    Private Sub ResetDataTablesPlugin()

        Dim builder As New StringBuilder()

        builder.Append("<script type='text/javascript'>")
        builder.Append("fnClickRedraw();")
        builder.Append("</script>")
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "fnClickRedraw", builder.ToString(), False)

    End Sub
End Class
