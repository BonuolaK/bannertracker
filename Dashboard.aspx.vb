Imports System.Web.Services
Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports System.Linq
Imports System.Data
Imports System.Security.Cryptography
Imports System.IO

Partial Class Dashboard
    Inherits System.Web.UI.Page

    Public Class chartdata
        Public Property [Date]() As String
            Get
                Return m_Date
            End Get
            Set(value As String)
                m_Date = value
            End Set
        End Property
        Private m_Date As String
        Public Property Sales() As Decimal
            Get
                Return m_Sales
            End Get
            Set(value As Decimal)
                m_Sales = value
            End Set
        End Property
        Private m_Sales As Decimal
        Public Property CampaignID() As Integer
            Get
                Return m_CampaignID
            End Get
            Set(value As Integer)
                m_CampaignID = value
            End Set
        End Property
        Private m_CampaignID As Integer
        Public Property CampaignName() As String
            Get
                Return m_CampaignName
            End Get
            Set(value As String)
                m_CampaignName = value
            End Set
        End Property
        Private m_CampaignName As String
    End Class
    <WebMethod()> Public Shared Function GetImpression(ByVal id As String) As String
        Dim NewID As Integer = Decrypt(id)
        Dim msg As DataTable = DAL.GetActiveCampaignsByCompanyID(NewID)
        Dim data As New List(Of Object)()
        Dim myResult As New List(Of chartdata)
        Dim chart As SqlDataReader = DAL.GetImpressionDashboardChart(NewID)
        Dim i As Integer = 0
        While chart.Read()
            Dim obj As New chartdata()
            obj.Sales = Convert.ToDecimal(chart("ImpressionCount"))
            obj.[Date] = chart("DateMade").ToString()
            obj.CampaignID = chart("CampaignID").ToString
            obj.CampaignName = chart("Name").ToString
            myResult.Add(obj)
            i = i + 1
        End While
        For Each row As DataRow In msg.Rows
            Dim ret = New With { _
                     Key .label = row.Item(1), _
                     Key .data = myResult.ToList.Where(Function(x) x.CampaignID = row.Item(0)).Select(Function(x) New String() {CStr(DateDiff("s", "01/01/1970", CDate(x.Date)) * 1000), x.Sales}) _
                  }
            data.Add(ret)
        Next
        Return JsonConvert.SerializeObject(data)
    End Function
    <WebMethod()> Public Shared Function GetClicks(ByVal id As String) As String
        Dim NewID As Integer = Decrypt(id)
        Dim msg As DataTable = DAL.GetActiveCampaignsByCompanyID(NewID)
        Dim data As New List(Of Object)()
        Dim myResult As New List(Of chartdata)
        Dim chart As SqlDataReader = DAL.GetClickDashboardChart(NewID)
        While chart.Read()
            Dim obj As New chartdata()
            obj.Sales = Convert.ToDecimal(chart("ImpressionCount"))
            obj.[Date] = chart("DateMade").ToString()
            obj.CampaignID = chart("CampaignID").ToString
            obj.CampaignName = chart("Name").ToString
            myResult.Add(obj)
        End While
        For Each row As DataRow In msg.Rows
            Dim ret = New With { _
                     Key .label = row.Item(1), _
                     Key .data = myResult.ToList.Where(Function(x) x.CampaignID = row.Item(0)).Select(Function(x) New String() {CStr(DateDiff("s", "01/01/1970", CDate(x.Date)) * 1000), x.Sales}) _
                  }
            data.Add(ret)
        Next
        Return JsonConvert.SerializeObject(data)
    End Function
    Public Shared Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "ZNF9876BIKI24OP"
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                LblID.Text = Encrypt(Session("COMPANYID"))
                gvNewCampaigns.DataSource = DAL.SelectNewCampaigns(Session("COMPANYID"))
                gvNewCampaigns.DataBind()
                gvTopCampaigns.DataSource = DAL.SelectTopCampaigns(Session("COMPANYID"))
                gvTopCampaigns.DataBind()
                gvTopPublishers.DataSource = DAL.SelectTopPublishers(Session("COMPANYID"))
                gvTopPublishers.DataBind()
                spanname.InnerText = Session("FIRSTNAME")
                spancompany.InnerText = Session("COMPANY")
                Dim msg As String() = DAL.GetDashboardInfo(Session("COMPANYID"))
                If msg IsNot Nothing Then
                    spantotal.InnerText = msg(0)
                    spanrunning.InnerText = msg(1)
                    spancomplete.InnerText = msg(2)
                    spanbanner.InnerText = msg(3)
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "ZNF9876BIKI24OP"
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

    Protected Sub gvNewCampaigns_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvNewCampaigns.RowCommand
        Dim e_ As Integer = e.CommandArgument()
        Dim rowe = gvNewCampaigns.Rows(e_)
        If CType(e.CommandSource, LinkButton).ID = "lblCampaignName" Then
            Dim cntrl1 As Control = rowe.FindControl("LblID")
            Dim LblID As Label = cntrl1
            Page.Response.Redirect("Approval.aspx?ID=" + LblID.Text)

        End If
    End Sub

    Protected Sub gvTopCampaigns_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvTopCampaigns.RowCommand
        Dim e_ As Integer = e.CommandArgument()
        Dim rowe = gvNewCampaigns.Rows(e_)
        If CType(e.CommandSource, LinkButton).ID = "lblCampaignName" Then
            Dim cntrl1 As Control = rowe.FindControl("LblID")
            Dim LblID As Label = cntrl1
            Page.Response.Redirect("Approval.aspx?ID=" + LblID.Text)

        End If
    End Sub
End Class
