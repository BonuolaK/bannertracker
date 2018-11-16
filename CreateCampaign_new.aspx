<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CreateCampaign.aspx.vb" Inherits="CreateCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <div class="panel panel-default">
            <header class="panel-heading">
                <span class="h4">Create Campaign</span>
            </header>
            <div class="panel-heading">
                <ul class="nav nav-tabs font-bold tabstep">
                    <li class="active" id="listep1"><a runat="server" id="astep1">Campaign Details</a></li>
                    <li id="listep2"><a runat="server" id="astep2">Add Banners</a></li>

                </ul>
            </div>
            <div class="panel-body">
                <div class="line line-lg"></div>
                <div class="progress progress-xs m-t-md">
                    <div id="divprogress" runat="server" class="progress-bar bg-success"></div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div style="display: none" id="divsuccess" runat="server" class="alert alert-success">
                            <button type="button" class="close" data-dismiss="alert">×</button>
                            <i class="fa fa-ok-sign"></i>
                            <label runat="server" id="errormsg"></label>
                        </div>
                    </div>
                </div>
                <div class="tab-content">
                    <div class="tab-pane" runat="server" id="step1">
                        <div class="form-group pull-in clearfix">
                            <div class="col-sm-6">
                                <label>Client</label><%--&nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator2" ValidationGroup="campaign" ControlToValidate="ddlClient" Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:CompareValidator> --%>
                                <asp:DropDownList ID="ddlClient" AutoPostBack="true" DataTextField="ClientName" DataValueField="ClientID" runat="server" class="form-control m-b">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                                <label>Brand</label><%--&nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator1" ValidationGroup="campaign" ControlToValidate="ddlBrand" Operator="NotEqual" ValueToCompare="0" runat="server" ForeColor="Red" ErrorMessage="This field is required"></asp:CompareValidator>--%>
                                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
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

                                <label>Campaign Name</label>  <%--&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="TxtName" runat="server" ValidationGroup="campaign" ErrorMessage="This field is required"></asp:RequiredFieldValidator>--%>
                                <asp:TextBox ID="TxtName" class="form-control" placeholder="Type campaign name" runat="server"></asp:TextBox>
                                <span id="loader"></span>
                            </div>
                            <div class="col-sm-6">

                                <label>No of Banners</label>
                                <asp:TextBox ID="TxtBannerNo" class="form-control" placeholder="Enter number of banners" runat="server"></asp:TextBox>
                            </div>

                        </div>

                        <!-- Old remove -->
                        <footer class="panel-footer text-right bg-light lter" runat="server" visible="false">

                            <asp:LinkButton ID="BtnSubmit1" ValidationGroup="campaign" CssClass="btn btn-success btn-s-xs" runat="server" ToolTip="Add Banner">Next Step <i class="i i-arrow-right2"></i></asp:LinkButton>

                        </footer>
                    </div>

                    <div class="tab-pane" runat="server" id="step2">
                        <!-- Old remove -->
                        <div class="row" runat="server" visible="false">
                            <div class="col-sm-8 col-md-offset-2">
                                <div style="max-height: 220px; overflow: auto">
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
                                </div>
                                <div class="col-sm-6" style="width: 100%; text-align: right; padding-top: 10px">
                                    <asp:Button ID="BtnAdd" CssClass="btn btn-sm btn-default" runat="server" Text="Add Line" />
                                    <%--<asp:Button Text="Add Line 2" ID="AddRow" ClientIDMode="Static" OnClientClick="return false;" CssClass="btn btn-sm btn-default" runat="server" />--%>
                                </div>
                            </div>
                        </div>

                        <div class="alert alert-info">
                            <i class="fa fa-info-circle"></i> Please upload an image with a maximum upload size of 50kb
                        </div>

                        <!-- New -->
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered" id="tblBanners">
                                <thead>
                                    <tr>
                                        <th>Banner Name</th>
                                        <th>Select File</th>
                                        <th class="text-center"><a href="javascript:;" class="AddRow" title="Add New Row"><i class="fa fa-2x fa-plus text-success"></i></a></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td colspan="3">Add new row</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <!-- Old remove -->
                        <footer style="margin-top: 32px" class="panel-footer bg-light lter" runat="server" visible="false">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="BtnModify" CssClass="btn btn-danger btn-s-xs" runat="server" ToolTip="Modify Campaign Details"><i class="i i-arrow-left2"></i> Prev Step</asp:LinkButton>
                                        <asp:Label ID="lblcampaignID" runat="server" Visible="false" Text="0"></asp:Label>
                                        <asp:Label ID="lblName" runat="server" Visible="false" Text=""></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:LinkButton ValidationGroup="banner" ID="BtnSchedule" CssClass="btn btn-primary btn-s-xs" runat="server" ToolTip="Proceed to schedule"><i class="fa  fa-hand-o-right"></i></asp:LinkButton>
                                        <asp:Label ID="lblbannerno" runat="server" Visible="false" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>

                        </footer>

                    </div>
                </div>
                <ul class="pager wizard m-b-sm">
                    <li class="previous" style="display: none;"><a href="javascript:;">Previous</a></li>
                    <li class="next" id="next"><a href="javascript:;">Next</a></li>
                    <li class="submit next" style="display: none;">
                        <asp:LinkButton Text="Schedule" ID="BtnCreateCampaign" OnClientClick="return false;" runat="server" />
                    </li>
                </ul>
            </div>

            <asp:Label Text="0" ID="CampaignID" CssClass="none" runat="server" />
        </div>

        <script>
            $(document).ready(function () {
                $("#next").click(function () {
                    $("#MainContent_divsuccess").hide();

                    var validator = $("#Form1").validate();

                    var a = validator.element("#MainContent_ddlClient");
                    var b = validator.element("#MainContent_ddlBrand");
                    var c = validator.element("#MainContent_TxtName");
                    var d = validator.element("#MainContent_TxtBannerNo");

                    if (a == true && b == true && c == true && d == true) {


                        //var insert_campaign = InsertCampaign();
                        var BannerNo = $("#MainContent_TxtBannerNo").val();
                        //var return_val = "";

                        $.ajax({
                            url: "CreateCampaign.aspx/NewCampaign",
                            type: "POST",
                            data: "{ ClientID : '" + $('#MainContent_ddlClient').val() + "', BrandID : '" + $('#MainContent_ddlBrand').val() + "', CampaignName : '" + $('#MainContent_TxtName').val() + "', BannerNo: '" + BannerNo + "', CampaignID : '" + $("#MainContent_CampaignID").text() + "'}",
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            async: "true",
                            cache: "false",
                            success: function (data) {
                                if ($.isNumeric(data.d)) {

                                    $("#MainContent_CampaignID").text(data.d);
                                    $("#MainContent_divsuccess").hide();
                                    $(".tabstep li").removeClass("active");
                                    $("#listep2").addClass("active");

                                    $("#next").hide();

                                    $(".previous").show();
                                    $(".submit").show();



                                    $("#tblBanners tbody").empty();

                                    for (var i = 0; i < BannerNo; i++) {
                                        $("#tblBanners tbody").append(
                                            "<tr>"
                                                + "<td><input type='text' name='txtBannerName' id='txtBannerName' class='form-control input-sm txtBannerName' placeholder='Enter banner name'></td>"
                                                + "<td><input type='file' id='fuBanner' class='fileInput'></td>"
                                                + "<td class='text-center'><a href='javascript:;' title='Remove Row' class='RemoveRow'><i class='fa fa-2x fa-minus-square text-danger'></i></a></td>"
                                            + "</tr>"
                                        );
                                    }

                                    

                                    $("#MainContent_step1").hide();
                                    $("#MainContent_step2").show();

                                    $(".progress-bar").css("width", "75%");

                                }
                                else if (data.d == "exists") {
                                    $("#MainContent_divsuccess").removeClass("alert-success").addClass("alert-danger");
                                    $("#MainContent_errormsg").text("Campaign name exists.Please,try again.");
                                    $("#MainContent_divsuccess").show();
                                }

                                else {
                                    $("#MainContent_divsuccess").removeClass("alert-success").addClass("alert-danger");
                                    $("#MainContent_errormsg").text("Unable to create campaign.Please,try again.");
                                    $("#MainContent_divsuccess").show();
                                }

                            },
                            error: function (data) {
                                // alert(data.statusText);
                                // return false;
                            }
                        });

                        
                    }
                });

                $(".previous").click(function () {
                    $(".tabstep li").removeClass("active");
                    $("#listep1").addClass("active");

                    $("#MainContent_step1").show();
                    $("#MainContent_step2").hide();

                    $(this).hide();
                    $("#next").show();
                    $(".submit").hide();

                    $(".progress-bar").css("width", "10%");
                });

                $(document).on("click", ".AddRow", function () {
                    $("#tblBanners tbody").append(
                        "<tr>"
                            + "<td><input type='text' name='txtBannerName' id='txtBannerName' class='form-control input-sm txtBannerName' placeholder='Enter banner name'></td>"
                            + "<td><input type='file' id='fuBanner' class='fileInput'></td>"
                            + "<td class='text-center'><a href='javascript:;' title='Remove Row' class='RemoveRow'><i class='fa fa-2x fa-minus-square text-danger'></i></a></td>"
                        + "</tr>"
                    );
                });

                $(document).on("click", ".RemoveRow", function () {
                    if ($("#tblBanners tbody").find("tr").length > 1) {
                        $(this).parents("tr").remove();
                    }
                    else {
                        alert("At least one banner is required");
                    }
                });
  

                $(document).on("change", ".txtBannerName", function () {
                    if ($(this).val() != "") {
                        $(this).parents("tr").removeClass("has-error").addClass("has-success");
                    }
                    else {
                        $(this).parents("tr").removeClass("has-success").addClass("has-error");
                    }
                })

                
                /*
                * Check file size and extension before upload
                */
                
                $('body').on('change', '.fileInput', function () {
                    var input = this;
                    error = "";
                    if (this.files[0].size > 500000)
                    {
                        error += "File is too large";
                    }

                    var ext = this.files[0].type;
                    if ($.inArray(ext, ['image/gif', 'image/png', 'image/jpg', 'image/jpeg']) == -1) {
                        error += ", Invalid File Type";
                    }

                    if (error != "") {
                        $(this).val("");
                        alert(error);
                    }
                });


                $(document).on("click", "#MainContent_BtnCreateCampaign", function () {

                    // get the number of rows in table
                    var grp = $("#tblBanners tbody").find("tr");


                    // This variable is used to check how many of the input fields have been filled
                    var count = 0;

                    var list = [];

                    // get the banner name and file on each row
                    var data = new FormData();

                    for (var i = 1; i <= grp.length; i++) {

                        var fileUpload = $("#tblBanners tbody tr:nth-child(" + i + ")").find("#fuBanner")[0];
              
                        if (fileUpload != '') {
                            data.append(fileUpload.files[0].name, fileUpload.files[0]);
                        }



                    }

                    for (var j = 1; j <= grp.length; j++)
                    {
                        var input = $("#tblBanners tbody tr:nth-child(" + i + ")").find(".txtBannerName");

                        if ($("#tblBanners tbody tr:nth-child(" + j + ")").find("#fuBanner").val() != '') {
                            if (input.val() != "") {
                                var obj = {};
                              
                                data.append("banner_"+ j, input.val());

                                input.parents("tr").removeClass("has-error").addClass("has-success");
                                count++;
                            }
                            else {
                                input.parents("tr").removeClass("has-success").addClass("has-error");
                            }
                        }
                    }

                    


                    //check if the count variable is equal to the number if rows in the table
                    //this is to ensure all the banner names have been filled



                    if (count == grp.length) {
                        alert(data);
                        // true. Send BannerFormData to server
                        $.ajax({
                            url: "FileUploadHandler.ashx",
                            type: "POST",
                            data:  data,
                            contentType: false,
                            processData: false,
                            success: function (data) {
                                if (data == "InvalidCampaignData") {
                                    $("#MainContent_divsuccess").removeClass("alert-success").addClass("alert-danger");
                                    $("#MainContent_errormsg").text("Please provide campaign details.");
                                    $("#MainContent_divsuccess").show();
                                }
                                else {
                                    if (data == "uploaded")
                                        alert("Banners Uploaded Successfully");
                                    else
                                        alert("Unable to upload banners... Try Again");
                                }
                            },
                            error: function (data) {
                                alert(data.statusText);
                            }
                        });

                    }
                    else {
                        alert("Please fill the required fields");
                    }

                    
                });


            });
    </script>
</asp:Content>


