$(document).ready(function () {
    //google.maps.event.addDomListener(window, 'load', initialize);
    document.getElementById('mapCanvasChurch').style.display = 'none';
    document.getElementById('mapCanvasReception').style.display = 'none';
    document.getElementById('mapCanvasHotel').style.display = 'none';
    document.getElementById('addressChurch').style.display = 'none';
    document.getElementById('addressReception').style.display = 'none';
    document.getElementById('addressHotel').style.display = 'none';

    $("[id*='viewMapChurch']").click(function (e) {
        var ctrlView = document.getElementById('viewMapChurch')
        var ctrlCanvas = document.getElementById('mapCanvasChurch')
        var divAddress = document.getElementById('addressChurch')
        mapButton(41.2057757, -96.0635123, 18, ctrlView, ctrlCanvas, "St. Gerald's Catholic Church", divAddress);
    });

    $("[id*='viewMapReception']").click(function (e) {
        var ctrlView = document.getElementById('viewMapReception')
        var ctrlCanvas = document.getElementById('mapCanvasReception')
        var divAddress = document.getElementById('addressReception')
        mapButton(41.235284, -96.1357882, 18, ctrlView, ctrlCanvas, "Arbor Hall", divAddress);
    });

    $("[id*='viewMapHotel']").click(function (e) {
        var ctrlView = document.getElementById('viewMapHotel')
        var ctrlCanvas = document.getElementById('mapCanvasHotel')
        var divAddress = document.getElementById('addressHotel')
        mapButton(41.261067, -96.0731519, 16, ctrlView, ctrlCanvas, "Marriott", divAddress);
    });

    
});

function mapButton(lat, lng, zoom, ctrlView, ctrlCanvas, markerTitle, divAddress) {
    if (ctrlView.textContent == "View Map") {
        displayMap(lat, lng, zoom, ctrlCanvas, markerTitle, divAddress);
        ctrlView.textContent = "Hide Map";
        divAddress.style.display = 'block';
    }
    else {
        ctrlCanvas.style.display = 'none';
        divAddress.style.display = 'none';
        ctrlView.textContent = "View Map";
    }
}

function displayMap(lat, lng, zoom, ctrlCanvas, markerTitle, divAddress) {

    ctrlCanvas.style.display = 'block';

    var myLatlng = new google.maps.LatLng(lat, lng);

    var mapOptions = {
        center: myLatlng,
        zoom: zoom
    };
    var map = new google.maps.Map(ctrlCanvas,mapOptions);

    // Add legend
    map.controls[google.maps.ControlPosition.RIGHT_BOTTOM].push(divAddress);

    // Add the marker to the map, use the 'map' property
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: markerTitle
    });
    google.maps.event.trigger(map, 'resize');
}
