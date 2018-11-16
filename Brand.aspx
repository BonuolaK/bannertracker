<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Brand.aspx.vb" Inherits="Brand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="row">
                <div class="col-sm-12">
                 
                    <section class="panel panel-default">
                      <header class="panel-heading">
                        <span class="h4">Create Brand</span>
                      </header>
                      <div class="panel-body">
                        <p class="text-muted">Please fill in brand information</p>
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
                                <label>Client</label>&nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator1" ValidationGroup="brand" ControlToValidate="ddlClient" Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:CompareValidator>
                                <asp:DropDownList ID="ddlClient" DataValueField="ClientID" DataTextField="ClientName" runat="server" class="form-control m-b">
                                </asp:DropDownList>



                            </div>
                            <div class="form-group">
                                <label>Brand Name</label>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="TxtName" runat="server" ValidationGroup="brand" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtName" class="form-control" runat="server" data-required="true"></asp:TextBox>

                            </div>

                            <footer class="panel-footer text-right bg-light lter">
                                <asp:Button ID="BtnSubmit" ValidationGroup="brand" class="btn btn-success btn-s-xs" runat="server" Text="Submit" />
                                <asp:Label ID="LblBrandID" runat="server" Text="0" Visible="false"></asp:Label>
                            </footer>
                            <br />

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvBrand" EventName="RowCommand" />
                        </Triggers>
                    
                    
                        </asp:UpdatePanel>
                    </div>
                               <div class="col-sm-8">
                                   <div class="table-responsive">
                                       <asp:UpdatePanel runat="server" ID="Panel2" UpdateMode="Conditional">
                                           <ContentTemplate>
                                               <asp:GridView ID="gvBrand" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left" CssClass="table table-striped b-t b-light" EmptyDataText="No brand created" Font-Size="12px" ForeColor="Gray" GridLines="None" ShowHeader="true" Width="100%" Visible="true">
                                                   <AlternatingRowStyle BackColor="White" ForeColor="Gray" />
                                                   <Columns>
                                                       <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                           <HeaderStyle BackColor="White" />
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit Brand">
                                                               </asp:LinkButton>
                                                           </ItemTemplate>
                                                           <ItemStyle Width="40px" />
                                                       </asp:TemplateField>
                                                       <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                                                           <HeaderStyle BackColor="White" />
                                                           <ItemTemplate>
                                                               <asp:Label ID="LblID" runat="server" Text='<%# Eval("BrandID")%>'></asp:Label>
                                                           </ItemTemplate>

                                                       </asp:TemplateField>

                                                       <asp:BoundField DataField="BrandName" HeaderText="Brand Name" ItemStyle-Font-Size="12px" SortExpression="BrandID">
                                                           <HeaderStyle BackColor="White" />
                                                       </asp:BoundField>

                                                       <asp:BoundField DataField="ClientName" HeaderText="Client Name" ItemStyle-Font-Size="12px" SortExpression="BrandID">
                                                           <HeaderStyle BackColor="White" />
                                                       </asp:BoundField>


                                                       <asp:TemplateField>
                                                           <HeaderStyle BackColor="White" />
                                                           <ItemTemplate>
                                                               <center>
                            <span id="imgAdmin" runat="server">
                            <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="if (confirm('Are you sure you want to delete this user?')==true)return true;else return false;" style="visibility: inherit">
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
                                               <asp:AsyncPostBackTrigger ControlID="BtnSubmit" EventName="Click" />
                                           </Triggers>

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
                   $('#MainContent_gvBrand').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable({
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
                   $('#MainContent_gvBrand').prepend($('<thead></thead>').append($('#MainContent_gvBrand').find('tr:first'))).dataTable({
                       'bFilter': false
                   });

                   $('.dataTables_length').hide();
               }
    </script>
</asp:Content>


