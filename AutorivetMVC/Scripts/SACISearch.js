    function Show(data) {
        //return data.filename
        var jsonStr=eval(data)
        var tableobj = document.getElementById("Table")
        var tbtext=""
        var tbtext = "<tr><th>查询图号</th><th>有效版次</th><th>下级装配号</th><th>名称</th><th>有效架次</th><th>分工</th><th>&nbsp&nbsp操作</th></tr>"
        for (var dd in jsonStr)
        {
            tbtext += "<tr><td>" + (jsonStr[dd].DrawingNo) + "</td>";
            tbtext += "<td>" + (jsonStr[dd].EffectRev) + "</td>"
            tbtext += "<td>" + (jsonStr[dd].NHA) + "</td>"
            tbtext += "<td>" + (jsonStr[dd].EngName) + "</td>"
            tbtext += "<td>" + (jsonStr[dd].EffectBat) + "</td>"
            tbtext += "<td>" + (jsonStr[dd].Work) + "</td>"
            tbtext += "<td><button class=\"btn btn-link\" onclick=\"copyToClipboard(\'" + (jsonStr[dd].Href) + "\')\"> 打开</button></td>"
            tbtext += "</tr>";
        }
        tableobj.innerHTML=tbtext
        //alert(data);
    }
function Transition() {
    var tableobj = document.getElementById("Table")
    tableobj.innerHTML = "服务器正在取回数据，请耐心等待......"
}
function copyToClipboard(txt) {
    if (txt == "") {
        alert("未查询到地址，请确认选择了正确的文件类型！");
        return;
    }
    var ht = $("#addr");
    // alert(ht);
    ht.text(txt);
    ht.select();
    if (window.clipboardData) {
        window.clipboardData.clearData();
        window.clipboardData.setData("Text", txt);
        alert("已经成功复制到剪帖板上，请在任意文件夹窗口中粘贴打开");
    }
    else
    {
        document.execCommand("Copy");
    }
}
