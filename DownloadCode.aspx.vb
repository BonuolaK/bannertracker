Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Partial Class DownloadCode
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim campaignid As Integer
            If Int32.TryParse(HttpContext.Current.Request.QueryString("Id"), campaignid) = True Then
                LblCampaignID.Text = campaignid
               
                gvdownload.DataSource = DAL.SelectSchedulebyCampaign(LblCampaignID.Text)
                gvdownload.DataBind()

            End If


        End If
    End Sub
    Protected Sub gvdownload_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvdownload.RowCommand

        'divsuccess.Attributes("class") = "alert alert-danger"
        'divsuccess.Style.Add("display", "none")
        'errormsg.InnerHtml = ""
        Try

            Dim e_ As Integer = e.CommandArgument()
            Dim rowe = gvdownload.Rows(e_)
            Dim name As String = Nothing
            Dim cntrl1 As Control = rowe.FindControl("LblID")
            Dim LblID As Label = cntrl1
            Dim cntrl2 As Control = rowe.FindControl("ImgBanner3")
            Dim ImgBanner3 As Image = cntrl2
            Dim msg As String() = DAL.GetCampaignInfo(LblCampaignID.Text, LblID.Text)
            If msg IsNot Nothing Then
                name = msg(2) + "_" + msg(1) + "_" + msg(0) + "_" + msg(7) + "_" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")
            End If
           
                '    Dim url As String = "http://bannertrack.optedia.com/click.aspx?clickthru="
                '    Dim id As String = HttpUtility.UrlEncode(Encrypt(LblID.Text, 1))
                '    Dim myStreamReaderL1 As System.IO.StreamReader
                '    Dim myStream As System.IO.StreamWriter

                '    Dim myStr As String
                '    'Dim url1 As String = "\\Code\\click_code.txt"
                '    '/Template/
                '    Dim fulldirect As String = Server.MapPath("~/") + "/Code/click_code.txt"
                '    myStreamReaderL1 = System.IO.File.OpenText(Server.MapPath("~/") + "/Code/click_code.txt")
                '    myStr = myStreamReaderL1.ReadToEnd()
                '    myStreamReaderL1.Close()
                '    myStr = myStr.Replace("passed_url", url + id)
                '    myStr = myStr.Replace("passed_src", "http://bannertrack.optedia.com/" + LblPath.Text)
                '    myStream = System.IO.File.CreateText(Server.MapPath("~/") + "Code/" + name + "_clickcode.txt")
                '    myStream.WriteLine(myStr)
                '    myStream.Close()
                '    Response.Clear()
                '    Response.ContentType = "text/plain"
                '    Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + "_clickcode.txt")
                '    Response.TransmitFile("/Code/" + name + "_clickcode.txt")

                '    'Response.AddHeader("content-disposition", "attachment; filename=" + "/Code/ " + name + ".txt")
            If CType(e.CommandSource, LinkButton).ID = "lbImpression" Then

                Dim url As String = "http://bannertrack.optedia.com/click.aspx?clickthru="
                Dim id As String = HttpUtility.UrlEncode(Encrypt(LblID.Text, 1))
                Dim idload As String = HttpUtility.UrlEncode(Encrypt(LblID.Text, 2))
                Dim myStreamReaderL1 As System.IO.StreamReader
                Dim myStream As System.IO.StreamWriter

                Dim myStr As String
                myStreamReaderL1 = System.IO.File.OpenText(Server.MapPath("~/") + "Code\click_impression_code.txt")
                myStr = myStreamReaderL1.ReadToEnd()
                myStreamReaderL1.Close()
                myStr = myStr.Replace("passed_url", url + id)
                myStr = myStr.Replace("passed_src", "http://bannertrack.optedia.com/" + ImgBanner3.ImageUrl)
                myStr = myStr.Replace("passed_id", idload)
                myStream = System.IO.File.CreateText(Server.MapPath("~/") + "Code/" + name + "_impressioncode.txt")
                myStream.WriteLine(myStr)
                myStream.Close()
                Response.Clear()
                Response.ContentType = "text/plain"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + "_impressioncode.txt")
                Response.TransmitFile("/Code/" + name + "_impressioncode.txt")

            ElseIf CType(e.CommandSource, LinkButton).ID = "lblLinkCode" Then

                'Dim url As String = "http://bannertrack.optedia.com/click.aspx?clickthru="
                'Dim id As String = HttpUtility.UrlEncode(Encrypt(LblID.Text, 1))
                'Dim idload As String = HttpUtility.UrlEncode(Encrypt(LblID.Text, 2))
                Dim myStreamReaderL1 As System.IO.StreamReader
                Dim myStream As System.IO.StreamWriter

                Dim myStr As String
                myStreamReaderL1 = System.IO.File.OpenText(Server.MapPath("~/") + "Code\click_code.txt")
                myStr = myStreamReaderL1.ReadToEnd()
                myStreamReaderL1.Close()
                'myStr = myStr.Replace("passed_url", url + id)
                myStr = myStr.Replace("passed_src", "http://bannertrack.optedia.com/" + ImgBanner3.ImageUrl)
                'myStr = myStr.Replace("passed_id", idload)
                myStr = myStr.Replace("passed_href", rowe.Cells(11).Text.Trim)
                myStream = System.IO.File.CreateText(Server.MapPath("~/") + "Code/" + name + "_link_image_code.txt")
                myStream.WriteLine(myStr)
                myStream.Close()
                Response.Clear()
                Response.ContentType = "text/plain"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + "_impressioncode.txt")
                Response.TransmitFile("/Code/" + name + "_link_image_code.txt")

            End If

        Catch ex As Exception

        End Try
        Response.End()
    End Sub
    Private Function Encrypt(clearText As String, ByVal type As Integer) As String
        Dim EncryptionKey As String
        If type = 1 Then
            EncryptionKey = "JU12VB678FDT56Y"
        Else
            EncryptionKey = "MYB7823BYUI89NK"
        End If


        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)

        Using encryptor As Aes = Aes.Create()

            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})

            encryptor.Key = pdb.GetBytes(32)

            encryptor.IV = pdb.GetBytes(16)

            Using ms As New MemoryStream()

                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)

                    cs.Write(clearBytes, 0, clearBytes.Length)

                    cs.Close()

                End Using

                clearText = Convert.ToBase64String(ms.ToArray())

            End Using

        End Using

        Return clearText

    End Function
End Class
