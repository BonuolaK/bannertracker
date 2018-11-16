<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ModifyCampaign.aspx.vb" Inherits="ModifyCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <style>
        div.kenny {
    background-color: black;
    display: block;
    opacity: 0;
    transition: opacity 5s;
    -webkit-transition: opacity 5s;
}
div.fade {
    opacity: 1;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
    <div class="col-sm-12">
        
                    <div class="panel panel-default">
                         <header class="panel-heading">
                        <span class="h4">Modify Campaign</span>
                      </header>
                      <div class="panel-heading">
                        <ul class="nav nav-tabs font-bold">
                          <li><a  runat="server"  id="astep1">Modify Campaign Details</a></li>
                          <li><a  runat="server"  id="astep2">Modify Banners</a></li>
                         
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
                              <label>Client</label>&nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator1" ValidationGroup="campaign" ControlToValidate="ddlClient"  Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:CompareValidator>
                              <asp:DropDownList ID="ddlClient" AutoPostBack="true" DataTextField="ClientName" DataValueField="ClientID" runat="server" class="form-control m-b">
                            
                            
                        </asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                              <label>Brand</label>&nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator2" ValidationGroup="campaign" ControlToValidate="ddlBrand"  Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:CompareValidator>
                              <asp:DropDownList ID="ddlBrand" DataTextField="BrandName" DataValueField="BrandID" runat="server" class="form-control m-b">
                           
                            
                        </asp:DropDownList>
                            </div>
                          </div>
                               <div class="form-group pull-in clearfix">
                              <div class="col-sm-6">
                          
                            <label>Campaign Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="TxtName" runat="server" ValidationGroup="campaign" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                              <asp:TextBox ID="TxtName"  class="form-control" runat="server"></asp:TextBox>
                           </div>
                           <div class="col-sm-6">
                           <label style="margin-bottom:12px">No of Banner(s)</label><br />  
                               <asp:Label style="padding: 20px 20px;" Font-Bold="true" Font-Size="14px" CssClass="text-black" ID="lblbannerno" runat="server" ></asp:Label>
                           
                          </div>
                                  
                      </div>
<footer class="panel-footer text-right bg-light lter">
       
                          <asp:LinkButton ValidationGroup="campaign" ID="BtnSubmit1" CssClass="btn btn-success btn-s-xs" runat="server" ToolTip="Modify Banners">Next Step <i class="i i-arrow-right2"></i></asp:LinkButton>
                       
                      </footer> 
                               <br />
                             
                     
                     </div>
                            
                          <div class="tab-pane" runat="server"  id="step2">
                             <div class="row">
                                  <div runat="server" id="divexisting" visible="false"  class="col-sm-6">
                                  <div style="max-height:300px;overflow:auto"> 
                                      <asp:GridView ID="gvExistingBanners" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit Line">
                                           </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>
                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblID" runat="server" Text='<%# Eval("BannerID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
          <asp:BoundField DataField="Name" HeaderText="Banner Name" ItemStyle-Font-Size="12px" SortExpression="BannerID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:TemplateField HeaderText="Existing Banners" ItemStyle-HorizontalAlign="left">
                     
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Image ID="Image1" Width="50px" Height="50px" ImageURL='<%# Eval("Path")%>' runat="server" />
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <center>
                            <span id="imgAdmin" runat="server">
                            <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="if (confirm('Are you sure you want to delete this banner?')==true)return true;else return false;" style="visibility: inherit">
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
                              <div runat="server" id="diveditadd" visible="false"  class="col-sm-6">
                                   <div id="diveditbanner" visible="false" style="border: 1px solid #ddd !important"  runat="server" class="col-sm-12">
                                  <div style="padding-top:10px;text-align:right">
                                        <asp:LinkButton ID="BtnAddBanner"  CssClass="" runat="server" ToolTip="Back"><i class="fa  fa-2x fa-times-circle-o"></i></asp:LinkButton>
            </div>
                                      
                                        <div class="form-group pull-in clearfix">
                              <div class="col-sm-6">
                          
                            <label>Banner Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txteditBanner" runat="server" ValidationGroup="banner" ErrorMessage="Required"></asp:RequiredFieldValidator>
                              <asp:TextBox ID="txteditBanner"  class="form-control" runat="server"></asp:TextBox>
                           </div>
                           <div class="col-sm-6">
                           <label>Upload Banner</label>
                               <asp:FileUpload Width="100%" ID="fueditbanner" runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                     runat="server" ControlToValidate="fueditbanner"
                     ErrorMessage="Only .jpeg, .gif, .png, .swf image formats are allowed" ForeColor="Red"
                    ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.JPG|.jpeg|.JPEG|.gif|.GIF|.png|.PNG)$"
                     ></asp:RegularExpressionValidator>
                               
                               <asp:Label ID="lblpath" runat="server" Text="" Visible="false"></asp:Label>
                          </div>
 
                                   </div>
                                      
                                <div>
       
                          <asp:LinkButton ID="BtnEditBanner" ValidationGroup="banner" CssClass="btn btn-success btn-s-xs" runat="server" ToolTip="Update Banner"><i class="fa fa-edit"></i> Update</asp:LinkButton>
                       <asp:Label ID="lblBannerID" runat="server" Text="" Visible="false"></asp:Label>
                                    <br /><br />
                                      <div  id="diveditsuccess" style="display:none" runat ="server" class="alert alert-success">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="editbannerrmsg"></label>
                  </div>
                                    
                      </div>       
                              </div>
                              <div id="divaddmore" visible="false" style="max-height:300px; border: 1px solid #ddd !important;overflow:auto"  runat="server" class="col-sm-12">
                                  <br />
                                   <div  id="divnewbannersuccess" style="display:none" runat ="server" class="alert alert-success">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="newbannererrmsg"></label>
                  </div>  
                                  <asp:GridView ID="gvbanner" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="false" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>

                 <asp:TemplateField HeaderText="Banner Name">
                     
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtbanner" CssClass="form-control" Font-Size="12px" Text='<%# Eval("Banner")%>' runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ValidationGroup="bannernew" ID="RequiredFieldValidator2" ControlToValidate="txtbanner" ForeColor="Red" runat="server" ErrorMessage="This field is required"></asp:RequiredFieldValidator>                     
                    </ItemTemplate>
                    
                </asp:TemplateField>
              
                 <asp:TemplateField HeaderText="Upload Banners"  ItemStyle-HorizontalAlign="left">
                     
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:FileUpload ID="fuBanner" Width="170px"  runat="server" />
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                     runat="server" ControlToValidate="fuBanner"
                     ErrorMessage="Only .jpeg, .gif, .png, .swf image formats are allowed" ForeColor="Red" 
                    ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.JPG|.jpeg|.JPEG|.gif|.GIF|.png|.PNG)$"
                     ></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ControlToValidate="fubanner" ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ValidationGroup="bannernew" ErrorMessage="Upload a banner"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                
                 
                
                
                <asp:TemplateField  >
                   
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
                                 
                                    <div class="row">
                                  <div class="col-sm-6">
  <asp:Button ID="BtnAdd" Visible="false"  CssClass="btn btn-sm btn-default" runat="server" Text="Add Line" />
                                  </div>   
                              <div class="col-sm-6 text-right" >
             <asp:LinkButton ID="BtnNewBanner" ValidationGroup="bannernew" CssClass="btn btn-success btn-s-xs" runat="server" ToolTip="Add Banners"><i class="fa fa-save"></i></asp:LinkButton>
                                        </div>   
         
                     </div>  
                                  <br />  
                                   
                              </div>
                        </div>
                                 </div>
                               <footer style="margin-top:32px" class="panel-footer bg-light lter">
                             <table style="width:100%">
                                 <tr>
                                     <td>
                                         <asp:LinkButton ID="BtnModify" CssClass="btn btn-danger btn-s-xs" runat="server" ToolTip="Modify Campaign Details"><i class="i i-arrow-left2"></i> Prev Step</asp:LinkButton>
                                         <asp:Label ID="lblcampaignID" runat="server" Visible="false" Text="0"></asp:Label>
                                         <asp:Label ID="lblName" runat="server" Visible="false" Text="0"></asp:Label>
                                     </td>
                                     <td style="text-align:right"> <asp:LinkButton ID="BtnSchedule" CssClass="btn btn-primary btn-s-xs" runat="server" ToolTip="Modify Schedule Data"><i class="fa  fa-hand-o-right"></i></asp:LinkButton>
                                         
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

