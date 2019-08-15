function getGenreList(){
    $.ajax({
        type: "GET",
        url: "http://localhost:51481/musiccategory/list",
        success(data) {
            //jquery to populate select list
            console.log(data);
            var genres = document.getElementById("genres");

            for (var i = 0; i < data.length; i++) {
                genres.innerHTML += "<option value=" + data[i].id + ">" + data[i].categoryName + "</option>"
            }
        }
    });
}