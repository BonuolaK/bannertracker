<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginPage.aspx.vb" Inherits="LoginPage" %>

<!DOCTYPE html>

<html lang="en"  class="app" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
  <title>ServeMagic |LoginPage</title>
  <meta name="description" content="app, web app, responsive, admin dashboard, admin, flat, flat ui, ui kit, off screen nav" />
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" /> 
  <link rel="stylesheet" href="css/bootstrap.css" type="text/css" />
  <link rel="stylesheet" href="css/animate.css" type="text/css" />
  <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css" />
  <link rel="stylesheet" href="css/icon.css" type="text/css" />
  <link rel="stylesheet" href="css/font.css" type="text/css" />
  <link rel="stylesheet" href="css/app.css" type="text/css" />  
    <!--[if lt IE 9]>
    <script src="js/ie/html5shiv.js"></script>
    <script src="js/ie/respond.min.js"></script>
    <script src="js/ie/excanvas.js"></script>
  <![endif]-->
</head>
<body id="Page-Login" class="" >
    <form id="form1" runat="server">
    <section id="content" class="m-t-lg wrapper-md animated fadeInUp">    
    <div class="container aside-xl">
      <a class="navbar-brand block" href="#"> <span class="headerk hidden-nav-xs" style="font-size:40px;color:#fff">ServeMagic</span></a>
      <section runat="server" id="sectionlogin" class="m-b-lg">
        <header class="wrapper text-center">
          <strong style="color:#fff">Sign in</strong>
        </header>
       
          <div class="list-group">
            <div class="list-group-item">
             <asp:TextBox ID="txtUserName" placeholder="Username" class="form-control no-border" runat="server"></asp:TextBox>
            </div>
            <div class="list-group-item">
               <asp:Textbox id="txtPassword" placeholder="Password"  runat="server" class="form-control no-border" TextMode="Password"></asp:Textbox>
            </div>
          </div>
        <asp:Button ID="BtnLogin" class="btn btn-lg btn-primary btn-block" runat="server" Text="Login" />
          <br />
          <div style="display:none" id="diverror" runat ="server" class="alert alert-danger">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="errormsg"></label>
                  </div>
          <div class="text-center m-t m-b"><a href="#" onclick="$('#sectionlogin').hide();
            $('#sectionForgot').show();"><small style="color:#fff">Forgot password?</small></a></div>
          <div class="line line-dashed"></div>
          
       
      </section>

         <section id="sectionForgot" runat="server" style="display:none" class="m-b-lg">
        <header class="wrapper text-center">
          <strong>Reset Password</strong>
        </header>
       
          <div class="list-group">
            <div class="list-group-item">
             <asp:TextBox ID="txtResetUser" placeholder="Username" class="form-control no-border" runat="server"></asp:TextBox>
            </div>
           
          </div>
        <asp:Button ID="BtnReset" class="btn btn-lg btn-primary btn-block" runat="server" Text="Reset Password" />
             <br />
             <center> <a href="#" onclick="$('#sectionForgot').hide();$('#sectionlogin').show();" >
                 <i class="fa fa-arrow-left"></i> Go Back </a></center>
            
             
        <div style="display:none" id="divforgotErr" runat ="server" class="alert alert-danger">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="LblForgotErr"></label>
                  </div>
         
          <div class="line line-dashed"></div>
          
       
      </section>

        <section id="sectionFirst" runat="server" style="display:none" class="m-b-lg">
        <header class="wrapper text-center">
          <strong>New User: Update Password</strong>
        </header>
       
          <div class="list-group">
            <div class="list-group-item">
             <asp:Textbox id="txtpassword1" placeholder="Password"  runat="server" class="form-control no-border" TextMode="Password"></asp:Textbox>
            </div>
            <div class="list-group-item">
               <asp:Textbox id="txtpassword2" placeholder="Password Again"  runat="server" class="form-control no-border" TextMode="Password"></asp:Textbox>
            </div>
          </div>
        <asp:Button ID="BtnSubmitNew" class="btn btn-lg btn-primary btn-block" runat="server" Text="Update Password" />
           
        <div style="display:none" id="divnewerr" runat ="server" class="alert alert-danger">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="LblNewerr"></label>
                  </div>
          <div class="text-center m-t m-b"><a href="#"><small>Forgot password?</small></a></div>
          <div class="line line-dashed"></div>
          
       
      </section>
    </div>
  </section>
  <!-- footer -->
  <footer id="footer">
    <div class="text-center padder">
      <p>
        <small style="color:#fff">Native Digital<br>&copy; 2015</small>
      </p>
    </div>
  </footer>
  <!-- / footer -->
  <script src="js/jquery.min.js"></script>
  <!-- Bootstrap -->
  <script src="js/bootstrap.js"></script>
  <!-- App -->
  <script src="js/app.js"></script>  
  <script src="js/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="js/app.plugin.js"></script>
    </form>
</body>
</html>
