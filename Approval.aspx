<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Approval.aspx.vb" Inherits="Approval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
    <div class="col-sm-12">
                    <div class="panel panel-default">
                         <header class="panel-heading">
                        <span class="h4">Campaign Information</span>
                      </header>
                    
                      <div class="panel-body">
                          <div class="alert alert-info">
                            <asp:Label ID="LblRecipient" Font-Bold="true" runat="server" Text=""></asp:Label>
                            </div> 

                          <div class="row">
                          <div style="margin-bottom:10px" class="col-sm-4">

                              <asp:TextBox ID="txtcomments" Visible="false" CssClass="form-control" Height="90px" Placeholder="Comments" TextMode="MultiLine" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtcomments" ValidationGroup="approval" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
      <div id="divsuccess" visible="false"   runat ="server" class="alert alert-success">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="lblerrmsg"></label>
                  </div> 
                          </div>
                           <div style="margin-bottom:10px" class="col-sm-4">
                                 <asp:LinkButton ID="BtnModify" Visible="false" CausesValidation="false" CssClass="btn btn-primary btn-s-xs" runat="server" ToolTip="Modify Campaign"><i class="fa fa-hand-o-left"></i></asp:LinkButton>
                               <asp:linkbutton ID="BtnReject" Visible="false" ValidationGroup="approval"  CssClass="btn btn-danger btn-s-xs" runat="server" ToolTip="Reject Schedule"><i class="fa fa-times-circle"></i></asp:linkbutton>
        <br /><br />
                           <asp:LinkButton ID="BtnSendAdmin" Visible="false" ValidationGroup="approval"  CssClass="btn btn-success btn-s-xs " runat="server" ToolTip="Send for Approval"><i class="fa fa-check-square-o"></i></asp:LinkButton> 
                               <asp:linkbutton ID="BtnSendClient" Visible="false" ValidationGroup="approval" CssClass="btn btn-success btn-s-xs" runat="server" ToolTip="Send to Client"><i class="fa fa-check-square-o"></i></asp:linkbutton>
                                         <asp:linkbutton ID="BtnSendPub" ValidationGroup="approval" Visible="false"  CssClass="btn btn-success btn-s-xs" runat="server" ToolTip="Set as Ongoing"><i class="fa fa-check-square-o"></i></asp:linkbutton>  
                               <asp:LinkButton ID="BtnAccept" Visible="false" ValidationGroup="approval" CssClass="btn btn-success btn-s-xs"  runat="server" ToolTip="Approve Schedule"><i class="fa fa-check-square-o"></i></asp:LinkButton>          
     <asp:Label ID="lblcampaignID" runat="server" Visible="false" Text="0"></asp:Label>
                                          <asp:Label ID="LblStatus" runat="server" Visible="false" Font-Bold="true" Text="" ></asp:Label>
                          </div>
                            </div>

                          <div class="row">
                            <div class="col-md-4">
                                <div style="border: 1px solid #ddd !important; font-weight:bold;color: #fff !important; background-color: #177bbb;border-color: #177bbb;">
                                <div class ="form-group" style="overflow:hidden;margin-bottom:0">
                                        <div class="col-sm-12">
                                            <br />
                                        <label>Client Name: </label>
                                            <asp:Label ID="lblClient" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-sm-12">
                                        <label>Brand Name: </label>
                                            <asp:Label ID="LblBrand"  runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-sm-12">
                                        <label>Campaign Name: </label>
                                            <asp:Label ID="LblCampaign"  runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-sm-12">
                                        <label>No of Banners: </label>
                                            <asp:Label ID="lblBannerNo"  runat="server" Text=""></asp:Label>
                                              
                                        </div>
                                        <div class="col-sm-12">
                                        <label>No of Direct Publishers: </label>
                                            <asp:Label ID="LblPublisherNo"  runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="padding-bottom:15px" class="col-sm-12">
                                        <label>No of External Sources: </label>
                                            <asp:Label ID="LblExternal"  runat="server" Text=""></asp:Label>
                                                 
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div>
                                         
                                          <div  style="border: 1px solid #ddd !important; font-weight:bold;padding-right: 15px;color: #fff !important;background-color: #177bbb;border-color: #177bbb;padding-left: 15px;">
     
                                            <br />
                                              <center>
                                              <asp:Label ID="LblDayinterval" CssClass="text-center"  runat="server" Text=""></asp:Label><br /></center>
                                              <div runat="server" id="divcomplete">

                                              </div>
                                          <label>First Run Date: </label>
                                              <asp:Label ID="LblFirst" runat="server" Text=""></asp:Label>
                                 <br />
                                         <label>Last Run Date: </label>
                                              <asp:Label ID="LblLast"  runat="server" Text=""></asp:Label>
                                        
                                          <br />
                                      
                                          <label>Total Spend: </label>
                                              <asp:Label ID="LblTotal"  runat="server" Text="0"></asp:Label>
                                              <br /><br /><br />
                                         
                                           </div>
                                      </div>
                               <%-- <section class="panel panel-default">
                          <form>
                            <textarea class="form-control no-border" rows="3" placeholder="What are you doing..."></textarea>
                          </form>
                          <footer class="panel-footer bg-light lter">
                            <button class="btn btn-info pull-right btn-sm">POST</button>
                            <ul class="nav nav-pills nav-sm">
                              <li><a href="#"><i class="fa fa-camera text-muted"></i></a></li>
                              <li><a href="#"><i class="fa fa-video-camera text-muted"></i></a></li>
                            </ul>
                          </footer>
                        </section>--%>
                            </div>
                            <div class="col-md-4">
                                <div style="height:184px;overflow:auto">
                                    <asp:GridView ID="gvExistingBanners" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" GridLines="None" EmptyDataText="No banners added" ShowHeader="true" Width="100%" Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray"  />
                                         <HeaderStyle BackColor="#177bbb" ForeColor="#aad7f4" />
            <Columns>
              
                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="#177bbb" ForeColor="#aad7f4" />
                    <ItemTemplate>
                        <asp:Label ID="LblID" runat="server" Text='<%# Eval("BannerID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
          <asp:BoundField DataField="Name" HeaderText="Banner Name" ItemStyle-Font-Size="12px" SortExpression="BannerID">
               <HeaderStyle BackColor="#177bbb" ForeColor="#aad7f4" />
                </asp:BoundField>
                 <asp:TemplateField HeaderText="Existing Banners" ItemStyle-HorizontalAlign="left">
                     
                   <HeaderStyle BackColor="#177bbb" ForeColor="#aad7f4" />
                    <ItemTemplate>
                        <a href='<%# Eval("Path")%>' target="_blank" >
                        <asp:Image ID="Image1" Width="50px" Height="50px" ImageURL='<%# Eval("Path")%>' runat="server" />
                            </a>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                
                 <asp:BoundField DataField="Size" HeaderText="Banner Size" ItemStyle-Font-Size="12px" SortExpression="BannerID">
                <HeaderStyle BackColor="#177bbb" ForeColor="#aad7f4" />
                </asp:BoundField>
            </Columns>
                     
            <FooterStyle BackColor="#CCCCCC" />
            <AlternatingRowStyle BackColor="#EEEEEE" />
           <HeaderStyle BackColor="#177bbb" Font-Size="12.5px" ForeColor="#aad7f4" />
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
                         
                     
                          <br />
                          <div class="row" >
                         <div class="col-sm-12">
                             <section  class="panel panel-default pos-rlt clearfix">
                    <header class="panel-heading">
                      <ul class="nav nav-pills pull-right">
                        <li>
                          <a href="#" class="panel-toggle text-muted"><i class="fa fa-caret-down text-active"></i><i class="fa fa-caret-up text"></i></a>
                        </li>
                      </ul>
                     Direct Publishing
                    </header>
                    <div class="panel-body clearfix">
                        <div style="max-height:300px;overflow:auto">
 <asp:GridView ID="gvdownload" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px"  CaptionAlign="Left"  CssClass="table  table-bordered  table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" EmptyDataText="Awaiting schedule" GridLines="none" ShowHeader="true"   Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
              
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

                 <asp:BoundField DataField="Name" HeaderText="Banner" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                
                 <asp:BoundField DataField="Size" HeaderText="Banner Size" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="Specification" HeaderText="Spec." ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblCurType" runat="server" Text='<%# Eval("CurType")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                     <asp:BoundField DataField="VolDisc" HeaderText="Vol Disc." ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
               <asp:BoundField DataField="AgencyComm" HeaderText="Agency Comm." ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                  <asp:BoundField DataField="Cost" HeaderText="Cost" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                    <asp:BoundField DataField="StartDate" DataFormatString="{0:dd MMM yyyy}" HeaderText="Start Date" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" DataFormatString="{0:dd MMM yyyy}" HeaderText="End Date" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="RedirectLink" HeaderText="Redirect Link" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                  <asp:TemplateField Visible="false"  >
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="lblPath" runat="server" Text='<%# Eval("Path")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                        </div>
                               </section>

                             <section class="panel panel-default pos-rlt clearfix">
                    <header class="panel-heading">
                      <ul class="nav nav-pills pull-right">
                        <li>
                          <a href="#" class="panel-toggle text-muted"><i class="fa fa-caret-down text-active"></i><i class="fa fa-caret-up text"></i></a>
                        </li>
                      </ul>
                      External Sources
                    </header>
                    <div class="panel-body clearfix">
                        <div style="max-height:300px;overflow:auto">
 <asp:GridView ID="gvexternal" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px"  CaptionAlign="Left"  CssClass="table  table-bordered  table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" EmptyDataText="Awaiting schedule" GridLines="none" ShowHeader="true"   Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
              
                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                        <asp:Label ID="LblID2" runat="server" Text='<%# Eval("ScheID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
              <asp:BoundField DataField="Publisher" HeaderText="Publisher" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="Name" HeaderText="Banner" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="Size" HeaderText="Banner Size" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="Specification" HeaderText="Spec." ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblCurType2" runat="server" Text='<%# Eval("CurType")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                  <asp:BoundField DataField="Cost" HeaderText="Cost" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                    <asp:BoundField DataField="StartDate" DataFormatString="{0:dd MMM yyyy}" HeaderText="Start Date" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" DataFormatString="{0:dd MMM yyyy}" HeaderText="End Date" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="RedirectLink" HeaderText="Redirect Link" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                  <asp:TemplateField Visible="false"  >
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="lblPath" runat="server" Text='<%# Eval("Path")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                        </div>
                               </section>

                             
                             
                             <div class="col-sm-5">
                                 <br />
                               
                             </div>
<div class="col-sm-7">
       
                              </div>
                         </div>  
                              </div>  <br />  
                          <div class="row">
<div class="col-sm-12">
     <div class="col-sm-5"></div>
     <div class="col-sm-7">
          
     </div>  
</div>
                          </div>
                              <br /><br />
                                
                      
                         
                               <footer class="panel-footer bg-light lter">
                             
                        
                      </footer>
                            
                       
                     
                    </div>
         
                 
            



        </div>
       
        </div>
        </div>
    <script>
        $(document).ready(function () {
            $('#nav').addClass('nav-xs');
            $('#maximize').addClass('active');
        });
</script> 
</asp:Content>

