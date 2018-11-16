<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section class="panel panel-default">
                      <header class="panel-heading">
                        <span class="h4">Overview</span>
                      </header>
                      
                      <div class="panel-body">
                          <div class="row">

                <div class="col-sm-12" >
                   
                    <asp:GridView ID="gvOverview" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table table-striped b-t b-light" EmptyDataText="No campaigns created" Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditAdmin" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit Client">
                                           </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblClientID" runat="server" Text='<%# Eval("ClientID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                
                <asp:BoundField DataField="ClientName" HeaderText="Client Name" ItemStyle-Font-Size="12px" SortExpression="ClientID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="Contact Email" HeaderText="Contact Email" ItemStyle-Font-Size="12px" SortExpression="ClientID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
             
                <asp:TemplateField>
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <center>
                            <span id="imgAdmin" runat="server">
                            <asp:LinkButton ID="imgDeleteAdmin" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="if (confirm('Are you sure you want to delete this user?')==true)return true;else return false;" style="visibility: inherit">
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
                    </section>
</asp:Content>
