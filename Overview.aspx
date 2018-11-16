<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Overview.aspx.vb" Inherits="Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <section class="panel panel-default">
        <header class="panel-heading">
            <span class="h4">Overview</span>
        </header>

        <div class="panel-body no-padder">
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row wrapper">
                    <div class="col-sm-5 m-b-xs">
                        <span class="block m-t-xs">
                            <strong id="strongagency" runat="server" class="font-bold text-lt"></strong>
                        </span>
                        <asp:DropDownList CssClass="input-sm form-control input-s-sm inline v-middle" ID="ddlClient" DataTextField="ClientName" DataValueField="ClientID" runat="server">
                        </asp:DropDownList>
                        <asp:Button CssClass="btn btn-sm btn-default" ID="BtnSearchclient" runat="server" Text="Search" />

                    </div>
                    <div class="col-sm-4 m-b-xs">
                        <div class="btn-group">
                            <asp:Button CssClass="btn btn-sm btn-default " ID="BtnAll" runat="server" Text="All" />
                            <asp:Button CssClass="btn btn-sm btn-default active" ID="BtnOngoing" runat="server" Text="Ongoing" />
                            <asp:Button CssClass="btn btn-sm btn-default" ID="BtnEnded" runat="server" Text="Ended" />
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <asp:TextBox ID="TxtSearch" placeholder="Search by Campaign Name" CssClass="input-sm form-control" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="BtnSearch" CssClass="btn btn-sm btn-default" runat="server" Text="Go!" />

                            </span>
                        </div>
                    </div>
                </div>
                    <div class="table-responsive">
                    <asp:GridView ID="gvoverview" runat="server" AutoGenerateColumns="false" CssClass="table table-striped b-t b-light" GridLines="none" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%" Visible="true">
                        <Columns>
                            <asp:TemplateField HeaderStyle-CssClass="table-bordered" ItemStyle-CssClass="table-bordered" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle BackColor="White" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Font-Underline="true" Text="Edit" ToolTip="Edit">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                                <HeaderStyle BackColor="White" />
                                <ItemTemplate>

                                    <asp:Label ID="LblID" runat="server" Text='<%# Eval("CampaignID")%>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Campaign Name" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                                <HeaderStyle BackColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BannerNo" HeaderText="No of Banners" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                                <HeaderStyle BackColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="publisherno" HeaderText="No. of publishers" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                                <HeaderStyle BackColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="impressions" HeaderText="Impressions" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                                <HeaderStyle BackColor="White" />
                            </asp:BoundField>

                            <asp:BoundField DataField="clicks" HeaderText="Clicks" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                                <HeaderStyle BackColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="spendings" Visible="false" HeaderText="Spend" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                                <HeaderStyle BackColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LastEndDate" DataFormatString="{0:MMMM d, yyyy}" HeaderText="LastEndDate" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                                <HeaderStyle BackColor="White" />
                            </asp:BoundField>
                            <%--  <asp:BoundField DataField="CPM" HeaderText="CPM" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>
                     <asp:BoundField DataField="CPC" HeaderText="CPC" ItemStyle-Font-Size="12px" SortExpression="CampaignID">
                <HeaderStyle BackColor="White" />
                </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Status">
                                <HeaderStyle BackColor="White" />
                                <ItemTemplate>

                                    <asp:Label ID="LblStatus" runat="server" Font-Bold="true" Text='<%# Eval("Status")%>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="table-bordered" ItemStyle-CssClass="table-bordered" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle BackColor="White" />
                                <ItemTemplate>
                                    <div style="display: inline-block">
                                        <asp:LinkButton ID="BtnDownloadCode" runat="server" CssClass="btn btn-sm btn-icon btn-success" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Visible="false" ToolTip="Download adservice code"><i class="fa fa-download"></i> </asp:LinkButton>
                                        <asp:LinkButton ID="BtnReports" runat="server" CssClass="btn btn-sm btn-icon btn-info" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" Visible="true" ToolTip="View Reports"><i class="i i-stats"></i> </asp:LinkButton>
                                        <asp:LinkButton ID="btnInvoice" runat="server" CausesValidation="False" CssClass="btn btn-sm btn-icon btn-primary" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Generate schedule invoices"> <i class="fa fa-file-text-o"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnPurge" runat="server" CausesValidation="False" CssClass="btn btn-sm btn-icon btn-danger" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Purge Campaign"><i class="fa fa-trash-o"></i> </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle Width="170px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnSearchclient" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>         
        </div>
    </section>

    <script>
        $(document).ready(function () {
            $('#MainContent_gvoverview').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable({
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
            $('#MainContent_gvoverview').prepend($('<thead></thead>').append($('#MainContent_gvoverview').find('tr:first'))).dataTable({
                'bFilter': false
            });

            $('.dataTables_length').hide();
        }
    </script>
</asp:Content>

