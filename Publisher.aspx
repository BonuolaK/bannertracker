<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Publisher.aspx.vb" Inherits="Publisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
                <div class="col-sm-12">
                 
                    <section class="panel panel-default">
                      <header class="panel-heading">
                        <span class="h4">Add Pubishers</span>
                      </header>
                      <div class="panel-body">
                        <p class="text-muted">Please fill in company information</p>
                           <div class="row">
                <div class="col-sm-3">
                     <div class="form-group">
                          <label>Name</label>
                            <asp:TextBox ID="TxtPubName" class="form-control" runat="server" data-required="true"></asp:TextBox>
                           
                        </div>
                       <div class="form-group">
                          <label>PublisherURL</label>
                            <asp:TextBox ID="TxtPubURL" class="form-control" runat="server" data-required="true"></asp:TextBox>
                           
                        </div>
                      <div class="form-group">
                          <label>Add User</label>
                          <asp:CheckBox ID="cbUser" runat="server" />
                        </div>
                       <%-- <div class="form-group">
                          <label>Contact Email</label>
                            <asp:TextBox ID="TxtEmail" class="form-control" data-type="email" runat="server" data-required="true"></asp:TextBox>
                                            
                        </div>--%>
                    <footer class="panel-footer text-right bg-light lter">
                          <asp:Button ID="BtnSubmit"  class="btn btn-success btn-s-xs" runat="server" Text="Submit" />
                        <asp:Label ID="LblCompanyID" runat="server" Text="0" Visible ="false"></asp:Label>
                       
                      </footer>
                    <br />
                     <div style="display:none" id="divsuccess" runat ="server" class="alert alert-success">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="errormsg"></label>
                  </div>
                    </div>
                                <div class="col-sm-9">
                                    <div class="table-responsive">
                     <asp:GridView ID="gvCompany" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table table-striped b-t b-light" EmptyDataText="No Company created" Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true">
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit Client">
                                           </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblID" runat="server" Text='<%# Eval("CompanyID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ItemStyle-Font-Size="12px" SortExpression="CompanyID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
               
             
                <asp:TemplateField>
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <center>
                            <span id="imgAdmin" runat="server">
                            <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="if (confirm('Are you sure you want to delete this company?')==true)return true;else return false;" style="visibility: inherit">
                                           <asp:Image ID="imgFolderAdmin" BorderStyle="None" Width="20px" Height="20px" runat="server" ImageUrl="~/images/trash.png" />

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
                      
                    </section>
                 
                </div>
      
         </div>
</asp:Content>

