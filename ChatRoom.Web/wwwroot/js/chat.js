"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();


connection.on("ReceiveMessage", function () {
    $("#chat-messages").empty(); // clear the old messages
    loadPosts();
});

connection.start().then(function () {
    connection.invoke("JoinRoom", $("#hdnRoomId").val())
        .then(function () {
            $("#btnPost").prop("disabled", false);
        })
        .catch(function (err) {
            return console.error(err.toString());
        });
}).catch(function (err) {
    return console.error(err.toString());
});

function loadPosts() {
    var roomId = $("#hdnRoomId").val();
    var userId = $("#hdnUserId").val();

    $.get(baseUrl + "Post/Find/" + roomId)
        .done(function (result) {

            if (result) {
                var divChat = $("#chat-messages");
                for (var i = 0; i < result.records.length; i++) {
                    var post = result.records[i];

                    if (post.fromUser === userId) {
                        divChat.append('<div class="chat-message-right pb-4"> ' +
                            '<div>' +
                            '<img src="/images/avatar.png" class="rounded-circle mr-1" alt="You" width="40" height="40">' +
                            '<div class="text-muted small text-nowrap mt-2">' + post.created + '</div>' +
                            '</div>' +
                            '<div class="flex-shrink-1 bg-light rounded py-2 px-3 mr-3">' +
                            '<div class="font-weight-bold mb-1">You</div>' +
                            (post.isCommand ? '<p class="command-post">' : '<p>') + post.content + '</p>' + 
                            '</div>' +
                            '</div>');
                    } else {
                        divChat.append('<div class="chat-message-left pb-4">' +
                            '<div>' +
                            '<img src="/images/avatar.png" class="rounded-circle mr-1" alt="' + post.fromUserName + '" width="40" height="40">' +
                            '<div class="text-muted small text-nowrap mt-2">' + post.created + '</div>' +
                            '</div>' +
                            '<div class="flex-shrink-1 bg-light rounded py-2 px-3 ml-3">' +
                            '<div class="font-weight-bold mb-1">' + post.fromUserName + '</div>' +
                            '<p>' + post.content + '</p>' + 
                            '</div>' +
                            '</div>');
                    }
                }
                divChat.scrollTop(divChat.prop("scrollHeight"));
                $("html, body").animate({ scrollTop: $(document).height() }, 1);
            }
        });
}

$(document).ready(function () {
    loadPosts();

    $("#btnPost").click(function (event) {
        const content = $("#txtContent").val();

        if (!content || content.length == 0)
            return;

        var data = {
            RoomId: $("#hdnRoomId").val(),
            Content: $("#txtContent").val()
        };
        $.post(baseUrl + "Post/Create", data)
            .done(function (result) {
                if (result.isValid) {
                    $("#txtContent").val("");
                }
            });
    });
});