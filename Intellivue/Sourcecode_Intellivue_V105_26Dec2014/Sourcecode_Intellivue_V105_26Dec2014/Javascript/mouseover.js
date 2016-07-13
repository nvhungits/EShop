// ============================================================================ '
// =         Copyright (c) 2006. MMSOFT Co., Ltd. All Rights Reserved.        = '
// =                                                                          = '
// =  Permission to use, copy, modify, and distribute this software and its   = '
// =  documentation for any purpose, without fee, and without a written       = '
// =  agreement, is here by granted, provided that the above copyright notice,= '
// =  this paragraph and the following two paragraphs appear in all copies,   = '
// =  modifications, and distributions.  Created by:                          = '
// =                                                                          = '
// =                        M.M..S.O.F.T.W.A.R.E                              = '
// =                                                                          = '
// =  MM Software Co., Ltd, 35 Tan Vinh Street, Ward 4                        = '
// =  District 4, Ho Chi Minh City, Viet Nam.                                 = '
// =  For technical information, contact mmsoftvn@gmail.com                   = '
// =                                                                          = '
// =  IN NO EVENT SHALL REGENTS BE LIABLE TO ANY PARTY FOR DIRECT, INDIRECT,  = '
// =  SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS,  = '
// =  ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF  = '
// =  REGENTS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.             = '
// =                                                                          = '
// =  REGENTS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT NOT       = '
// =  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A = '
// =  PARTICULAR PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF     = '
// =  ANY, PROVIDED HEREUNDER IS PROVIDED "AS IS". REGENTS HAS NO OBLIGATION  = '
// =  TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR              = '
// =  MODIFICATIONS.                                                          = '
// ============================================================================ '

// =  Written by: Vo Tan Phong. Lastest modified: 04 Oct 2006.                = '
// =  This file is used for process the mouse over event on the home page.    = '

var analysis_h =new Image(); 
analysis_h.src = "../Images/Color_BIUser.gif";
var analysis_nh = new Image(); 
analysis_nh.src = "../Images/Gray_BIUser.gif";

var report_h =new Image(); 
report_h.src = "../Images/Color_Report.gif";
var report_nh = new Image(); 
report_nh.src = "../Images/Gray_Report.gif";

var administration_h = new Image();
administration_h.src = "../Images/Color_Administration.gif";
var administration_nh = new Image();
administration_nh.src = "../Images/Gray_Administration.gif";

var dashboard_h = new Image();
dashboard_h.src = "../Images/Color_Dashboard.gif";
var dashboard_nh = new Image();
dashboard_nh.src = "../Images/Gray_Dashboard.gif";

var logout_h =new Image(); 
logout_h.src = "../Images/Color_Logout.gif";
var logout_nh = new Image(); 
logout_nh.src = "../Images/Gray_Logout.gif";

var kpi_h = new Image();
kpi_h.src = "../Images/Color_KPI.gif";
var kpi_nh = new Image();
kpi_nh.src = "../Images/Gray_KPI.gif";

var manageDashboard_h = new Image();
manageDashboard_h.src = "../Images/Color_ManageDashboard.jpg";
var manageDashboard_nh = new Image();
manageDashboard_nh.src = "../Images/Gray_ManageDashboard.jpg";

var alertConfig_h = new Image();
alertConfig_h.src = "../Images/Color_AlertConfig.jpg";
var alertConfig_nh = new Image();
alertConfig_nh.src = "../Images/Gray_AlertConfig.jpg";

var mdwp_h = new Image();
mdwp_h.src = "../Images/Color_MDWP.jpg";
var mdwp_nh = new Image();
mdwp_nh.src = "../Images/Gray_MDWP.jpg";

var cr_h = new Image();
cr_h.src = "../Images/Color_CustomzeReport.jpg";
var cr_nh = new Image();
cr_nh.src = "../Images/Gray_CustomizeReport.jpg";

var theObj="";

//Analysis function
function analysisover() 
{
        document.analysis.src = analysis_h.src;
}
function analysisout() 
{
        document.analysis.src = analysis_nh.src;
}
//End

//Report function
function reportover() 
{
        document.report.src=report_h.src;
}
function reportout() 
{
        document.report.src=report_nh.src;
}
//End

//Administration function
function administrationover()
{
	document.administration.src = administration_h.src;
}
function administrationout()
{
	document.administration.src = administration_nh.src;
}
//End

//Dashboard function
function dashboardover()
{
	document.dashboard.src = dashboard_h.src;
}
function dashboardout()
{
	document.dashboard.src = dashboard_nh.src;
}
//End

//Logout function
function logoutover() 
{
        document.logout.src=logout_h.src;
}

function logoutout() 
{
        document.logout.src=logout_nh.src;
}
//End

//Manage KPI function
function manageKPIover()
{
	document.manageKPI.src = kpi_h.src;
}
function manageKPIout()
{
	document.manageKPI.src = kpi_nh.src;
}
//End

//Manage Dashboard function
function manageDashboardover()
{
	document.manageDashboard.src = manageDashboard_h.src;
}
function manageDashboardout()
{
	document.manageDashboard.src = manageDashboard_nh.src;
}
//End

//Alert Config funtion
function alertConfigover()
{
	document.alertConfig.src = alertConfig_h.src;
}
function alertConfigout()
{
	document.alertConfig.src = alertConfig_nh.src;
}
//End

//Manage Data warehouse process function
function mdwpover()
{
	document.mdwp.src = mdwp_h.src;
}
function mdwpout()
{
	document.mdwp.src = mdwp_nh.src;
}
//End

//Customize Report funtions
function crover()
{
	document.cr.src = cr_h.src;
}
function crout()
{
	document.cr.src = cr_nh.src;
}
//End