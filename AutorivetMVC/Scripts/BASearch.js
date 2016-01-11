    function Show(data) {
        //return data.filename
        var jsonStr = JSON.parse(data)
        var tableobj = document.getElementById("Table")
        var tbtext = "<tr><th>文件名</th><th>标题</th><th>操作</th></tr>"
        for (var dd in jsonStr) {
            tbtext += "<tr><td>" + (jsonStr[dd].filename) + "</td>";
            tbtext += "<td>" + (jsonStr[dd].title) + "</td>"
            tbtext += "<td><a href=" + (jsonStr[dd].localpath) + " target=_blank>打开</a></td>"
            tbtext += "</tr>";
        }
        tableobj.innerHTML = tbtext
        //alert(data);
    }


    //function fetchAjax(str) {

    //    var aj = $.ajax({
    //        url: 'productManager_reverseUpdate',  
    //        data: {
    //            name: str,
    //        },
    //        type: 'post',
    //        cache: false,
    //        dataType: 'json',
    //        success: Show(data) ,
    //        error: function () {
    //            // view("异常！");  
    //            alert("异常！");
    //        }
    //    });

    //}
