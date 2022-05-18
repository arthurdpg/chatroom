"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();


connection.on("ReceiveMessage", function (user, message) {
   //update user ui
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});


$(document).ready(function () {
    $(".btn-join").click(function (event) {

        //var room = $(this).data("roomid");
        //connection.invoke("JoinRoom", room).catch(function (err) {
        //    return console.error(err.toString());
        //});
        //event.preventDefault();
    });

    $("#btnPost").click(function (event) {
        const content = $("#txtContent").val();

        if (!content || content.length == 0)
            return;

        const data = {
            RoomId: $("#hdnRoomId").val(),
            Content: $("#txtContent").val()
        };
        $.post(baseUrl + "Chat/CreatePost", data)
            .done(function (result) {
                // if any updated is needed
            });
    });
});