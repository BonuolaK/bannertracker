Imports System.Security.Cryptography
Imports System.IO

Partial Class Click
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As Integer
            If Int32.TryParse(Decrypt(HttpUtility.UrlDecode(Request.QueryString("clickthru"))), id) = True Then
                Dim ipaddress As String
                ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
                If ipaddress = "" Or ipaddress Is Nothing Then
                    ipaddress = Request.ServerVariables("REMOTE_ADDR")
                End If
                Dim referer As String = Request.UrlReferrer.ToString()
                Dim msg As String = DAL.InsertCount(id, ipaddress, 1, referer)
                    Dim msg1 As String = DAL.UpdateScheduleClick(id)
                    Dim msg2 As String = DAL.GetRedirectLink(id)
                If Request.QueryString("source") = "bounce" Then
                    Response.Redirect("http://www.gloworld.com/ng/personal/voice-sms/bounce/")
                Else
                    Response.Redirect(msg2)
                End If

                End If
        End If



    End Sub
    Private Function Decrypt(cipherText As String) As String

        Dim EncryptionKey As String = "JU12VB678FDT56Y"

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
End Class
