
function getComments(EventId) {
    var comments = [];
    $.ajax({
        type: "GET",
        url: "https://localhost:44303/comment/List/" + EventId,
        success: function (data) {
            console.log("got a response");
            comments = data;
            console.log(data);
            var commentsDiv = document.getElementById("comments");
            for (var i = 0; i < comments.length; i++) {
                commentsDiv.innerHTML += comments[i].commentText + "<br/>";
            }
        }
    });
}

var text = "";
function updateComment() {
    text = document.getElementById("comment").value;
};

function addComment() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44303/comment/Create/?EventId=" + EventId + "&text=" + text,
        success: function (data) {
            console.log("works");
        },
    });
}