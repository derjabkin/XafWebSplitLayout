var DXagent = navigator.userAgent.toLowerCase();
var DXopera = (DXagent.indexOf("opera") > -1);
var DXsafari = DXagent.indexOf("safari") > -1;
var DXie = (DXagent.indexOf("msie") > -1 && !DXopera);
var DXns = (DXagent.indexOf("mozilla") > -1 || DXagent.indexOf("netscape") > -1 || DXagent.indexOf("firefox") > -1) && !DXsafari && !DXie && !DXopera;
function DXattachEventToElement(element, eventName, func) {
    if (element) {
        if (DXns || DXsafari)
            element.addEventListener(eventName, func, true);
        else {
            if (eventName.toLowerCase().indexOf("on") != 0)
                eventName = "on" + eventName;
            element.attachEvent(eventName, func);
        }
    }
}
function GetWindowHeight() {
    var height = 0;
    if (typeof (window.innerHeight) == 'number') {
        height = window.innerHeight;
    } else if (document.documentElement && document.documentElement.clientHeight) {
        height = document.documentElement.clientHeight;
    } else if (document.body && document.body.clientHeight) {
        height = document.body.clientHeight;
    }
    var margin = 0;
    if (document.body.currentStyle) {
        margin = parseInt(document.body.currentStyle.margin);
    }
    return parseInt(height) - (margin * 2);
}
function AdjustSize() {
    var middleRowContent = document.getElementById("CP");
    var middleRowParent = document.getElementById("MRC");
    var mainTable = document.getElementById("MT");
    //    if (!__aspxIE) {
    //        middleRowContent.style.height = "0px"
    //    }

    var getHeight = function (id) {
        var element = document.getElementById(id);
        if (element) {
            return element.offsetHeight;
        }
        else {
            return 0;
        }
    };

    var getParentTagHeight = function (id, parentTagName) {
        var element = document.getElementById(id);
        parentTagName = parentTagName.toUpperCase();
        while (element && element.tagName.toUpperCase() != parentTagName) {
            element = element.parentNode;
        }

        if (element) {
            return element.offsetHeight;
        }
        else {
            return 0;
        }

    }
    var mainTableHeight;

    mainTableHeight = mainTable.offsetHeight;

    var windowHeight = GetWindowHeight();
    var footer = document.getElementById("Footer");
    var newHeight = windowHeight - mainTableHeight - 20;
    var elementToResize = document.getElementById("MasterDetailSplitter");
    var footerTableHeight = footer != null ? footer.getElementsByTagName("table")[0].offsetHeight : 0;

    var middleRowHeight = windowHeight - mainTableHeight + footerTableHeight + middleRowParent.offsetHeight - getHeight("UPVH") -
        getHeight("TB_Menu") - getParentTagHeight("UPQC", "td");

    if (elementToResize) {
        var controlToResize = elementToResize.ClientControl;
        if (controlToResize) {
            controlToResize.SetWidth(window.innerWidth - 50 - document.getElementById("LPcell").offsetWidth);
            controlToResize.SetHeight(middleRowHeight - 20);
            if (elementToResize.parentNode.offsetHeight > elementToResize.offsetHeight)
                controlToResize.SetHeight(elementToResize.parentNode.offsetHeight);

            middleRowContent.style.height = middleRowHeight + "px";
        }
    }
    else {
        if (windowHeight > mainTable.offsetHeight) {
            middleRowContent.style.height = middleRowHeight + "px";
        }
        else {
            middleRowContent.style.height = "100%";
        }
    }



}


