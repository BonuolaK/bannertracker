<%@ WebHandler Language="VB" Class="ValidateFile" %>

Imports System
Imports System.Web

Public Class ValidateFile : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        Dim valid_count As Integer = 0
        If context.Request.Files.Count > 0 Then
            
            Dim files As HttpFileCollection = context.Request.Files
            
            For i As Integer = 0 To files.Count - 1
                Dim file As HttpPostedFile = files(i)
                Dim ext As String = System.IO.Path.GetExtension(file.FileName).ToLower()
                
                ' verify file extension
                If ext = ".png" Or ext = ".gif" Or ext = ".jpg" Then
                    ' verify file size
                    If file.ContentLength <> 5000 Then
                        valid_count = valid_count+ 1
                    Else
                        valid_count = valid_count                       
                    End If
                Else
                        valid_count = valid_count                    
                End If
            Next
        End If
        
        If valid_count = context.Request.Files.Count Then
            context.Response.ContentType = "text/plain"
            context.Response.Write("Valid")
        Else
            context.Response.ContentType = "text/plain"
            context.Response.Write("Invalid")            
        End If
        
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class