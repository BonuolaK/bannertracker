Imports System.Data
Imports System.IO
Partial Class ModifyCampaign
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim campaignid As Integer
            If Session("ROLEID") = 1 Then
                If Int32.TryParse(HttpContext.Current.Request.QueryString("ID"), campaignid) = True Then
                    lblcampaignID.Text = campaignid
                    astep1.Attributes("style") = "border-color: #eaeef1 !important; border-bottom-color: #fff !important; background-color: #ffffff;"
                    step1.Style.Add("display", "block")
                    divprogress.Style.Add("width", "50%")
                    Dim msg As String() = DAL.SelectCampaignInfobyID(lblcampaignID.Text)
                    If msg IsNot Nothing Then
                        TxtName.Text = msg(0)
                        lblName.Text = msg(0)
                        lblbannerno.Text = msg(2)
                        ddlClient.DataSource = DAL.SelectClient(Session("COMPANYID"))
                        ddlClient.DataBind()
                        Dim newItem As New ListItem("Please Select", "0")
                        ddlClient.Items.Add(newItem)
                        ddlClient.SelectedValue = msg(1)

                        ddlBrand.DataSource = DAL.SelectBrandByClientID(msg(1), Session("COMPANYID"))
                        ddlBrand.DataBind()
                        ddlBrand.Items.Add(newItem)
                        ddlBrand.SelectedValue = msg(3)
                        If msg(4) = "1" Or msg(4) = "3" Then
                            BtnSubmit1.Enabled = True
                            BtnNewBanner.Enabled = True
                            BtnSchedule.Enabled = True
                            BtnModify.Enabled = True
                        ElseIf msg(4) = "2" Or msg(4) = "4" Or msg(4) = "5" Or msg(4) = "6" Or msg(4) = "7" Or msg(4) = "0" Then
                            BtnSubmit1.Enabled = False
                            BtnNewBanner.Enabled = False
                            BtnSchedule.Enabled = False
                            BtnModify.Enabled = False
                        End If


                    End If
                End If
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


                If TxtName.Text <> "" Then
                    If TxtName.Text <> lblName.Text Then
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
                        insertcampaign()
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
    Private Sub insertcampaign()
        Dim msg As String = DAL.InsertCampaign(TxtName.Text, lblbannerno.Text, ddlBrand.SelectedValue, lblcampaignID.Text, Session("COMPANYID"), Session("USERID"))
        If msg <> 0 Then
            astep1.Attributes("style") = "background-color: #f9fafc; border-color: #eaeef1;"
            astep2.Attributes("style") = "border-color: #eaeef1 !important; border-bottom-color: #fff !important; background-color: #ffffff;"
            'margin: -10px -15px;margin: -11px -16px; margin: 0;padding-top: 11px;padding-bottom: 11px;
            step1.Style.Add("display", "none")
            step2.Style.Add("display", "block")
            divprogress.Style.Add("width", "100%")
            lblName.Text = TxtName.Text
            gvExistingBanners.DataSource = DAL.SelectBannerbyCampaignID(lblcampaignID.Text)
            gvExistingBanners.DataBind()
            Dim table As DataTable = getemptytable()
            table.Rows.Add("")
            gvbanner.DataSource = table
            gvbanner.DataBind()
           
            If gvExistingBanners.Rows.Count = 0 Then
                If lblbannerno.Text <> "" Or lblbannerno.Text <> "0" Then
                    Dim table2 As DataTable = getemptytable()
                    For i As Integer = 0 To CInt(lblbannerno.Text) - 1
                        table2.Rows.Add("")
                    Next
                    gvbanner.DataSource = table
                    gvbanner.DataBind()
                End If
                gvbanner.Visible = True
                diveditadd.Visible = True
                divexisting.Visible = False
                diveditbanner.Visible = False
                divaddmore.Visible = True
                BtnAdd.Visible = True
            Else
               
                BtnAdd.Visible = True
                gvbanner.Visible = True
                divexisting.Visible = True
                diveditadd.Visible = True
                diveditbanner.Visible = False
                divaddmore.Visible = True
            End If


           
        Else
            divsuccess.Attributes("class") = "alert alert-danger"
            divsuccess.Style.Add("display", "block")
            errormsg.InnerHtml = "<strong>Error!</strong> Error Encountered, please try again."
        End If

    End Sub
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
    Protected Sub BtnAddBanner_Click(sender As Object, e As EventArgs) Handles BtnAddBanner.Click
        divnewbannersuccess.Attributes("class") = "alert alert-danger"
        divnewbannersuccess.Style.Add("display", "none")
        newbannererrmsg.InnerHtml = ""
        Dim table As DataTable = getemptytable()
        table.Rows.Add("")
        gvbanner.DataSource = table
        gvbanner.DataBind()
        gvbanner.Visible = True
        diveditbanner.Visible = False
        divaddmore.Visible = True
        divexisting.Visible = True
        diveditadd.Visible = True
        BtnAdd.Visible = True
    End Sub
    Protected Sub BtnAdd_Click1(sender As Object, e As EventArgs) Handles BtnAdd.Click
        divnewbannersuccess.Attributes("class") = "alert alert-danger"
        divnewbannersuccess.Style.Add("display", "none")
        newbannererrmsg.InnerHtml = ""
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

    Protected Sub gvExistingBanners_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvExistingBanners.RowCommand
        divaddmore.Visible = False
        diveditadd.Visible = False
        diveditbanner.Visible = False
        divexisting.Visible = True
        lblpath.Text = ""
        txteditBanner.Text = ""
        lblBannerID.Text = ""
        diveditsuccess.Attributes("class") = "alert alert-danger"
        diveditsuccess.Style.Add("display", "none")
        editbannerrmsg.InnerHtml = ""
        Try

            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvExistingBanners.Rows(e_)
            If CType(e.CommandSource, LinkButton).ID = "imgDelete" Then
                Dim lID As Label = Nothing
                Dim control As Control = TryCast(rowe.FindControl("LblID"), Label)
                If control IsNot Nothing Then
                    lID = DirectCast(control, Label)
                End If
                Dim Image1 As Image = Nothing
                Dim control1 As Control = TryCast(rowe.FindControl("Image1"), Image)
                If control1 IsNot Nothing Then
                    Image1 = DirectCast(control1, Image)
                End If
                Dim path As String = Image1.ImageUrl.ToString()
                Dim filename As String() = path.Split("/")
                Dim pathToCreate As String = "~/banner/" + Session("COMPANY") + Session("COMPANYID")
                Dim fulldirect As String = Server.MapPath(pathToCreate + "/") + filename(2).ToString
                If System.IO.File.Exists(fulldirect) Then
                    System.IO.File.Delete(fulldirect)
                    Dim msg As String = DAL.DeleteBanner(lID.Text)
                End If

                gvExistingBanners.DataSource = DAL.SelectBannerbyCampaignID(lblcampaignID.Text)
                gvExistingBanners.DataBind()
            ElseIf CType(e.CommandSource, LinkButton).ID = "btnEdit" Then

                txteditBanner.Text = rowe.Cells(2).Text
                Dim image1 As Image = Nothing
                Dim ctrl1 As Control = TryCast(rowe.FindControl("Image1"), Image)
                If ctrl1 IsNot Nothing Then
                    image1 = DirectCast(ctrl1, Image)
                End If
                Dim lblID As Label = Nothing
                Dim ctrl As Control = TryCast(rowe.FindControl("LblID"), Label)
                If ctrl IsNot Nothing Then
                    lblID = DirectCast(ctrl, Label)
                End If
                lblpath.Text = image1.ImageUrl.ToString()
                lblBannerID.Text = lblID.Text
              
                diveditbanner.Visible = True
                diveditadd.Visible = True
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub gvbanner_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvbanner.RowCommand

        divnewbannersuccess.Attributes("class") = "alert alert-danger"
        divnewbannersuccess.Style.Add("display", "none")
        newbannererrmsg.InnerHtml = ""
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
    Protected Sub BtnEditBanner_Click(sender As Object, e As EventArgs) Handles BtnEditBanner.Click
        diveditsuccess.Attributes("class") = "alert alert-danger"
        diveditsuccess.Style.Add("display", "none")
        editbannerrmsg.InnerHtml = ""
        Try
            If txteditBanner.Text <> "" And lblpath.Text <> "" Then
                If fueditbanner.HasFile Then
                    Dim filename As String = Path.GetFileName(fueditbanner.FileName)
                    If Path.GetExtension(filename) = ".jpg" Or Path.GetExtension(filename) = ".JPG" Or Path.GetExtension(filename) = ".jpeg" Or Path.GetExtension(filename) = ".JPEG" _
                    Or Path.GetExtension(filename) = ".swf" Or Path.GetExtension(filename) = ".SWF" Or Path.GetExtension(filename) = ".png" Or Path.GetExtension(filename) = ".PNG" _
                Or Path.GetExtension(filename) = ".gif" Or Path.GetExtension(filename) = ".GIF" Then
                        If fueditbanner.PostedFile.ContentLength < 50176 Then
                            Dim pathToCreate As String = "~/banner/" + Session("COMPANY") + Session("COMPANYID")
                            Dim fulldirect As String = Server.MapPath(pathToCreate + "/") + filename
                            fueditbanner.SaveAs(fulldirect)
                            Dim imgsize As String
                            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(fueditbanner.PostedFile.InputStream)
                            imgsize = CStr(img.Width) + " x " + CStr(img.Height)
                            Dim msg1 As String = DAL.InsertBanner(txteditBanner.Text, imgsize, lblcampaignID.Text, Path.GetExtension(filename), "banner/" + Session("COMPANY") + Session("COMPANYID") + "/" + filename, lblBannerID.Text)
                            If msg1 <> 0 Then
                                diveditsuccess.Attributes("class") = "alert alert-success"
                                diveditsuccess.Style.Add("display", "block")
                                editbannerrmsg.InnerHtml = "Success! Banner was edited sucessfully"
                                txteditBanner.Text = ""
                                lblpath.Text = ""
                                lblBannerID.Text = ""
                                gvExistingBanners.DataSource = DAL.SelectBannerbyCampaignID(lblcampaignID.Text)
                                gvExistingBanners.DataBind()
                                divexisting.Visible = True
                            Else
                                diveditsuccess.Attributes("class") = "alert alert-danger"
                                diveditsuccess.Style.Add("display", "block")
                                editbannerrmsg.InnerHtml = "Error! Please try again"
                            End If
                        Else
                            diveditsuccess.Attributes("class") = "alert alert-danger"
                            diveditsuccess.Style.Add("display", "block")
                            editbannerrmsg.InnerHtml = "Error! Make sure file is below 50KB"
                        End If

                    Else
                        diveditsuccess.Attributes("class") = "alert alert-danger"
                        diveditsuccess.Style.Add("display", "block")
                        editbannerrmsg.InnerHtml = "Error! Invalid file type; only accepts .jpg,.jpeg,.gif,.swf,.png file extensions."
                    End If
                Else
                    Dim msg As String = DAL.UpdateBannerName(lblBannerID.Text, txteditBanner.Text)
                    If msg <> 0 Then
                        diveditsuccess.Attributes("class") = "alert alert-success"
                        diveditsuccess.Style.Add("display", "block")
                        editbannerrmsg.InnerHtml = "Success! Banner was edited sucessfully"
                        gvExistingBanners.DataSource = DAL.SelectBannerbyCampaignID(lblcampaignID.Text)
                        gvExistingBanners.DataBind()
                        divexisting.Visible = True
                    Else
                        diveditsuccess.Attributes("class") = "alert alert-danger"
                        diveditsuccess.Style.Add("display", "block")
                        editbannerrmsg.InnerHtml = "Error! Please try again"
                    End If
                End If
            Else
                diveditsuccess.Attributes("class") = "alert alert-danger"
                diveditsuccess.Style.Add("display", "block")
                editbannerrmsg.InnerHtml = "Error! Fill in a banner name"
            End If
        Catch ex As Exception

        End Try
   
    End Sub
    Private Function checkrows() As Boolean
        divnewbannersuccess.Attributes("class") = "alert alert-danger"
        divnewbannersuccess.Style.Add("display", "none")
        newbannererrmsg.InnerHtml = ""
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
    Protected Sub BtnSchedule_Click(sender As Object, e As EventArgs) Handles BtnSchedule.Click
        Page.Response.Redirect("CreateSchedule.aspx?Id=" + lblcampaignID.Text)
    End Sub
    Protected Sub BtnNewBanner_Click(sender As Object, e As EventArgs) Handles BtnNewBanner.Click
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
                Dim msg1 As String = DAL.InsertBanner(txtbanner.Text, imgsize, lblcampaignID.Text, Path.GetExtension(filename), "banner/" + Session("COMPANY") + Session("COMPANYID") + "/" + filename, 0)
            Next
            Dim msg As String = DAL.UpdateCampaignBannerNo(lblcampaignID.Text, gvExistingBanners.Rows.Count() + gvbanner.Rows.Count())
            If msg <> 0 Then
                divexisting.Visible = True
                gvExistingBanners.DataSource = DAL.SelectBannerbyCampaignID(lblcampaignID.Text)
                gvExistingBanners.DataBind()
                Dim table As DataTable = getemptytable()
                table.Rows.Add("")
                gvbanner.DataSource = table
                gvbanner.DataBind()
                divnewbannersuccess.Attributes("class") = "alert alert-success"
                divnewbannersuccess.Style.Add("display", "block")
                newbannererrmsg.InnerHtml = "<strong>Success!</strong> Banners successfully added"
            End If
        Else
            divnewbannersuccess.Attributes("class") = "alert alert-danger"
            divnewbannersuccess.Style.Add("display", "block")
            newbannererrmsg.InnerHtml = "<strong>Error!</strong> Please upload a valid image below 50KB and insert a name or delete any unused lines"
        End If
    End Sub
   
End Class
