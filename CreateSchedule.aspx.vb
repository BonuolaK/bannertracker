Imports System.Data

Partial Class CreateSchedule
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim campaignid As Integer
            If Session("ROLEID") = 1 Then
                If Int32.TryParse(HttpContext.Current.Request.QueryString("Id"), campaignid) = True Then
                    LblCampaignID.Text = campaignid
                    Dim table As DataTable = DAL.SelectSchedulebyCampaign(LblCampaignID.Text)
                    Dim dr As DataRow
                    dr = table.NewRow()
                    dr("ScheID") = 0
                    dr("BannerID") = 0
                    dr("SpecID") = 0
                    dr("PublisherID") = 0
                    dr("CurType") = 1
                    dr("VolDisc") = 0
                    dr("AgencyComm") = 0
                    dr("RedirectLink") = "http://"
                    table.Rows.Add(dr)
                    ViewState("table") = table
                    gvschedule.DataSource = table
                    gvschedule.DataBind()

                    disableallrows(1)
                    Dim table2 As DataTable = DAL.SelectExternalSchedulebyCampaign(LblCampaignID.Text)
                    Dim dr2 As DataRow
                    dr2 = table2.NewRow()
                    dr2("ScheID") = 0
                    dr2("BannerID") = 0
                    dr2("SpecID") = 0
                    dr2("PublisherID") = 0
                    dr2("VolDisc") = 0
                    dr2("AgencyComm") = 0
                    dr2("RedirectLink") = "http://"
                    dr2("CurType") = 2
                    table2.Rows.Add(dr2)
                    ViewState("table2") = table2
                    gvexternal.DataSource = table2
                    gvexternal.DataBind()
                    disableallrows(2)
                    Dim msg As String() = DAL.SelectCampaignInfobyID(LblCampaignID.Text)
                    If msg IsNot Nothing Then
                        If msg(4) = "1" Or msg(4) = "3" Then
                            BtnSubmit.Enabled = True

                        ElseIf msg(4) = "2" Or msg(4) = "4" Or msg(4) = "5" Or msg(4) = "6" Or msg(4) = "7" Or msg(4) = "0" Then
                            BtnSubmit.Enabled = False
                        End If
                    End If
                End If


            Else
                Response.Redirect("Overview.aspx")
            End If

        End If
    End Sub

    Private Sub disableallrows(ByVal type As Integer)
        If type = 1 Then
            Dim count As Integer = gvschedule.Rows.Count - 1
            For Each row As GridViewRow In gvschedule.Rows()
                If row.RowIndex = count Then
                    For j As Integer = 0 To 12
                        row.Cells(j).BorderStyle = BorderStyle.None
                    Next
                    'Dim LblID As Label = Nothing
                    Dim ddlpublisher As DropDownList = DirectCast(row.FindControl("ddlpublisher"), DropDownList)
                    ddlpublisher.Visible = False
                    Dim txtpubadd As Label = DirectCast(row.FindControl("txtpubadd"), Label)
                    txtpubadd.Visible = False
                    Dim ddlbanner As DropDownList = DirectCast(row.FindControl("ddlbanner"), DropDownList)
                    ddlbanner.Visible = False
                    Dim ddlcostspec As DropDownList = DirectCast(row.FindControl("ddlcostspec"), DropDownList)
                    ddlcostspec.Visible = False
                    Dim txtunitprice As TextBox = DirectCast(row.FindControl("txtunitprice"), TextBox)
                    txtunitprice.Visible = False
                    Dim txtvoldisc As TextBox = DirectCast(row.FindControl("txtvoldisc"), TextBox)
                    txtvoldisc.Visible = False
                    Dim txtagencycomm As TextBox = DirectCast(row.FindControl("txtagencycomm"), TextBox)
                    txtagencycomm.Visible = False
                    Dim txtstart As TextBox = DirectCast(row.FindControl("txtstart"), TextBox)
                    txtstart.Visible = False
                    Dim txtend As TextBox = DirectCast(row.FindControl("txtend"), TextBox)
                    txtend.Visible = False
                    Dim txtlink As TextBox = DirectCast(row.FindControl("txtlink"), TextBox)
                    txtlink.Visible = False
                    Dim txtduration As TextBox = DirectCast(row.FindControl("txtduration"), TextBox)
                    txtduration.Visible = False
                    Dim ddlcurtype As DropDownList = DirectCast(row.FindControl("ddlcurtype"), DropDownList)
                    ddlcurtype.Visible = False

                    Dim cntrl13 As Control = row.FindControl("imgAdd")
                    Dim imgAdd As LinkButton = cntrl13
                    imgAdd.Text = "<i class='fa fa-2x fa-plus text-success'></i>"
                    imgAdd.ToolTip = "Add Row"
                    imgAdd.CausesValidation = True
                Else
                    Dim cntrl13 As Control = row.FindControl("imgAdd")
                    Dim imgAdd As LinkButton = cntrl13
                    imgAdd.Text = "<i class='fa fa-2x fa-minus-square text-danger'></i>"
                    imgAdd.ToolTip = "Remove Row"
                    imgAdd.CausesValidation = False
                End If
            Next
        Else
            Dim count As Integer = gvexternal.Rows.Count - 1
            For Each row As GridViewRow In gvexternal.Rows()
                If row.RowIndex = count Then
                    For j As Integer = 0 To 11
                        row.Cells(j).BorderStyle = BorderStyle.None
                    Next
                    'Dim LblID As Label = Nothing
                    Dim ddlpublisher As DropDownList = DirectCast(row.FindControl("ddlsource"), DropDownList)
                    ddlpublisher.Visible = False
                    Dim ddlbanner As DropDownList = DirectCast(row.FindControl("ddlbanner2"), DropDownList)
                    ddlbanner.Visible = False
                    Dim ddlcostspec As DropDownList = DirectCast(row.FindControl("ddlcostspec2"), DropDownList)
                    ddlcostspec.Visible = False
                    Dim txtunitprice As TextBox = DirectCast(row.FindControl("txtunitprice2"), TextBox)
                    txtunitprice.Visible = False
                    Dim txtvoldisc As TextBox = DirectCast(row.FindControl("txtvoldisc2"), TextBox)
                    txtvoldisc.Visible = False
                    Dim txtagencycomm As TextBox = DirectCast(row.FindControl("txtagencycomm2"), TextBox)
                    txtagencycomm.Visible = False
                    Dim txtstart As TextBox = DirectCast(row.FindControl("txtstart2"), TextBox)
                    txtstart.Visible = False
                    Dim txtend As TextBox = DirectCast(row.FindControl("txtend2"), TextBox)
                    txtend.Visible = False
                    Dim txtlink As TextBox = DirectCast(row.FindControl("txtlink2"), TextBox)
                    txtlink.Visible = False
                    Dim txtduration As TextBox = DirectCast(row.FindControl("txtduration2"), TextBox)
                    txtduration.Visible = False
                    Dim ddlcurtype As DropDownList = DirectCast(row.FindControl("ddlcurtype2"), DropDownList)
                    ddlcurtype.Visible = False

                    Dim cntrl13 As Control = row.FindControl("imgAdd2")
                    Dim imgAdd As LinkButton = cntrl13
                    imgAdd.Text = "<i class='fa fa-2x fa-plus text-success'></i>"
                    imgAdd.ToolTip = "Add Row"
                    imgAdd.CausesValidation = True
                Else
                    Dim cntrl13 As Control = row.FindControl("imgAdd2")
                    Dim imgAdd As LinkButton = cntrl13
                    imgAdd.Text = "<i class='fa fa-2x fa-minus-square text-danger'></i>"
                    imgAdd.ToolTip = "Remove Row"
                    imgAdd.CausesValidation = False
                End If
            Next
        End If

    End Sub
    ''Protected Sub BtnAddNew_Click(sender As Object, e As EventArgs) Handles BtnAddNew.Click

    ''    divsuccess.Attributes("class") = "alert alert-danger"
    ''    divsuccess.Style.Add("display", "none")
    ''    errormsg.InnerHtml = ""
    ''    Dim table As DataTable = getemptytable(1)
    ''    Dim dr As DataRow
    ''    For Each row In gvschedule.Rows
    ''        dr = table.NewRow()

    ''        Dim ctrl11 As Control = TryCast(row.FindControl("LblID"), Label)
    ''        If ctrl11 IsNot Nothing Then
    ''            Dim LID As Label = DirectCast(ctrl11, Label)
    ''            dr(0) = LID.Text
    ''        End If
    ''        Dim ctrl As Control = TryCast(row.FindControl("ddlpublisher"), DropDownList)
    ''        If ctrl IsNot Nothing Then
    ''            Dim ddlpublisher As DropDownList = DirectCast(ctrl, DropDownList)
    ''            dr(2) = ddlpublisher.SelectedValue
    ''        End If
    ''        Dim ctrl1 As Control = TryCast(row.FindControl("txtpubadd"), Label)
    ''        If ctrl1 IsNot Nothing Then
    ''            Dim txtpubadd As Label = DirectCast(ctrl1, Label)
    ''            dr(3) = txtpubadd.Text
    ''        End If
    ''        Dim ctrl2 As Control = TryCast(row.FindControl("ddlbanner"), DropDownList)
    ''        If ctrl2 IsNot Nothing Then
    ''            Dim ddlbanner As DropDownList = DirectCast(ctrl2, DropDownList)
    ''            dr(4) = ddlbanner.SelectedValue

    ''            dr(5) = ddlbanner.SelectedItem
    ''        End If
    ''        Dim ctrl3 As Control = TryCast(row.FindControl("ddlcostspec"), DropDownList)
    ''        If ctrl3 IsNot Nothing Then
    ''            Dim ddlcostspec As DropDownList = DirectCast(ctrl3, DropDownList)
    ''            dr(6) = ddlcostspec.SelectedValue
    ''            dr(7) = ddlcostspec.SelectedItem
    ''        End If
    ''        Dim ctrl8 As Control = TryCast(row.FindControl("txtunitprice"), TextBox)
    ''        If ctrl8 IsNot Nothing Then
    ''            Dim txtunitprice As TextBox = DirectCast(ctrl8, TextBox)
    ''            dr(8) = txtunitprice.Text
    ''        End If
    ''        Dim ctrl4 As Control = TryCast(row.FindControl("txtvoldisc"), TextBox)
    ''        If ctrl4 IsNot Nothing Then
    ''            Dim txtvoldisc As TextBox = DirectCast(ctrl4, TextBox)
    ''            dr(9) = txtvoldisc.Text
    ''        End If
    ''        Dim ctrl5 As Control = TryCast(row.FindControl("txtagencycomm"), TextBox)
    ''        If ctrl5 IsNot Nothing Then
    ''            Dim txtagencycomm As TextBox = DirectCast(ctrl5, TextBox)
    ''            dr(10) = txtagencycomm.Text
    ''        End If
    ''        Dim ctrl6 As Control = TryCast(row.FindControl("txtstart"), TextBox)
    ''        If ctrl6 IsNot Nothing Then
    ''            Dim txtstart As TextBox = DirectCast(ctrl6, TextBox)
    ''            dr(11) = txtstart.Text
    ''        End If
    ''        Dim ctrl7 As Control = TryCast(row.FindControl("txtend"), TextBox)
    ''        If ctrl7 IsNot Nothing Then
    ''            Dim txtend As TextBox = DirectCast(ctrl7, TextBox)
    ''            dr(12) = txtend.Text
    ''        End If
    ''        Dim ctrl9 As Control = TryCast(row.FindControl("txtlink"), TextBox)
    ''        If ctrl9 IsNot Nothing Then
    ''            Dim txtlink As TextBox = DirectCast(ctrl9, TextBox)
    ''            dr(13) = txtlink.Text
    ''        End If
    ''        Dim ctrl10 As Control = TryCast(row.FindControl("txtduration"), TextBox)
    ''        If ctrl10 IsNot Nothing Then
    ''            Dim txtduration As TextBox = DirectCast(ctrl10, TextBox)
    ''            dr(14) = txtduration.Text
    ''        End If
    ''        Dim ctrl12 As Control = TryCast(row.FindControl("ddlcurtype"), DropDownList)
    ''        If ctrl12 IsNot Nothing Then
    ''            Dim ddlcurtype As DropDownList = DirectCast(ctrl12, DropDownList)
    ''            dr(15) = ddlcurtype.SelectedValue
    ''        End If
    ''        table.Rows.Add(dr)
    ''    Next
    ''    dr = table.NewRow()
    ''    dr("BannerID") = 0
    ''    dr("SpecID") = 0
    ''    dr("PublisherID") = 0
    ''    dr("CurType") = 1
    ''    table.Rows.Add(dr)
    ''    ViewState("table") = table
    ''    gvschedule.DataSource = table
    ''    gvschedule.DataBind()
    ''End Sub
    'Protected Sub BtnAddNew2_Click(sender As Object, e As EventArgs) Handles BtnAddNew2.Click

    '    divsuccess.Attributes("class") = "alert alert-danger"
    '    divsuccess.Style.Add("display", "none")
    '    errormsg.InnerHtml = ""
    '    Dim table As DataTable = getemptytable(2)
    '    Dim dr As DataRow
    '    For Each row In gvexternal.Rows
    '        dr = table.NewRow()
    '        Dim ctrl11 As Control = TryCast(row.FindControl("LblID2"), Label)
    '        If ctrl11 IsNot Nothing Then
    '            Dim LID As Label = DirectCast(ctrl11, Label)
    '            dr(0) = LID.Text
    '        End If
    '        Dim ctrl As Control = TryCast(row.FindControl("ddlsource"), DropDownList)
    '        If ctrl IsNot Nothing Then
    '            Dim ddlsource As DropDownList = DirectCast(ctrl, DropDownList)
    '            dr(2) = ddlsource.SelectedValue
    '        End If
    '        Dim ctrl2 As Control = TryCast(row.FindControl("ddlbanner2"), DropDownList)
    '        If ctrl2 IsNot Nothing Then
    '            Dim ddlbanner2 As DropDownList = DirectCast(ctrl2, DropDownList)
    '            dr(3) = ddlbanner2.SelectedValue

    '            dr(4) = ddlbanner2.SelectedItem
    '        End If
    '        Dim ctrl3 As Control = TryCast(row.FindControl("ddlcostspec2"), DropDownList)
    '        If ctrl3 IsNot Nothing Then
    '            Dim ddlcostspec2 As DropDownList = DirectCast(ctrl3, DropDownList)
    '            dr(5) = ddlcostspec2.SelectedValue
    '            dr(6) = ddlcostspec2.SelectedItem
    '        End If
    '        Dim ctrl8 As Control = TryCast(row.FindControl("txtunitprice2"), TextBox)
    '        If ctrl8 IsNot Nothing Then
    '            Dim txtunitprice2 As TextBox = DirectCast(ctrl8, TextBox)
    '            dr(7) = txtunitprice2.Text
    '        End If
    '        Dim ctrl6 As Control = TryCast(row.FindControl("txtstart2"), TextBox)
    '        If ctrl6 IsNot Nothing Then
    '            Dim txtstart2 As TextBox = DirectCast(ctrl6, TextBox)
    '            dr(8) = txtstart2.Text
    '        End If
    '        Dim ctrl7 As Control = TryCast(row.FindControl("txtend2"), TextBox)
    '        If ctrl7 IsNot Nothing Then
    '            Dim txtend2 As TextBox = DirectCast(ctrl7, TextBox)
    '            dr(9) = txtend2.Text
    '        End If
    '        Dim ctrl9 As Control = TryCast(row.FindControl("txtlink2"), TextBox)
    '        If ctrl9 IsNot Nothing Then
    '            Dim txtlink2 As TextBox = DirectCast(ctrl9, TextBox)
    '            dr(10) = txtlink2.Text
    '        End If
    '        Dim ctrl10 As Control = TryCast(row.FindControl("txtduration2"), TextBox)
    '        If ctrl10 IsNot Nothing Then
    '            Dim txtduration2 As TextBox = DirectCast(ctrl10, TextBox)
    '            dr(11) = txtduration2.Text
    '        End If
    '        Dim ctrl12 As Control = TryCast(row.FindControl("ddlcurtype2"), DropDownList)
    '        If ctrl12 IsNot Nothing Then
    '            Dim ddlcurtype2 As DropDownList = DirectCast(ctrl12, DropDownList)
    '            dr(12) = ddlcurtype2.SelectedValue
    '        End If
    '        table.Rows.Add(dr)
    '    Next
    '    dr = table.NewRow()
    '    dr("BannerID") = 0
    '    dr("SpecID") = 0
    '    dr("PublisherID") = 0
    '    dr("CurType") = 2
    '    table.Rows.Add(dr)
    '    ViewState("table2") = table
    '    gvexternal.DataSource = table
    '    gvexternal.DataBind()
    'End Sub
    Public Function getemptytable(ByVal type As Integer) As DataTable
        If type = 1 Then
            Dim table As New DataTable
            table.Columns.Add("ScheID", GetType(String))
            table.Columns.Add("Publisher", GetType(String))
            table.Columns.Add("PublisherID", GetType(String))
            table.Columns.Add("PublisherURL", GetType(String))
            table.Columns.Add("BannerID", GetType(String))
            table.Columns.Add("BannerSpec", GetType(String))
            table.Columns.Add("SpecID", GetType(String))
            table.Columns.Add("SpecName", GetType(String))
            table.Columns.Add("UnitPrice", GetType(String))
            table.Columns.Add("VolDisc", GetType(String))
            table.Columns.Add("AgencyComm", GetType(String))
            table.Columns.Add("StartDate", GetType(String))
            table.Columns.Add("EndDate", GetType(String))
            table.Columns.Add("RedirectLink", GetType(String))
            table.Columns.Add("Duration", GetType(String))
            table.Columns.Add("CurType", GetType(String))

            Return table
        Else
            Dim table As New DataTable
            table.Columns.Add("ScheID", GetType(String))
            table.Columns.Add("Publisher", GetType(String))
            table.Columns.Add("PublisherID", GetType(String))
            table.Columns.Add("BannerID", GetType(String))
            table.Columns.Add("BannerSpec", GetType(String))
            table.Columns.Add("SpecID", GetType(String))
            table.Columns.Add("SpecName", GetType(String))
            table.Columns.Add("UnitPrice", GetType(String))
            table.Columns.Add("VolDisc", GetType(String))
            table.Columns.Add("AgencyComm", GetType(String))
            table.Columns.Add("StartDate", GetType(String))
            table.Columns.Add("EndDate", GetType(String))
            table.Columns.Add("RedirectLink", GetType(String))
            table.Columns.Add("Duration", GetType(String))
            table.Columns.Add("CurType", GetType(String))

            Return table
        End If

    End Function
    Protected Sub gvschedule_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvschedule.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cntrl As Control = e.Row.FindControl("ddlbanner")
            Dim ddlbanner As DropDownList = cntrl
            ddlbanner.DataSource = DAL.SelectBannerbyCampaignID(LblCampaignID.Text)
            ddlbanner.DataBind()
            Dim listitem As New ListItem("Select", 0)
            ddlbanner.Items.Add(listitem)
            Dim cntrl1 As Control = e.Row.FindControl("ddlcostspec")
            Dim ddlcostspec As DropDownList = cntrl1
            ddlcostspec.DataSource = DAL.SelectSpecification()
            ddlcostspec.DataBind()
            Dim listitem1 As New ListItem("Select", 0)
            ddlcostspec.Items.Add(listitem1)
            Dim cntrl2 As Control = e.Row.FindControl("ddlpublisher")
            Dim ddlpublisher As DropDownList = cntrl2
            ddlpublisher.DataSource = DAL.SelectPublishers(Session("COMPANYID"))
            ddlpublisher.DataBind()
            Dim listitem3 As New ListItem(" <-- Create New --> ", "Create New")
            ddlpublisher.Items.Add(listitem3)
            Dim listitem2 As New ListItem("Please Select", 0)
            ddlpublisher.Items.Add(listitem2)
            For Each Li As ListItem In ddlpublisher.Items
                If Li.Value <> "Create New" Then
                    Dim msg2 As String() = DAL.SelectPublishersandClientsbyID(4, Li.Value)
                    Li.Attributes.Add("title", msg2(3))
                Else
                    If Li.Value = "Create New" Then
                        Li.Attributes.Add("title", "Create New Publisher")
                    Else
                        Li.Attributes.Add("title", "Please Select from List")
                    End If

                End If

            Next

            Dim cntrl3 As Control = e.Row.FindControl("ddlcurtype")
            Dim ddlcurtype As DropDownList = cntrl3
            If ViewState("table") IsNot Nothing Then
                Dim dtCurrentData As DataTable = DirectCast(ViewState("table"), DataTable)
                Dim bannerid As Integer = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("BannerID"))
                Dim newlistitem As ListItem = Nothing
                newlistitem = ddlbanner.Items.FindByValue(bannerid)
                If newlistitem Is Nothing Then
                    ddlbanner.SelectedValue = 0
                    ddlbanner.Style.Add("border-color", "red")
                    ddlbanner.ToolTip = "Previous Banner Deleted"
                Else
                    ddlbanner.Style.Add("border-color", "none")
                    ddlbanner.ToolTip = ""
                    ddlbanner.SelectedValue = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("BannerID"))
                End If

                ddlcostspec.SelectedValue = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("SpecID"))
                ddlpublisher.SelectedValue = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("PublisherID"))
                ddlcurtype.SelectedValue = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("CurType"))
            Else
                ddlcurtype.SelectedValue = 1
                ddlbanner.SelectedValue = 0
                ddlcostspec.SelectedValue = 0
                ddlpublisher.SelectedValue = 0
            End If

            e.Row.Cells(2).Attributes.Add("style", "word-break:break-all;word-wrap:break-word;")

        End If
    End Sub
    Protected Sub gvexternal_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvexternal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cntrl As Control = e.Row.FindControl("ddlbanner2")
            Dim ddlbanner2 As DropDownList = cntrl
            ddlbanner2.DataSource = DAL.SelectBannerbyCampaignID(LblCampaignID.Text)
            ddlbanner2.DataBind()
            Dim listitem As New ListItem("Select", 0)
            ddlbanner2.Items.Add(listitem)
            Dim cntrl1 As Control = e.Row.FindControl("ddlcostspec2")
            Dim ddlcostspec2 As DropDownList = cntrl1
            ddlcostspec2.DataSource = DAL.SelectExternalSpecification()
            ddlcostspec2.DataBind()
            Dim listitem1 As New ListItem("Select", 0)
            ddlcostspec2.Items.Add(listitem1)
            Dim cntrl2 As Control = e.Row.FindControl("ddlsource")
            Dim ddlsource As DropDownList = cntrl2
            ddlsource.DataSource = DAL.SelectExternalSources()
            ddlsource.DataBind()
            Dim listitem2 As New ListItem("Please Select", 0)
            ddlsource.Items.Add(listitem2)
            Dim cntrl3 As Control = e.Row.FindControl("ddlcurtype2")
            Dim ddlcurtype2 As DropDownList = cntrl3
            If ViewState("table2") IsNot Nothing Then
                Dim dtCurrentData As DataTable = DirectCast(ViewState("table2"), DataTable)
                Dim bannerid As Integer = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("BannerID"))
                Dim newlistitem As ListItem = Nothing
                newlistitem = ddlbanner2.Items.FindByValue(bannerid)
                If newlistitem Is Nothing Then
                    ddlbanner2.SelectedValue = 0
                    ddlbanner2.Style.Add("border-color", "red")
                    ddlbanner2.ToolTip = "Previous Banner Deleted"
                Else
                    ddlbanner2.Style.Add("border-color", "none")
                    ddlbanner2.ToolTip = ""
                    ddlbanner2.SelectedValue = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("BannerID"))
                End If

                ddlcostspec2.SelectedValue = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("SpecID"))
                ddlsource.SelectedValue = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("PublisherID"))
                ddlcurtype2.SelectedValue = Convert.ToInt32(dtCurrentData.Rows(e.Row.RowIndex)("CurType"))

            Else
                ddlcurtype2.SelectedValue = 2
                ddlbanner2.SelectedValue = 0
                ddlcostspec2.SelectedValue = 0
                ddlsource.SelectedValue = 0
            End If
        End If
    End Sub
    Protected Sub gvschedule_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvschedule.RowCommand

        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        Try

            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvschedule.Rows(e_)
            If CType(e.CommandSource, LinkButton).ID = "imgAdd" Then
                If CType(e.CommandSource, LinkButton).Text = "<i class='fa fa-2x fa-plus text-success'></i>" Then
                    If gvschedule.Rows.Count = 1 Then
                        InsertRow(e_)
                        disableallrows(1)
                    Else
                        If Page.IsValid Then
                            If checkschedulerows(e_ - 1) = True Then
                                InsertRow(e_)
                                disableallrows(1)
                            Else
                                divsuccess.Attributes("class") = "alert alert-danger"
                                divsuccess.Style.Add("display", "block")
                                errormsg.InnerHtml = "<strong>Error!</strong> Please fill in all information"
                            End If
                        Else
                            divsuccess.Attributes("class") = "alert alert-danger"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Invalid Submission!</strong> Please fill in required information"
                        End If
                        
                    End If

                Else
                    Dim lID As Label = Nothing
                    Dim control As Control = TryCast(rowe.FindControl("LblID"), Label)
                    If control IsNot Nothing Then
                        lID = DirectCast(control, Label)
                    End If
                    If lID.Text = 0 Then
                        If gvschedule.Rows.Count = 1 Then

                        Else
                            Deleterows(e_, 1)
                            disableallrows(1)
                        End If

                    ElseIf lID.Text <> 0 Then
                        If LblDelete.Text = "" Then
                            LblDelete.Text = lID.Text
                        Else
                            LblDelete.Text = LblDelete.Text + "," + lID.Text
                        End If
                        Deleterows(e_, 1)
                        disableallrows(1)
                    End If

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Function checkschedulerows(ByVal e_ As Integer) As Boolean
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        Dim row = gvschedule.Rows(e_)
        Dim ddlpublisher As DropDownList = Nothing
        Dim txtpubadd As Label = Nothing
        Dim ddlbanner As DropDownList = Nothing
        Dim ddlcostspec As DropDownList = Nothing
        Dim txtunitprice As TextBox = Nothing
        Dim txtvoldisc As TextBox = Nothing
        Dim txtagencycomm As TextBox = Nothing
        Dim txtstart As TextBox = Nothing
        Dim txtend As TextBox = Nothing
        Dim txtlink As TextBox = Nothing
        Dim txtduration As TextBox = Nothing
        Dim ddlcurtype As DropDownList = Nothing
        Dim ctrl As Control = TryCast(row.FindControl("ddlpublisher"), DropDownList)
        If ctrl IsNot Nothing Then
            ddlpublisher = DirectCast(ctrl, DropDownList)
        End If
        Dim ctrl1 As Control = TryCast(row.FindControl("txtpubadd"), Label)
        If ctrl1 IsNot Nothing Then
            txtpubadd = DirectCast(ctrl1, Label)
        End If
        Dim ctrl2 As Control = TryCast(row.FindControl("ddlbanner"), DropDownList)
        If ctrl2 IsNot Nothing Then
            ddlbanner = DirectCast(ctrl2, DropDownList)
        End If
        Dim ctrl3 As Control = TryCast(row.FindControl("ddlcostspec"), DropDownList)
        If ctrl3 IsNot Nothing Then
            ddlcostspec = DirectCast(ctrl3, DropDownList)
        End If
        Dim ctrl8 As Control = TryCast(row.FindControl("txtunitprice"), TextBox)
        If ctrl8 IsNot Nothing Then
            txtunitprice = DirectCast(ctrl8, TextBox)
        End If
        Dim ctrl4 As Control = TryCast(row.FindControl("txtvoldisc"), TextBox)
        If ctrl4 IsNot Nothing Then
            txtvoldisc = DirectCast(ctrl4, TextBox)
        End If
        Dim ctrl5 As Control = TryCast(row.FindControl("txtagencycomm"), TextBox)
        If ctrl5 IsNot Nothing Then
            txtagencycomm = DirectCast(ctrl5, TextBox)
        End If
        Dim ctrl6 As Control = TryCast(row.FindControl("txtstart"), TextBox)
        If ctrl6 IsNot Nothing Then
            txtstart = DirectCast(ctrl6, TextBox)
        End If
        Dim ctrl7 As Control = TryCast(row.FindControl("txtend"), TextBox)
        If ctrl7 IsNot Nothing Then
            txtend = DirectCast(ctrl7, TextBox)
        End If
        Dim ctrl9 As Control = TryCast(row.FindControl("txtlink"), TextBox)
        If ctrl9 IsNot Nothing Then
            txtlink = DirectCast(ctrl9, TextBox)
        End If
        Dim ctrl10 As Control = TryCast(row.FindControl("txtduration"), TextBox)
        If ctrl10 IsNot Nothing Then
            txtduration = DirectCast(ctrl10, TextBox)
        End If

        If ddlpublisher.SelectedValue <> 0 And txtpubadd.Text.Trim <> "" And ddlbanner.SelectedValue <> 0 And ddlcostspec.SelectedValue <> 0 And txtunitprice.Text.Trim <> "" And txtvoldisc.Text.Trim <> "" And _
         txtagencycomm.Text.Trim <> "" And txtstart.Text.Trim <> "" And txtend.Text.Trim <> "" And txtlink.Text.Trim <> "" And txtduration.Text.Trim <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function checkexternalrows(ByVal e_ As Integer) As Boolean
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        Dim row = gvexternal.Rows(e_)
        Dim ddlsource As DropDownList = Nothing
        Dim ddlbanner2 As DropDownList = Nothing
        Dim ddlcostspec2 As DropDownList = Nothing
        Dim txtunitprice2 As TextBox = Nothing
        Dim txtvoldisc2 As TextBox = Nothing
        Dim txtagencycomm2 As TextBox = Nothing
        Dim txtstart2 As TextBox = Nothing
        Dim txtend2 As TextBox = Nothing
        Dim txtlink2 As TextBox = Nothing
        Dim txtduration2 As TextBox = Nothing
        Dim ddlcurtype2 As DropDownList = Nothing
        Dim ctrl As Control = TryCast(row.FindControl("ddlsource"), DropDownList)
        If ctrl IsNot Nothing Then
            ddlsource = DirectCast(ctrl, DropDownList)
        End If
        Dim ctrl2 As Control = TryCast(row.FindControl("ddlbanner2"), DropDownList)
        If ctrl2 IsNot Nothing Then
            ddlbanner2 = DirectCast(ctrl2, DropDownList)
        End If
        Dim ctrl3 As Control = TryCast(row.FindControl("ddlcostspec2"), DropDownList)
        If ctrl3 IsNot Nothing Then
            ddlcostspec2 = DirectCast(ctrl3, DropDownList)
        End If
        Dim ctrl8 As Control = TryCast(row.FindControl("txtunitprice2"), TextBox)
        If ctrl8 IsNot Nothing Then
            txtunitprice2 = DirectCast(ctrl8, TextBox)
        End If
        Dim ctrl4 As Control = TryCast(row.FindControl("txtvoldisc2"), TextBox)
        If ctrl4 IsNot Nothing Then
            txtvoldisc2 = DirectCast(ctrl4, TextBox)
        End If
        Dim ctrl5 As Control = TryCast(row.FindControl("txtagencycomm2"), TextBox)
        If ctrl5 IsNot Nothing Then
            txtagencycomm2 = DirectCast(ctrl5, TextBox)
        End If
        Dim ctrl6 As Control = TryCast(row.FindControl("txtstart2"), TextBox)
        If ctrl6 IsNot Nothing Then
            txtstart2 = DirectCast(ctrl6, TextBox)

        End If
        Dim ctrl7 As Control = TryCast(row.FindControl("txtend2"), TextBox)
        If ctrl7 IsNot Nothing Then
            txtend2 = DirectCast(ctrl7, TextBox)

        End If
        Dim ctrl9 As Control = TryCast(row.FindControl("txtlink2"), TextBox)
        If ctrl9 IsNot Nothing Then
            txtlink2 = DirectCast(ctrl9, TextBox)
        End If
        Dim ctrl10 As Control = TryCast(row.FindControl("txtduration2"), TextBox)
        If ctrl10 IsNot Nothing Then
            txtduration2 = DirectCast(ctrl10, TextBox)
        End If

        If ddlsource.SelectedValue <> 0 And ddlbanner2.SelectedValue <> 0 And ddlcostspec2.SelectedValue <> 0 And txtunitprice2.Text.Trim <> "" _
         And txtstart2.Text.Trim <> "" And txtend2.Text.Trim <> "" And txtlink2.Text.Trim <> "" And txtduration2.Text.Trim <> "" And txtagencycomm2.Text.Trim <> "" And txtvoldisc2.Text.Trim <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub InsertRow(ByVal e_ As Integer)
        Try
          
            Dim table As DataTable = getemptytable(1)
            For Each row In gvschedule.Rows
                Dim dr As DataRow
                dr = table.NewRow()
                Dim LblID As Label = Nothing
                Dim ddlpublisher As DropDownList = Nothing
                Dim txtpubadd As Label = Nothing
                Dim ddlbanner As DropDownList = Nothing
                Dim ddlcostspec As DropDownList = Nothing
                Dim txtunitprice As TextBox = Nothing
                Dim txtvoldisc As TextBox = Nothing
                Dim txtagencycomm As TextBox = Nothing
                Dim txtstart As TextBox = Nothing
                Dim txtend As TextBox = Nothing
                Dim txtlink As TextBox = Nothing
                Dim txtduration As TextBox = Nothing
                Dim ddlcurtype As DropDownList = Nothing
                Dim imgAdd As LinkButton = Nothing
                Dim ctrl11 As Control = TryCast(row.FindControl("LblID"), Label)
                If ctrl11 IsNot Nothing Then
                    LblID = DirectCast(ctrl11, Label)
                    dr(0) = LblID.Text
                End If
                Dim ctrl As Control = TryCast(row.FindControl("ddlpublisher"), DropDownList)
                If ctrl IsNot Nothing Then
                    ddlpublisher = DirectCast(ctrl, DropDownList)
                    dr(2) = ddlpublisher.SelectedValue
                    ddlpublisher.Visible = True
                End If
                Dim ctrl1 As Control = TryCast(row.FindControl("txtpubadd"), Label)
                If ctrl1 IsNot Nothing Then
                    txtpubadd = DirectCast(ctrl1, Label)
                    dr(3) = txtpubadd.Text
                    txtpubadd.Visible = True
                End If
                Dim ctrl2 As Control = TryCast(row.FindControl("ddlbanner"), DropDownList)
                If ctrl2 IsNot Nothing Then
                    ddlbanner = DirectCast(ctrl2, DropDownList)
                    dr(4) = ddlbanner.SelectedValue
                    dr(5) = ddlbanner.SelectedItem
                    ddlbanner.Visible = True
                End If
                Dim ctrl3 As Control = TryCast(row.FindControl("ddlcostspec"), DropDownList)
                If ctrl3 IsNot Nothing Then
                    ddlcostspec = DirectCast(ctrl3, DropDownList)
                    dr(6) = ddlcostspec.SelectedValue
                    dr(7) = ddlcostspec.SelectedItem
                    ddlcostspec.Visible = True
                End If
                Dim ctrl8 As Control = TryCast(row.FindControl("txtunitprice"), TextBox)
                If ctrl8 IsNot Nothing Then
                    txtunitprice = DirectCast(ctrl8, TextBox)
                    dr(8) = txtunitprice.Text
                End If
                Dim ctrl4 As Control = TryCast(row.FindControl("txtvoldisc"), TextBox)
                If ctrl4 IsNot Nothing Then
                    txtvoldisc = DirectCast(ctrl4, TextBox)
                    dr(9) = txtvoldisc.Text
                    txtvoldisc.Visible = True
                End If
                Dim ctrl5 As Control = TryCast(row.FindControl("txtagencycomm"), TextBox)
                If ctrl5 IsNot Nothing Then
                    txtagencycomm = DirectCast(ctrl5, TextBox)
                    dr(10) = txtagencycomm.Text
                    txtagencycomm.Visible = True
                End If
                Dim ctrl6 As Control = TryCast(row.FindControl("txtstart"), TextBox)
                If ctrl6 IsNot Nothing Then
                    txtstart = DirectCast(ctrl6, TextBox)
                    dr(11) = txtstart.Text
                    txtstart.Visible = True
                End If
                Dim ctrl7 As Control = TryCast(row.FindControl("txtend"), TextBox)
                If ctrl7 IsNot Nothing Then
                    txtend = DirectCast(ctrl7, TextBox)
                    dr(12) = txtend.Text
                    txtend.Visible = True
                End If
                Dim ctrl9 As Control = TryCast(row.FindControl("txtlink"), TextBox)
                If ctrl9 IsNot Nothing Then
                    txtlink = DirectCast(ctrl9, TextBox)
                    dr(13) = txtlink.Text
                    txtlink.Visible = True
                End If
                Dim ctrl10 As Control = TryCast(row.FindControl("txtduration"), TextBox)
                If ctrl10 IsNot Nothing Then
                    txtduration = DirectCast(ctrl10, TextBox)
                    dr(14) = txtduration.Text
                    txtduration.Visible = True
                End If
                Dim ctrl12 As Control = TryCast(row.FindControl("ddlcurtype"), DropDownList)
                If ctrl12 IsNot Nothing Then
                    ddlcurtype = DirectCast(ctrl12, DropDownList)
                    dr(15) = ddlcurtype.SelectedValue
                    ddlcurtype.Visible = True
                End If
                Dim ctrl13 As Control = TryCast(row.FindControl("imgAdd"), LinkButton)
                If ctrl13 IsNot Nothing Then
                    imgAdd = DirectCast(ctrl13, LinkButton)
                End If
                table.Rows.Add(dr)
            Next
            Dim emptyrow As DataRow
            emptyrow = table.NewRow()
            emptyrow("ScheID") = 0
            emptyrow("BannerID") = 0
            emptyrow("SpecID") = 0
            emptyrow("PublisherID") = 0
            emptyrow("CurType") = 1
            emptyrow("VolDisc") = 0
            emptyrow("AgencyComm") = 0
            emptyrow("RedirectLink") = "http://"
            table.Rows.Add(emptyrow)
            ViewState("table") = table
            gvschedule.DataSource = table
            gvschedule.DataBind()
            'disableallrows(1)
        Catch ex As Exception
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Error encountered, Please try again"
        End Try
    End Sub
    Private Sub InsertExternalRow(ByVal e_ As Integer)
        Try
            Dim table As DataTable = getemptytable(2)
            For Each row In gvexternal.Rows
                Dim dr As DataRow
                dr = table.NewRow()
                Dim LblID As Label = Nothing
                Dim ddlsource As DropDownList = Nothing
                Dim ddlbanner2 As DropDownList = Nothing
                Dim ddlcostspec2 As DropDownList = Nothing
                Dim txtunitprice2 As TextBox = Nothing
                Dim txtvoldisc2 As TextBox = Nothing
                Dim txtagencycomm2 As TextBox = Nothing
                Dim txtstart2 As TextBox = Nothing
                Dim txtend2 As TextBox = Nothing
                Dim txtlink2 As TextBox = Nothing
                Dim txtduration2 As TextBox = Nothing
                Dim ddlcurtype2 As DropDownList = Nothing
                Dim imgAdd As LinkButton = Nothing
                Dim ctrl11 As Control = TryCast(row.FindControl("LblID2"), Label)
                If ctrl11 IsNot Nothing Then
                    LblID = DirectCast(ctrl11, Label)
                    dr(0) = LblID.Text
                End If
                Dim ctrl As Control = TryCast(row.FindControl("ddlsource"), DropDownList)
                If ctrl IsNot Nothing Then
                    ddlsource = DirectCast(ctrl, DropDownList)
                    dr(2) = ddlsource.SelectedValue
                    ddlsource.Visible = True

                End If
                Dim ctrl2 As Control = TryCast(row.FindControl("ddlbanner2"), DropDownList)
                If ctrl2 IsNot Nothing Then
                    ddlbanner2 = DirectCast(ctrl2, DropDownList)
                    dr(3) = ddlbanner2.SelectedValue
                    dr(4) = ddlbanner2.SelectedItem
                    ddlbanner2.Visible = True
                End If
                Dim ctrl3 As Control = TryCast(row.FindControl("ddlcostspec2"), DropDownList)
                If ctrl3 IsNot Nothing Then
                    ddlcostspec2 = DirectCast(ctrl3, DropDownList)
                    dr(5) = ddlcostspec2.SelectedValue
                    dr(6) = ddlcostspec2.SelectedItem
                    ddlcostspec2.Visible = True
                End If
                Dim ctrl8 As Control = TryCast(row.FindControl("txtunitprice2"), TextBox)
                If ctrl8 IsNot Nothing Then
                    txtunitprice2 = DirectCast(ctrl8, TextBox)
                    dr(7) = txtunitprice2.Text
                    txtunitprice2.Visible = True
                End If
                Dim ctrl4 As Control = TryCast(row.FindControl("txtvoldisc2"), TextBox)
                If ctrl4 IsNot Nothing Then
                    txtvoldisc2 = DirectCast(ctrl4, TextBox)
                    dr(8) = txtvoldisc2.Text
                    txtvoldisc2.Visible = True
                End If
                Dim ctrl5 As Control = TryCast(row.FindControl("txtagencycomm2"), TextBox)
                If ctrl5 IsNot Nothing Then
                    txtagencycomm2 = DirectCast(ctrl5, TextBox)
                    dr(9) = txtagencycomm2.Text
                    txtagencycomm2.Visible = True
                End If
                Dim ctrl6 As Control = TryCast(row.FindControl("txtstart2"), TextBox)
                If ctrl6 IsNot Nothing Then
                    txtstart2 = DirectCast(ctrl6, TextBox)
                    dr(10) = txtstart2.Text
                    txtstart2.Visible = True
                End If
                Dim ctrl7 As Control = TryCast(row.FindControl("txtend2"), TextBox)
                If ctrl7 IsNot Nothing Then
                    txtend2 = DirectCast(ctrl7, TextBox)
                    dr(11) = txtend2.Text
                    txtend2.Visible = True
                End If
                Dim ctrl9 As Control = TryCast(row.FindControl("txtlink2"), TextBox)
                If ctrl9 IsNot Nothing Then
                    txtlink2 = DirectCast(ctrl9, TextBox)
                    dr(12) = txtlink2.Text
                    txtlink2.Visible = True
                End If
                Dim ctrl10 As Control = TryCast(row.FindControl("txtduration2"), TextBox)
                If ctrl10 IsNot Nothing Then
                    txtduration2 = DirectCast(ctrl10, TextBox)
                    dr(13) = txtduration2.Text
                    txtduration2.Visible = True
                End If
                Dim ctrl13 As Control = TryCast(row.FindControl("ddlcurtype2"), DropDownList)
                If ctrl13 IsNot Nothing Then
                    ddlcurtype2 = DirectCast(ctrl13, DropDownList)
                    dr(14) = ddlcurtype2.SelectedValue
                    ddlcurtype2.Visible = True
                End If
                table.Rows.Add(dr)
            Next
            Dim emptyrow As DataRow
            emptyrow = table.NewRow()
            emptyrow("ScheID") = 0
            emptyrow("BannerID") = 0
            emptyrow("SpecID") = 0
            emptyrow("PublisherID") = 0
            emptyrow("CurType") = 2
            emptyrow("VolDisc") = 0
            emptyrow("AgencyComm") = 0
            emptyrow("RedirectLink") = "http://"
            table.Rows.Add(emptyrow)
            ViewState("table2") = table
            gvexternal.DataSource = table
            gvexternal.DataBind()
            disableallrows(2)
        Catch ex As Exception
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Error encountered, Please try again"
        End Try
    End Sub
    Private Sub Deleterows(ByVal e_ As Integer, ByVal type As Integer)
        If type = 1 Then
            Dim table As DataTable = getemptytable(1)
            Dim dr As DataRow
            For Each row In gvschedule.Rows
                dr = table.NewRow()
                Dim ctrl11 As Control = TryCast(row.FindControl("LblID"), Label)
                If ctrl11 IsNot Nothing Then
                    Dim LID As Label = DirectCast(ctrl11, Label)
                    dr(0) = LID.Text
                End If
                Dim ctrl As Control = TryCast(row.FindControl("ddlpublisher"), DropDownList)
                If ctrl IsNot Nothing Then
                    Dim ddlpublisher As DropDownList = DirectCast(ctrl, DropDownList)
                    dr(2) = ddlpublisher.SelectedValue
                End If
                Dim ctrl1 As Control = TryCast(row.FindControl("txtpubadd"), Label)
                If ctrl1 IsNot Nothing Then
                    Dim txtpubadd As Label = DirectCast(ctrl1, Label)
                    dr(3) = txtpubadd.Text
                End If
                Dim ctrl2 As Control = TryCast(row.FindControl("ddlbanner"), DropDownList)
                If ctrl2 IsNot Nothing Then
                    Dim ddlbanner As DropDownList = DirectCast(ctrl2, DropDownList)
                    dr(4) = ddlbanner.SelectedValue

                    dr(5) = ddlbanner.SelectedItem
                End If
                Dim ctrl3 As Control = TryCast(row.FindControl("ddlcostspec"), DropDownList)
                If ctrl3 IsNot Nothing Then
                    Dim ddlcostspec As DropDownList = DirectCast(ctrl3, DropDownList)
                    dr(6) = ddlcostspec.SelectedValue
                    dr(7) = ddlcostspec.SelectedItem
                End If
                Dim ctrl8 As Control = TryCast(row.FindControl("txtunitprice"), TextBox)
                If ctrl8 IsNot Nothing Then
                    Dim txtunitprice As TextBox = DirectCast(ctrl8, TextBox)
                    dr(8) = txtunitprice.Text
                End If
                Dim ctrl4 As Control = TryCast(row.FindControl("txtvoldisc"), TextBox)
                If ctrl4 IsNot Nothing Then
                    Dim txtvoldisc As TextBox = DirectCast(ctrl4, TextBox)
                    dr(9) = txtvoldisc.Text
                End If
                Dim ctrl5 As Control = TryCast(row.FindControl("txtagencycomm"), TextBox)
                If ctrl5 IsNot Nothing Then
                    Dim txtagencycomm As TextBox = DirectCast(ctrl5, TextBox)
                    dr(10) = txtagencycomm.Text
                End If
                Dim ctrl6 As Control = TryCast(row.FindControl("txtstart"), TextBox)
                If ctrl6 IsNot Nothing Then
                    Dim txtstart As TextBox = DirectCast(ctrl6, TextBox)
                    dr(11) = txtstart.Text
                End If
                Dim ctrl7 As Control = TryCast(row.FindControl("txtend"), TextBox)
                If ctrl7 IsNot Nothing Then
                    Dim txtend As TextBox = DirectCast(ctrl7, TextBox)
                    dr(12) = txtend.Text
                End If
                Dim ctrl9 As Control = TryCast(row.FindControl("txtlink"), TextBox)
                If ctrl9 IsNot Nothing Then
                    Dim txtlink As TextBox = DirectCast(ctrl9, TextBox)
                    dr(13) = txtlink.Text
                End If
                Dim ctrl10 As Control = TryCast(row.FindControl("txtduration"), TextBox)
                If ctrl10 IsNot Nothing Then
                    Dim txtduration As TextBox = DirectCast(ctrl10, TextBox)
                    dr(14) = txtduration.Text
                End If
                Dim ctrl12 As Control = TryCast(row.FindControl("ddlcurtype"), DropDownList)
                If ctrl12 IsNot Nothing Then
                    Dim ddlcurtype As DropDownList = DirectCast(ctrl12, DropDownList)
                    dr(15) = ddlcurtype.SelectedValue
                End If
                table.Rows.Add(dr)

            Next
            table.Rows.RemoveAt(e_)
            ViewState("table") = table
            gvschedule.DataSource = table
            gvschedule.DataBind()
        Else
            Dim table As DataTable = getemptytable(2)
            Dim dr As DataRow
            For Each row In gvexternal.Rows
                dr = table.NewRow()
                Dim ctrl11 As Control = TryCast(row.FindControl("LblID2"), Label)
                If ctrl11 IsNot Nothing Then
                    Dim LID2 As Label = DirectCast(ctrl11, Label)
                    dr(0) = LID2.Text
                End If
                Dim ctrl As Control = TryCast(row.FindControl("ddlsource"), DropDownList)
                If ctrl IsNot Nothing Then
                    Dim ddlsource As DropDownList = DirectCast(ctrl, DropDownList)
                    dr(2) = ddlsource.SelectedValue
                End If
                Dim ctrl2 As Control = TryCast(row.FindControl("ddlbanner2"), DropDownList)
                If ctrl2 IsNot Nothing Then
                    Dim ddlbanner2 As DropDownList = DirectCast(ctrl2, DropDownList)
                    dr(3) = ddlbanner2.SelectedValue

                    dr(4) = ddlbanner2.SelectedItem
                End If
                Dim ctrl3 As Control = TryCast(row.FindControl("ddlcostspec2"), DropDownList)
                If ctrl3 IsNot Nothing Then
                    Dim ddlcostspec2 As DropDownList = DirectCast(ctrl3, DropDownList)
                    dr(5) = ddlcostspec2.SelectedValue
                    dr(6) = ddlcostspec2.SelectedItem
                End If
                Dim ctrl8 As Control = TryCast(row.FindControl("txtunitprice2"), TextBox)
                If ctrl8 IsNot Nothing Then
                    Dim txtunitprice2 As TextBox = DirectCast(ctrl8, TextBox)
                    dr(7) = txtunitprice2.Text
                End If
                Dim ctrl4 As Control = TryCast(row.FindControl("txtvoldisc2"), TextBox)
                If ctrl4 IsNot Nothing Then
                    Dim txtvoldisc2 As TextBox = DirectCast(ctrl4, TextBox)
                    dr(8) = txtvoldisc2.Text
                End If
                Dim ctrl5 As Control = TryCast(row.FindControl("txtagencycomm2"), TextBox)
                If ctrl5 IsNot Nothing Then
                    Dim txtagencycomm2 As TextBox = DirectCast(ctrl5, TextBox)
                    dr(9) = txtagencycomm2.Text
                End If
                Dim ctrl6 As Control = TryCast(row.FindControl("txtstart2"), TextBox)
                If ctrl6 IsNot Nothing Then
                    Dim txtstart2 As TextBox = DirectCast(ctrl6, TextBox)
                    dr(10) = txtstart2.Text
                End If
                Dim ctrl7 As Control = TryCast(row.FindControl("txtend2"), TextBox)
                If ctrl7 IsNot Nothing Then
                    Dim txtend2 As TextBox = DirectCast(ctrl7, TextBox)
                    dr(11) = txtend2.Text
                End If
                Dim ctrl9 As Control = TryCast(row.FindControl("txtlink2"), TextBox)
                If ctrl9 IsNot Nothing Then
                    Dim txtlink2 As TextBox = DirectCast(ctrl9, TextBox)
                    dr(12) = txtlink2.Text
                End If
                Dim ctrl10 As Control = TryCast(row.FindControl("txtduration2"), TextBox)
                If ctrl10 IsNot Nothing Then
                    Dim txtduration2 As TextBox = DirectCast(ctrl10, TextBox)
                    dr(13) = txtduration2.Text
                End If
                Dim ctrl12 As Control = TryCast(row.FindControl("ddlcurtype2"), DropDownList)
                If ctrl12 IsNot Nothing Then
                    Dim ddlcurtype2 As DropDownList = DirectCast(ctrl12, DropDownList)
                    dr(14) = ddlcurtype2.SelectedValue
                End If
                table.Rows.Add(dr)

            Next
            table.Rows.RemoveAt(e_)
            ViewState("table2") = table
            gvexternal.DataSource = table
            gvexternal.DataBind()
        End If

    End Sub
    Protected Sub gvexternal_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvexternal.RowCommand

        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        Try
            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvexternal.Rows(e_)
            If CType(e.CommandSource, LinkButton).ID = "imgAdd2" Then
                If CType(e.CommandSource, LinkButton).Text = "<i class='fa fa-2x fa-plus text-success'></i>" Then
                    If gvexternal.Rows.Count = 1 Then
                        InsertExternalRow(e_)
                        disableallrows(2)
                    Else
                        If Page.IsValid Then
                            If checkexternalrows(e_ - 1) = True Then
                                InsertExternalRow(e_)
                                disableallrows(2)
                            Else
                                divsuccess.Attributes("class") = "alert alert-danger"
                                divsuccess.Style.Add("display", "block")
                                errormsg.InnerHtml = "<strong>Error!</strong> Please fill in all information"
                            End If
                        Else
                            divsuccess.Attributes("class") = "alert alert-danger"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Invalid Submission!</strong> Please fill in required information"
                        End If
                        
                    End If
                Else
                    Dim lID As Label = Nothing
                    Dim control As Control = TryCast(rowe.FindControl("LblID2"), Label)
                    If control IsNot Nothing Then
                        lID = DirectCast(control, Label)
                    End If
                    If lID.Text = 0 Then
                        If gvexternal.Rows.Count = 1 Then

                        Else
                            Deleterows(e_, 2)
                            disableallrows(2)
                        End If

                    ElseIf lID.Text <> 0 Then
                        If LblDelete2.Text = "" Then
                            LblDelete2.Text = lID.Text
                        Else
                            LblDelete2.Text = LblDelete2.Text + "," + lID.Text
                        End If
                        Deleterows(e_, 2)
                        disableallrows(2)
                    End If

                End If

            End If


        Catch ex As Exception

        End Try

    End Sub


    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click

        If checkrows() = True Then
            Try
                Dim count As Integer
                Dim count2 As Integer
                Dim table As DataTable = getemptytable(1)
                For count = 0 To gvschedule.Rows.Count - 2
                    Dim LblID As Label = Nothing
                    Dim ddlpublisher As DropDownList = Nothing
                    Dim txtpubadd As Label = Nothing
                    Dim ddlbanner As DropDownList = Nothing
                    Dim ddlcostspec As DropDownList = Nothing
                    Dim txtunitprice As TextBox = Nothing
                    Dim txtvoldisc As TextBox = Nothing
                    Dim txtagencycomm As TextBox = Nothing
                    Dim txtstart As TextBox = Nothing
                    Dim txtend As TextBox = Nothing
                    Dim txtlink As TextBox = Nothing
                    Dim txtduration As TextBox = Nothing
                    Dim ddlcurtype As DropDownList = Nothing
                    Dim ctrl11 As Control = TryCast(gvschedule.Rows(count).FindControl("LblID"), Label)
                    If ctrl11 IsNot Nothing Then
                        LblID = DirectCast(ctrl11, Label)
                    End If
                    Dim ctrl As Control = TryCast(gvschedule.Rows(count).FindControl("ddlpublisher"), DropDownList)
                    If ctrl IsNot Nothing Then
                        ddlpublisher = DirectCast(ctrl, DropDownList)
                    End If
                    Dim ctrl1 As Control = TryCast(gvschedule.Rows(count).FindControl("txtpubadd"), Label)
                    If ctrl1 IsNot Nothing Then
                        txtpubadd = DirectCast(ctrl1, Label)
                    End If
                    Dim ctrl2 As Control = TryCast(gvschedule.Rows(count).FindControl("ddlbanner"), DropDownList)
                    If ctrl2 IsNot Nothing Then
                        ddlbanner = DirectCast(ctrl2, DropDownList)
                    End If
                    Dim ctrl3 As Control = TryCast(gvschedule.Rows(count).FindControl("ddlcostspec"), DropDownList)
                    If ctrl3 IsNot Nothing Then
                        ddlcostspec = DirectCast(ctrl3, DropDownList)
                    End If
                    Dim ctrl8 As Control = TryCast(gvschedule.Rows(count).FindControl("txtunitprice"), TextBox)
                    If ctrl8 IsNot Nothing Then
                        txtunitprice = DirectCast(ctrl8, TextBox)
                    End If
                    Dim ctrl4 As Control = TryCast(gvschedule.Rows(count).FindControl("txtvoldisc"), TextBox)
                    If ctrl4 IsNot Nothing Then
                        txtvoldisc = DirectCast(ctrl4, TextBox)
                    End If
                    Dim ctrl5 As Control = TryCast(gvschedule.Rows(count).FindControl("txtagencycomm"), TextBox)
                    If ctrl5 IsNot Nothing Then
                        txtagencycomm = DirectCast(ctrl5, TextBox)
                    End If
                    Dim ctrl6 As Control = TryCast(gvschedule.Rows(count).FindControl("txtstart"), TextBox)
                    If ctrl6 IsNot Nothing Then
                        txtstart = DirectCast(ctrl6, TextBox)
                    End If
                    Dim ctrl7 As Control = TryCast(gvschedule.Rows(count).FindControl("txtend"), TextBox)
                    If ctrl7 IsNot Nothing Then
                        txtend = DirectCast(ctrl7, TextBox)
                    End If
                    Dim ctrl9 As Control = TryCast(gvschedule.Rows(count).FindControl("txtlink"), TextBox)
                    If ctrl9 IsNot Nothing Then
                        txtlink = DirectCast(ctrl9, TextBox)
                    End If
                    Dim ctrl10 As Control = TryCast(gvschedule.Rows(count).FindControl("txtduration"), TextBox)
                    If ctrl10 IsNot Nothing Then
                        txtduration = DirectCast(ctrl10, TextBox)
                    End If
                    Dim ctrl12 As Control = TryCast(gvschedule.Rows(count).FindControl("ddlcurtype"), DropDownList)
                    If ctrl12 IsNot Nothing Then
                        ddlcurtype = DirectCast(ctrl12, DropDownList)
                    End If
                    If LblDelete.Text <> "" Then
                        Dim deletelines As String() = LblDelete.Text.Trim.Split(",")
                        For j As Integer = 0 To deletelines.Length - 1
                            Dim msg As String = DAL.DeleteScheduleDatabyScheID(CInt(deletelines(j)))
                        Next
                        LblDelete.Text = ""
                    End If
                    If LblID.Text = "0" Then
                        Dim ag As Decimal = Math.Round(CDec(txtagencycomm.Text) / 100, 2, MidpointRounding.AwayFromZero)
                        Dim vd As Decimal = Math.Round(CDec(txtvoldisc.Text) / 100, 2, MidpointRounding.AwayFromZero)
                        Dim calc As Decimal = (1 - ag) * (1 - vd)
                        Dim unitcost As Decimal = CDec(txtunitprice.Text) * calc
                        Dim finalcost As Decimal
                        'If ddlcostspec.SelectedValue = 2 Then
                        '    finalcost = CDec(txtunitprice.Text) * (CDec(txtduration.Text) / 1000)
                        'Else
                        '    finalcost = CDec(txtunitprice.Text) * CDec(txtduration.Text)
                        'End If
                        finalcost = unitcost * CDec(txtduration.Text)
                        Dim cost As String = CStr(finalcost)
                        Dim msg1 As String = DAL.InsertSchedule(LblCampaignID.Text, ddlbanner.SelectedValue, ddlcostspec.SelectedValue, ddlpublisher.SelectedItem.Text, _
                  ddlpublisher.SelectedValue, txtpubadd.Text, txtstart.Text, txtend.Text, txtvoldisc.Text, txtagencycomm.Text, txtunitprice.Text, cost, txtlink.Text, txtduration.Text, ddlcurtype.SelectedValue, 1, unitcost)
                        If msg1 = 0 Then
                            divsuccess.Attributes("class") = "alert alert-danger"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Error!</strong> Error encountered, Refresh page and try again"
                            Exit Try
                        End If

                    Else
                        Dim ag As Decimal = Math.Round(CDec(txtagencycomm.Text) / 100, 2, MidpointRounding.AwayFromZero)
                        Dim vd As Decimal = Math.Round(CDec(txtvoldisc.Text) / 100, 2, MidpointRounding.AwayFromZero)
                        Dim calc As Decimal = (1 - ag) * (1 - vd)
                        Dim unitcost As Decimal = CDec(txtunitprice.Text) * calc
                        Dim finalcost As Decimal
                        'If ddlcostspec.SelectedValue = 2 Then
                        '    finalcost = CDec(txtunitprice.Text) * (CDec(txtduration.Text) / 1000)
                        'Else
                        '    finalcost = CDec(txtunitprice.Text) * CDec(txtduration.Text)
                        'End If
                        finalcost = unitcost * CDec(txtduration.Text)
                        Dim cost As String = CStr(finalcost)
                        Dim msg1 As String = DAL.UpdateSchedule(LblCampaignID.Text, ddlbanner.SelectedValue, ddlcostspec.SelectedValue, ddlpublisher.SelectedItem.Text, _
                  ddlpublisher.SelectedValue, txtpubadd.Text, txtstart.Text, txtend.Text, CDec(txtvoldisc.Text), CDec(txtagencycomm.Text), txtunitprice.Text, cost, txtlink.Text, txtduration.Text, ddlcurtype.SelectedValue, LblID.Text, unitcost)
                        If msg1 = 0 Then
                            divsuccess.Attributes("class") = "alert alert-danger"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Error!</strong> Error encountered, Refresh page and try again"
                            Exit Try
                        End If
                    End If
                Next
                For count2 = 0 To gvexternal.Rows.Count - 2
                    Dim LblID As Label = Nothing
                    Dim ddlsource As DropDownList = Nothing
                    Dim ddlbanner2 As DropDownList = Nothing
                    Dim ddlcostspec2 As DropDownList = Nothing
                    Dim txtunitprice2 As TextBox = Nothing
                    Dim txtvoldisc2 As TextBox = Nothing
                    Dim txtagencycomm2 As TextBox = Nothing
                    Dim txtstart2 As TextBox = Nothing
                    Dim txtend2 As TextBox = Nothing
                    Dim txtlink2 As TextBox = Nothing
                    Dim txtduration2 As TextBox = Nothing
                    Dim ddlcurtype2 As DropDownList = Nothing
                    Dim ctrl11 As Control = TryCast(gvexternal.Rows(count2).FindControl("LblID2"), Label)
                    If ctrl11 IsNot Nothing Then
                        LblID = DirectCast(ctrl11, Label)
                    End If
                    Dim ctrl As Control = TryCast(gvexternal.Rows(count2).FindControl("ddlsource"), DropDownList)
                    If ctrl IsNot Nothing Then
                        ddlsource = DirectCast(ctrl, DropDownList)
                    End If
                    Dim ctrl2 As Control = TryCast(gvexternal.Rows(count2).FindControl("ddlbanner2"), DropDownList)
                    If ctrl2 IsNot Nothing Then
                        ddlbanner2 = DirectCast(ctrl2, DropDownList)
                    End If
                    Dim ctrl3 As Control = TryCast(gvexternal.Rows(count2).FindControl("ddlcostspec2"), DropDownList)
                    If ctrl3 IsNot Nothing Then
                        ddlcostspec2 = DirectCast(ctrl3, DropDownList)
                    End If
                    Dim ctrl8 As Control = TryCast(gvexternal.Rows(count2).FindControl("txtunitprice2"), TextBox)
                    If ctrl8 IsNot Nothing Then
                        txtunitprice2 = DirectCast(ctrl8, TextBox)
                    End If
                    Dim ctrl4 As Control = TryCast(gvexternal.Rows(count2).FindControl("txtvoldisc2"), TextBox)
                    If ctrl4 IsNot Nothing Then
                        txtvoldisc2 = DirectCast(ctrl4, TextBox)
                    End If
                    Dim ctrl5 As Control = TryCast(gvexternal.Rows(count2).FindControl("txtagencycomm2"), TextBox)
                    If ctrl5 IsNot Nothing Then
                        txtagencycomm2 = DirectCast(ctrl5, TextBox)
                    End If
                    Dim ctrl6 As Control = TryCast(gvexternal.Rows(count2).FindControl("txtstart2"), TextBox)
                    If ctrl6 IsNot Nothing Then
                        txtstart2 = DirectCast(ctrl6, TextBox)
                    End If
                    Dim ctrl7 As Control = TryCast(gvexternal.Rows(count2).FindControl("txtend2"), TextBox)
                    If ctrl7 IsNot Nothing Then
                        txtend2 = DirectCast(ctrl7, TextBox)
                    End If
                    Dim ctrl9 As Control = TryCast(gvexternal.Rows(count2).FindControl("txtlink2"), TextBox)
                    If ctrl9 IsNot Nothing Then
                        txtlink2 = DirectCast(ctrl9, TextBox)
                    End If
                    Dim ctrl10 As Control = TryCast(gvexternal.Rows(count2).FindControl("txtduration2"), TextBox)
                    If ctrl10 IsNot Nothing Then
                        txtduration2 = DirectCast(ctrl10, TextBox)
                    End If
                    Dim ctrl13 As Control = TryCast(gvexternal.Rows(count2).FindControl("ddlcurtype2"), DropDownList)
                    If ctrl13 IsNot Nothing Then
                        ddlcurtype2 = DirectCast(ctrl13, DropDownList)
                    End If
                    If LblDelete2.Text <> "" Then
                        Dim deletelines As String() = LblDelete2.Text.Trim.Split(",")
                        For j As Integer = 0 To deletelines.Length - 1
                            Dim msg As String = DAL.DeleteScheduleDatabyScheID(CInt(deletelines(j)))
                        Next
                        LblDelete2.Text = ""
                    End If
                    If LblID.Text = "0" Then
                        Dim ag As Decimal = Math.Round(CDec(txtagencycomm2.Text) / 100, 2, MidpointRounding.AwayFromZero)
                        Dim vd As Decimal = Math.Round(CDec(txtvoldisc2.Text) / 100, 2, MidpointRounding.AwayFromZero)
                        Dim calc As Decimal = (1 - ag) * (1 - vd)
                        Dim unitcost As Decimal = CStr(CDec(txtunitprice2.Text) * calc)
                        Dim finalcost As Decimal
                        'If ddlcostspec2.SelectedValue = 2 Then
                        '    finalcost = CDec(txtunitprice2.Text) * (CDec(txtduration2.Text) / 1000)
                        'Else
                        '    finalcost = CDec(txtunitprice2.Text) * CDec(txtduration2.Text)
                        'End If
                        finalcost = unitcost * CDec(txtduration2.Text)
                        Dim cost As String = CStr(finalcost)
                        Dim msg1 As String = DAL.InsertExternalSchedule(LblCampaignID.Text, ddlbanner2.SelectedValue, ddlcostspec2.SelectedValue, ddlsource.SelectedItem.ToString, _
                                              ddlsource.SelectedValue, txtstart2.Text, txtend2.Text, CDec(txtvoldisc2.Text), CDec(txtvoldisc2.Text), txtunitprice2.Text, cost, txtlink2.Text, txtduration2.Text, ddlcurtype2.SelectedValue, 2, CDec(txtunitprice2.Text))
                        If msg1 = 0 Then
                            divsuccess.Attributes("class") = "alert alert-danger"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Error!</strong> Error encountered, Refresh page and try again"
                            Exit Try
                        End If
                    Else
                        Dim ag As Decimal = Math.Round(CDec(txtagencycomm2.Text) / 100, 2, MidpointRounding.AwayFromZero)
                        Dim vd As Decimal = Math.Round(CDec(txtvoldisc2.Text) / 100, 2, MidpointRounding.AwayFromZero)
                        Dim calc As Decimal = (1 - ag) * (1 - vd)
                        Dim unitcost As Decimal = CStr(CDec(txtunitprice2.Text) * calc)
                        Dim finalcost As Decimal
                        'If ddlcostspec2.SelectedValue = 2 Then
                        '    finalcost = CDec(txtunitprice2.Text) * (CDec(txtduration2.Text) / 1000)
                        'Else
                        '    finalcost = CDec(txtunitprice2.Text) * CDec(txtduration2.Text)
                        'End If
                        finalcost = unitcost * CDec(txtduration2.Text)
                        Dim cost As String = CStr(finalcost)
                        Dim msg1 As String = DAL.UpdateExternalSchedule(LblCampaignID.Text, ddlbanner2.SelectedValue, ddlcostspec2.SelectedValue, ddlsource.SelectedItem.ToString, _
                                              ddlsource.SelectedValue, txtstart2.Text, txtend2.Text, CDec(txtvoldisc2.Text), CDec(txtvoldisc2.Text), txtunitprice2.Text, cost, txtlink2.Text, txtduration2.Text, ddlcurtype2.SelectedValue, LblID.Text, CDec(txtunitprice2.Text))
                        If msg1 = 0 Then
                            divsuccess.Attributes("class") = "alert alert-danger"
                            divsuccess.Style.Add("display", "block")
                            errormsg.InnerHtml = "<strong>Error!</strong> Error encountered, Refresh page and try again"
                            Exit Try
                        End If
                    End If
                Next

                If count = gvschedule.Rows.Count - 1 And count2 = gvexternal.Rows.Count - 1 Then
                    divsuccess.Attributes("class") = "alert alert-success"
                    divsuccess.Style.Add("display", "block")
                    errormsg.InnerHtml = "<strong>Success!</strong> Successfully Saved"
                    rebindtables()
                End If
                If gvschedule.Rows.Count - 2 < 0 And gvexternal.Rows.Count - 2 < 0 Then
                    divsuccess.Attributes("class") = "alert alert-danger"
                    divsuccess.Style.Add("display", "block")
                    errormsg.InnerHtml = "<strong>Error!</strong>No rows added."
                End If
            Catch ex As Exception

                divsuccess.Attributes("class") = "alert alert-danger"
                divsuccess.Style.Add("display", "block")
                errormsg.InnerHtml = "<strong>Error!</strong> Error encountered, Refresh page and try again"
            End Try


        Else
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Please fill in all information"
        End If
       
    End Sub
    Private Function checkrows() As Boolean
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        Try
            For count As Integer = 0 To gvschedule.Rows.Count - 2
                Dim ddlpublisher As DropDownList = Nothing
                Dim txtpubadd As Label = Nothing
                Dim ddlbanner As DropDownList = Nothing
                Dim ddlcostspec As DropDownList = Nothing
                Dim txtunitprice As TextBox = Nothing
                Dim txtvoldisc As TextBox = Nothing
                Dim txtagencycomm As TextBox = Nothing
                Dim txtstart As TextBox = Nothing
                Dim txtend As TextBox = Nothing
                Dim txtlink As TextBox = Nothing
                Dim txtduration As TextBox = Nothing
                Dim ddlcurtype As DropDownList = Nothing

                Dim ctrl As Control = TryCast(gvschedule.Rows(count).FindControl("ddlpublisher"), DropDownList)
                If ctrl IsNot Nothing Then
                    ddlpublisher = DirectCast(ctrl, DropDownList)

                End If
                Dim ctrl1 As Control = TryCast(gvschedule.Rows(count).FindControl("txtpubadd"), Label)
                If ctrl1 IsNot Nothing Then
                    txtpubadd = DirectCast(ctrl1, Label)

                End If
                Dim ctrl2 As Control = TryCast(gvschedule.Rows(count).FindControl("ddlbanner"), DropDownList)
                If ctrl2 IsNot Nothing Then
                    ddlbanner = DirectCast(ctrl2, DropDownList)

                End If
                Dim ctrl3 As Control = TryCast(gvschedule.Rows(count).FindControl("ddlcostspec"), DropDownList)
                If ctrl3 IsNot Nothing Then
                    ddlcostspec = DirectCast(ctrl3, DropDownList)

                End If
                Dim ctrl8 As Control = TryCast(gvschedule.Rows(count).FindControl("txtunitprice"), TextBox)
                If ctrl8 IsNot Nothing Then
                    txtunitprice = DirectCast(ctrl8, TextBox)
                End If
                Dim ctrl4 As Control = TryCast(gvschedule.Rows(count).FindControl("txtvoldisc"), TextBox)
                If ctrl4 IsNot Nothing Then
                    txtvoldisc = DirectCast(ctrl4, TextBox)

                End If
                Dim ctrl5 As Control = TryCast(gvschedule.Rows(count).FindControl("txtagencycomm"), TextBox)
                If ctrl5 IsNot Nothing Then
                    txtagencycomm = DirectCast(ctrl5, TextBox)

                End If
                Dim ctrl6 As Control = TryCast(gvschedule.Rows(count).FindControl("txtstart"), TextBox)
                If ctrl6 IsNot Nothing Then
                    txtstart = DirectCast(ctrl6, TextBox)

                End If
                Dim ctrl7 As Control = TryCast(gvschedule.Rows(count).FindControl("txtend"), TextBox)
                If ctrl7 IsNot Nothing Then
                    txtend = DirectCast(ctrl7, TextBox)

                End If
                Dim ctrl9 As Control = TryCast(gvschedule.Rows(count).FindControl("txtlink"), TextBox)
                If ctrl9 IsNot Nothing Then
                    txtlink = DirectCast(ctrl9, TextBox)

                End If
                Dim ctrl10 As Control = TryCast(gvschedule.Rows(count).FindControl("txtduration"), TextBox)
                If ctrl10 IsNot Nothing Then
                    txtduration = DirectCast(ctrl10, TextBox)

                End If

                If ddlpublisher.SelectedValue <> 0 And txtpubadd.Text <> "" And ddlbanner.SelectedValue <> 0 And ddlcostspec.SelectedValue <> 0 And txtunitprice.Text <> "" And txtvoldisc.Text <> "" And _
                 txtagencycomm.Text <> "" And txtstart.Text <> "" And txtend.Text <> "" And txtlink.Text <> "" And txtduration.Text <> "" Then

                Else
                    Return False
                    Exit For
                End If
            Next
        For count As Integer = 0 To gvexternal.Rows.Count - 2
                Dim ddlsource As DropDownList = Nothing
                Dim ddlbanner2 As DropDownList = Nothing
                Dim ddlcostspec2 As DropDownList = Nothing
                Dim txtunitprice2 As TextBox = Nothing
                Dim txtvoldisc2 As TextBox = Nothing
                Dim txtagencycomm2 As TextBox = Nothing
            Dim txtstart2 As TextBox = Nothing
            Dim txtend2 As TextBox = Nothing
            Dim txtlink2 As TextBox = Nothing
            Dim txtduration2 As TextBox = Nothing
            Dim ddlcurtype2 As DropDownList = Nothing
            Dim ctrl As Control = TryCast(gvexternal.Rows(count).FindControl("ddlsource"), DropDownList)
            If ctrl IsNot Nothing Then
                ddlsource = DirectCast(ctrl, DropDownList)
            End If
            Dim ctrl2 As Control = TryCast(gvexternal.Rows(count).FindControl("ddlbanner2"), DropDownList)
            If ctrl2 IsNot Nothing Then
                ddlbanner2 = DirectCast(ctrl2, DropDownList)
            End If
            Dim ctrl3 As Control = TryCast(gvexternal.Rows(count).FindControl("ddlcostspec2"), DropDownList)
            If ctrl3 IsNot Nothing Then
                ddlcostspec2 = DirectCast(ctrl3, DropDownList)
            End If
            Dim ctrl8 As Control = TryCast(gvexternal.Rows(count).FindControl("txtunitprice2"), TextBox)
            If ctrl8 IsNot Nothing Then
                txtunitprice2 = DirectCast(ctrl8, TextBox)
                End If
                Dim ctrl4 As Control = TryCast(gvexternal.Rows(count).FindControl("txtvoldisc2"), TextBox)
                If ctrl4 IsNot Nothing Then
                    txtvoldisc2 = DirectCast(ctrl4, TextBox)

                End If
                Dim ctrl5 As Control = TryCast(gvexternal.Rows(count).FindControl("txtagencycomm2"), TextBox)
                If ctrl5 IsNot Nothing Then
                    txtagencycomm2 = DirectCast(ctrl5, TextBox)

                End If
            Dim ctrl6 As Control = TryCast(gvexternal.Rows(count).FindControl("txtstart2"), TextBox)
            If ctrl6 IsNot Nothing Then
                txtstart2 = DirectCast(ctrl6, TextBox)

            End If
                Dim ctrl7 As Control = TryCast(gvexternal.Rows(count).FindControl("txtend2"), TextBox)
            If ctrl7 IsNot Nothing Then
                txtend2 = DirectCast(ctrl7, TextBox)

            End If
            Dim ctrl9 As Control = TryCast(gvexternal.Rows(count).FindControl("txtlink2"), TextBox)
            If ctrl9 IsNot Nothing Then
                txtlink2 = DirectCast(ctrl9, TextBox)
            End If
            Dim ctrl10 As Control = TryCast(gvexternal.Rows(count).FindControl("txtduration2"), TextBox)
            If ctrl10 IsNot Nothing Then
                txtduration2 = DirectCast(ctrl10, TextBox)
            End If

                If ddlsource.SelectedValue <> 0 And ddlbanner2.SelectedValue <> 0 And ddlcostspec2.SelectedValue <> 0 And txtunitprice2.Text <> "" _
                 And txtstart2.Text <> "" And txtend2.Text <> "" And txtlink2.Text <> "" And txtduration2.Text <> "" And txtunitprice2.Text <> "" And txtvoldisc2.Text <> "" Then

                Else
                    Return False
                    Exit For
                End If

        Next
        
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Sub ddlpublisher_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = TryCast(sender, DropDownList)
            If ddl.SelectedValue <> "0" Then
                If ddl.SelectedValue = "Create New" Then
                    For Each row As GridViewRow In gvschedule.Rows
                        'Finding Dropdown control  
                        Dim ctrl As Control = TryCast(row.FindControl("ddlpublisher"), DropDownList)
                        If ctrl IsNot Nothing Then
                            Dim ddl1 As DropDownList = DirectCast(ctrl, DropDownList)
                            'Comparing ClientID of the dropdown with sender
                            If ddl.ClientID = ddl1.ClientID Then
                                Dim ctrl2 As Control = TryCast(row.FindControl("txtpubadd"), Label)
                                Dim txtpubaddress As Label = DirectCast(ctrl2, Label)
                                txtpubaddress.Text = ""
                            End If
                        End If
                    Next
                    gvPublisher.DataSource = DAL.SelectAgencyorPublisher(4, Session("COMPANYID"))
                    gvPublisher.DataBind()
                    TxtUrl.Text = ""
                    TxtPublisherName.Text = ""
                    ddlurltype.SelectedValue = "http://"
                    LblPublisherID.Text = "0"
                    divsuccessUser.Attributes("class") = "alert alert-danger"
                    divsuccessUser.Style.Add("display", "none")
                    errmsguser.InnerHtml = ""
                    mppublisher.Show()

                Else
                    For Each row As GridViewRow In gvschedule.Rows
                        'Finding Dropdown control  
                        Dim ctrl As Control = TryCast(row.FindControl("ddlpublisher"), DropDownList)
                        If ctrl IsNot Nothing Then
                            Dim ddl1 As DropDownList = DirectCast(ctrl, DropDownList)
                            'Comparing ClientID of the dropdown with sender
                            If ddl.ClientID = ddl1.ClientID Then
                                Dim msg() As String = DAL.SelectPublishersandClientsbyID(4, ddl.SelectedValue)
                                Dim ctrl2 As Control = TryCast(row.FindControl("txtpubadd"), Label)
                                Dim txtpubaddress As Label = DirectCast(ctrl2, Label)
                                txtpubaddress.Text = msg(3)
                            End If
                        End If
                    Next
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSubmitPublisher_Click(sender As Object, e As EventArgs) Handles BtnSubmitPublisher.Click
        divsuccessUser.Attributes("class") = "alert alert-danger"
        divsuccessUser.Style.Add("display", "none")
        errmsguser.InnerHtml = ""
        If Page.IsValid Then
            Try
                If TxtPublisherName.Text.Trim <> "" And TxtUrl.Text.Trim <> "" Then
                    Dim msg As String = DAL.InsertPublisher(LblPublisherID.Text, TxtPublisherName.Text, Session("COMPANYID"), ddlurltype.SelectedValue + TxtUrl.Text)
                    If msg <> 0 Then
                        gvPublisher.DataSource = DAL.SelectAgencyorPublisher(4, Session("COMPANYID"))
                        gvPublisher.DataBind()
                        If LblPublisherID.Text = "0" Then
                            divsuccessUser.Attributes("class") = "alert alert-success"
                            divsuccessUser.Style.Add("display", "block")
                            errmsguser.InnerHtml = "<strong>Success!</strong> New publisher successfully created"
                            mppublisher.Show()
                        Else
                            divsuccessUser.Attributes("class") = "alert alert-success"
                            divsuccessUser.Style.Add("display", "block")
                            errmsguser.InnerHtml = "<strong>Success!</strong> Publisher information updated."
                            mppublisher.Show()
                        End If
                        TxtUrl.Text = ""
                        TxtPublisherName.Text = ""
                        ddlurltype.SelectedValue = "http://"
                        LblPublisherID.Text = "0"
                        Dim table As DataTable = ViewState("table")
                        gvschedule.DataSource = table
                        gvschedule.DataBind()



                    End If
                Else
                    divsuccessUser.Attributes("class") = "alert alert-danger"
                    divsuccessUser.Style.Add("display", "block")
                    errmsguser.InnerHtml = "<strong>Error!</strong> Please fill in all fields"
                    mppublisher.Show()
                End If
            Catch ex As Exception
                divsuccessUser.Attributes("class") = "alert alert-danger"
                divsuccessUser.Style.Add("display", "block")
                errmsguser.InnerHtml = "<strong>Error!</strong>Error encountered, please try again"
                mppublisher.Show()
            End Try
        Else
            divsuccessUser.Attributes("class") = "alert alert-danger"
            divsuccessUser.Style.Add("display", "block")
            errmsguser.InnerHtml = "<strong>Invalid Submission!</strong>Please fill in required information"
            mppublisher.Show()
        End If
        
    End Sub
    Protected Sub gvPublisher_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPublisher.RowCommand
        TxtUrl.Text = ""
        TxtPublisherName.Text = ""
        ddlurltype.SelectedValue = "http://"
        LblPublisherID.Text = "0"
        divsuccessUser.Attributes("class") = "alert alert-danger"
        divsuccessUser.Style.Add("display", "none")
        errmsguser.InnerHtml = ""
        Try
            Dim Publisherid As Integer
            Dim dr As String() = Nothing
            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvPublisher.Rows(e_)
            If CType(e.CommandSource, LinkButton).ID = "btnEditPublisher" Then
                Dim label As Control = TryCast(gvPublisher.Rows(rowe.RowIndex).FindControl("LblCompanyID"), Label)
                Dim lbl As Label = DirectCast(label, Label)
                Publisherid = lbl.Text
                Dim msg As String() = DAL.SelectPublishersandClientsbyID(4, Publisherid)
                If msg IsNot Nothing Then
                    TxtPublisherName.Text = msg(1)
                    LblPublisherID.Text = msg(0)
                    Dim url As String() = msg(3).ToString.Split("/")
                    If url(0) = "http:" Then
                        ddlurltype.SelectedValue = "http://"
                    Else
                        ddlurltype.SelectedValue = "https://"
                    End If
                    TxtUrl.Text = url(2)
                    mppublisher.Show()
                End If

            End If

        Catch ex As Exception
            'tblShowError.Visible = True
            'lblShowError.Text = ex.Message
        End Try
    End Sub
    Private Sub rebindtables()
        Dim table As DataTable = DAL.SelectSchedulebyCampaign(LblCampaignID.Text)
        Dim dr As DataRow
        dr = table.NewRow()
        dr("ScheID") = 0
        dr("BannerID") = 0
        dr("SpecID") = 0
        dr("PublisherID") = 0
        dr("CurType") = 1
        dr("VolDisc") = 0
        dr("AgencyComm") = 0
        dr("RedirectLink") = "http://"
        table.Rows.Add(dr)
        ViewState("table") = table
        gvschedule.DataSource = table
        gvschedule.DataBind()

        disableallrows(1)
        Dim table2 As DataTable = DAL.SelectExternalSchedulebyCampaign(LblCampaignID.Text)
        Dim dr2 As DataRow
        dr2 = table2.NewRow()
        dr2("ScheID") = 0
        dr2("BannerID") = 0
        dr2("SpecID") = 0
        dr2("PublisherID") = 0
        dr2("VolDisc") = 0
        dr2("AgencyComm") = 0
        dr2("RedirectLink") = "http://"
        dr2("CurType") = 2
        table2.Rows.Add(dr2)
        ViewState("table2") = table2
        gvexternal.DataSource = table2
        gvexternal.DataBind()
        disableallrows(2)
    End Sub
    Protected Sub BtnProcced_Click(sender As Object, e As EventArgs) Handles BtnProcced.Click
        Response.Redirect("Approval.aspx?ID=" + LblCampaignID.Text)
    End Sub
End Class
