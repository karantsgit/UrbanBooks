var numbersOnly = /^\d+$/;
var decimalOnly = /^\s*-?[1-9]\d*(\.\d{1,2})?\s*$/;
var uppercaseOnly = /^[A-Z]+$/;
var lowercaseOnly = /^[a-z]+$/;
var stringOnly = /^[A-Za-z0-9]+$/;

$(document).ready(
    function () {
        setMenu();
    }
);

function setMenu() {
    var url = window.location.toString();
    url = url.split("?")[0];
    
    var temp = url.split("/");

    var keyWord = '';
    for (i = 3; i < temp.length; i++) {
        keyWord += '/' + temp[i] ;
    }
    $('a[href~="' + keyWord + '"]').parent().addClass("active");
    if (!$('body').hasClass("sidebar-xs")) {
        $('a[href~="' + keyWord + '"]').parent().parent().show();
    }
    $('a[href*="/Project/Index"]').find('span').css("cursor", "pointer")
    $('a[href="/"]').find('span').css("cursor", "pointer")
    $('a[href="/crm/"]').find('span').css("cursor", "pointer")

}


function ClrearErrorSuccessMsgs() {
    $("#success-notification-div").css("display", "none");
    $("#error-notification-div").css("display", "none");
    $("#success-notification-div-for").hide();
    $("#error-notification-div-for").hide();
}

function ShowErrorSuccessMsgs(statusType, result) {
    
    if (result) {
        $("#success-notification-div").show();
        $("#success-notification-div").removeAttr('style');
        var statusType = statusType + "d";
        $("#successmsg").html("Record " + statusType + " successfully.");
    }
    else {
        $("#error-notification-div").show();
        $("#error-notification-div").removeAttr('style');
        $("#errormsg").html("Record " + statusType + " failed.");
    }
}

function ShowErrorMsgDetails(result) {
    var msg = "";
    for (var i = 0; i < result.Message.length ; i++)
    {
        msg = msg + result.Message[i] + "<br/>";
    }
        $("#error-notification-div").show();
        $("#error-notification-div").removeAttr('style');
        $("#errormsg").html(msg);
    
}

/*Get query string value at client side by key*/
function GetQueryStringValueByKey(Strkey) {
    var key = Strkey;
    key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
    var qs = regex.exec(window.location.href);
    var retValue;
    if (qs != null) {
        retValue = qs[1];
    }
    return retValue;
}
function OnlyNumber(e) {
    var unicode = e.charCode ? e.charCode : e.keyCode;
    if (unicode != 8) { /*if the key isn't the backspace key (which we should allow)*/
        if (unicode < 48 || unicode > 57) /*if not a number*/
            return false; /*disable key press*/
    }
}
function OnlyDecimal(el, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var number = el.value.split('.');
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    /*just one dot*/
    if (number.length > 1 && charCode == 46) {
        return false;
    }
    /*get the carat position*/
    var caratPos = getSelectionStart(el);
    var dotPos = el.value.indexOf(".");
    if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
        return false;
    }
    return true;
}
function getSelectionStart(o) {
    if (o.createTextRange) {
        var r = document.selection.createRange().duplicate();
        r.moveEnd('character', o.value.length);
        if (r.text == '') return o.value.length;
        return o.value.lastIndexOf(r.text);
    } else return o.selectionStart;
}
function IsDecimal(text)
{
    if (text !== '') {
        if (decimalOnly.test(text)) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}
function ErrorHandler(msg) {
    if (msg != undefined && msg != "") {
        alert(msg);
    } else {
        alert("An error occurred. Please try again later.");
    }
}
function onErrorCustom(e) {
    e.sender.cancelChanges();
    var message = "";
    $.each(e.errors, function (key, value) {
        $.each(value.errors, function () {
            message += this + "\n\n";
        });
    });
    alert(546);
    showNotification(message, 2);
}
function RestrictSpace(textboxId) {
    $("#" + textboxId).keydown(function (e) {
        if (e.which === 32)
            return false;

        $("#" + textboxId).change(function (e) {
            this.value = this.value.replace(/\s/g, "");
        });
    });
}


