

$(document).ready(function () {

    $("#btnSave").click(function (event) {
        event.preventDefault();

        var addUrl = app.Urls.writerAddUrl;
        var redirectUrl = app.Urls.writerIndexUrl;

        var viewModel = {
            FullName: $("input[id=writerName]").val(),
            Country: $("input[id=writerCountry]").val()
        }

        var jsonData = JSON.stringify(viewModel);
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl;
                }, 1500);
            },
            error: function () {
                toast.error("Bir hata oluştu.", "Hata");
            }
        });
    });
});