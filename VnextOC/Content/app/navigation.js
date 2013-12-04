$(function() {
    $("nav ul li").click(function() {
        var id = this.id;
        $.get("/" + id, function(data) {
            $("#content").html(data);
        });
    });
    $.get("/calendar", function (data) {
        $("#content").html(data);
    });
})