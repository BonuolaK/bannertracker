Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Web.Script.Serialization


Partial Class CreateCampaign
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("ROLEID") = 1 Then
                'astep1.Attributes("style") = "border-color: #eaeef1 !important; border-bottom-color: #fff !important; background-color: #ffffff;"
                step1.Style.Add("display", "block")
                divprogress.Style.Add("width", "10%")
                ddlClient.DataSource = DAL.SelectClient(Session("COMPANYID"))
                ddlClient.DataBind()
                Dim newItem As New ListItem("Please Select", "0")
                ddlClient.Items.Add(newItem)
                ddlClient.SelectedValue = 0

                Dim newItem1 As New ListItem("Please Select", "0")
                ddlBrand.Items.Add(newItem1)
                ddlBrand.SelectedValue = 0
            Else
                Response.Redirect("Overview.aspx")
            End If
          



        End If
    End Sub

    Protected Sub BtnSubmit1_Click(sender As Object, e As EventArgs) Handles BtnSubmit1.Click
        Try
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "none")
            errormsg.InnerHtml = ""
            If ddlClient.SelectedValue <> 0 And ddlBrand.SelectedValue <> 0 Then


                If TxtName.Text <> "" And TxtBannerNo.Text <> "0" Then
                    If lblcampaignID.Text = "0" Then
                        Dim msg1 As String() = DAL.ValidateCampaignName(TxtName.Text)
                        If msg1 IsNot Nothing Then
                            If msg1(0) = "" Then
                                insertcampaign()
                            Else
                                divsuccess.Attributes("class") = "alert alert-danger"
                                divsuccess.Style.Add("display", "block")
                                errormsg.InnerHtml = "<strong>Error!</strong> This campaign name already exists."
                            End If



                        End If
                    Else
                        If lblName.Text = TxtName.Text Then
                            insertcampaign()
                        Else
                            Dim msg1 As String() = DAL.ValidateCampaignName(TxtName.Text)
                            If msg1 IsNot Nothing Then
                                If msg1(0) = "" Then
                                    insertcampaign()
                                Else
                                    divsuccess.Attributes("class") = "alert alert-danger"
                                    divsuccess.Style.Add("display", "block")
                                    errormsg.InnerHtml = "<strong>Error!</strong> This campaign name already exists."
                                End If



                            End If
                        End If

                    End If
                Else
                    divsuccess.Attributes("class") = "alert alert-danger"
                    divsuccess.Style.Add("display", "block")
                    errormsg.InnerHtml = "<strong>Error!</strong> Please fill in all data."

                End If
            Else

                divsuccess.Attributes("class") = "alert alert-danger"
                divsuccess.Style.Add("display", "block")
                errormsg.InnerHtml = "<strong>Error!</strong> Please fill in all data."
               

            End If

        Catch ex As Exception

            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
        End Try

    End Sub
    'Private Sub insertcampaign()

    '    Dim msg As String = DAL.InsertCampaign(TxtName.Text, TxtBannerNo.Text, ddlBrand.SelectedValue, lblcampaignID.Text, Session("COMPANYID"), Session("USERID"))
    '    If msg <> 0 Then

    '        astep1.Attributes("style") = "background-color: #f9fafc; border-color: #eaeef1;"
    '        astep2.Attributes("style") = "border-color: #eaeef1 !important; border-bottom-color: #fff !important; background-color: #ffffff;"
    '        'margin: -10px -15px;margin: -11px -16px; margin: 0;padding-top: 11px;paddinbg-bottom: 11px;
    '        step1.Style.Add("display", "none")
    '        step2.Style.Add("display", "block")
    '        divprogress.Style.Add("width", "100%")
    '        If lblcampaignID.Text = "0" Then
    '            Dim msg2 As String() = DAL.ValidateCampaignName(Trim(TxtName.Text))
    '            If msg2 IsNot Nothing Then
    '                lblName.Text = TxtName.Text
    '                lblcampaignID.Text = msg2(0)
    '            End If
    '            Dim msg1 As String = DAL.InsertNotification(Session("USERID"), Session("COMPANYID"), 1, lblcampaignID.Text)
    '        Else
    '            Dim msg2 As String() = DAL.ValidateCampaignName(Trim(TxtName.Text))
    '            If msg2 IsNot Nothing Then
    '                lblName.Text = TxtName.Text
    '                lblcampaignID.Text = msg2(0)
    '            End If
    '        End If


    '        Dim table As DataTable = getemptytable()
    '        'Dim i As Integer = CInt(TxtBannerNo.Text)
    '        For i = 0 To CInt(TxtBannerNo.Text) - 1
    '            table.Rows.Add("")
    '        Next

    '        gvbanner.DataSource = table
    '        gvbanner.DataBind()
    '    Else
    '        divsuccess.Attributes("class") = "alert alert-danger"
    '        divsuccess.Style.Add("display", "block")
    '        errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
    '    End If

    'End Sub
    Protected Sub ddlClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClient.SelectedIndexChanged
        ddlBrand.DataSource = DAL.SelectBrandByClientID(ddlClient.SelectedValue, Session("COMPANYID"))
        ddlBrand.DataBind()
        Dim newItem1 As New ListItem("Please Select", "0")
        ddlBrand.Items.Add(newItem1)
        ddlBrand.SelectedValue = 0
    End Sub
    Public Function getemptytable() As DataTable
        Dim table As New DataTable
        table.Columns.Add("Upload", GetType(String))
        table.Columns.Add("Banner", GetType(String))



        Return table
    End Function

    Protected Sub BtnAdd_Click1(sender As Object, e As EventArgs) Handles BtnAdd.Click
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        Dim table As DataTable = getemptytable()
        Dim dr As DataRow
        For Each row In gvbanner.Rows
            dr = table.NewRow()
            Dim ctrl As Control = TryCast(row.FindControl("txtbanner"), TextBox)
            If ctrl IsNot Nothing Then
                Dim txtbanner As TextBox = DirectCast(ctrl, TextBox)
                dr(1) = txtbanner.Text
            End If

            table.Rows.Add(dr)
        Next
        dr = table.NewRow()
        table.Rows.Add(dr)
        gvbanner.DataSource = table
        gvbanner.DataBind()

    End Sub

    Protected Sub BtnModify_Click(sender As Object, e As EventArgs) Handles BtnModify.Click
       
        astep2.Attributes("style") = "background-color: #f9fafc;border-color: #eaeef1;"
            astep1.Attributes("style") = "border-color: #eaeef1 !important; border-bottom-color: #fff !important; background-color: #ffffff;"
            'margin: -10px -15px;margin: -11px -16px; margin: 0;padding-top: 11px;padding-bottom: 11px;
            step2.Style.Add("display", "none")
            step1.Style.Add("display", "block")
            divprogress.Style.Add("width", "50%")


    End Sub

    Protected Sub BtnSchedule_Click(sender As Object, e As EventArgs) Handles BtnSchedule.Click
        If checkrows() = True Then
            For Each row In gvbanner.Rows

                Dim txtbanner As TextBox = Nothing
                Dim fubanner As FileUpload = Nothing
                Dim imgsize As String
                Dim ctrl As Control = TryCast(row.FindControl("fuBanner"), FileUpload)
                If ctrl IsNot Nothing Then
                    fubanner = DirectCast(ctrl, FileUpload)
                End If
                Dim ctrl1 As Control = TryCast(row.FindControl("txtbanner"), TextBox)
                If ctrl1 IsNot Nothing Then
                    txtbanner = DirectCast(ctrl1, TextBox)
                End If
                Dim pathToCreate As String = "~/banner/" + Session("COMPANY") + Session("COMPANYID")
                If Directory.Exists(Server.MapPath(pathToCreate)) = False Then
                    Directory.CreateDirectory(Server.MapPath(pathToCreate))
                End If
                Dim filename As String = Path.GetFileName(fubanner.FileName)
                Dim filenameWOExt As String = Path.GetFileNameWithoutExtension(fubanner.FileName)
                Dim ext As String = Path.GetExtension(fubanner.FileName)
                Dim fulldirect As String = Server.MapPath(pathToCreate + "/") + filename
                Dim savepath As String = Server.MapPath(pathToCreate + "/")
                Dim pathtocheck As String = savepath + filename
                Dim counter As Integer = 1
                Dim tempfilename As String = ""
                If File.Exists(pathtocheck) Then
                    While File.Exists(pathtocheck)
                        tempfilename = filenameWOExt + "(" + counter.ToString() + ")" + ext
                        pathtocheck = savepath + tempfilename
                        counter += 1
                    End While
                    filename = tempfilename
                End If
                savepath += filename
                'Dim url As String = "\\banner\\" + filename
                ' Dim fulldirect As String = Server.MapPath("~/") + url
                fubanner.SaveAs(savepath)
                Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(fubanner.PostedFile.InputStream)
                imgsize = CStr(img.Width) + " x " + CStr(img.Height)
                'Dim msg1 As String = DAL.InsertBanner(txtbanner.Text, imgsize, lblcampaignID.Text, Path.GetExtension(filename), "banner/" + Session("COMPANY") + Session("COMPANYID") + "/" + filename, 0)
            Next
            'Dim msg As String = DAL.UpdateCampaignBannerNo(lblcampaignID.Text, gvbanner.Rows.Count())
            'If msg <> 0 Then
            'Page.Response.Redirect("CreateSchedule.aspx?Id=" + lblcampaignID.Text)
            'End If
        Else
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "block")
        errormsg.InnerHtml = "<strong>Error!</strong> Please upload a valid image below 50KB and insert a name or delete any unused lines"
        End If



    End Sub
    Private Function checkrows() As Boolean
        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        For Each row In gvbanner.Rows
            Dim txtbanner As TextBox = Nothing
            Dim fubanner As FileUpload = Nothing

            Dim ctrl As Control = TryCast(row.FindControl("fuBanner"), FileUpload)
            If ctrl IsNot Nothing Then
                fubanner = DirectCast(ctrl, FileUpload)
            End If
            Dim ctrl1 As Control = TryCast(row.FindControl("txtbanner"), TextBox)
            If ctrl1 IsNot Nothing Then
                txtbanner = DirectCast(ctrl1, TextBox)
            End If
            If fubanner.HasFile And txtbanner.Text <> "" Then
                Dim filename As String = Path.GetFileName(fubanner.FileName)
                If Path.GetExtension(filename) = ".jpg" Or Path.GetExtension(filename) = ".JPG" Or Path.GetExtension(filename) = ".jpeg" Or Path.GetExtension(filename) = ".JPEG" _
                    Or Path.GetExtension(filename) = ".swf" Or Path.GetExtension(filename) = ".SWF" Or Path.GetExtension(filename) = ".png" Or Path.GetExtension(filename) = ".PNG" _
                Or Path.GetExtension(filename) = ".gif" Or Path.GetExtension(filename) = ".GIF" Then
                    If fubanner.PostedFile.ContentLength > 50176 Then
                        Return False
                        Exit For
                    End If

                Else
                    Return False
                    Exit For
                End If
            Else
                Return False
                Exit For
            End If
        Next
        Return True
    End Function


    Protected Sub gvbanner_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvbanner.RowCommand

        divsuccess.Attributes("class") = "alert alert-danger"
        divsuccess.Style.Add("display", "none")
        errormsg.InnerHtml = ""
        Try
           
            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvbanner.Rows(e_)
            If CType(e.CommandSource, LinkButton).ID = "imgDelete" Then

                Dim table As DataTable = getemptytable()
                Dim dr As DataRow
                For Each row In gvbanner.Rows
                    dr = table.NewRow()
                    Dim ctrl As Control = TryCast(row.FindControl("txtbanner"), TextBox)
                    If ctrl IsNot Nothing Then
                        Dim txtbanner As TextBox = DirectCast(ctrl, TextBox)
                        dr(1) = txtbanner.Text
                    End If

                    table.Rows.Add(dr)

                Next
                table.Rows.RemoveAt(e_)

                gvbanner.DataSource = table
                gvbanner.DataBind()

              

            End If

        Catch ex As Exception

        End Try

    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function GetBrand(ByVal ClientID As String) As String
        If ClientID.Trim() <> "" Then
            ' check if the session has expired
            If HttpContext.Current.Session("COMPANYID") <> Nothing Then
                Dim list As List(Of Brands) = New List(Of Brands)
                Dim dt As DataTable = DAL.SelectBrandByClientID(Convert.ToInt32(ClientID), HttpContext.Current.Session("COMPANYID"))
                For Each dr As DataRow In dt.Rows
                    Dim brand As Brands = New Brands
                    brand.id = dr("BrandID").ToString()
                    brand.name = dr("BrandName").ToString()
                    list.Add(brand)
                Next
                Dim ser As JavaScriptSerializer = New JavaScriptSerializer()
                Return ser.Serialize(list)
            Else
                Return "False"
            End If
        Else
            Return "False"
        End If
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function NewCampaign(ByVal ClientID As String, ByVal BrandID As String, ByVal CampaignName As String, ByVal BannerNo As String, ByVal CampaignID As String) As String
        If ClientID.Trim() <> "" And BrandID.Trim() <> "" And CampaignName.Trim() <> "" And BannerNo.Trim() <> "" And CampaignID.Trim() <> "" Then


            ' insert the campaign details
            ' DAL.InsertCampaign(TxtName.Text, TxtBannerNo.Text, ddlBrand.SelectedValue, lblcampaignID.Text, Session("COMPANYID"), Session("USERID"))
            Dim msg As String() = DAL.ValidateCampaignName(CampaignName.Trim())

            Dim campgID As String

            'Insert new campaign
            If (CampaignID = "0") Then
                If msg(0) = Nothing Then

                    Dim msg1 As String = DAL.InsertCampaign(CampaignName, BannerNo, BrandID, CampaignID, HttpContext.Current.Session("COMPANYID"), HttpContext.Current.Session("USERID"))
                    If msg1 IsNot Nothing Then
                        Dim msg3 As String() = DAL.ValidateCampaignName(CampaignName.Trim())
                        campgID = msg3(0)
                        'check the CampaignID if zero, insert notification
                        If CampaignID = "0" Then
                            DAL.InsertNotification(HttpContext.Current.Session("USERID"), HttpContext.Current.Session("COMPANYID"), 1, campgID)
                            Return campgID
                        End If
                        Return campgID
                    Else
                        'unable to insert campaign details
                        Return "false"
                    End If

                Else
                    'campaign exists
                    Return "exists"
                End If

                'Update Campaign
            ElseIf (CampaignID <> "0") Then


                Dim msg3 As String() = DAL.ValidateCampaignName(CampaignName.Trim())

                If msg3(0) IsNot Nothing And msg3(0) <> CampaignID Then
                    Return "false"
                Else
                    'update campaign
                    Dim msg1 As String = DAL.InsertCampaign(CampaignName, BannerNo, BrandID, CampaignID, HttpContext.Current.Session("COMPANYID"), HttpContext.Current.Session("USERID"))
                    'check the CampaignID if not zero, insert notification
                    If CampaignID <> "0" Then
                        DAL.InsertNotification(HttpContext.Current.Session("USERID"), HttpContext.Current.Session("COMPANYID"), 1, CampaignID)
                        Return CampaignID
                    End If
                    Return CampaignID
                End If

            Else
                Return "Invalid"
            End If
        Else
            Return "Invalid"
        End If

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ValidateCampaign(ByVal CampaignName As String) As String

        If CampaignName.Trim() <> "" Then
            Dim msg As String() = DAL.ValidateCampaignName(CampaignName)

            If msg(0) = "" Then
                ' campagin dosent exists return false;
                Return "false"
            Else
                ' campaign exists return true
                Return "true"
            End If
        Else
            Return "false"
        End If
    End Function

    Protected Sub BtnCreateCampaign_Click(sender As Object, e As EventArgs)
        'BtnSubmit1_Click(sender, e)
        BtnSchedule_Click(sender, e)
    End Sub

    Private Sub insertcampaign()

        Dim msg As String = DAL.InsertCampaign(TxtName.Text, TxtBannerNo.Text, ddlBrand.SelectedValue, lblcampaignID.Text, Session("COMPANYID"), Session("USERID"))
        If msg <> 0 Then

            astep1.Attributes("style") = "background-color: #f9fafc; border-color: #eaeef1;"
            astep2.Attributes("style") = "border-color: #eaeef1 !important; border-bottom-color: #fff !important; background-color: #ffffff;"
            'margin: -10px -15px;margin: -11px -16px; margin: 0;padding-top: 11px;paddinbg-bottom: 11px;
            step1.Style.Add("display", "none")
            step2.Style.Add("display", "block")
            divprogress.Style.Add("width", "100%")
            If lblcampaignID.Text = "0" Then
                Dim msg2 As String() = DAL.ValidateCampaignName(Trim(TxtName.Text))
                If msg2 IsNot Nothing Then
                    lblName.Text = TxtName.Text
                    lblcampaignID.Text = msg2(0)
                End If
                Dim msg1 As String = DAL.InsertNotification(Session("USERID"), Session("COMPANYID"), 1, lblcampaignID.Text)
            Else
                Dim msg2 As String() = DAL.ValidateCampaignName(Trim(TxtName.Text))
                If msg2 IsNot Nothing Then
                    lblName.Text = TxtName.Text
                    lblcampaignID.Text = msg2(0)
                End If
            End If


            Dim table As DataTable = getemptytable()
            'Dim i As Integer = CInt(TxtBannerNo.Text)
            For i = 0 To CInt(TxtBannerNo.Text) - 1
                table.Rows.Add("")
            Next

            gvbanner.DataSource = table
            gvbanner.DataBind()
        Else
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
        End If

    End Sub
End Class

Public Class Brands
    Public id As String
    Public name As String
End Class
