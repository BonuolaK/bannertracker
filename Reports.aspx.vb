
Partial Class Reports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim campaignid As Integer
            If Int32.TryParse(HttpContext.Current.Request.QueryString("ID"), campaignid) = True Then
                lblcampaignID.Text = campaignid
                gvrental.DataSource = DAL.SelectRentalReport(lblcampaignID.Text)
                gvrental.DataBind()
                gvclicks.DataSource = DAL.SelectClickReport(lblcampaignID.Text)
                gvclicks.DataBind()
                gvimpression.DataSource = DAL.SelectImpressionReport(lblcampaignID.Text)
                gvimpression.DataBind()
                Dim msg As String() = DAL.SelectCampaignInfobyID(lblcampaignID.Text)
                If msg IsNot Nothing Then
                    lblClientName.Text = msg(5)
                    lblBrandName.Text = msg(6)

                    lblCampaignName.Text = msg(0)
                End If
            Else
            End If
        End If
    End Sub

    Protected Sub gvrental_RowCommand(sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvrental.RowCommand
        If Page.IsValid Then
            Try
                Dim e_ As Integer = e.CommandArgument()
                Dim rowe = gvrental.Rows(e_)
                If CType(e.CommandSource, LinkButton).ID = "BtnSave" Then
                    Dim cntrl4 As Control = rowe.FindControl("TxtClicks")
                    Dim TxtClicks As TextBox = cntrl4
                    Dim cntrl5 As Control = rowe.FindControl("TxtImpression")
                    Dim TxtImpression As TextBox = cntrl5
                    Dim cntrl6 As Control = rowe.FindControl("LblID2")
                    Dim LblID2 As Label = cntrl6
                    If TxtClicks.Text.Trim <> "" And TxtImpression.Text.Trim <> "" Then
                        Dim msg As Integer = DAL.UpdateExternalReport(TxtClicks.Text, TxtImpression.Text, LblID2.Text)
                        gvrental.DataSource = DAL.SelectRentalReport(lblcampaignID.Text)
                        gvrental.DataBind()
                        rental.Attributes("class") = "tab-pane active"
                        click.Attributes("class") = "tab-pane"
                        impression.Attributes("class") = "tab-pane"
                        LinkRental.Attributes("class") = "active"
                        LinkImpression.Attributes("class") = ""
                        LinkClick.Attributes("class") = ""
                    End If
                   
                End If
            Catch ex As Exception

            End Try
           
        Else

        End If
       
    End Sub
    Protected Sub gvclicks_RowCommand(sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvclicks.RowCommand
        If Page.IsValid Then
            Try
                Dim e_ As Integer = e.CommandArgument()
                Dim rowe = gvclicks.Rows(e_)
                If CType(e.CommandSource, LinkButton).ID = "BtnSave" Then
                    Dim cntrl4 As Control = rowe.FindControl("TxtClicks")
                    Dim TxtClicks As TextBox = cntrl4
                    Dim cntrl5 As Control = rowe.FindControl("TxtImpression")
                    Dim TxtImpression As TextBox = cntrl5
                    Dim cntrl6 As Control = rowe.FindControl("LblID3")
                    Dim LblID2 As Label = cntrl6
                    If TxtClicks.Text.Trim <> "" And TxtImpression.Text.Trim <> "" Then
                        Dim msg As Integer = DAL.UpdateExternalReport(TxtClicks.Text, TxtImpression.Text, LblID2.Text)
                        gvclicks.DataSource = DAL.SelectClickReport(lblcampaignID.Text)
                        gvclicks.DataBind()
                        rental.Attributes("class") = "tab-pane"
                        click.Attributes("class") = "tab-pane active"
                        impression.Attributes("class") = "tab-pane"
                        LinkRental.Attributes("class") = ""
                        LinkImpression.Attributes("class") = ""
                        LinkClick.Attributes("class") = "active"
                    End If

                End If
            Catch ex As Exception

            End Try

        Else

        End If

    End Sub
    Protected Sub gvimpression_RowCommand(sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvimpression.RowCommand
        If Page.IsValid Then
            Try
                Dim e_ As Integer = e.CommandArgument()
                Dim rowe = gvimpression.Rows(e_)
                If CType(e.CommandSource, LinkButton).ID = "BtnSave" Then
                    Dim cntrl4 As Control = rowe.FindControl("TxtClicks")
                    Dim TxtClicks As TextBox = cntrl4
                    Dim cntrl5 As Control = rowe.FindControl("TxtImpression")
                    Dim TxtImpression As TextBox = cntrl5
                    Dim cntrl6 As Control = rowe.FindControl("LblID4")
                    Dim LblID2 As Label = cntrl6
                    If TxtClicks.Text.Trim <> "" And TxtImpression.Text.Trim <> "" Then
                        Dim msg As Integer = DAL.UpdateExternalReport(TxtClicks.Text, TxtImpression.Text, LblID2.Text)
                        gvimpression.DataSource = DAL.SelectImpressionReport(lblcampaignID.Text)
                        gvimpression.DataBind()
                        rental.Attributes("class") = "tab-pane"
                        click.Attributes("class") = "tab-pane"
                        impression.Attributes("class") = "tab-pane active"
                        LinkRental.Attributes("class") = ""
                        LinkImpression.Attributes("class") = "active"
                        LinkClick.Attributes("class") = ""
                    End If

                End If
            Catch ex As Exception

            End Try

        Else

        End If

    End Sub

    Protected Sub gvrental_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvrental.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cntrl As Control = e.Row.FindControl("LblCurType")
            Dim LblCurType As Label = cntrl
            If LblCurType.Text = "1" Then
                e.Row.Cells(5).Text = ChrW(8358) + e.Row.Cells(5).Text
                e.Row.Cells(8).Text = ChrW(8358) + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = ChrW(8358) + e.Row.Cells(9).Text
            ElseIf LblCurType.Text = "2" Then
                e.Row.Cells(5).Text = "$" + e.Row.Cells(5).Text
                e.Row.Cells(8).Text = "$" + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = "$" + e.Row.Cells(9).Text
            ElseIf LblCurType.Text = "3" Then
                e.Row.Cells(5).Text = "£" + e.Row.Cells(5).Text
                e.Row.Cells(8).Text = "£" + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = "£" + e.Row.Cells(9).Text

            End If
            Dim cntrl1 As Control = e.Row.FindControl("LblScheType")
            Dim LblScheType As Label = cntrl1
            Dim cntrl2 As Control = e.Row.FindControl("LblClicks")
            Dim LblClicks As Label = cntrl2
            Dim cntrl3 As Control = e.Row.FindControl("LblImpression")
            Dim LblImpression As Label = cntrl3
            Dim cntrl4 As Control = e.Row.FindControl("TxtClicks")
            Dim TxtClicks As TextBox = cntrl4
            Dim cntrl5 As Control = e.Row.FindControl("TxtImpression")
            Dim TxtImpression As TextBox = cntrl5
            Dim cntrl6 As Control = e.Row.FindControl("BtnSave")
            Dim BtnSave As LinkButton = cntrl6
            If LblScheType.Text.Trim = "Direct Publisher" Then
                LblClicks.Visible = True
                LblImpression.Visible = True
                TxtClicks.Visible = False
                TxtImpression.Visible = False
                BtnSave.Visible = False
            Else
                LblClicks.Visible = False
                LblImpression.Visible = False
                TxtClicks.Visible = True
                TxtImpression.Visible = True
                BtnSave.Visible = True
            End If
        End If
    End Sub

    Protected Sub gvclicks_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvclicks.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cntrl As Control = e.Row.FindControl("LblCurType2")
            Dim LblCurType As Label = cntrl
            If LblCurType.Text = "1" Then
                e.Row.Cells(7).Text = ChrW(8358) + e.Row.Cells(7).Text
                e.Row.Cells(8).Text = ChrW(8358) + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = ChrW(8358) + e.Row.Cells(9).Text
                e.Row.Cells(10).Text = ChrW(8358) + e.Row.Cells(10).Text
            ElseIf LblCurType.Text = "2" Then
                e.Row.Cells(7).Text = "$" + e.Row.Cells(7).Text
                e.Row.Cells(8).Text = "$" + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = "$" + e.Row.Cells(9).Text
                e.Row.Cells(10).Text = "$" + e.Row.Cells(10).Text
            ElseIf LblCurType.Text = "3" Then
                e.Row.Cells(7).Text = "£" + e.Row.Cells(7).Text
                e.Row.Cells(8).Text = "£" + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = "£" + e.Row.Cells(9).Text
                e.Row.Cells(10).Text = "£" + e.Row.Cells(10).Text

            End If
            Dim cntrl1 As Control = e.Row.FindControl("LblScheType")
            Dim LblScheType As Label = cntrl1
            Dim cntrl2 As Control = e.Row.FindControl("LblClicks")
            Dim LblClicks As Label = cntrl2
            Dim cntrl3 As Control = e.Row.FindControl("LblImpression")
            Dim LblImpression As Label = cntrl3
            Dim cntrl4 As Control = e.Row.FindControl("TxtClicks")
            Dim TxtClicks As TextBox = cntrl4
            Dim cntrl5 As Control = e.Row.FindControl("TxtImpression")
            Dim TxtImpression As TextBox = cntrl5
            Dim cntrl6 As Control = e.Row.FindControl("BtnSave")
            Dim BtnSave As LinkButton = cntrl6
            If Session("ROLEID") = 1 Then
                If LblScheType.Text.Trim = "Direct Publisher" Then
                    LblClicks.Visible = True
                    LblImpression.Visible = True
                    TxtClicks.Visible = False
                    TxtImpression.Visible = False
                    BtnSave.Visible = False
                Else
                    LblClicks.Visible = False
                    LblImpression.Visible = False
                    TxtClicks.Visible = True
                    TxtImpression.Visible = True
                    BtnSave.Visible = True
                End If
            ElseIf Session("ROLEID") = 3 Or Session("ROLEID") = 2 Then

                LblClicks.Visible = True
                LblImpression.Visible = True
                TxtClicks.Visible = False
                TxtImpression.Visible = False
                BtnSave.Visible = False
            
            End If
           
        End If
    End Sub

    Protected Sub gvimpression_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvimpression.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cntrl As Control = e.Row.FindControl("LblCurType3")
            Dim LblCurType As Label = cntrl
            If LblCurType.Text = "1" Then
                e.Row.Cells(7).Text = ChrW(8358) + e.Row.Cells(7).Text
                e.Row.Cells(8).Text = ChrW(8358) + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = ChrW(8358) + e.Row.Cells(9).Text
                e.Row.Cells(10).Text = ChrW(8358) + e.Row.Cells(10).Text
            ElseIf LblCurType.Text = "2" Then
                e.Row.Cells(7).Text = "$" + e.Row.Cells(7).Text
                e.Row.Cells(8).Text = "$" + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = "$" + e.Row.Cells(9).Text
                e.Row.Cells(10).Text = "$" + e.Row.Cells(10).Text
            ElseIf LblCurType.Text = "3" Then
                e.Row.Cells(7).Text = "£" + e.Row.Cells(7).Text
                e.Row.Cells(8).Text = "£" + e.Row.Cells(8).Text
                e.Row.Cells(9).Text = "£" + e.Row.Cells(9).Text
                e.Row.Cells(10).Text = "£" + e.Row.Cells(10).Text

            End If
            Dim cntrl1 As Control = e.Row.FindControl("LblScheType")
            Dim LblScheType As Label = cntrl1
            Dim cntrl2 As Control = e.Row.FindControl("LblClicks")
            Dim LblClicks As Label = cntrl2
            Dim cntrl3 As Control = e.Row.FindControl("LblImpression")
            Dim LblImpression As Label = cntrl3
            Dim cntrl4 As Control = e.Row.FindControl("TxtClicks")
            Dim TxtClicks As TextBox = cntrl4
            Dim cntrl5 As Control = e.Row.FindControl("TxtImpression")
            Dim TxtImpression As TextBox = cntrl5
            Dim cntrl6 As Control = e.Row.FindControl("BtnSave")
            Dim BtnSave As LinkButton = cntrl6
            If Session("ROLEID") = 1 Then
                If LblScheType.Text.Trim = "Direct Publisher" Then
                    LblClicks.Visible = True
                    LblImpression.Visible = True
                    TxtClicks.Visible = False
                    TxtImpression.Visible = False
                    BtnSave.Visible = False
                Else
                    LblClicks.Visible = False
                    LblImpression.Visible = False
                    TxtClicks.Visible = True
                    TxtImpression.Visible = True
                    BtnSave.Visible = True
                End If
            ElseIf Session("ROLEID") = 3 Or Session("ROLEID") = 2 Then

                LblClicks.Visible = True
                LblImpression.Visible = True
                TxtClicks.Visible = False
                TxtImpression.Visible = False
                BtnSave.Visible = False

            End If
        End If
    End Sub

    Protected Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        If TxtEndDate.Text.Trim <> "" And TxtEndDate.Text.Trim <> "" Then
            Try
                gvrental.DataSource = DAL.SelectRentalReportbyDate(lblcampaignID.Text, TxtStartDate.Text.Trim, TxtEndDate.Text.Trim)
                gvrental.DataBind()
                gvclicks.DataSource = DAL.SelectClickReportbyDate(lblcampaignID.Text, TxtStartDate.Text.Trim, TxtEndDate.Text.Trim)
                gvclicks.DataBind()
                gvimpression.DataSource = DAL.SelectImpressionReportbyDate(lblcampaignID.Text, TxtStartDate.Text.Trim, TxtEndDate.Text.Trim)
                gvimpression.DataBind()
            Catch ex As Exception

            End Try

        End If
    End Sub
End Class
