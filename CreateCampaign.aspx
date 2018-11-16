<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CreateCampaign.aspx.vb" Inherits="CreateCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
    <div class="col-sm-12">
        
                    <div class="panel panel-default">
                         <header class="panel-heading">
                        <span class="h4">Create Campaign</span>
                      </header>
                      <div class="panel-heading">
                        <ul class="nav nav-tabs font-bold">
                          <li><a  runat="server" id="astep1">Create Campaign Details</a></li>
                          <li><a  runat="server" id="astep2">Add Banners</a></li>
                         
                        </ul>
                      </div>
                      <div class="panel-body">
                        <div class="line line-lg"></div>
                        <div class="progress progress-xs m-t-md">
                          <div id="divprogress" runat="server" class="progress-bar bg-success" ></div>
                        </div>
                        <div class="tab-content">
                          <div class="tab-pane" runat="server"  id="step1">                            
                            <div class="form-group pull-in clearfix">
                            <div class="col-sm-6">
                              <label>Client</label>&nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator2" ValidationGroup="campaign" ControlToValidate="ddlClient"  Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:CompareValidator>
                              <asp:DropDownList ID="ddlClient" AutoPostBack="true" DataTextField="ClientName" DataValueField="ClientID" runat="server" class="form-control m-b">
                            
                            
                        </asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                                <asp:UpdatePanel runat="server"  ID="panel1" UpdateMode="Conditional">
                                    <ContentTemplate>
                                         <label>Brand</label>&nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator1" ValidationGroup="campaign" ControlToValidate="ddlBrand"  Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:CompareValidator>
                                          <asp:DropDownList ID="ddlBrand" DataTextField="BrandName" DataValueField="BrandID" runat="server" class="form-control m-b">
                                          </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                                        
                            
                        
                            </div>
                          </div>
                               <div class="form-group pull-in clearfix">
                              <div class="col-sm-6">
                          
                            <label>Campaign Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="TxtName" runat="server" ValidationGroup="campaign" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                              <asp:TextBox ID="TxtName"  class="form-control" runat="server"></asp:TextBox>
                           </div>
                           <div class="col-sm-6">
                         
                            <label>No of Banners</label>
                            <asp:TextBox ID="TxtBannerNo"  class="form-control" runat="server"></asp:TextBox>
                          </div>
                                  
                      </div>
 <footer class="panel-footer text-right bg-light lter">
       
                          <asp:LinkButton ID="BtnSubmit1" ValidationGroup="campaign" CssClass="btn btn-success btn-s-xs" runat="server" ToolTip="Add Banner">Next Step <i class="i i-arrow-right2"></i></asp:LinkButton>
                       
                      </footer> 
                               <br />
                     
                     </div>

                          <div class="tab-pane" runat="server"  id="step2">
                              <div class="row">
                              <div class="col-sm-8 col-md-offset-2" >
                              <div style="max-height:220px;overflow:auto">
                                  <asp:UpdatePanel runat="server" ID="panel2" UpdateMode="Conditional">
                                      <ContentTemplate>
                                          <asp:GridView ID="gvbanner" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left" CssClass="table table-striped b-t b-light" Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true">
                                              <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
                                              <Columns>
                                                  <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate> Text='<%# Eval("ClientID")%>'
                        <asp:LinkButton ID="btnEditAdmin" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit Client">
                                           </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>--%>
                                                  <asp:TemplateField HeaderText="Banner Name" ItemStyle-HorizontalAlign="left">
                                                      <HeaderStyle BackColor="White" />
                                                      <ItemTemplate>
                                                          <asp:TextBox ID="txtbanner" CssClass="form-control" Text='<%# Eval("Banner")%>' runat="server"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ValidationGroup="banner" ID="RequiredFieldValidator1" ControlToValidate="txtbanner" ForeColor="Red" runat="server" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                                      </ItemTemplate>
                                                  </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Upload Banners" ItemStyle-HorizontalAlign="Center">

                                                      <HeaderStyle BackColor="White" />
                                                      <ItemTemplate>
                                                          <asp:FileUpload ID="fuBanner" runat="server" />
                                                      </ItemTemplate>

                                                  </asp:TemplateField>
                                                  <asp:TemplateField>
                                                      <HeaderStyle BackColor="White" />
                                                      <ItemTemplate>
                                                          <center>
                            <span id="imgAdmin" runat="server">
                            <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="if (confirm('Are you sure you want to delete this line?')==true)return true;else return false;" style="visibility: inherit">
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
                                      </ContentTemplate>
                                      <Triggers>
                                          <asp:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
                                      </Triggers>
                                  </asp:UpdatePanel>
                           
                                  </div>
                              <div class="col-sm-6" style="width:100%; text-align:right; padding-top:10px">
             <asp:Button ID="BtnAdd"  CssClass="btn btn-sm btn-default" runat="server" Text="Add Line" />
                     </div> </div></div>
                            <%--<table class="table table-striped b-t b-light" style="width:100%">
                                      <tr><th></th><th>Banner Name</th></tr>
                                       <asp:Repeater ID="Repeater1" runat="server">
                                      <ItemTemplate>
                                          <tr><td>
                                            <asp:FileUpload ID="FUBanner" runat="server" />   </td>
                                             
                                          <td>
                                               <asp:TextBox ID="TxtBannerName"  runat="server"></asp:TextBox>
                                         
                                          </td>

                                      </tr>
                                      </ItemTemplate>

                                  </asp:Repeater> 
                                      <tr><td colspan="2">
                                          <asp:Button ID="BtnAdd" OnClick="BtnAdd_Click" CssClass="btn btn-sm btn-default" runat="server" Text="Add More" /></td></tr>
                                  </table>--%> 

                         <footer style="margin-top:32px" class="panel-footer bg-light lter">
                             <table style="width:100%">
                                 <tr>
                                    <td>
                                         <asp:LinkButton ID="BtnModify" CssClass="btn btn-danger btn-s-xs" runat="server" ToolTip="Modify Campaign Details"><i class="i i-arrow-left2"></i> Prev Step</asp:LinkButton>
                                         <asp:Label ID="lblcampaignID" runat="server" Visible="false" Text="0"></asp:Label>
                                          <asp:Label ID="lblName" runat="server" Visible="false" Text=""></asp:Label>
                                     </td>
                                     <td style="text-align:right"> <asp:LinkButton ValidationGroup="banner" ID="BtnSchedule" CssClass="btn btn-primary btn-s-xs" runat="server" ToolTip="Proceed to schedule"><i class="fa  fa-hand-o-right"></i></asp:LinkButton>
                                         <asp:Label ID="lblbannerno" runat="server" Visible="false" Text="0"></asp:Label>
                                     </td>
                                 </tr>
                             </table>
                        
                      </footer>

                          </div>
                            <div class="row">
                                <div class="col-sm-12">
                                <div class="col-sm-6"></div>
                                    <div class="col-sm-6">
                       <div style="display:none" id="divsuccess" runat ="server" class="alert alert-success">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="errormsg"></label>
                  </div>
                                        </div>
                                </div>
                                </div>
                        </div>
                      </div>
                    </div>
         
                 
            



        </div>
       
        </div>
</asp:Content>


