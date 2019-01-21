/// <reference name="MicrosoftAjax.js"/>
function changeAllGridCheckBoxState(chkBoxHeaderID, chkBoxArrID)
{
    var chBoxHeader = document.getElementById(chkBoxHeaderID);
    if (null == chkBoxHeaderID)
        return;
    var chkState = chBoxHeader.checked;
    var chkBoxArr = chkBoxArrID.split(';');
    for (var i = 0; i < chkBoxArr.length; i++) {
        var chkBoxItem = document.getElementById(chkBoxArr[i]);
        chkBoxItem.checked = chkState;
    }
}

//This function is used to restrict enrting specific character as per the type of filed.
//Types are 1. Numeric - allows only digits from 0-9 other character are restricted.
//          2. AlphaNumeric - allows only alphabets from a-z and digits from 0-9 other 
//                            character are restricted.     
function Validation(e, type) {
    var keynum;
    var keychar;
    var numcheck;
    if (window.event) // IE
    {
        keynum = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        keynum = e.which;
    }
    if (keynum != 8 && keynum != 22 && keynum != undefined) {
        keychar = String.fromCharCode(keynum);
        if (type == 'Numeric')
            numcheck = /^[0-9]$/;
        else if (type = 'AlphaNumeric')
            numcheck = /^[A-Za-z0-9 ]$/;
        return numcheck.test(keychar);
    }
    else {
        return true;
    }
}

function confirmMsg(frm) {
    // loop through all elements
    for (i = 0; i < frm.length; i++) {
        // Look for our checkboxes only
        if (frm.elements[i].name.indexOf("chkboxItem") != -1) {
            // If any are checked then confirm alert, otherwise nothing happens
            if (frm.elements[i].checked)
                return confirm('Are you sure you want to delete your selection(s)?')
        }
    }
}

