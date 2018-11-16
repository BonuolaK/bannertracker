<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CreateCompany.aspx.vb" Inherits="CreateCompany" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
     <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            width: 100%;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
                <div class="col-sm-12">
                 
                    <section class="panel panel-default">
                      <header class="panel-heading">
                        <span class="h4">Add Company</span>
                      </header>
                      <div class="panel-body">
                          <div  class="row">
                              <div  class="col-sm-5"   >
                            
                <div class="col-sm-12">
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Panel4">
                        <ContentTemplate>

                            <p>Please fill in company information</p>
                            <div style="display: none" id="divsuccess" runat="server" class="alert alert-success">
                                <button type="button" class="close" onclick="$('#MainContent_divsuccess').hide();">×</button>
                                <i class="fa fa-ok-sign"></i>
                                <label runat="server" id="errormsg"></label>
                            </div>
                            <div class="form-group">
                                <label>Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Company" runat="server" ForeColor="Red" Text="This field is required" ControlToValidate="TxtName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtName" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Company Role</label>&nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator1" ValidationGroup="Company" ControlToValidate="ddlrole" Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:CompareValidator>
                                <asp:DropDownList ID="ddlRole" AutoPostBack="true" CssClass="form-control btn btn-sm btn-default dropdown-toggle" DataTextField="Role" DataValueField="RoleID" runat="server"></asp:DropDownList>
                            </div>
                            <div id="divurl" visible="false" runat="server" class="form-group">
                                <label>Publisher URL</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Company" runat="server" ForeColor="Red" Text="This field is required" ControlToValidate="TxtUrl" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlurltype" CssClass="form-control btn btn-sm  btn-default dropdown-toggle" runat="server">
                                            <asp:ListItem Text="http://" Value="http://">
                                            </asp:ListItem>
                                            <asp:ListItem Text="https://" Value="https://">
                                            </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div style="padding-left: 0" class="col-sm-8">
                                        <asp:TextBox ID="TxtUrl" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <footer class="panel-footer text-right bg-light lter">
                                <asp:Button ID="BtnSubmit" ValidationGroup="Company" class="btn btn-success btn-s-xs" runat="server" Text="Submit" />
                                <asp:Label ID="LblCompanyID" runat="server" Text="0" Visible="false"></asp:Label>
                            </footer>
                            <br />
                            


                        </ContentTemplate>
                        <Triggers><asp:AsyncPostBackTrigger ControlID="gvexisting" EventName="RowCommand"  /></Triggers>


                    </asp:UpdatePanel>       
                               </div>
                                  
                                  </div>
                              <div class="col-sm-7">
                                  <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Panel5">
                                      <ContentTemplate>
                                          <div class="row wrapper">
                                              <div class="col-sm-5 m-b-xs">

                                                  <div class="btn-group">
                                                      <asp:Button CssClass="btn btn-sm btn-default active" ID="BtnAll" runat="server" Text="All" />
                                                      <asp:Button CssClass="btn btn-sm btn-default" ID="BtnClients" runat="server" Text="Clients" />
                                                      <asp:Button CssClass="btn btn-sm btn-default" ID="BtnPublishers" runat="server" Text="Publishers" />
                                                  </div>



                                              </div>
                                              <div class="col-sm-2 m-b-xs">
                                              </div>
                                              <div class="col-sm-5">
                                                  <div class="input-group">
                                                      <asp:TextBox ID="TxtSearch" placeholder="Search" CssClass="input-sm form-control" runat="server"></asp:TextBox>
                                                      <span class="input-group-btn">
                                                          <asp:Button ID="BtnSearch" CssClass="btn btn-sm btn-default" runat="server" Text="Go!" />

                                                      </span>
                                                  </div>
                                              </div>
                                          </div>    
                                  
                                           <asp:GridView ID="gvexisting"  runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left" CssClass="table table-striped b-t b-light" EmptyDataText="No Company created" Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true">
                                      <AlternatingRowStyle BackColor="White" ForeColor="Gray" />

                                      <Columns>

                                          <asp:TemplateField>
                                              <HeaderStyle BackColor="White" />
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit Company">
                                                  </asp:LinkButton>
                                              </ItemTemplate>

                                          </asp:TemplateField>
                                          <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                                              <HeaderStyle BackColor="White" />
                                              <ItemTemplate>
                                                  <asp:Label ID="LblExistingID" runat="server" Text='<%# Eval("CompanyID")%>'></asp:Label>
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                          <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ItemStyle-Font-Size="12px" SortExpression="CompanyID">
                                              <HeaderStyle BackColor="White" />
                                          </asp:BoundField>
                                          <asp:BoundField DataField="Role" HeaderText="Company Role" ItemStyle-Font-Size="12px" SortExpression="CompanyID">
                                              <HeaderStyle BackColor="White" />
                                          </asp:BoundField>
                                          <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                                              <HeaderStyle BackColor="White" />
                                              <ItemTemplate>
                                                  <asp:Label ID="LblAgencies" runat="server" Text='<%# Eval("AgencyID")%>'></asp:Label>
                                              </ItemTemplate>

                                          </asp:TemplateField>
                                          <asp:BoundField DataField="URL" HeaderText="URL" ItemStyle-Font-Size="12px" SortExpression="CompanyID">
                                              <HeaderStyle BackColor="White" />
                                          </asp:BoundField>
                                          <asp:TemplateField HeaderStyle-CssClass="table-bordered" ItemStyle-CssClass="table-bordered" ItemStyle-HorizontalAlign="Center">
                                              <HeaderStyle BackColor="White" />
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="if (confirm('Are you sure you want to delete this user?')==true)return true;else return false;" Style="visibility: inherit">
                                                      <asp:Image ID="imgFolderAdmin1" BorderStyle="None" Width="20px" Height="20px" runat="server" ImageUrl="~/images/trash.png" />

                                                  </asp:LinkButton>
                                              </ItemTemplate>

                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-CssClass="table-bordered" ItemStyle-CssClass="table-bordered">
                                              <HeaderStyle BackColor="White" />
                                              <ItemTemplate>
                                                  <center>
                            <span id="imgUser" runat="server">
                            <asp:LinkButton ID="imgCreateUser" runat="server" CausesValidation="False" Visible="true" CommandArgument="<%# Container.DataItemIndex %>" >
                                           <asp:Image ID="imgFolderAdmin" BorderStyle="None" Width="20px" Height="20px" runat="server" ImageUrl="~/images/th.jpg" />

                                           </asp:LinkButton>
                            </span>
                        </center>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                      </Columns>
                                      <FooterStyle BackColor="#CCCCCC" />
                                      <AlternatingRowStyle BackColor="#EEEEEE" />
                                      <HeaderStyle BackColor="#0099CC" Font-Bold="True" ForeColor="Gray" />
                                      <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                      <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                      <RowStyle BorderColor="#CCCCCC" />
                                      <SortedAscendingCellStyle BackColor="#F9F9F9" />
                                      <SortedAscendingHeaderStyle BackColor="#808080" />
                                      <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                      <SortedDescendingHeaderStyle BackColor="#383838" />
                                  </asp:GridView>  
                                    </ContentTemplate>
                                      <Triggers><asp:AsyncPostBackTrigger ControlID="BtnSubmit" EventName="Click" />
                                        
                                      </Triggers>
                                    
                                    

                                  </asp:UpdatePanel>  
                                   
                              </div>                           
                          </div>                     
                      </div>
                        
                                <div style="display: none">
                                    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />
                                </div>
                                <!-- ModalPopupExtender -->
                                <cc1:ModalPopupExtender  ID="mpuser" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
                                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>


                                <asp:Panel ID="Panel1" runat="server" CssClass="row" Style="display: none; width: 70%">
                                    <div class="col-sm-12">
                                        <asp:UpdatePanel runat="server" ID="Panel8" UpdateMode="Conditional">
                            <ContentTemplate>
                                        <div class="panel b-a">
                                            <div class="panel-heading no-border bg-primary lt ">
                                                <div class="row">
                                                    <div class="col-sm-6 text-left">
                                                        <br />

                                                        <strong id="userheader" runat="server" class="text-white  text-center" style="font-size: 16px"></strong>
                                                    </div>
                                                    <div class=" col-sm-6 text-right">
                                                        <asp:LinkButton ID="btnClose" OnClick="btnClose_Click" CssClass="text-right" runat="server">  <i class="fa fa-times-circle fa fa-2x m-t m-b text-white"></i></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>



                                            <div style="background-color: #FFFFFF" class="padder-v  clearfix">
                                                <div style="background-color: #FFFFFF" class="col-sm-4">
                                                    <div class="form-group">
                                                        <label>First Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="user" ControlToValidate="TxtFirstName" runat="server" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="TxtFirstName" class="form-control" runat="server"></asp:TextBox>

                                                    </div>
                                                    <div class="form-group">
                                                        <label>Last Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="TxtLastName" ValidationGroup="user" runat="server" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="TxtLastName" class="form-control" runat="server"></asp:TextBox>

                                                    </div>
                                                    <div class="form-group">
                                                        <label>UserName</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="TxtUserName" runat="server" ValidationGroup="user" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="TxtUserName" class="form-control" runat="server"></asp:TextBox>
                                                    </div>

                                                    <%-- <div class="form-group">
                          <label>Contact Email</label>
                            <asp:TextBox ID="TxtEmail" class="form-control" data-type="email" runat="server" data-required="true"></asp:TextBox>
                                            
                        </div>--%>
                                                    <footer class="panel-footer text-left bg-light lter">
                                                        <asp:Button ID="BtnSubmitUser" ValidationGroup="user" class="btn btn-success btn-s-xs" runat="server" Text="Submit" />
                                                        <asp:Label ID="LblUserID2" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:Label ID="LblRoleID" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:Label ID="LblCompanyID2" runat="server" Text="0" Visible="false"></asp:Label>
                                                    </footer>
                                                    <br />
                                                    <div style="display: none" id="divsuccessUser" runat="server" class="alert alert-success">
                                                        <button type="button" class="close" onclick="$('#MainContent_divsuccessUser').hide();">×</button>
                                                        <i class="fa fa-ok-sign"></i>
                                                        <label runat="server" id="errmsguser"></label>
                                                    </div>
                                                </div>
                                                <div style="background-color: #FFFFFF" class="col-sm-8">
                                                    <div class="table-responsive">


                                                        <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left" CssClass="table table-striped b-t b-light" EmptyDataText="No user created" Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle BackColor="White" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEditUser" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit User">
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="40px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                    <HeaderStyle BackColor="White" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LblUserID" runat="server" Text='<%# Eval("UserID")%>'></asp:Label>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Font-Size="12px" SortExpression="UserID">
                                                                    <HeaderStyle BackColor="White" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="UserName" HeaderText="Username" ItemStyle-Font-Size="12px" SortExpression="UserID">
                                                                    <HeaderStyle BackColor="White" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="CompanyName" HeaderText="Company" ItemStyle-Font-Size="12px" SortExpression="UserID">
                                                                    <HeaderStyle BackColor="White" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="Role" HeaderText="Role" ItemStyle-Font-Size="12px" SortExpression="UserID">
                                                                    <HeaderStyle BackColor="White" />
                                                                </asp:BoundField>


                                                                <asp:TemplateField>
                                                                    <HeaderStyle BackColor="White" />
                                                                    <ItemTemplate>
                                                                        <center>
                            <span id="imgAdminUser" runat="server">
                            <asp:LinkButton ID="imgDeleteUser" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="if (confirm('Are you sure you want to delete this user?')==true)return true;else return false;" style="visibility: inherit">
                                           <asp:Image ID="imgFolderAdminUser" BorderStyle="None" Width="20px" Height="20px" runat="server" ImageUrl="~/images/trash.png" />

                                           </asp:LinkButton>
                            </span>
                        </center>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#CCCCCC" />
                                                            <AlternatingRowStyle BackColor="#EEEEEE" />
                                                            <HeaderStyle BackColor="#0099CC" Font-Bold="True" ForeColor="Gray" />
                                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BorderColor="#CCCCCC" />
                                                            <SortedAscendingCellStyle BackColor="#F9F9F9" />
                                                            <SortedAscendingHeaderStyle BackColor="#808080" />
                                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                            <SortedDescendingHeaderStyle BackColor="#383838" />
                                                        </asp:GridView>





                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                 </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="gvexisting" EventName="RowCommand" />
                            </Triggers>

                        </asp:UpdatePanel>
                                    </div>

                                </asp:Panel>
                           

   
                    </section>
                 
                </div>
        
         </div>
       <script>
           $(document).ready(function () {
               $('#MainContent_gvexisting').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable({
                   'bFilter': false
               });

               $('.dataTables_length').hide();


               //$("#MainContent_TxtSearch").on('keypress', function (event) {
               //    if (event.which === 13) {
               //        $('#MainContent_BtnSearch').click();
               //    }
               //});
           });

           function fnClickRedraw() {
               $('#MainContent_gvexisting').prepend($('<thead></thead>').append($('#MainContent_gvexisting').find('tr:first'))).dataTable({
                   'bFilter': false
               });

               $('.dataTables_length').hide();
           }
    </script>

    
</asp:Content>

