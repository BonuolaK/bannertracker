<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DownloadCode.aspx.vb" Inherits="DownloadCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <section class="panel panel-default">
                      <header class="panel-heading">
                        <span class="h4">Download AdService HTML code</span>
                      </header>
                      
                      <div class="panel-body">
                          

                <div class="col-sm-12" style="overflow:auto" >
                    <asp:GridView ID="gvdownload" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px"  CaptionAlign="Left"  CssClass="table  table-bordered  table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" GridLines="none" EmptyDataText="No schedule has been created for this campaign" ShowHeader="true" Width="100%"  Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
               <asp:TemplateField  >
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lbImpression" CssClass="btn btn-sm btn-icon btn-success"  CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true"  ToolTip="Download AdsTracking Code" runat="server"><i class="fa fa-bar-chart-o"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  >
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lblLinkCode" CssClass="btn btn-sm btn-icon btn-primary"  CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true"  ToolTip="Download Adservice Code" runat="server"><i class="i i-images"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                        <asp:Label ID="LblID" runat="server" Text='<%# Eval("ScheID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:BoundField DataField="Publisher" HeaderText="Publisher" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />

                </asp:BoundField>

                 <asp:BoundField DataField="PublisherURL" HeaderText="Publisher Address" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="Specification" HeaderText="Specification" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="StartDate" dataformatstring="{0:MMMM d, yyyy}" HeaderText="Start Date" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" dataformatstring="{0:MMMM d, yyyy}" HeaderText="End Date" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Banner" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="Size" HeaderText="Banner Size" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                  <asp:TemplateField HeaderText="Banner">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <a href='<%# Eval("Path")%>' title="View Banner" target="_blank" >
                        <asp:Image ID="ImgBanner3" Width="50px"  Height="50px" ImageURL='<%# Eval("Path")%>' runat="server" />
                            </a>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:BoundField DataField="RedirectLink" HeaderText="Redirect Link" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                
            </Columns>
                     
            <FooterStyle BackColor="#CCCCCC" />
            <AlternatingRowStyle BackColor="#EEEEEE" />
            <HeaderStyle BackColor="#0099CC"  Font-Bold="True" ForeColor="Gray" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <RowStyle BorderColor="#CCCCCC" />
            <SortedAscendingCellStyle BackColor="#F9F9F9" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
                  
                    
                </div>
                    <div class="col-sm-12" style="text-align:right">
                        <asp:Label ID="LblCampaignID" runat="server" Text="" Visible="false"></asp:Label>
                        <br /><br />
                           </div>   
                              
                             
                              
                              
                          </div>
                    </section>
</asp:Content>

