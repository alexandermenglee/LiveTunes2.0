(function () {

})();

function success(pos) {
    coordinates = pos.coords;
    console.log(coordinates);
}
function error(err) {
    console.log('ERROR(' + err.code + '): ' + err.message);
}
target = {
    latitude: 0,
    longitude: 0
};
options = {
    enableHighAccuracy: true,
    timeout: 60000,
    speed: true,
    maximumAge: 0
};
navigator.geolocation.watchPosition(success, error, options);