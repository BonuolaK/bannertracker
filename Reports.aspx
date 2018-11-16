<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Reports.aspx.vb" Inherits="Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
  
   
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  
       <div class="row">
    <div class="col-sm-12">
                    <div class="panel panel-default">
                         <header class="panel-heading">
                        <span class="h4">Campaign Reports</span>
                      </header>                   
                       <div class="panel-body">
                            <a ID="LinkButton1" onclick="$('#filter').fadeIn();" Class="btn btn-primary btn-s-xs" title="Filter Report"><i class="fa fa-search"></i> Filter</a>
                                <div  style="padding:0 15px;margin-top:20px" class="row">
                           <div class="col-sm-12" id="filter" style="background-color: whiteSmoke;display:none;
border: 1px solid #DDD;padding-top:15px;margin-bottom:10px">
                             
                                   <div class="col-sm-3">
                                       
                                       <asp:TextBox CssClass="datestart form-control datepicker-input " data-date-format="dd/mm/yyyy" placeholder="Select Start Date" ID="TxtStartDate" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ValidationGroup = "filter" ID="RequiredFieldValidator6" ControlToValidate="TxtStartDate" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>            
                    
                                   </div>
                                   <div class="col-sm-3">
                                   
                                       <asp:TextBox  ID="TxtEndDate" data-date-format="dd/mm/yyyy" CssClass="form-control datepicker-input " placeholder="Select End Date" runat="server"></asp:TextBox>
                                       <asp:RequiredFieldValidator ValidationGroup = "filter" ID="RequiredFieldValidator5" ControlToValidate="TxtEndDate" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>            
                  
                                   </div>
                                <div class="col-sm-3">
                                    
                                    <asp:DropDownList ID="ddlpublishers" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="All Publishers" Value="0">
                                        </asp:ListItem>
                                        <asp:ListItem Text="Linda Ikeji" Value="1">
                                        </asp:ListItem>
                                        <asp:ListItem Text="360Nobs" Value="2">
                                        </asp:ListItem>
                                    </asp:DropDownList>  
                                     <asp:RequiredFieldValidator ValidationGroup = "filter" ID="RequiredFieldValidator7" ControlToValidate="TxtEndDate" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>            
                  
                                   </div>
                               <div class="col-sm-3">
                                   
                                       <asp:LinkButton ID="BtnFilter" CausesValidation="true" ValidationGroup="filter" CssClass="btn btn-primary btn-s-xs" runat="server" Tooltip="Filter"><i class="fa fa-search"></i></asp:LinkButton>
                                   </div>
                               <div style="position:absolute;right:20px;top:20px">
                                   
                                       <a ID="closefilter" onclick="$('#filter').fadeOut();" class="text-danger" title="Close Filter"><i class="fa fa-2x fa-times-circle"></i></a>
                                   </div>
                               </div>
                              </div>
                           <div style="padding:0" class="row">
                           <div class="col-sm-12" style="padding-top:15px;padding-bottom:20px;margin-bottom:10px">
                             
                                   <div style="padding:10px 10px" class="col-sm-4 table-bordered">
                                      <span>Client Name</span><br />
                                       <asp:Label Font-Bold="true" ID="lblClientName" runat="server" Text=""></asp:Label>
                                   </div>
                                   <div style="padding:10px 10px" class="col-sm-4 table-bordered">
                                     <span>Brand Name</span><br />
                                       <asp:Label Font-Bold="true" ID="lblBrandName" runat="server" Text=""></asp:Label>
                                   </div>
                               <div style="padding:10px 10px" class="col-sm-4 table-bordered">
                                  <span>Campaign Name</span><br />
                                   <asp:Label Font-Bold="true" ID="lblCampaignName" runat="server" Text=""></asp:Label>
                               </div>
                                <div style="padding:10px 10px" class="col-sm-4 table-bordered">
                                      <span>Showing Start Date</span><br />
                                    <asp:Label Font-Bold="true" ID="lblStartDate" runat="server" Text="28 Jun, 2015"></asp:Label>
                                   </div>
                                   <div style="padding:10px 10px" class="col-sm-4 table-bordered">
                                      <span>Showing End date</span><br />
                                       <asp:Label Font-Bold="true" ID="lblEndDate" runat="server" Text="28 Aug, 2015"></asp:Label>
                                   </div>
                               <div style="padding:10px 10px" class="col-sm-4 table-bordered">
                                  <span>Publishers</span><br />
                                   <asp:Label Font-Bold="true" ID="LblPublishers" runat="server" Text="ALL"></asp:Label>
                               </div>
                               </div>
                              </div>
                           
                       <div style="margin-bottom:10px" class="row">  
                           <div style="text-align:right" class="col-sm-12">
                               <asp:LinkButton ID="LnkExport"  CssClass="btn btn-success btn-s-xs" runat="server" Tooltip="Export to Excel"><i class="i i-file-excel"></i> Export to excel</asp:LinkButton>
                     </div>
                       </div>  
                           <section class="panel panel-default">
                                
                    <header class="panel-heading text-right bg-light">
                      <ul class="nav nav-tabs pull-left">
                        <li id="LinkRental" runat="server" class="active"><a href="#MainContent_rental" data-toggle="tab">Rental</a></li>
                        <li id="LinkImpression" runat="server"><a href="#MainContent_impression" data-toggle="tab">Impression Based</a></li>
                           <li id="LinkClick" runat="server"><a href="#MainContent_click" data-toggle="tab">Click Based</a></li>
                      </ul>
                        <span class="hidden-sm"><br /></span>
                    </header>
                    <div class="panel-body">        
                      <div class="tab-content">
                        <div runat="server" class="tab-pane active" id="rental">
                                                    <div style="overflow:auto; width:100%">
                        <asp:GridView ID="gvrental" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px"  CaptionAlign="Left"  CssClass="table  table-bordered  table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" EmptyDataText="No Data" GridLines="none" ShowHeader="true"   Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
               <asp:TemplateField>
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                      <a data-toggle="popover" href="javascript:void(0)" data-html="true" data-placement="right" data-content="<div class='scrollable' style='height:100px'><b>PublisherURL: </b><%# Eval("PublisherURL")%><br /> <b>StartDate: </b><%# Eval("StartDate", "{0:dd MMM yyyy}")%><br /><b>EndDate: </b><%# Eval("EndDate", "{0:dd MMM yyyy}")%><br /><b>Spec: </b><%# Eval("SpecName") + " X " + Eval("Duration").ToString%><br /><b>Type: </b><%# Eval("ScheduleType")%> </div>" title="" data-original-title='<button type="button" class="close pull-right" data-dismiss="popover">&times;</button>Additional Info'><i class="i i-info2"></i></a>

                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                        <asp:Label ID="LblID2" runat="server" Text='<%# Eval("ScheID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
              <asp:BoundField DataField="Publisher" HeaderText="Publisher" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblScheType" runat="server" Text='<%# Eval("ScheduleType")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblCurType" runat="server" Text='<%# Eval("CurType")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                  <asp:BoundField DataField="Cost" HeaderText="Cost" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:TemplateField HeaderText="Clicks" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblClicks" runat="server" Text='<%# Eval("Click")%>' ></asp:Label>
                        <asp:textbox ID="TxtClicks" onkeyup = "javascript:this.value=Comma(this.value);"  CssClass="form-control" runat="server" Text='<%# Eval("Click")%>' ></asp:textbox>
                        <asp:RequiredFieldValidator ValidationGroup = '<%# "Rental_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator5" ControlToValidate="TxtClicks" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender id="ftbp5" TargetControlID="TxtClicks" runat="server"  Enabled="True" FilterType ="Custom, Numbers" ValidChars=","></asp:FilteredTextBoxExtender>
                   
                    </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Impressions" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblImpression" runat="server" Text='<%# Eval("Impression")%>' ></asp:Label>
                        <asp:textbox ID="TxtImpression" onkeyup = "javascript:this.value=Comma(this.value);"  CssClass="form-control" runat="server" Text='<%# Eval("Impression")%>' ></asp:textbox>
                        <asp:RequiredFieldValidator ValidationGroup = '<%# "Rental_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator4" ControlToValidate="TxtImpression" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender id="ftbp4" TargetControlID="TxtImpression" runat="server"  Enabled="True" FilterType ="Custom, Numbers" ValidChars=","></asp:FilteredTextBoxExtender>
                   
                    </ItemTemplate>  
                </asp:TemplateField>
                <asp:BoundField DataField="CPC" HeaderText="CPC" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="CPM" HeaderText="CPM" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="RedirectLink" HeaderText="Redirect Link" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                  <asp:TemplateField HeaderText="Banner">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <a href='<%# Eval("Path")%>' title="View Banner" target="_blank" >
                        <asp:Image ID="ImgBanner" Width="50px" Height="50px" ImageURL='<%# Eval("Path")%>' runat="server" />
                            </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="BtnSave" CausesValidation="true" CommandArgument="<%# Container.DataItemIndex %>" ValidationGroup = '<%# "Rental_" + Container.DataItemIndex.ToString%>' CssClass="btn btn-icon btn-primary btn-sm" runat="server" Tooltip="Save"><i class="fa fa-save"></i></asp:LinkButton>
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
                        <asp:Label ID="lblcampaignID" runat="server" Visible="false" Text="0"></asp:Label>
                        </div>
                        <div class="tab-pane" runat="server" id="impression">
                            <div style="overflow:auto; width:100%">
                        <asp:GridView ID="gvimpression" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px"  CaptionAlign="Left"  CssClass="table  table-bordered  table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" EmptyDataText="No Data" GridLines="none" ShowHeader="true"   Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
               <asp:TemplateField>
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                      <a data-toggle="popover" href="javascript:void(0)" data-html="true" data-placement="right" data-content="<div class='scrollable' style='height:100px'><b>PublisherURL: </b><%# Eval("PublisherURL")%><br /> <b>StartDate: </b><%# Eval("StartDate", "{0:dd MMM yyyy}")%><br /><b>EndDate: </b><%# Eval("EndDate", "{0:dd MMM yyyy}")%><br /><b>Spec: </b><%# Eval("SpecName") + " X " + Eval("Duration").ToString%><br /><b>Type: </b><%# Eval("ScheduleType")%> </div>" title="" data-original-title='<button type="button" class="close pull-right" data-dismiss="popover">&times;</button>Additional Info'><i class="i i-info2"></i></a>

                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblID4" runat="server" Text='<%# Eval("ScheID")%>' ></asp:Label>
                    </ItemTemplate>       
                </asp:TemplateField>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblScheType" runat="server" Text='<%# Eval("ScheduleType")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
              <asp:BoundField DataField="Publisher" HeaderText="Publisher" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblCurType3" runat="server" Text='<%# Eval("CurType")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Clicks" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblClicks" runat="server" Text='<%# Eval("Click")%>' ></asp:Label>
                        <asp:textbox ID="TxtClicks" onkeyup = "javascript:this.value=Comma(this.value);"  CssClass="form-control" runat="server" Text='<%# Eval("Click")%>' ></asp:textbox>
                        <asp:RequiredFieldValidator ValidationGroup = '<%# "Impression_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator3" ControlToValidate="TxtClicks" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                     <asp:FilteredTextBoxExtender id="ftbp3" TargetControlID="TxtClicks" runat="server"  Enabled="True" FilterType ="Custom, Numbers" ValidChars=","></asp:FilteredTextBoxExtender>
                   
                    </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Impressions" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblImpression" runat="server" Text='<%# Eval("Impression")%>' ></asp:Label>
                        <asp:textbox ID="TxtImpression" onkeyup = "javascript:this.value=Comma(this.value);"  CssClass="form-control" runat="server" Text='<%# Eval("Impression")%>' ></asp:textbox>
                        <asp:RequiredFieldValidator ValidationGroup = '<%# "Impression_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator2" ControlToValidate="TxtImpression" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                     <asp:FilteredTextBoxExtender id="ftbp2" TargetControlID="TxtImpression" runat="server"  Enabled="True" FilterType ="Custom, Numbers" ValidChars=","></asp:FilteredTextBoxExtender>
                   
                    </ItemTemplate>  
                </asp:TemplateField>
                <asp:BoundField DataField="PlannedCPM" HeaderText="Planned CPM" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="ActualCPM" HeaderText="Actual CPM" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="Cost" HeaderText="Planned Cost" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="ActualCost" HeaderText="Actual Cost" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="RedirectLink" HeaderText="Redirect Link" ItemStyle-Font-Size="12px" SortExpression="ScheID">
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
                <asp:TemplateField HeaderText="">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="BtnSave" CausesValidation="true" ValidationGroup = '<%# "Impression_" + Container.DataItemIndex.ToString%>' CssClass="btn btn-icon btn-primary btn-sm" CommandArgument="<%# Container.DataItemIndex %>" runat="server" Tooltip="Save"><i class="fa fa-save"></i></asp:LinkButton>
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
                           <div class="tab-pane" runat="server" id="click">
                               <div style="overflow:auto; width:100%">
                        <asp:GridView ID="gvclicks" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px"  CaptionAlign="Left"  CssClass="table  table-bordered  table-striped b-t b-light"  Font-Size="12px" ForeColor="Gray" EmptyDataText="No Data" GridLines="none" ShowHeader="true"   Visible="true" >
            <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
            <Columns>
               <asp:TemplateField>
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                      <a data-toggle="popover" href="javascript:void(0)" data-html="true" data-placement="right" data-content="<div class='scrollable' style='height:100px'><b>PublisherURL: </b><%# Eval("PublisherURL")%><br /> <b>StartDate: </b><%# Eval("StartDate", "{0:dd MMM yyyy}")%><br /><b>EndDate: </b><%# Eval("EndDate", "{0:dd MMM yyyy}")%><br /><b>Spec: </b><%# Eval("SpecName") + " X " + Eval("Duration").ToString%><br /><b>Type: </b><%# Eval("ScheduleType")%> </div>" title="" data-original-title='<button type="button" class="close pull-right" data-dismiss="popover">&times;</button>Additional Info'><i class="i i-info2"></i></a>

                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                       
                        <asp:Label ID="LblID3" runat="server" Text='<%# Eval("ScheID")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
              <asp:BoundField DataField="Publisher" HeaderText="Publisher" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblCurType2" runat="server" Text='<%# Eval("CurType")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblScheType" runat="server" Text='<%# Eval("ScheduleType")%>' ></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Clicks" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblClicks" runat="server" Text='<%# Eval("Click")%>' ></asp:Label>
                        <asp:textbox ID="TxtClicks" onkeyup = "javascript:this.value=Comma(this.value);"  CssClass="form-control" runat="server" Text='<%# Eval("Click")%>' ></asp:textbox>
                         <asp:RequiredFieldValidator ValidationGroup = '<%# "Click_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator1" ControlToValidate="TxtClicks" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                     <asp:FilteredTextBoxExtender id="ftbp" TargetControlID="TxtClicks" runat="server"  Enabled="True" FilterType ="Custom, Numbers" ValidChars=","></asp:FilteredTextBoxExtender>
                    </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Impressions" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:Label ID="LblImpression" runat="server" Text='<%# Eval("Impression")%>' ></asp:Label>
                        <asp:textbox ID="TxtImpression" onkeyup = "javascript:this.value=Comma(this.value);"  CssClass="form-control" runat="server" Text='<%# Eval("Impression")%>' ></asp:textbox>
                        <asp:RequiredFieldValidator ValidationGroup = '<%# "Click_" + Container.DataItemIndex.ToString%>' ID="RequiredFieldValidator8" ControlToValidate="TxtImpression" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                   <asp:FilteredTextBoxExtender id="ftbp1" TargetControlID="TxtImpression" runat="server"  Enabled="True" FilterType ="Custom, Numbers" ValidChars=","></asp:FilteredTextBoxExtender>
                      </ItemTemplate>  
                </asp:TemplateField>
                <asp:BoundField DataField="PlannedCPC" HeaderText="Planned CPC" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="ActualCPC" HeaderText="Actual CPC" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="Cost" HeaderText="Planned Cost" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="ActualCost" HeaderText="Actual Cost" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                 <asp:BoundField DataField="RedirectLink" HeaderText="Redirect Link" ItemStyle-Font-Size="12px" SortExpression="ScheID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                  <asp:TemplateField HeaderText="Banner">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <a href='<%# Eval("Path")%>' title="View Banner" target="_blank" >
                        <asp:Image ID="ImgBanner2" Width="50px"  Height="50px" ImageURL='<%# Eval("Path")%>' runat="server" />
                            </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <HeaderStyle BackColor="White" />
                    <ItemTemplate>
                        <asp:LinkButton ID="BtnSave" CausesValidation="true" ValidationGroup = '<%# "Click_" + Container.DataItemIndex.ToString%>' CssClass="btn btn-icon btn-primary btn-sm" CommandArgument="<%# Container.DataItemIndex %>" runat="server" Tooltip="Save"><i class="fa fa-save"></i></asp:LinkButton>
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
                      </div>

                    </div>
                  </section>

</div>
                
         </div>
        </div>
           </div>
        <script>
            $(document).ready(function () {
               
                $('.datestart').datepicker().on('changeDate', function (e) {
                    var text = e.target.id;
                    text = text.replace('TxtStartDate', 'TxtEndDate');
                    var startdate = $('#' + e.target.id).val();
                    var inputString = startdate;
                    var dString = inputString.split('/');
                    var dt = new Date(dString[2], dString[1] - 1, dString[0]);
                    dt.setDate(dt.getDate() + 1);
                    var finalDate = dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
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

