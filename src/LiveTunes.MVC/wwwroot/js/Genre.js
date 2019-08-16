function getGenreList() {
    $.ajax({
        type: "GET",
        url: "musiccategory/list",
        success(data) {
            //jquery to populate select list
            console.log(data);
            var genres = document.getElementsByClassName("genres");

            for (var j = 0; j < genres.length; j++) {
                for (var i = 0; i < data.length; i++) {
                    genres[j].innerHTML += "<option value=" + data[i].id + ">" + data[i].categoryName + "</option>"
                }
            }
        }
    });
}

getGenreList();