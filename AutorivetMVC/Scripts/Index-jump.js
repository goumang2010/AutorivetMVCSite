function reToBASearch() {
    var searchstr = $("#BASearch").val()
    var cururl = window.location.href
    if (cururl.toLowerCase().indexOf("home") > 0) {
        if (searchstr != "") {
            window.open("../BASearch/Index?Search=" + searchstr)
        }
        else {
            window.open("../BASearch/Index")
        }
    }
    else {
        if (searchstr != "") {
            window.open("BASearch/Index?Search=" + searchstr)
        }
        else {
            window.open("BASearch/Index")
        }
    }
}

function reToSpec(searchStr) {
    $("#BASearch").val(searchStr)
    reToBASearch()
}
