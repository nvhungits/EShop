<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wcLeftMenu.ascx.vb" Inherits="User_Controls_LeftMenu" %>
<script src='<%= ResolveClientUrl("~/Javascript/jquery-1.6.4.min.js") %>' type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    jQuery( document ).ready( function () {
        $( ".hideSub1" ).click( function () {
            $( "#panel1" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft1" ).animate( { width: "0px", opacity: 0 }, 400 );
        } );
        $( "#menuClick1" ).click( function () {
            $( "#panel2" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft2" ).animate( { width: "0px", opacity: 0 }, 400 );
            $( "#panel3" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft3" ).animate( { width: "0px", opacity: 0 }, 400 );
            $( "#panel4" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft4" ).animate( { width: "0px", opacity: 0 }, 400 );
            if ( $( "#colleft1" ).width() == 0 ) {
                $( "#panel1" ).animate( { marginLeft: "29px" }, 400 );
                $( "#colleft1" ).animate( { width: "249px", opacity: 1 }, 400 );
            }
            else {
                $( "#panel1" ).animate( { marginLeft: "-220px" }, 500 );
                $( "#colleft1" ).animate( { width: "0px", opacity: 0 }, 400 );
            }
        } );

        $( ".hideSub2" ).click( function () {
            $( "#panel2" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft2" ).animate( { width: "0px", opacity: 0 }, 400 );
        } );
        $( "#menuClick2" ).click( function () {
            $( "#panel1" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft1" ).animate( { width: "0px", opacity: 0 }, 400 );
            $( "#panel3" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft3" ).animate( { width: "0px", opacity: 0 }, 400 );
            $( "#panel4" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft4" ).animate( { width: "0px", opacity: 0 }, 400 );
            if ( $( "#colleft2" ).width() == 0 ) {
                $( "#panel2" ).animate( { marginLeft: "29px" }, 400 );
                $( "#colleft2" ).animate( { width: "249px", opacity: 1 }, 400 );
            }
            else {
                $( "#panel2" ).animate( { marginLeft: "-220px" }, 500 );
                $( "#colleft2" ).animate( { width: "0px", opacity: 0 }, 400 );
            }
        } );

        $( ".hideSub3" ).click( function () {
            $( "#panel3" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft3" ).animate( { width: "0px", opacity: 0 }, 400 );
        } );
        $( "#menuClick3" ).click( function () {
            $( "#panel1" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft1" ).animate( { width: "0px", opacity: 0 }, 400 );
            $( "#panel2" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft2" ).animate( { width: "0px", opacity: 0 }, 400 );
            $( "#panel4" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft4" ).animate( { width: "0px", opacity: 0 }, 400 );
            if ( $( "#colleft3" ).width() == 0 ) {
                $( "#panel3" ).animate( { marginLeft: "29px" }, 400 );
                $( "#colleft3" ).animate( { width: "249px", opacity: 1 }, 400 );
            }
            else {
                $( "#panel3" ).animate( { marginLeft: "-220px" }, 500 );
                $( "#colleft3" ).animate( { width: "0px", opacity: 0 }, 400 );
            }
        } );

        $( ".hideSub4" ).click( function () {
            $( "#panel4" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft4" ).animate( { width: "0px", opacity: 0 }, 400 );
        } );
        $( "#menuClick4" ).click( function () {
            $( "#panel1" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft1" ).animate( { width: "0px", opacity: 0 }, 400 );
            $( "#panel2" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft2" ).animate( { width: "0px", opacity: 0 }, 400 );
            $( "#panel3" ).animate( { marginLeft: "-220px" }, 500 );
            $( "#colleft3" ).animate( { width: "0px", opacity: 0 }, 400 );
            if ( $( "#colleft4" ).width() == 0 ) {
                $( "#panel4" ).animate( { marginLeft: "29px" }, 400 );
                $( "#colleft4" ).animate( { width: "249px", opacity: 1 }, 400 );
            }
            else {
                $( "#panel4" ).animate( { marginLeft: "-220px" }, 500 );
                $( "#colleft4" ).animate( { width: "0px", opacity: 0 }, 400 );
            }
        } );
    } );
</script>
<div id="menuDV" style="position:absolute;top:0px;left:0px;font-size:0px">
    <div id="showPanel">
        <span>
            <div style="float:left;min-height:1px" class="box_rotate">
                <a id="menuClick1" class="menuClick">Analysis Services</a>
                <a class="splitMenuCaps">&nbsp&nbsp|&nbsp&nbsp</a>
                <a id="menuClick2" class="menuClick">Reporting Services</a>
                <a class="splitMenuCaps">&nbsp&nbsp|&nbsp&nbsp</a>
                <a id="menuClick3" class="menuClick">Dashboard</a>
                <a class="splitMenuCaps">&nbsp&nbsp|&nbsp&nbsp</a>
                <a id="menuClick4" class="menuClick">Administration</a>
                <a>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</a>
            </div>
        </span>
    </div>
    <div id="colleft1">
        <!-- cool panel goes here -->
        <div id="panel1">
            <div class="leftMenuCaption hideSub1">
                <div style="float:left;width:20px;min-height:1px"></div>
                <div style="float:left;min-height:1px">
                    <a href="#">Analysis Services</a>
                </div>
            </div>
            <div style="clear:both"></div>
            <div class="leftMenuBody">
                <div style="float:left;width:220px;min-height:1px">
                    <div style="float:left;width:220px;min-height:1px">
                        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Analysis Service/AdviserWeek.aspx") %>'>Adviser By Product Week</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
                        <div style="clear:both"></div>
                        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Analysis Service/AdviserMonth.aspx") %>'>Adviser By Product Month</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
                        <div style="clear:both"></div>
                        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Analysis Service/FumByProductByDate.aspx") %>'>FUM By Product By Date</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
                        <div style="clear:both"></div>
                        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Analysis Service/FumByDateByProduct.aspx") %>'>FUM By Date By Product</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
                        <div style="clear:both"></div>
                        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Customer</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
                        <div style="clear:both"></div>
                        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Sales Week (Pivot Table)</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
                        <div style="clear:both"></div>
                        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Sales Month (Pivot Table)</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
                        <div style="clear:both"></div>
                        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>FUM (Pivot Table)</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
                    </div>
                </div>
                <div style="clear:both;height:5px;font-size:0px"></div>
                <div id="hidePanel1">
                    <a href="#" class="hideSub1">&laquo; Hide Menu</a>
                </div>
            </div>
        </div>
    </div>
    <div id="colleft2">
	    <!-- cool panel goes here -->
	    <div id="panel2">
            <div class="leftMenuCaption hideSub2">
				<div style="float:left;width:20px;min-height:1px"></div>
				<div style="float:left;min-height:1px">
                    <a href="#">Reporting Services</a>
                </div>
			</div>
			<div style="clear:both"></div>
            <div class="leftMenuBody">
		        <div style="float:left;width:220px;min-height:1px">
			        <div style="float:left;width:220px;min-height:1px">
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/AdviserFumReport.aspx") %>'>Adviser Funding FUM</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/AdviserInflowReport.aspx") %>'>Adviser Funding Inflow</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/AdviserNetflowReport.aspx") %>'>Adviser Funding Netflow</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/AdviserOutflowReport.aspx") %>'>Adviser Funding Outflow</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/FumReport.aspx") %>'>Fund Uder Management</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/FundsFlowByAccountReport.aspx") %>'>Funds Flow By Account</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/FundsFlowByProduct.aspx") %>'>Funds Flow By Product</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/InvestmentOptionTransactionReport.aspx") %>'>Inv Option Transaction</a>
                        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Investor Summary (By Option)</a>
                        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Standard Reports/InvestorSummary.aspx") %>'>Investor Summary</a>
                        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Transactions Report</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
			        </div>
		        </div>
		        <div style="clear:both;height:5px;font-size:0px"></div>
		        <div id="hidePanel2">
			        <a href="#" class="hideSub2">&laquo; Hide Menu</a>
		        </div>
            </div>
	    </div>
    </div>
    <div id="colleft3">
	    <!-- cool panel goes here -->
	    <div id="panel3">
            <div class="leftMenuCaption hideSub3">
				<div style="float:left;width:20px;min-height:1px"></div>
				<div style="float:left;min-height:1px">
                    <a href="#">Dashboard</a>
                </div>
			</div>
			<div style="clear:both"></div>
            <div class="leftMenuBody">
		        <div style="float:left;width:220px;min-height:1px">
			        <div style="float:left;width:220px;min-height:1px">
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Dashboard/dasboard mng/dashboardmng.aspx") %>'>Dashboard Management</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/Dashboard/dasboard mng/DashboardViewer.aspx") %>'>Dashboard Viewer</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
			        </div>
		        </div>
		        <div style="clear:both;height:5px;font-size:0px"></div>
		        <div id="hidePanel3">
			        <a href="#" class="hideSub3">&laquo; Hide Menu</a>
		        </div>
            </div>
	    </div>
    </div>
    <div id="colleft4">
	    <!-- cool panel goes here -->
	    <div id="panel4">
            <div class="leftMenuCaption hideSub4">
				<div style="float:left;width:20px;min-height:1px"></div>
				<div style="float:left;min-height:1px">
                    <a href="#">Administration</a>
                </div>
			</div>
			<div style="clear:both"></div>
            <div class="leftMenuBody">
		        <div style="float:left;width:220px;min-height:1px">
			        <div style="float:left;width:220px;min-height:1px">
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Alert Management</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Manage Data Warehouse Process</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Distributing</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Scheduling</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/System Config/pgInterfaceConfig.aspx") %>'>Content Management</a>
				        <div style="clear:both"></div>
				        <div class="splitLinks"></div>
				        <div style="clear:both"></div>
				        <a class="subLink" href='<%= ResolveClientUrl("~/Interfaces/pgUnderConstruction.aspx") %>'>Workflow Management</a>
                        <div style="clear:both"></div>
                        <div class="splitLinks"></div>
			        </div>
		        </div>
		        <div style="clear:both;height:5px;font-size:0px"></div>
		        <div id="hidePanel4">
			        <a href="#" class="hideSub4">&laquo; Hide Menu</a>
		        </div>
            </div>
	    </div>
    </div>
</div>