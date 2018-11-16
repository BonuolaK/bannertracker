<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CreateSchedule.aspx.vb" Inherits="CreateSchedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <style type="text/css">
        .nopadding {

   padding: 0 !important;
   margin: 0 !important;
}
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
       div.fake_select {
      border: 1px solid #000;
      width:70px;
      height: 50px;
      overflow: auto;
      overflow-x:hidden;
   }

   div.fake_select a {
      padding: 1px 3px;
      margin: 0;
      cursor: pointer;
      cursor: hand;
      border: 0;
      width:70px;
      border-bottom: 1px solid #ddd;
      display: inline-block;
   }

   div.fake_select a:hover {
       background-color:#0094ff;
      text-decoration: none;
      color: #002;
   }

   div.fake_select a.active {
      background-color: #ffcc33;
      color: #ccff66;
   }
    </style>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <section class="panel panel-default">
                      <header class="panel-heading">
                        <span class="h4">Create Schedule</span>
                      </header>
                      
                      <div class="panel-body">
                          <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-6">
                       <div  id="divsuccess" style="display:none"  runat ="server" class="alert alert-success">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="errormsg"></label>
                  </div>
                                        <asp:Label ID="LblDelete" Visible ="false" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="LblDelete2" Visible ="false" runat="server" Text=""></asp:Label>
                                        </div>
                                      <div class="col-sm-6" style="text-align:right"><asp:LinkButton ID="BtnSubmit" CausesValidation="false" CssClass="btn btn-success btn-s-xs" runat="server" Tooltip="Save Schedule"><i class="fa fa-save"></i></asp:LinkButton>
                        <asp:LinkButton ID="BtnProcced" CausesValidation="false" CssClass="btn btn-primary btn-s-xs" runat="server" Tooltip="Proceed"><i class="fa  fa-hand-o-right"></i></asp:LinkButton>
                                </div> 
                                </div>
                             
                            
                        <asp:Label ID="LblCampaignID" runat="server" Text="" Visible="false"></asp:Label>
                        <br /><br />
                             
                           </div>   
                              
                               
                          <section class="panel panel-default pos-rlt clearfix">
                    <header class="panel-heading">
                      <ul class="nav nav-pills pull-right">
                        <li>
                          <a href="#" class="panel-toggle text-muted"><i class="fa fa-caret-down text-active"></i><i class="fa fa-caret-up text"></i></a>
                        </li>
                      </ul>
                      Direct Publishing
                    </header>
                    <div class="panel-body clearfix">
                     <div class="col-sm-12" style="padding-left:0;padding-right:0; overflow:auto" >
                         <asp:UpdatePanel ID="Panel13" runat="server" UpdateMode="Conditional">
                             <ContentTemplate>
                                 <asp:GridView ID="gvschedule" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left" CssClass="table  table-bordered  table-striped b-t b-light" Font-Size="12px" ForeColor="Gray" GridLines="none" ShowHeader="true" Width="100%" Visible="true">
                                     <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
                                     <Columns>
                                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:Label ID="LblID" runat="server" Text='<%# Eval("ScheID")%>'></asp:Label>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Publisher" ItemStyle-Width="10.5%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:DropDownList ID="ddlpublisher" AutoPostBack="true" OnSelectedIndexChanged="ddlpublisher_SelectedIndexChanged" Font-Size="12px" CssClass="form-control" DataValueField="PublisherID" DataTextField="Publisher" runat="server"></asp:DropDownList>
                                                 <asp:CompareValidator ID="CompareValidator1" ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ControlToValidate="ddlpublisher" Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="Required Field"></asp:CompareValidator>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Publisher Address" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center" Visible="false">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:Label ID="txtpubadd" ToolTip='<%#  Eval("PublisherURL")%>' Font-Size="12px" Text='<%#  Eval("PublisherURL")%>' runat="server"></asp:Label>
                                             </ItemTemplate>

                                         </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Banner" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:DropDownList ID="ddlbanner" Font-Size="12px" CssClass="form-control" DataValueField="BannerID" DataTextField="BannerSpec" runat="server"></asp:DropDownList>
                                                 <asp:CompareValidator ID="CompareValidator2" ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ControlToValidate="ddlbanner" Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="Required Field"></asp:CompareValidator>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Cost Spec" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:DropDownList ID="ddlcostspec" Font-Size="12px" CssClass="form-control" DataValueField="SpecID" DataTextField="SpecName" runat="server"></asp:DropDownList>
                                                 <asp:CompareValidator ID="CompareValidator3" ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ControlToValidate="ddlcostspec" Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="Required Field"></asp:CompareValidator>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Cur Type" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:DropDownList ID="ddlcurtype" Font-Size="12px" CssClass="form-control" runat="server">
                                                     <asp:ListItem Selected="True" Text="N" Value="1"> </asp:ListItem>
                                                     <asp:ListItem Text="$" Value="2"></asp:ListItem>
                                                     <asp:ListItem Text="£" Value="3"></asp:ListItem>
                                                 </asp:DropDownList>

                                             </ItemTemplate>

                                         </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Unit Price" ItemStyle-Width="9.5%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>

                                                 <asp:TextBox ID="txtunitprice" onkeyup="javascript:this.value=Comma(this.value);" Font-Size="12px" CssClass="form-control" Text='<%# Eval("UnitPrice")%>' runat="server"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator2" ControlToValidate="txtunitprice" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Freq." ItemStyle-Width="9.5%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>

                                                 <asp:TextBox ID="txtduration" onkeyup="javascript:this.value=Comma(this.value);" Font-Size="12px" CssClass="form-control" Text='<%# Eval("Duration")%>' runat="server"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator8" ControlToValidate="txtduration" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Vol Disc." ItemStyle-Width="6.15%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtvoldisc" Font-Size="12px" CssClass="form-control" Text='<%# Eval("VolDisc")%>' runat="server"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator3" ControlToValidate="txtvoldisc" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Agency Com." ItemStyle-Width="6.15%" HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtagencycomm" CssClass="form-control" Font-Size="12px" Text='<%# Eval("AgencyComm")%>' runat="server"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator4" ControlToValidate="txtagencycomm" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Start Date" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtstart" CssClass="datestart datepicker-input form-control" Font-Size="11px" Text='<%# Eval("StartDate")%>' runat="server" data-date-format="dd-mm-yyyy"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator5" ControlToValidate="txtstart" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="End Date" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtend" CssClass=" datepicker-input form-control" Font-Size="11px" Text='<%# Eval("EndDate")%>' runat="server" data-date-format="dd-mm-yyyy"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator6" ControlToValidate="txtend" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Redirect Link" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtlink" ToolTip="Full URL http:// or https://" CssClass="form-control" Font-Size="12px" Text='<%# Eval("RedirectLink")%>' runat="server"></asp:TextBox>
                                                 <asp:RegularExpressionValidator ID="regexURLValid" runat="server" ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?" ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ControlToValidate="txtlink" ForeColor="Red" ErrorMessage="Invalid URL"></asp:RegularExpressionValidator>
                                                 <asp:RequiredFieldValidator ValidationGroup='<%# "Schedule_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator7" ControlToValidate="txtlink" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-Width=".125%">
                                             <HeaderStyle BackColor="White" />
                                             <ItemTemplate>
                                                 <center>
                            <span id="imgAdmin3" runat="server">
                            <asp:LinkButton ID="imgAdd" runat="server" CausesValidation="true" ValidationGroup = '<%# "Schedule_" + (Container.DataItemIndex - 1).ToString%>' CommandArgument="<%# Container.DataItemIndex %>"  style="visibility: inherit">
                                <i class="fa fa-2x fa-plus text-success"></i>
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
                             <%--<Triggers>
                                 <asp:AsyncPostBackTrigger ControlID="imgAdd" EventName="Click" />
                             </Triggers>--%>
                         </asp:UpdatePanel>


                         
                    <%--<asp:Button ID="BtnAddNew"  runat="server" Text="Add New Line" />--%>
                    
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
                      External Placements
                    </header>
                    <div class="panel-body clearfix">
                     <div class="col-sm-12" style="padding-left:0;padding-right:0;overflow:auto" >
                    <asp:GridView ID="gvexternal" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px"  CaptionAlign="Left"  CssClass="table  table-bordered  table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" GridLines="none" ShowHeader="true" Width="100%"  Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblID2" runat="server" Text='<%# Eval("ScheID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Source" ItemStyle-Width="10.5%"  ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlsource" Font-Size="12px" CssClass="form-control" DataValueField="ID" DataTextField="ExternalSource" runat="server"></asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator4" ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ControlToValidate="ddlsource"  Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="Required Field"></asp:CompareValidator></ItemTemplate>
                    
                </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Banner" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlbanner2"  Font-Size="12px" CssClass="form-control" DataValueField="BannerID" DataTextField="BannerSpec" runat="server"></asp:DropDownList>                   
                   <asp:CompareValidator ID="CompareValidator5" ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ControlToValidate="ddlbanner2"  Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="Required Field"></asp:CompareValidator>
                         </ItemTemplate>
                    
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cost Spec" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       <asp:DropDownList ID="ddlcostspec2" Font-Size="12px"  CssClass="form-control" DataValueField="SpecID" DataTextField="SpecName" runat="server"></asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator6" ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ControlToValidate="ddlcostspec2"  Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="Required Field"></asp:CompareValidator>                    
                    </ItemTemplate>                    
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cur Type" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                         <asp:DropDownList ID="ddlcurtype2" Font-Size="12px"  CssClass="form-control" runat="server">
                             <asp:ListItem Selected="True" Text="$" Value="2" ></asp:ListItem>
                             <asp:ListItem Text="£" Value="3" ></asp:ListItem>
                         </asp:DropDownList>
          
                     </ItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Unit Price" ItemStyle-Width="9.5%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                        <asp:TextBox ID="txtunitprice2"  onkeyup = "javascript:this.value=Comma(this.value);" Font-Size="12px" CssClass="form-control comma"   Text='<%# Eval("UnitPrice")%>' runat="server"></asp:TextBox>           
 <asp:RequiredFieldValidator ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator10" ControlToValidate="txtunitprice2" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Freq." ItemStyle-Width="9.5%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                        <asp:TextBox ID="txtduration2" onkeyup = "javascript:this.value=Comma(this.value);" Font-Size="12px" CssClass="form-control"   Text='<%# Eval("Duration")%>' runat="server"></asp:TextBox>           
 <asp:RequiredFieldValidator ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator9" ControlToValidate="txtduration2" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vol Disc." ItemStyle-Width="6.15%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtvoldisc2" Font-Size="12px" CssClass="form-control"    Text='<%# Eval("VolDisc")%>' runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator14" ControlToValidate="txtvoldisc2" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Agency Com." ItemStyle-Width="6.15%"  HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtagencycomm2" CssClass="form-control" Font-Size="12px" Text='<%# Eval("AgencyComm")%>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator15" ControlToValidate="txtagencycomm2" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>            
                    </ItemTemplate>
                    
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Start Date" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtstart2" CssClass="datestart datepicker-input form-control" Font-Size="11px"   Text='<%# Eval("StartDate")%>' runat="server" data-date-format="dd-mm-yyyy"></asp:TextBox>
                       <asp:RequiredFieldValidator ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator11" ControlToValidate="txtstart2" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>            
                    </ItemTemplate>
                    
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="End Date" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtend2" CssClass=" datepicker-input form-control" Font-Size="11px"   Text='<%# Eval("EndDate")%>' runat="server" data-date-format="dd-mm-yyyy"></asp:TextBox>
                       <asp:RequiredFieldValidator ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator12" ControlToValidate="txtend2" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>            
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Redirect Link" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtlink2" ToolTip="Full URL http:// or https://" CssClass="form-control" Font-Size="12px"   Text='<%# Eval("RedirectLink")%>' runat="server" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexURLValid2" runat="server" ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?" ValidationGroup = '<%# "Schedule2_" + Container.DataItemIndex.ToString%>' ControlToValidate="txtlink2" ForeColor="Red" ErrorMessage="Invalid URL"></asp:RegularExpressionValidator>                            
                      <asp:RequiredFieldValidator ValidationGroup="schedule2" ID="RequiredFieldValidator13" ControlToValidate="txtlink2" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>                            
                    </ItemTemplate>                  
                </asp:TemplateField>
               <asp:TemplateField  ItemStyle-Width=".125%" >
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <center>
                            <span id="imgAdmin2" runat="server">
                        
                            <asp:LinkButton ID="imgAdd2" ValidationGroup = '<%# "Schedule2_" + (Container.DataItemIndex - 1).ToString%>' runat="server" CausesValidation="true" CommandArgument="<%# Container.DataItemIndex %>"  style="visibility: inherit">
                                            <i class="fa fa-2x fa-plus text-success"></i>

                                           </asp:LinkButton>
                            </span>
                        </center>
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
                    <%--<asp:Button ID="BtnAddNew2"  runat="server" Text="Add New Line" />--%>
                    
                </div>
                    </div>
                                <br /><br /><br />
                  </section>                      
                          </div>
         <div style="display:none">
<asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />
    </div>
<!-- ModalPopupExtender -->
<asp:ModalPopupExtender ID="mppublisher" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="row"  style = "display:none;width:70%">
   <div class="col-sm-12">
                      <div class="panel b-a">
                        <div class="panel-heading no-border bg-primary lt ">
                            <div class="row">
                            <div class="col-sm-6 text-left">
                                <br />
                                
                        <strong class="text-white  text-center" style="font-size:16px">Create New Publisher</strong>
                    </div>
                            <div class=" col-sm-6 text-right">
                        <asp:LinkButton ID="btnClose" CssClass="text-right" runat="server">  <i class="fa fa-times-circle fa fa-2x m-t m-b text-white"></i></asp:LinkButton>
                    </div>
                                </div>
                                </div>
                             
                               
                          
       <div style="background-color: #FFFFFF" class="padder-v  clearfix">    
         <div style="background-color: #FFFFFF" class="col-sm-5">
                     <div class="form-group">
                          <label>Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="user" ControlToValidate="TxtPublisherName" runat="server" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtPublisherName" class="form-control" runat="server" ></asp:TextBox>
                           
                        </div>
                       <div class="form-group">
                           <label>Publisher URL</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="user" runat="server" ForeColor="Red"  ControlToValidate="TxtUrl" ErrorMessage="This field is required"></asp:RequiredFieldValidator>   
                           <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?" ValidationGroup="user" ControlToValidate="TxtUrl" ForeColor="Red" ErrorMessage="Invalid URL"></asp:RegularExpressionValidator>                 
                        <div class="row"> 
                           <div class="col-sm-4">
 <asp:DropDownList ID="ddlurltype"   CssClass="form-control btn btn-sm  btn-default dropdown-toggle" runat="server">
     <asp:ListItem Text="http://" Value="http://">
     </asp:ListItem>
     <asp:ListItem Text="https://" Value="https://">
     </asp:ListItem>
 </asp:DropDownList>                         
                         </div>
                        <div style="padding-left:0" class="col-sm-8">
 <asp:TextBox ID="TxtUrl" class="form-control" runat="server"></asp:TextBox>
                        </div>
                            </div>
                       </div>
                    <footer class="panel-footer text-left bg-light lter">
                          <asp:Button ID="BtnSubmitPublisher" ValidationGroup="user"  class="btn btn-success btn-s-xs" runat="server" Text="Submit" />
                        <asp:Label ID="LblUserID2" runat="server" Text="0" Visible ="false"></asp:Label>
                        <asp:Label ID="LblRoleID" runat="server" Text="0" Visible ="false"></asp:Label>
                       <asp:Label ID="LblPublisherID" runat="server" Text="0" Visible ="false"></asp:Label>
                      </footer>
                    <br />
                     <div style="display:none" id="divsuccessUser" runat ="server" class="alert alert-success">
                    <button type="button" class="close" onclick="$('#MainContent_divsuccessUser').hide();">×</button>
                    <i class="fa fa-ok-sign"></i><label runat ="server" id="errmsguser"></label>
                  </div>
                    </div>
         <div style="background-color: #FFFFFF" class="col-sm-7">
                                    <div class="table-responsive">
                     <asp:GridView ID="gvPublisher" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table table-striped b-t b-light" EmptyDataText="No publisher created" Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true">
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditPublisher" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit Publisher">
                                           </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblCompanyID" runat="server" Text='<%# Eval("CompanyID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                
                <asp:BoundField DataField="CompanyName" HeaderText="Publisher" ItemStyle-Font-Size="12px" SortExpression="CompanyID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>

                 <asp:BoundField DataField="URL" HeaderText="URL" ItemStyle-Font-Size="12px" SortExpression="CompanyID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                <%--<asp:TemplateField>
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
                </asp:TemplateField>--%>
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
     </div>
  
</asp:Panel>
                    </section>
    <script>
        $(document).ready(function () {
            $('#nav').addClass('nav-xs');
            $('#maximize').addClass('active');

            $('.datestart').datepicker().on('changeDate', function (e) {
                var text = e.target.id;
                text = text.replace('txtstart', 'txtend');
                var startdate = $('#' + e.target.id).val();
                var inputString = startdate;
                var dString = inputString.split('-');
                var dt = new Date(dString[2], dString[1]-1, dString[0]);
                dt.setDate(dt.getDate() + 1);
                var finalDate = dt.getDate() + "-" + (dt.getMonth() + 1) + "-" + dt.getFullYear();
                if (finalDate) {
                    $('#' + text).datepicker('setValue', finalDate).datepicker('update');
                }
                else { }
               
            });
           
        });
       
        function Comma(Num) { //function to add commas to textboxes
            Num += '';
            Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
            Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
            x = Num.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1))
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            return x1 + x2;
        }
</script>
</asp:Content>
