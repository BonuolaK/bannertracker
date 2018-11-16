<%@ WebHandler Language="VB" Class="FileUploadHandler" %>

Imports System
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.IO


Public Class FileUploadHandler : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        
        '' get all the input variable from the ajax post 
        'Dim strJson As String = New StreamReader(context.Request.InputStream).ReadToEnd()
        
        '' deserialize json input into a class "CampaignData"
        'Dim ser As JavaScriptSerializer = New JavaScriptSerializer()
        'Dim myTask As CampaignData = DirectCast(ser.Deserialize(Of CampaignData)(strJson), CampaignData)
        
        ''check if any of the campaign data information is not empty here
        'If myTask.Name <> Nothing And myTask.Client <> Nothing And myTask.Brand <> Nothing And myTask.BannerNo <> Nothing Then
        '    ' all the variables have been supplied
            
        '    'get the list of banners
        '    Dim ser2 As JavaScriptSerializer = New JavaScriptSerializer()
        '    Dim myBanner As List(Of Banner) = DirectCast(ser2.Deserialize(Of List(Of Banner))(myTask.Banners), List(Of Banner))
            
        '    For i As Integer = 0 To myBanner.Count - 1
        '        'for each banner
        '        context.Response.ContentType = "text/plain"
        '        context.Response.Write(myBanner(i).File)
        '        'If myBanner(i) Then
                    
                    
        '        'End If
        '    Next
        'Else
        '    context.Response.ContentType = "text/plain"
        '    context.Response.Write("InvalidCampaignData")
        'End If      

        
        If context.Request.Files.Count > 0 Then
            Dim files As HttpFileCollection = context.Request.Files
            
             
            
            For i As Integer = 0 To files.Count - 1
                Dim file As HttpPostedFile = files(i)
                Dim ext As String = System.IO.Path.GetExtension(file.FileName).ToLower()
                
                ' verify file extension
                If ext = ".png" Or ext = ".gif" Or ext = ".jpg" Then
                    ' verify file size
                    If file.ContentLength <> 5000 Then
                        Dim fname As String = context.Server.MapPath("uploads/" + file.FileName)
                        file.SaveAs(fname)
                        
                        'Else
                        '    context.Response.ContentType = "text/plain"
                        '    context.Response.Write("Upload file exceeds maximum file limit!")
                    End If
                    'Else
                    '    context.Response.ContentType = "text/plain"
                    '    context.Response.Write("Please upload a valid image!")
                End If
            Next
            
            context.Response.ContentType = "text/plain"
            context.Response.Write("uploaded")
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
    
    Public Class CampaignData
        Public Name As String
        Public Brand As String
        Public Client As String
        Public BannerNo As String
        Public Banners As String
    End Class
    
    Public Class Banner
        Public BannerName As String
        Public File As String
    End Class

End Class