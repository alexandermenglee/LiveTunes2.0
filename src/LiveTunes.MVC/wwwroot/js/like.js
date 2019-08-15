function like( EventId ) {
    $.ajax({
        type: "GET",
        url: "https://localhost:44303/like/dolike/" + EventId
    });
}