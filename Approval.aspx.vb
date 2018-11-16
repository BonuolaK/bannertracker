Imports System.Data
Imports System.Threading
Imports System.Globalization
Partial Class Approval
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim campaignid As Integer
                If Int32.TryParse(HttpContext.Current.Request.QueryString("ID"), campaignid) = True Then
                    lblcampaignID.Text = campaignid
                    Dim msg As String() = DAL.SelectCampaignInfobyID(lblcampaignID.Text)
                    If msg IsNot Nothing Then

                        lblClient.Text = msg(5)
                        LblBrand.Text = msg(6)
                        lblBannerNo.Text = msg(2)
                        LblCampaign.Text = msg(0)
                        LblStatus.Text = msg(4)
                        StatusUpdate(msg(8), msg(7), msg(11), msg(10), msg(9))
                        gvExistingBanners.DataSource = DAL.SelectBannerbyCampaignID(lblcampaignID.Text)
                        gvExistingBanners.DataBind()
                        LblPublisherNo.Text = CStr(gvdownload.Rows.Count())
                        LblExternal.Text = CStr(gvexternal.Rows.Count())
                        Dim totaldollar As Double = 0
                        Dim totalpounds As Double = 0
                        Dim totalnaira As Double = 0
                        Dim firstdate As DateTime
                        Dim lastdate As DateTime
                        ' Thread.CurrentThread.CurrentCulture = New CultureInfo("en-GB")
                        For Each row As TableRow In gvdownload.Rows
                            Dim cntl As Control = row.FindControl("LblCurType")
                            Dim LblCurType As Label = cntl
                            If LblCurType.Text = 1 Then
                                totalnaira = totalnaira + CDbl(row.Cells(10).Text.Remove(0, 1))
                            ElseIf LblCurType.Text = 2 Then
                                totaldollar = totaldollar + CDbl(row.Cells(10).Text.Remove(0, 1))
                            ElseIf LblCurType.Text = 3 Then
                                totalpounds = totalpounds + CDbl(row.Cells(10).Text.Remove(0, 1))
                            End If
                            If firstdate = Nothing Then
                                firstdate = row.Cells(11).Text
                            Else
                                If row.Cells(11).Text < firstdate Then
                                    firstdate = row.Cells(11).Text
                                End If
                            End If
                            If lastdate = Nothing Then
                                lastdate = row.Cells(12).Text
                            Else
                                If row.Cells(12).Text > lastdate Then
                                    lastdate = row.Cells(12).Text
                                End If
                            End If
                            
                        Next
                        For Each row As TableRow In gvexternal.Rows
                            Dim cntl As Control = row.FindControl("LblCurType2")
                            Dim LblCurType2 As Label = cntl
                            If LblCurType2.Text = 1 Then
                                totalnaira = totalnaira + CDbl(row.Cells(7).Text.Remove(0, 1))
                            ElseIf LblCurType2.Text = 2 Then
                                totaldollar = totaldollar + CDbl(row.Cells(7).Text.Remove(0, 1))
                            ElseIf LblCurType2.Text = 3 Then
                                totalpounds = totalpounds + CDbl(row.Cells(7).Text.Remove(0, 1))
                            End If
                            If firstdate = Nothing Then
                                firstdate = row.Cells(8).Text
                            Else
                                If row.Cells(8).Text < firstdate Then
                                    firstdate = row.Cells(8).Text
                                End If
                            End If
                            If lastdate = Nothing Then
                                lastdate = row.Cells(9).Text
                            Else
                                If row.Cells(9).Text > lastdate Then
                                    lastdate = row.Cells(9).Text
                                End If
                            End If
                            
                        Next

                        If gvdownload.Rows.Count > 0 Or gvexternal.Rows.Count > 0 Then
                          
                            LblTotal.Text = ChrW(8358) & FormatNumber(totalnaira, 2, TriState.False, TriState.True, TriState.True) & " ; $" & _
                                FormatNumber(totaldollar, 2, TriState.False, TriState.True, TriState.True) & " ; £" & FormatNumber(totalpounds, 2, TriState.False, TriState.True, TriState.True)
                            LblFirst.Text = firstdate.ToString("dd MMM yyyy")
                            LblLast.Text = lastdate.ToString("dd MMM yyyy")

                            Dim dayinterval As Integer = DateDiff(DateInterval.Day, firstdate, lastdate)
                            Dim todayinteraval As Integer = DateDiff(DateInterval.Day, firstdate, Today)

                            If Today > lastdate Then
                                LblDayinterval.Text = "Day " & dayinterval + 1 & " of " & dayinterval + 1
                                divcomplete.InnerHtml = "<div class='progress progress-sm progress-striped'><div class='progress-bar bg-success'" & _
                                    "data-toggle='tooltip' data-original-title='100% Complete' style='color:black; width: 100%'></div></div>"
                            ElseIf Today < firstdate Then
                                LblDayinterval.Text = "Day 0" & " of " & dayinterval + 1
                                divcomplete.InnerHtml = "<div class='progress progress-sm progress-striped'><div class='progress-bar bg-success'" & _
                                    "data-toggle='tooltip' data-original-title='0% Complete' style='color:black; width: 0%'></div></div>"
                            Else
                                Dim percentagestyle As String = CStr(Math.Round((todayinteraval / dayinterval) * 100, 1)) + "%"
                                Dim percentage As String = percentagestyle + " Complete"
                                LblDayinterval.Text = "Day" & todayinteraval + 1 & " of " & dayinterval + 1


                                divcomplete.InnerHtml = "<div class='progress progress-sm progress-striped'><div class='progress-bar bg-success'" & _
                                    "data-toggle='tooltip' data-original-title='" + percentage + "' style='color:black; width:" + percentagestyle + "'></div></div>"
                            End If
                        Else
                            LblTotal.Text = ChrW(8358) & "0.00 ; $0.00 ; £0.00"
                            LblFirst.Text = "N/A"
                            LblLast.Text = "N/A"
                            LblDayinterval.Text = "Day 0 of 0"
                            divcomplete.InnerHtml = "<div class='progress progress-sm progress-striped'><div class='progress-bar bg-success'" & _
                                    "data-toggle='tooltip' data-original-title='0% Complete' style='color:black; width: 0%'></div></div>"
                        End If

                    End If
                Else
                    Response.Redirect("Overview.aspx")
                End If

            Catch ex As Exception

            End Try
          
        End If
    End Sub
    
    Private Sub StatusUpdate(ByVal name As String, ByVal username As String, ByVal time As String, ByVal company As String, ByVal comments As String)
        If Session("ROLEID") = 2 Then
            If LblStatus.Text = "1" Then
                gvdownload.DataBind()
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = False
                LblRecipient.Text = "Campaign created by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
                gvdownload.DataBind()
            ElseIf LblStatus.Text = "2" Then
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
                gvdownload.DataBind()
                gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
                gvexternal.DataBind()
                BtnReject.Visible = True
                BtnAccept.Visible = True
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                txtcomments.Visible = True
                LblRecipient.Text = "Schedule created by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "3" Then
                gvdownload.DataBind()
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                txtcomments.Text = comments
                txtcomments.Visible = True
                LblRecipient.Text = "Schedule rejected by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "4" Then
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
                gvdownload.DataBind()
                gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = True
                BtnSendPub.Visible = False
                txtcomments.Text = comments
                LblRecipient.Text = "Schedule approved by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "5" Then
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
                gvdownload.DataBind()
                gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = True
                txtcomments.Text = comments
                LblRecipient.Text = "Schedule sent to client by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "6" Then
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
                gvdownload.DataBind()
                gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                BtnSendPub.Visible = False
                txtcomments.Visible = True
                txtcomments.Text = comments
                LblRecipient.Text = "Schedule approved by " & name & " of " & company & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "7" Then
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
                gvdownload.DataBind()
                gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                BtnSendPub.Visible = False
                txtcomments.Visible = True
                txtcomments.Text = comments
                LblRecipient.Text = "Schedule sent to publishers by " & name & " of " & company & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            End If

        End If

        If Session("ROLEID") = 1 Then
            gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
            gvdownload.DataBind()
            gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
            gvexternal.DataBind()
            If LblStatus.Text = "1" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                txtcomments.Visible = True
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnSendAdmin.Visible = True
                BtnModify.Visible = True
                LblRecipient.Text = "Campaign created by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "2" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                txtcomments.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                LblRecipient.Text = "Schedule sent to admin by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "3" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                txtcomments.Visible = True
                txtcomments.Text = comments
                BtnModify.Visible = True
                BtnSendAdmin.Visible = True
                LblRecipient.Text = "Schedule rejected by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "4" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                txtcomments.Visible = True
                BtnSendClient.Visible = True
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                txtcomments.Text = comments
                BtnSendAdmin.Visible = False
                LblRecipient.Text = "Schedule approved by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "5" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                txtcomments.Visible = True
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Text = comments
                LblRecipient.Text = "Schedule sent to client by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "6" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                txtcomments.Visible = True
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                BtnSendPub.Visible = True
                txtcomments.Text = comments
                LblRecipient.Text = "Schedule approved by " & name & " of " & company & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "7" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                txtcomments.Visible = True
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                BtnSendPub.Visible = False
                txtcomments.Text = comments
                LblRecipient.Text = "Schedule sent to publishers by " & name & " of " & company & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            End If

        End If

        If Session("ROLEID") = 3 Then
            If LblStatus.Text = "1" Then
                gvdownload.DataBind()
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = False
                LblRecipient.Text = ""
                LblRecipient.ToolTip = ""
                gvdownload.DataBind()
            ElseIf LblStatus.Text = "2" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = False
                LblRecipient.Text = ""
                LblRecipient.ToolTip = ""
                gvdownload.DataBind()
                gvexternal.DataBind()
            ElseIf LblStatus.Text = "3" Then
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = False
                LblRecipient.Text = ""
                LblRecipient.ToolTip = ""
                gvdownload.DataBind()
                gvexternal.DataBind()
            ElseIf LblStatus.Text = "4" Then
                gvdownload.DataBind()
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = False
                LblRecipient.Text = ""
                LblRecipient.ToolTip = ""
            ElseIf LblStatus.Text = "5" Then
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
                gvdownload.DataBind()
                gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
                gvexternal.DataBind()
                BtnReject.Visible = True
                BtnAccept.Visible = True
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = True
                txtcomments.Text = comments
                LblRecipient.Text = "Schedule sent by " & name & " at " & CDate(time).ToString("dd MMM yyyy hh:mm tt")
                LblRecipient.ToolTip = username
            ElseIf LblStatus.Text = "6" Then
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
                gvdownload.DataBind()
                gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = False
                LblRecipient.Text = ""
                LblRecipient.ToolTip = ""
            ElseIf LblStatus.Text = "7" Then
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(lblcampaignID.Text)
                gvdownload.DataBind()
                gvexternal.DataSource = DAL.SelectExternalSchedulebyCampaign(lblcampaignID.Text)
                gvexternal.DataBind()
                BtnReject.Visible = False
                BtnAccept.Visible = False
                BtnSendClient.Visible = False
                BtnSendPub.Visible = False
                BtnModify.Visible = False
                BtnSendAdmin.Visible = False
                txtcomments.Visible = False
                LblRecipient.Text = ""
                LblRecipient.ToolTip = ""
            End If

        End If

    End Sub
    Protected Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click
        If Session("ROLEID") = 2 Then
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Visible = False
            lblerrmsg.InnerHtml = ""
            Dim msg As String = DAL.UpdateCampaignStatus(lblcampaignID.Text, 4, Session("USERID"), Session("COMPANYID"), txtcomments.Text)
            If msg <> 0 Then
                divsuccess.Attributes("class") = "alert alert-success"
                divsuccess.Visible = True
                lblerrmsg.InnerHtml = "Campaign Schedule Approved"
                BtnAccept.Visible = False
                BtnReject.Visible = False
            End If
        ElseIf Session("ROLEID") = 3 Then
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Visible = False
            lblerrmsg.InnerHtml = ""
            Dim msg As String = DAL.UpdateCampaignStatus(lblcampaignID.Text, 6, Session("USERID"), Session("COMPANYID"), txtcomments.Text)
            If msg <> 0 Then
                divsuccess.Attributes("class") = "alert alert-success"
                divsuccess.Visible = True
                lblerrmsg.InnerHtml = "Campaign Schedule Approved"
                BtnAccept.Visible = False
                BtnReject.Visible = False
            End If
        End If
    End Sub

    Protected Sub BtnReject_Click(sender As Object, e As EventArgs) Handles BtnReject.Click

        If Session("ROLEID") = 2 Then
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Visible = False
            lblerrmsg.InnerHtml = ""
            Dim msg As String = DAL.UpdateCampaignStatus(lblcampaignID.Text, 3, Session("USERID"), Session("COMPANYID"), txtcomments.Text)
            If msg <> 0 Then
                divsuccess.Attributes("class") = "alert alert-success"
                divsuccess.Visible = True
                lblerrmsg.InnerHtml = "Campaign Schedule Rejected"
                BtnAccept.Visible = False
                BtnReject.Visible = False
            End If
        ElseIf Session("ROLEID") = 3 Then
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Visible = False
            lblerrmsg.InnerHtml = ""
            Dim msg As String = DAL.UpdateCampaignStatus(lblcampaignID.Text, 3, Session("USERID"), Session("COMPANYID"), txtcomments.Text)
            If msg <> 0 Then
                divsuccess.Attributes("class") = "alert alert-success"
                divsuccess.Visible = True
                lblerrmsg.InnerHtml = "Campaign Schedule Rejected"
                BtnAccept.Visible = False
                BtnReject.Visible = False
            End If
        End If
    End Sub


    Protected Sub BtnSendClient_Click(sender As Object, e As EventArgs) Handles BtnSendClient.Click
        If Session("ROLEID") = 1 Then
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Visible = False
            lblerrmsg.InnerHtml = ""
            Dim msg As String = DAL.UpdateCampaignStatus(lblcampaignID.Text, 5, Session("USERID"), Session("COMPANYID"), txtcomments.Text)
            If msg <> 0 Then
                divsuccess.Attributes("class") = "alert alert-success"
                divsuccess.Visible = True
                lblerrmsg.InnerHtml = "Schedule sent to client"
                BtnSendClient.Visible = False
            End If
        End If
    End Sub

    Protected Sub BtnSendPub_Click(sender As Object, e As EventArgs) Handles BtnSendPub.Click
        If Session("ROLEID") = 1 Then
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Visible = False
            lblerrmsg.InnerHtml = ""
            Dim msg As String = DAL.UpdateCampaignStatus(lblcampaignID.Text, 7, Session("USERID"), Session("COMPANYID"), txtcomments.Text)
            If msg <> 0 Then
                divsuccess.Attributes("class") = "alert alert-success"
                divsuccess.Visible = True
                lblerrmsg.InnerHtml = "Campaign set as ongoing."
                BtnSendPub.Visible = False
            End If
        End If
    End Sub

    Protected Sub BtnModify_Click(sender As Object, e As EventArgs) Handles BtnModify.Click
        If Session("ROLEID") = 1 Then
           
            Response.Redirect("ModifyCampaign.aspx?ID=" + lblcampaignID.Text)
        End If
    End Sub

    Protected Sub BtnSendAdmin_Click(sender As Object, e As EventArgs) Handles BtnSendAdmin.Click
        If Session("ROLEID") = 1 Then
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Visible = False
            lblerrmsg.InnerHtml = ""
            Dim msg As String = DAL.UpdateCampaignStatus(lblcampaignID.Text, 2, Session("USERID"), Session("COMPANYID"), txtcomments.Text)
            If msg <> 0 Then
                divsuccess.Attributes("class") = "alert alert-success"
                divsuccess.Visible = True
                lblerrmsg.InnerHtml = "Schedule sent to admin"
                BtnSendAdmin.Visible = False
            End If
        End If
    End Sub

    Protected Sub gvdownload_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvdownload.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cntrl As Control = e.Row.FindControl("LblCurType")
            Dim LblCurType As Label = cntrl
            If LblCurType.Text = "1" Then
                e.Row.Cells(7).Text = ChrW(8358) + e.Row.Cells(7).Text
                e.Row.Cells(10).Text = ChrW(8358) + e.Row.Cells(10).Text
            ElseIf LblCurType.Text = "2" Then
                e.Row.Cells(7).Text = "$" + e.Row.Cells(7).Text
                e.Row.Cells(10).Text = "$" + e.Row.Cells(10).Text
            ElseIf LblCurType.Text = "3" Then
                e.Row.Cells(7).Text = "£" + e.Row.Cells(7).Text
                e.Row.Cells(10).Text = "£" + e.Row.Cells(10).Text

            End If
        End If
    End Sub
    Protected Sub gvexternal_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvexternal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cntrl As Control = e.Row.FindControl("LblCurType2")
            Dim LblCurType As Label = cntrl
            If LblCurType.Text = "1" Then
                e.Row.Cells(7).Text = ChrW(8358) + e.Row.Cells(7).Text
                e.Row.Cells(6).Text = ChrW(8358) + e.Row.Cells(6).Text
            ElseIf LblCurType.Text = "2" Then
                e.Row.Cells(7).Text = "$" + e.Row.Cells(7).Text
                e.Row.Cells(6).Text = "$" + e.Row.Cells(6).Text
            ElseIf LblCurType.Text = "3" Then
                e.Row.Cells(7).Text = "£" + e.Row.Cells(7).Text
                e.Row.Cells(6).Text = "£" + e.Row.Cells(6).Text

            End If
        End If
    End Sub
End Class
