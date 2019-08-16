var genreList = [];

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
                    genreList.push({ id: data[i].Id, name: data[i].categoryName });
                    genreList[i].categoryName = data[i].categoryName;
                    genreList[i].id = data[i].id;
                    genres[j].innerHTML += "<option value=" + data[i].id + ">" + data[i].categoryName + "</option>"
                }
            }
        }
    });
}

function getGenre( id ) {
    let r = genreList.filter(x => x.id == id)[0];
    return r.categoryName;
}

getGenreList();