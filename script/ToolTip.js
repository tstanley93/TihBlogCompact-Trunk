// Extended Tooltip Javascript
// copyright 9th August 2002, 3rd July 2005, 24th August 2008
// by Stephen Chapman, Felgall Pty Ltd

// permission is granted to use this javascript provided that the below code is not altered


function pw() { return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth };

function mouseX(evt) { return evt.clientX ? evt.clientX + (document.documentElement.scrollLeft || document.body.scrollLeft) : evt.pageX; }

function mouseY(evt) { return evt.clientY ? evt.clientY + (document.documentElement.scrollTop || document.body.scrollTop) : evt.pageY }

function popUp(evt, oi) {
    if (document.getElementById) {
        var wp = pw();
        dm = document.getElementById(oi);
        ds = dm.style;
        st = ds.visibility;
//        if (dm.offsetWidth) ew = dm.offsetWidth;
//        else if (dm.clip.width) ew = dm.clip.width;
        if (st == "visible" || st == "show") {
            ds.visibility = "hidden"; 
        }
        else {
            tv = mouseY(evt) + 20;
            //            lv = mouseX(evt) - (ew / 4);
            lv = mouseX(evt);
            if (lv < 2) lv = 2;
//            else if (lv + ew > wp) lv -= ew / 2;
            lv += 'px';
            tv += 'px';
            ds.left = lv;
            ds.top = tv;
            ds.visibility = "visible";
        }
    }
}

function PopulateDiv(evt, elemName, message) {
    if (document.getElementById) {
        var StrSplit = message.split(".");
        for (var i = 0; i < StrSplit.length; i++) {
            var j = 1 + i;
            var LiteralName = "ctl00_TipLabel" + j;
            var Lit = document.getElementById(LiteralName);
            if (StrSplit[i] == "") {
            }
            else {
                Lit.innerHTML = StrSplit[i].toString();
                var liName = "TipLi" + j;
                document.getElementById(liName).style.display = 'list-item';
            }
        }
        popUp(evt, elemName);
    }
}

function ConfirmAdd() {
    if (confirm("Commenting Policy:  The Arc of Grays Harbor encourages comments from readers. Please keep your comments respectful, on issues relevant to developmental disabilities and not an attack on any individual or organization. We reserve the right not to approve any comments that are offensive, defamatory or off-topic content.")) {

    }
    else {
        document.getElementById("ctl00$_mainContentPlaceHolder$txtHidData").value = "false";     
    }
}

