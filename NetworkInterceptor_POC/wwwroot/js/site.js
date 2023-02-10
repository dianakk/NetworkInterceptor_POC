// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $.ajax({
        url: '/Home/TestHeaderInterception',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        //data: JSON.stringify(person)
    })
        .done(function (result) {
            // alert(result);
        });
});
