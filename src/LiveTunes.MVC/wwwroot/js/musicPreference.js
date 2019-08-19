function createMusicPreference(artist, song, genre) {
    //some ajax here
    $.ajax({
        type: "GET",
        url: "https://localhost:44303/musicpreference/create?artist=" + artist + "&songName=" + song + "&genre=" + genre,
    });
}

let recommendedSongs = [];

function genreStringManipulator(genre) {
    if (genre.includes("/")){
        let indexOfBackslash = genre.indexOf("/");
        genre = genre.substring(0, indexOfBackslash).trim().replace(" ", "+");
        return genre;
    }

    if (genre.includes("&")) {
        let indexOfBackslash = genre.indexOf("&");
        genre = genre.substring(0, indexOfBackslash).trim().replace(" ", "+");
        return genre;
    }

    return genre;
}

function getSurveyData() {
    $.ajax({
        dataType: "json",
        url: "/MusicPreference/GetSurveyData",
        method: "get",
        success: data => {
            getSongsByGenre1(data);
        },
        error: error => console.log(error)
    });
}

function getSongsByGenre1(genres) {
    let endpoint = "https://itunes.apple.com/search?term=" + genreStringManipulator(genres.genre1) + "&limit=1";  
    $.ajax({
        dataType: "jsonp",
        method: "get",
        url: endpoint,
        success: data => {
            recommendedSongs.push(data.results[0]);
            getSongsByGenre2(genres);
        },
        error: error => console.log(error)
    });
}

function getSongsByGenre2(genres) {
    let endpoint = "https://itunes.apple.com/search?term=" + genreStringManipulator(genres.genre2) + "&limit=1";
    $.ajax({
        dataType: "jsonp",
        method: "get",
        url: endpoint,
        success: data => {
            recommendedSongs.push(data.results[0]);
            getSongsByGenre3(genres);
        },
        error: error => console.log(error)
    });
}

function getSongsByGenre3(genres) {
    let endpoint = "https://itunes.apple.com/search?term=" + genreStringManipulator(genres.genre3) + "&limit=1";
    $.ajax({
        dataType: "jsonp",
        method: "get",
        url: endpoint,
        success: data => {
            console.log(data);
            recommendedSongs.push(data.results[0]);
            console.log(recommendedSongs);
            displayRecommendedSongs(recommendedSongs);
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
            console.log(song);
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

getSurveyData();