<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="display:none">
        <asp:Label ID="LblID" runat="server" Text=""></asp:Label></div>
    <section class="row m-b-md">
                    <div class="col-sm-6">
                      <h3 class="m-b-xs text-black">Dashboard</h3>
                      <small>Welcome back, <span id="spanname" runat="server"></span>, <i class="fa fa-map-marker fa-lg text-primary"></i> <span id="spancompany" runat="server"></span></small>
                  <br />  <br /> 
                          </div>
        
        <div class="col-sm-12">
                      <div class="panel b-a">
                        <div class="row m-n">
                          <div class="col-md-3 b-b b-r">
                            <a href="overview.aspx" class="block padder-v hover">
                              <span class="i-s i-s-2x pull-left m-r-sm">
                                <i class="i i-hexagon2 i-s-base text-primary hover-rotate"></i>
                                <i class="i i-plus2 i-1x text-white"></i>
                              </span>
                              <span class="clear">
                                <span runat="server" id="spantotal" class="h3 block m-t-xs text-primary"></span>
                                <small class="text-muted text-u-c">Total Campaigns</small>
                              </span>
                            </a>
                          </div>
                          <div class="col-md-3 b-b b-r">
                            <a href="overview.aspx" class="block padder-v hover">
                              <span class="i-s i-s-2x pull-left m-r-sm">
                                <i class="i i-hexagon2 i-s-base text-warning-lt hover-rotate"></i>
                                <i class="i i-cycle i-sm text-white"></i>
                              </span>
                              <span class="clear">
                                <span runat="server" id="spanrunning" class="h3 block m-t-xs text-warning"></span>
                                <small class="text-muted text-u-c">Running Campaigns</small>
                              </span>
                            </a>
                          </div>
                          <div class="col-md-3 b-b b-r">
                            <a href="overview.aspx" class="block padder-v hover">
                              <span class="i-s i-s-2x pull-left m-r-sm">
                                <i class="i i-hexagon2 i-s-base text-success-dker hover-rotate"></i>
                                <i class="i  i-checked i-sm text-white"></i>
                              </span>
                              <span class="clear">
                                <span id="spancomplete" runat="server" class="h3 block m-t-xs text-success-dker"></span>
                                <small class="text-muted text-u-c">Completed Campaigns</small>
                              </span>
                            </a>
                          </div>
                          <div class="col-md-3 b-b">
                            <a href="#" class="block padder-v hover">
                              <span class="i-s i-s-2x pull-left m-r-sm">
                                <i class="i i-hexagon2 i-s-base text-info hover-rotate"></i>
                                <i class="fa fa-cloud-download i-sm text-white"></i>
                              </span>
                              <span class="clear">
                                <span runat="server" id="spanbanner" class="h3 block m-t-xs text-info"></span>
                                <small class="text-muted text-u-c">Banners Online</small>
                              </span>
                            </a>
                          </div>
                        </div>
                      </div>
                    </div>
                     
                <div class="col-md-12">
                    <section class="panel panel-default">
                    <header class="panel-heading text-right bg-light">
                      <ul class="nav nav-tabs pull-left">
                        <li class="active"><a href="#Impressions" class="font-bold" data-toggle="tab">Impressions</a></li>
                        <li class=""><a href="#Clicks" class="font-bold" data-toggle="tab">Clicks</a></li>
                        </ul>
                        <span class="hidden-sm font-bold">Ongoing Campaigns</span>
                    </header>

                    <div class="panel-body">
                      <div class="tab-content">
                        <div class="tab-pane active" id="Impressions">
                              <div id="flot-chart"  style="height:300px"></div>
                        </div>
                        <div class="tab-pane active" id="Clicks">
                            <div id="flot-chart2"  style="height:300px"></div>
                        </div>
                      </div>
                    </div>
                  </section>
                </div>
                             </section>
                  <div class="row">
                    <div class="col-md-4">
                      <section class="panel b-a">
                        <div class="panel-body" style="padding:0">
                          <asp:GridView ID="gvNewCampaigns"  runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table  b-t b-light"  Font-Size="14px" ForeColor="Gray" GridLines="None" EmptyDataText="No Campaigns" ShowHeader="true" Width="100%" Visible="true" >
                                         <HeaderStyle Font-Size="15px" CssClass="panel-heading bg-dark"/>
                              
            <Columns>
      <asp:TemplateField>
          <HeaderTemplate>
              <span  class="label bg-success">New</span> <span class="font-bold text-success">Campaigns</span>
          </HeaderTemplate>
          <ItemTemplate>
              <asp:Linkbutton ID="lblCampaignName" ToolTip="View Campaign Details" CommandArgument="<%# Container.DataItemIndex %>" runat="server" Text='<%# Eval("Name")%>' ></asp:Linkbutton>
          </ItemTemplate>
      </asp:TemplateField>
                 <asp:TemplateField Visible="false">
           <ItemTemplate>
               <asp:Label ID="LblID" runat="server" Text='<%# Eval("CampaignID")%>' ></asp:Label>
                    </ItemTemplate>
      </asp:TemplateField>
                 <asp:BoundField DataField="Impression" HeaderText="Impression" ItemStyle-Font-Size="14px" SortExpression="CampaignID">
                <HeaderStyle  ForeColor="#aad7f4" />
                </asp:BoundField>
                   <asp:BoundField DataField="Click" HeaderText="Click" ItemStyle-Font-Size="14px" SortExpression="CampaignID">
                <HeaderStyle  ForeColor="#aad7f4" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <RowStyle BorderColor="#CCCCCC" />
            <SortedAscendingCellStyle BackColor="#F9F9F9" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
                        </div>
                      </section>
                    </div>
                    <div class="col-md-4">
                      <section class="panel b-a">
                         <div class="panel-body" style="padding:0">
                          <asp:GridView ID="gvTopPublishers"  runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table  b-t b-light"  Font-Size="14px" ForeColor="Gray" GridLines="None" EmptyDataText="No Publishers" ShowHeader="true" Width="100%" Visible="true" >
                                         <HeaderStyle Font-Size="15px" CssClass="panel-heading bg-dark"/>
                              
            <Columns>
      <asp:TemplateField>
          <HeaderTemplate>
            <span  class="label bg-primary">Top</span> <span class="font-bold text-primary"> Publishers</span>
          </HeaderTemplate>
          <ItemTemplate>
              <span class="text-black"><%# Eval("Publisher")%></span>
          </ItemTemplate>
      </asp:TemplateField>
                 <asp:TemplateField Visible="false">
           <ItemTemplate>
               <asp:Label ID="LblID" runat="server" Text='<%# Eval("PublisherID")%>' ></asp:Label>
                    </ItemTemplate>
      </asp:TemplateField>
                 <asp:BoundField DataField="Impression" HeaderText="Impression" ItemStyle-Font-Size="14px" SortExpression="PublisherID">
                <HeaderStyle  ForeColor="#aad7f4" />
                </asp:BoundField>
                   <asp:BoundField DataField="Click" HeaderText="Click" ItemStyle-Font-Size="14px" SortExpression="PublisherID">
                <HeaderStyle  ForeColor="#aad7f4" />
                </asp:BoundField>
            </Columns>
                     
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <RowStyle BorderColor="#CCCCCC" />
            <SortedAscendingCellStyle BackColor="#F9F9F9" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
                        </div>
                      </section>
                    </div>
                    <div class="col-md-4">
                      <section class="panel b-light">
                        <div class="panel-body" style="padding:0">
                          <asp:GridView ID="gvTopCampaigns"  runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#F0F0F0" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left"  CssClass="table  b-t b-light"  Font-Size="14px" ForeColor="Gray" GridLines="None" EmptyDataText="No Campaigns" ShowHeader="true" Width="100%" Visible="true" >
                                         <HeaderStyle Font-Size="15px" CssClass="panel-heading bg-dark"/>
                              
            <Columns>
      <asp:TemplateField>
          <HeaderTemplate>
            <span  class="label bg-warning">Top</span> <span class="font-bold text-warning"> Campaigns</span>
          </HeaderTemplate>
          <ItemTemplate>
              <asp:Linkbutton ID="lblCampaignName" runat="server" ToolTip="View Campaign Details" CommandArgument="<%# Container.DataItemIndex %>" Text='<%# Eval("Name")%>' ></asp:Linkbutton>
          </ItemTemplate>
      </asp:TemplateField>
                 <asp:TemplateField Visible="false">
           <ItemTemplate>
               <asp:Label ID="LblID" runat="server" Text='<%# Eval("CampaignID")%>' ></asp:Label>
                    </ItemTemplate>
      </asp:TemplateField>
                 <asp:BoundField DataField="Impression" HeaderText="Impression" ItemStyle-Font-Size="14px" SortExpression="CampaignID">
                <HeaderStyle  ForeColor="#aad7f4" />
                </asp:BoundField>
                   <asp:BoundField DataField="Click" HeaderText="Click" ItemStyle-Font-Size="14px" SortExpression="CampaignID">
                <HeaderStyle  ForeColor="#aad7f4" />
                </asp:BoundField>
            </Columns>
                     
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <RowStyle BorderColor="#CCCCCC" />
            <SortedAscendingCellStyle BackColor="#F9F9F9" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
                        </div>
                      </section>                  
                    </div>
                  </div>
               
            <!-- side content -->
            
            <!-- / side content -->
          
          <a href="#" class="hide nav-off-screen-block" data-toggle="class:nav-off-screen" data-target="#nav"></a>
    <script>
        $(document).ready(function () {
            var id = document.getElementById('<%= LblID.ClientID%>').innerText;
            GetImpressions(id);
            GetClicks(id);
        });

      
        function GetImpressions(id)
        {
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/GetImpression",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: "{id: '" + id + "'}",
                success: function (msg) {
                    var data = ($.parseJSON(msg.d));
               
                    $("#flot-chart").length && $.plot($("#flot-chart"), data,
                        {
                            series: {
                                lines: {
                                    show: true,
                                    fill: true,
                                    fillColor: {
                                        colors: [{
                                            opacity: 0.3
                                        }, {
                                            opacity: 0.3
                                        }]
                                    }
                                },
                                splines: {
                                    show: true,
                                    tension: 0.4,
                                    lineWidth: 1,
                                    fill: true
                                },
                                points: {
                                    show: true
                                },
                                shadowSize: 2
                            },
                            grid: {
                                hoverable: true,
                                clickable: true,
                                tickColor: "#f0f0f0",
                                borderWidth: 1,

                            },

                            xaxis: {
                                mode: "time", timeformat: "%b %d"
                            },
                            yaxis: {
                                min: 0,
                            },
                            tooltip: true,
                            tooltipOpts: {
                                content: "impression count of '%s' is %y.4",
                                defaultTheme: false,
                                shifts: {
                                    x: 0,
                                    y: 20
                                }
                            }
                        }
                                            //{
                                            //    series: {
                                            //        lines: {
                                            //            show: true,
                                            //            lineWidth: 1,
                                            //            fill: true,
                                            //            fillColor: {
                                            //                colors: [{
                                            //                    opacity: 0.3
                                            //                }, {
                                            //                    opacity: 0.3
                                            //                }]
                                            //            }
                                            //        },
                                            //        points: {
                                            //            show: true
                                            //        },
                                            //        shadowSize: 2
                                            //    },
                                            //    grid: {
                                            //        hoverable: true,
                                            //        clickable: true,
                                            //        tickColor: "#f0f0f0",
                                            //        borderWidth: 0
                                            //    },

                                            //    xaxis: {
                                            //        mode: "time", timeformat: "%b %d"
                                            //    },
                                            //    yaxis: {
                                            //        min: 0,

                                            //    },
                                            //    tooltip: true,
                                            //    tooltipOpts: {
                                            //        content: "impression count of '%s' is %y.4",
                                            //        defaultTheme: false,
                                            //        shifts: {
                                            //            x: 0,
                                            //            y: 20
                                            //        }
                                            //    }
                                            //}
                                             );


                },
                error: function (xhr, status, error) {
                    alert('ajax error');

                }
            });

        }
        function GetClicks(id)
        {
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/GetClicks",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: "{id: '" + id + "'}",
                success: function (msg) {
                    var data2 = ($.parseJSON(msg.d));
                    $("#flot-chart2").length && $.plot($("#flot-chart2"), data2,
                                             {
                                                 series: {
                                                     lines: {
                                                         show: true,
                                                         fill: true,
                                                         fillColor: {
                                                             colors: [{
                                                                 opacity: 0.3
                                                             }, {
                                                                 opacity: 0.3
                                                             }]
                                                         }
                                                     },
                                                     splines: {
                                                         show: true,
                                                         tension: 0.4,
                                                         lineWidth: 1,
                                                         fill: true
                                                     },
                                                     points: {
                                                         show: true
                                                     },
                                                     shadowSize: 2
                                                 },
                                                 grid: {
                                                     hoverable: true,
                                                     clickable: true,
                                                     tickColor: "#f0f0f0",
                                                     borderWidth: 1,

                                                 },

                                                 xaxis: {
                                                     mode: "time", timeformat: "%b %d"
                                                 },
                                                 yaxis: {
                                                     min: 0,
                                                 },
                                                 tooltip: true,
                                                 tooltipOpts: {
                                                     content: "click count of '%s' is %y.4",
                                                     defaultTheme: false,
                                                     shifts: {
                                                         x: 0,
                                                         y: 20
                                                     }
                                                 }
                                             }
                                              );

                    $("#Clicks").removeClass("active")

                },
                error: function (xhr, status, error) {
                    alert('ajax error');

                }


            });
        }
       
    </script>
</asp:Content>

