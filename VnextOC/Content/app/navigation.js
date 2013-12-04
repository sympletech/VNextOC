$(function() {
    $("nav ul li").click(function() {
        var id = this.id;
        $.get("/"+id, function(data) {
            $("#content").html(data);
        });
    });
})