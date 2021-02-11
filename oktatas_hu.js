// ==UserScript==
// @name         oktatas.hu
// @namespace    oktatas_hu_v1
// @version      1.0
// @author       ahurkatolto
// @description  🔮 https://github.com/ahurkatolto/oktatas.hu
// @iconURL      https://www.oktatas.hu/design/images/favicon.ico
// @updateURL    https://raw.githubusercontent.com/ahurkatolto/oktatas.hu/master/oktatas_hu.js
// @match        *://dload-oktatas.educatio.hu/*
// @grant        none
// ==/UserScript==

(function() {
    // create buttons
    var div = document.createElement("div");
    div.setAttribute("style","position: fixed; z-index: 999; left: 1%; bottom: 3%; font-size: 25px; text-align: center;");
    div.innerHTML = `<a href="${window.location.href.replace("_fl.pdf","_ut.pdf")}" target="_blank" style="text-decoration: none;">🔮</a><br><a style="text-decoration: none; cursor: pointer;" id="splits">📄📄</a>`;
    document.body.appendChild(div);
    document.getElementById("splits").addEventListener("click", splitScreen, false);
    // function for the splitscreen toggle
    function splitScreen() {
        if(document.getElementsByTagName("embed").length>1) {
            document.getElementById("secondHalf").remove();
            document.getElementsByTagName("embed")[0].setAttribute("style","width:100%; height: 100%; position:absolute; left: 0; top: 0;");
            document.getElementById("splits").innerText = "📄📄";
        }
        else {
            document.getElementsByTagName("embed")[0].setAttribute("style","width:50%; height: 100%; position:absolute; left: 0; top: 0;");
            var secondHalf = document.createElement("embed");
            secondHalf.setAttribute("style","width:50%; height: 100%; position:absolute; right: 0; top: 0;");
            secondHalf.setAttribute("src",window.location.href.replace("_fl.pdf","_ut.pdf"));
            secondHalf.setAttribute("id","secondHalf");
            document.body.appendChild(secondHalf);
            document.getElementById("splits").innerText = "📄❌";
        }
    }
})();