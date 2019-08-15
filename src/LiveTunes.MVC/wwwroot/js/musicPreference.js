function createMusicPreference(artist, song, genre) {
    //some ajax here
    $.ajax({
        type: "GET",
        url: "https://localhost:44303/musicpreference/create?artist=" + artist + "&songName=" + song + "&genre=" + genre,
    });
}

function getSuggestedSong() {
    //some ajax here and call to music api
}