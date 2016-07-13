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

//////////////////////////////
//This code is used for AJAX//
/////////////////////////////
var xmlhttp;
function loadXMLDoc(url, callbackFunction, content)
{
    // code for Mozilla, etc.
    if (window.XMLHttpRequest)
    {
        if (content == '')	
            c=null;
        else
            c=content;
        
        xmlhttp=new XMLHttpRequest();
        xmlhttp.onreadystatechange= function() {eval(callbackFunction);} ;
        xmlhttp.open("POST",url,false);        
        xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded") ;	
        xmlhttp.send(c);
                
    }
    // code for IE
    else if (window.ActiveXObject)
    {
        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
        if (xmlhttp)
        {
            xmlhttp.onreadystatechange= function() {eval(callbackFunction);} ;
            xmlhttp.open("POST",url,false);
            xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded") ;
            xmlhttp.send(content);
        }
    }
}
////////////////////////////

//Clear all the Options for Select Object
function clearOptions(selectObj)
{
   while (selectObj.length>0)
   {
    selectObj.remove(selectObj.length-1)
   }

}

//General function to create Options for Select Object
function createOptions(selectObj,txtObj,valueObj)
{
    var optionObj = document.createElement('option')
    optionObj.text = txtObj
    optionObj.value = valueObj
    try
    {
        selectObj.add(optionObj,null)
    }
    catch(ex)
    {
        selectObj.add(optionObj)
    }
}

///////////////////////
//	FUNCTION ACCEPT NUMBER ONLY
///////////////////////
function NumberOnly()
{
	var x=event.keyCode;
	if(x>47 && x <58)
		return true;
	else
		return false;
}

//FUNCTION CHECK ALL FIELD MUST BE FILLED IN//
function checkNull(form)
{
for (x=0; x < form.elements.length; x++ )  {		
	if (form.elements(x).type == "text") {
		if(form.elements(x).value == "" ) {
			alert("Can not use blank value !") ;
			form.elements(x).focus() ;
			return false ;
			}
		}		
	}		
}


//Function Left Trim and Right Trim to delete the space value
function LTrim(iStr)
{
	while (iStr.charCodeAt(0) <= 32)
	{
		iStr=iStr.substr(1);
	}
	return iStr;

}

function RTrim(iStr)

{
    while (iStr.charCodeAt(iStr.length - 1) <= 32)
	{
		iStr=iStr.substr(0, iStr.length - 1);
	}
	return iStr;
}

//trim string
function trim(str)
{
    //trim left
    while (str.substring(0,1) == ' ')
    {
        str = str.substring(1, str.length);
    }
    //trim right
    while (str.substring(str.length-1, str.length) == ' ')
    {
        str = str.substring(0,str.length-1);
    }
    return str;
}

//convert Date String from dd/mm/yyyy to mm/dd/yyyy
function toMMDDYYYY(pdate)
{
    var arrDate  = pdate.split("/");
    return (arrDate[1].toString()+"/"+arrDate[0].toString()+"/"+arrDate[2].toString());
}

//convert Date String from dd/mm/yyyy to yyyy/mm/dd
function toYYYYMMDD(pdate)
{
    var arrDate  = pdate.split("/");
    return (arrDate[2].toString()+"/"+arrDate[1].toString()+"/"+arrDate[0].toString());
}



//Begin VTHIEP Functions
//Javascript written by VTHIEP 03-08-2006//



//Function happens when submit button is clicked
//This function is use to view report
function ViewReport_onclick(ReportName)
{
     document.form1.txtAction.value = ReportName
     document.form1.submit()
}


//Function to generate Options for TopN of Select Object
function generateTopN()
{
    var GroupLevel2 = document.getElementById("GroupLevel2")
    var TopNObj = document.getElementById("TopN")
   
    //Clear Options before inserting
    clearOptions(TopNObj)
    //Insert Default Options
    createOptions(TopNObj,"0 - All Records","0")
    createOptions.selectedIndex = 0  
    if (GroupLevel2.value == 0)
    {         
        createOptions(TopNObj,"5 - Top 5","5")
        createOptions(TopNObj,"10 - Top 10","10")
        createOptions(TopNObj,"20 - Top 20","20")
    }
}


//End VTHIEP Functions
/*******************************************************************************/






/*************************************************************************/
//Begin NVKHOA Functions for ClientMailMergeReport
//Javascript written by NVKHOA 12-10-2006//

function setDateOpened()
{
    if (document.form1.Checkbox1.checked == true)
    {
        document.getElementById('DateOpened').style.backgroundColor = '#ECE5D8'
        document.form1.DateOpened.value = "";
        
        document.form1.DateOpened.disabled = true;
        
        document.form1.hidden1.value = "1"
    
        var img = document.getElementById("Img2");
        img.disabled = true;
    }
    else
    {
        document.getElementById('DateOpened').style.backgroundColor = 'White'
        document.form1.DateOpened.disabled = false
        
        document.form1.hidden1.value = "0"
    
        var img = document.getElementById("Img2");
        img.disabled = false;
    }
}

function setDateClosed()
{
    if (document.form1.Checkbox2.checked == true)
    {
        document.getElementById('DateClosed').style.backgroundColor = '#ECE5D8'
        document.form1.DateClosed.value = "";
        document.form1.DateClosed.disabled = true;
        
        document.form1.hidden2.value = "1"
    
        var img = document.getElementById("Img3");
        img.disabled = true;
    }
    else
    {
        document.getElementById('DateClosed').style.backgroundColor = 'White'
        document.form1.DateClosed.disabled = false
        
        document.form1.hidden2.value = "0"
    
        var img = document.getElementById("Img3");
        img.disabled = false;
    }
}

function setConsent()
{
    if (document.form1.Consent.checked == true)
    {
        document.form1.hidden3.value = "1"
    }
    else
    {
        document.form1.hidden3.value = "0";
    }
}

function setException()
{
    if (document.form1.Exception.checked == true)
    {
        document.form1.hidden4.value = "1";
    }
    else
    {
        document.form1.hidden4.value = "0";
    }
}
/*************************************************************************/



