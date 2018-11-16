Imports System.Security.Cryptography
Imports System.IO
Imports System.Web.Services

Partial Class Load
    Inherits System.Web.UI.Page
    '<WebMethod()> Public Shared Function load1(ByVal id As String, ByVal referer As String) As Boolean

    '    Dim ipaddress As String
    '    ipaddress = HttpContext.Current.Request.UserHostAddress
    '    Dim msg As String = DAL.InsertCount(id, ipaddress, 2, referer)
    '    Dim msg1 As String = DAL.InsertScheduleImpression(id)

    '    Return True

    'End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim ID As Integer

        If Int32.TryParse(Decrypt(HttpUtility.UrlDecode(Request.QueryString("id"))), ID) = True Then
            Dim ipaddress As String
            ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If ipaddress = "" Or ipaddress Is Nothing Then
                ipaddress = Request.ServerVariables("REMOTE_ADDR")
            End If
            Dim referer As String = Request.UrlReferrer.ToString()

            Dim msg As String = DAL.InsertCount(ID, ipaddress, 2, referer)
            Dim msg1 As String = DAL.InsertScheduleImpression(ID)
        End If
      


    End Sub
    Private Function Decrypt(cipherText As String) As String

        Dim EncryptionKey As String = "MYB7823BYUI89NK"

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
