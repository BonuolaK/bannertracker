Imports System.Web.Services

Partial Class SiteMaster
    Inherits MasterPage

    Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Dim _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As System.EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie As HttpCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If ((Not requestCookie Is Nothing) AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue)) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie As HttpCookie = New HttpCookie(AntiXsrfTokenKey) With {.HttpOnly = True, .Value = _antiXsrfTokenValue}
            If (FormsAuthentication.RequireSSL And Request.IsSecureConnection) Then
                responseCookie.Secure = True
            End If
            Response.Cookies.Set(responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Private Sub master_Page_PreLoad(sender As Object, e As System.EventArgs)
        If (Not IsPostBack) Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, String.Empty)
        Else
            ' Validate the Anti-XSRF token
            If (Not DirectCast(ViewState(AntiXsrfTokenKey), String) = _antiXsrfTokenValue _
                Or Not DirectCast(ViewState(AntiXsrfUserNameKey), String) = If(Context.User.Identity.Name, String.Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        spancompany.InnerText = Session("COMPANY")
        If Session("ROLEID") = 5 Then
            Notify()
            licampaign.Visible = False
            strongusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            spanusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            spanrole.InnerText = "Native"
            librand.Visible = False
            limanagement.Visible = True
            liCompany.Visible = False
            liuser.Visible = True
            liNativeCompany.Visible = True
        ElseIf Session("ROLEID") = 4 Then
            Notify()
            strongusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            spanusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            licampaign.Visible = False
            spanrole.InnerText = "Client"
            liNativeCompany.Visible = False
            librand.Visible = False
            limanagement.Visible = True
            liCompany.Visible = False
            liuser.Visible = True
        ElseIf Session("ROLEID") = 3 Then
            Notify()
            strongusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            spanusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            licampaign.Visible = False
            librand.Visible = False
            spanrole.InnerText = "Publisher"
            liCompany.Visible = False
            liNativeCompany.Visible = False
            limanagement.Visible = True
            liuser.Visible = True
        ElseIf Session("ROLEID") = 2 Then
            Notify()
            strongusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            spanusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            licampaign.Visible = False
            spanrole.InnerText = "Administrator"
            librand.Visible = True
            liCompany.Visible = True
            limanagement.Visible = True
            liNativeCompany.Visible = False
            liuser.Visible = True
        ElseIf Session("ROLEID") = 1 Then
            Notify()
            strongusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            spanusername.InnerText = Session("FIRSTNAME") + " " + Session("LASTNAME")
            licampaign.Visible = True
            spanrole.InnerText = "User"
            librand.Visible = False
            liCompany.Visible = False
            limanagement.Visible = False
            liNativeCompany.Visible = False
            liuser.Visible = False
        Else
            Response.Redirect("LoginPage.aspx")
        End If


    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If Session("ROLEID") = 2 Or Session("ROLEID") = 1 Then
                Notify()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Notify()
        Dim msg As Data.DataTable = DAL.SelectNotification(Session("COMPANYID"), Session("ROLEID"))
        If msg.Rows.Count > 0 Then

            Dim datenow As DateTime = Date.Now()

            Dim i As Integer = 0
            For Each dr As Data.DataRow In msg.Rows
                Dim datediff1 As String = Nothing
                'message(i) = dr("message")
                'notifyid(i) = dr("NotificationID")
                'status(i) = dr("NotificationStatus")
                'datemade(i) = dr("DateMade")
                'campaignID(i) = dr("CampaignID")
                If DateDiff(DateInterval.Minute, CDate(dr("DateMade")), datenow) < 1 Then
                    datediff1 = DateDiff(DateInterval.Second, CDate(dr("DateMade")), datenow)
                    If datediff1 = 1 Then
                        datediff1 = datediff1 + " Second"
                    Else
                        datediff1 = datediff1 + " Seconds"
                    End If
                ElseIf DateDiff(DateInterval.Minute, CDate(dr("DateMade")), datenow) > 1 And DateDiff(DateInterval.Minute, CDate(dr("DateMade")), datenow) < 60 Then
                    datediff1 = DateDiff(DateInterval.Minute, CDate(dr("DateMade")), datenow)
                    If datediff1 = 1 Then
                        datediff1 = datediff1 + " Minute"
                    Else
                        datediff1 = datediff1 + " Minutes"
                    End If
                ElseIf DateDiff(DateInterval.Minute, CDate(dr("DateMade")), datenow) > 60 And DateDiff(DateInterval.Minute, CDate(dr("DateMade")), datenow) < 1440 Then
                    datediff1 = DateDiff(DateInterval.Hour, CDate(dr("DateMade")), datenow)
                    If datediff1 = 1 Then
                        datediff1 = datediff1 + " Hour"
                    Else
                        datediff1 = datediff1 + " Hours"
                    End If
                ElseIf DateDiff(DateInterval.Minute, CDate(dr("DateMade")), datenow) > 1440 Then
                    datediff1 = DateDiff(DateInterval.Day, CDate(dr("DateMade")), datenow)
                    If datediff1 = 1 Then
                        datediff1 = datediff1 + " Day"
                    Else
                        datediff1 = datediff1 + " Days"
                    End If



                End If
                If i = 0 Then
                    If dr("Status") = "4" Or dr("Status") = "6" Then
                        divmessage.InnerHtml = "<a href='javascript:void(0)' onclick='UpdateStatus(this);return false;' class='notify media list-group-item'><span class='campid' style='display:none'>" & dr("CampaignID") & "</span><span class='notid' style='display:none'>" & dr("NotificationID") & "</span><span class='pull-left thumb-sm text-center'>" & _
                    "<i class='fa  fa-check-square-o fa-2x text-success'></i></span><span class='media-body block m-b-none'>" & dr("message") & _
                   "<small class='text-muted'>&nbsp;" & datediff1 & " ago." & "</small></span></a>"
                    ElseIf dr("Status") = "3" Then
                        divmessage.InnerHtml = "<a href='javascript:void(0)' onclick='UpdateStatus(this);return false;' class='notify media list-group-item'><span class='campid' style='display:none'>" & dr("CampaignID") & "</span><span class='notid' style='display:none'>" & dr("NotificationID") & "</span><span class='pull-left thumb-sm text-center'>" & _
                  "<i class='fa  fa-times-circle fa-2x text-danger'></i></span><span class='media-body block m-b-none'>" & dr("message") & _
                 "<small class='text-muted'>&nbsp;" & datediff1 & " ago." & "</small></span></a>"
                    Else
                        divmessage.InnerHtml = "<a href='javascript:void(0)' onclick='UpdateStatus(this);return false;' class='notify media list-group-item'><span class='campid' style='display:none'>" & dr("CampaignID") & "</span><span class='notid' style='display:none'>" & dr("NotificationID") & "</span><span class='pull-left thumb-sm text-center'>" & _
                    "<i class='fa fa-envelope-o fa-2x text-success'></i></span><span class='media-body block m-b-none'>" & dr("message") & _
                   "<small class='text-muted'>&nbsp;" & datediff1 & " ago." & "</small></span></a>"
                    End If

                Else
                    Dim previous As String = divmessage.InnerHtml
                    If dr("Status") = "4" Or dr("Status") = "6" Then
                        divmessage.InnerHtml = "<a href='javascript:void(0)' onclick='UpdateStatus(this);return false;' class='notify media list-group-item'><span class='campid' style='display:none'>" & dr("CampaignID") & "</span><span class='notid' style='display:none'>" & dr("NotificationID") & "</span><span class='pull-left thumb-sm text-center'>" & _
                    "<i class='fa  fa-check-square-o fa-2x text-success'></i></span><span class='media-body block m-b-none'>" & dr("message") & _
                   "<small class='text-muted'>&nbsp;" & datediff1 & " ago." & "</small></span></a>" & previous
                    ElseIf dr("Status") = "3" Then
                        divmessage.InnerHtml = "<a href='javascript:void(0)' onclick='UpdateStatus(this);return false;' class='notify media list-group-item'><span class='campid' style='display:none'>" & dr("CampaignID") & "</span><span class='notid' style='display:none'>" & dr("NotificationID") & "</span><span class='pull-left thumb-sm text-center'>" & _
                  "<i class='fa  fa-times-circle fa-2x text-danger'></i></span><span class='media-body block m-b-none'>" & dr("message") & _
                 "<small class='text-muted'>&nbsp;" & datediff1 & " ago." & "</small></span></a>" & previous
                    Else
                        divmessage.InnerHtml = "<a href='javascript:void(0)' onclick='UpdateStatus(this);return false;' class='notify media list-group-item'><span class='campid' style='display:none'>" & dr("CampaignID") & "</span><span class='notid' style='display:none'>" & dr("NotificationID") & "</span><span class='pull-left thumb-sm text-center'>" & _
                    "<i class='fa fa-envelope-o fa-2x text-success'></i></span><span class='media-body block m-b-none'>" & dr("message") & _
                   "<small class='text-muted'>&nbsp;" & datediff1 & " ago." & "</small></span></a>" & previous
                    End If

                End If
                i = i + 1
            Next
            SpanNotifyCount.InnerText = msg.Rows.Count()

            spancount2.InnerText = msg.Rows.Count()
            SpanNotify.InnerText = msg.Rows.Count()
        Else
            divmessage.InnerHtml = ""
            SpanNotifyCount.InnerText = ""

            spancount2.InnerText = ""
            SpanNotify.InnerText = ""
        End If
    End Sub
    
End Class