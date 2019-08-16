genreList = [];
function getGenreList() {
    $.ajax({
        type: "GET",
        url: "/musiccategory/list",
        success(data) {
            //jquery to populate select list
            console.log(data);
            genreList = data;
            var genres = document.getElementsByClassName("genres");
           
            for (var j = 0; j < genres.length; j++) {
                for (var i = 0; i < data.length; i++) {
                    //genreList.push({ id: data[i].Id, name: data[i].categoryName });
                    
                    genres[j].innerHTML += "<option value=" + data[i].id + ">" + data[i].categoryName + "</option>"
                }
            }
        }
    });
}
getGenreList();
function getGenre(id) {
    //console.log(genreList + "genres here");

    var arr = genreList.filter(x => x.id == id);
    return arr[0].categoryName;
}

