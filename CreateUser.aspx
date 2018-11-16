<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CreateUser.aspx.vb" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
                <div class="col-sm-12">
                 
                    <section class="panel panel-default">
                      <header class="panel-heading">
                        <span class="h4">Create User</span>
                      </header>
                      <div class="panel-body">
                        <p class="text-muted">Please fill in user information</p>
                           <div class="row">
                               <div class="col-sm-4">
                                   
                                   <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Panel1">
                                       <ContentTemplate>
                                           <div style="display: none" id="divsuccess" runat="server" class="alert alert-success">
                                               <button type="button" class="close" data-dismiss="alert">×</button>
                                               <i class="fa fa-ok-sign"></i>
                                               <label runat="server" id="errormsg"></label>
                                           </div>
                                           <div class="form-group">
                                               <label>First Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtFirstName" runat="server" ForeColor="Red" ValidationGroup="user" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                               <asp:TextBox ID="TxtFirstName" class="form-control" runat="server" data-required="true"></asp:TextBox>

                                           </div>
                                           <div class="form-group">
                                               <label>Last Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtLastName" runat="server" ForeColor="Red" ValidationGroup="user" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                               <asp:TextBox ID="TxtLastName" class="form-control" runat="server" data-required="true"></asp:TextBox>

                                           </div>
                                           <div class="form-group">
                                               <label>UserName</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TxtUserName" runat="server" ForeColor="Red" ValidationGroup="user" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                               <asp:TextBox ID="TxtUserName" class="form-control" runat="server" data-required="true"></asp:TextBox>

                                           </div>
                                           <div id="divcomp" runat="server" visible="false" class="form-group">
                                               <label>Company</label>
                                               <asp:DropDownList ID="DdlCompany" class="form-control" DataTextField="CompanyName" DataValueField="CompanyID" runat="server"></asp:DropDownList>

                                           </div>
                                           <div id="divrole" runat="server" visible="false" class="form-group">
                                               <label>User Role</label>
                                               <asp:DropDownList ID="ddlRole" CssClass="form-control" DataTextField="Role" DataValueField="RoleID" runat="server"></asp:DropDownList>

                                           </div>
                                           <div id="divadmin" runat="server" visible="false" class="form-group">
                                               <label>Create as Admin</label>
                                               <asp:CheckBox ID="CbAdmin" runat="server" />

                                           </div>

                                           <%-- <div class="form-group">
                          <label>Contact Email</label>
                            <asp:TextBox ID="TxtEmail" class="form-control" data-type="email" runat="server" data-required="true"></asp:TextBox>
                                            
                        </div>--%>
                                           <footer class="panel-footer text-right bg-light lter">
                                               <asp:Button ValidationGroup="user" ID="BtnSubmit" class="btn btn-success btn-s-xs" runat="server" Text="Submit" />
                                               <asp:Label ID="LblUserID" runat="server" Text="0" Visible="false"></asp:Label>

                                           </footer>
                                           <br />


                                       </ContentTemplate>
                                       <Triggers>
                                           <asp:AsyncPostBackTrigger ControlID="gvUser" EventName="RowCommand" />
                                       </Triggers>

                                   </asp:UpdatePanel>


                               </div>
                                <div class="col-sm-8">
                                    <div class="table-responsive">
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Panel2">
                                            <ContentTemplate>
                                                 <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table table-striped b-t b-light" EmptyDataText="No user created" Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true">
                                                <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle BackColor="White" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit User">
                                                                               </asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="40px" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                                                        <HeaderStyle BackColor="White" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblID" runat="server" Text='<%# Eval("UserID")%>' ></asp:Label>
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
                                                                <span id="imgAdmin" runat="server">
                           
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
                                            <Triggers><asp:AsyncPostBackTrigger ControlID="BtnSubmit" EventName="Click" /></Triggers>
                                        </asp:UpdatePanel>
                                
                 
        
                 
                </div>
                    </div>
                               </div>
                       
                        
                        
                      </div>
                      
                    </section>
                 
                </div>
      
         </div>

           <script>
               $(document).ready(function () {
                   $('#MainContent_gvUser').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable({
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
                   $('#MainContent_gvUser').prepend($('<thead></thead>').append($('#MainContent_gvUser').find('tr:first'))).dataTable({
                       'bFilter': false
                   });

                   $('.dataTables_length').hide();
               }
    </script>
</asp:Content>

