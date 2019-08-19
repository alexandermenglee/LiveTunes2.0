function createMusicPreference(artist, song, genre) {
    //some ajax here
    $.ajax({
        type: "GET",
        url: "https://localhost:44303/musicpreference/create?artist=" + artist + "&songName=" + song + "&genre=" + genre,
    });
}

function getSuggestedSong() {
    let endpoint = "https://itunes.apple.com/search?term=hip+hop";
    $.ajax({
        dataType: "jsonp",
        method: "get",
        url: endpoint,
        success: data => {
            displayRecommendedSongs(data.results);
        },
        error: error => console.log(error)
    });
}

function displayRecommendedSongs(songs) {
    let resultsDiv = document.getElementById("results");

    for (let i = 0; i < 5; i++) {
        let song = {
            SongName: songs[i].trackName,
            ArtistName: songs[i].artistName
        }

        let songDiv = document.createElement("div");
        songDiv.classList.add("add-border");

        let albumArt = document.createElement("img");
        albumArt.src = songs[i].artworkUrl100;

        let songSample = document.createElement("audio");
        songSample.src = songs[i].previewUrl;
        songSample.controls = 'controls';

        let trackName = document.createElement("h4");
        trackName.textContent = songs[i].trackName;

        let artistName = document.createElement("p");
        artistName.textContent = songs[i].artistName;

        let likeButton = document.createElement("button");
        likeButton.innerHTML = "Like";
        $(likeButton).click(() => {
            $.post({
                url: "Like",
                data: JSON.stringify(song),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: () => console.log("SUCCESS"),
                error: err => console.log(err)
            });
        });

        resultsDiv.append(songDiv);
        resultsDiv.append(albumArt);
        resultsDiv.append(trackName);
        resultsDiv.append(artistName);
        resultsDiv.append(songSample);
        resultsDiv.append(likeButton);
    }
}

getSuggestedSong();