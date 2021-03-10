// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let map, heatmap;
var devices = [];

function initMap() {
    $.ajax({
        url: "http://localhost:30574/DeviceStats", success: function (result) {
            var index = 0;
            for (var i = 0; i < result.length; i++) {
                devices.push(new google.maps.LatLng(result[i].lat, result[i].lon));
                if (result[i].lat != 0 && result[i].lon != 0)
                    index = i;
            }
            map = new google.maps.Map(document.getElementById("map"), {
                zoom: 2,
                center: { lat: parseInt(result[index].lat), lng: parseInt(result[index].lon)},
                mapTypeId: "satellite",
            });
            heatmap = new google.maps.visualization.HeatmapLayer({
                data: devices,
                map: map,
            });
        }
    });
}

function toggleHeatmap() {
    heatmap.setMap(heatmap.getMap() ? null : map);
}

function changeGradient() {
    const gradient = [
        "rgba(0, 255, 255, 0)",
        "rgba(0, 255, 255, 1)",
        "rgba(0, 191, 255, 1)",
        "rgba(0, 127, 255, 1)",
        "rgba(0, 63, 255, 1)",
        "rgba(0, 0, 255, 1)",
        "rgba(0, 0, 223, 1)",
        "rgba(0, 0, 191, 1)",
        "rgba(0, 0, 159, 1)",
        "rgba(0, 0, 127, 1)",
        "rgba(63, 0, 91, 1)",
        "rgba(127, 0, 63, 1)",
        "rgba(191, 0, 31, 1)",
        "rgba(255, 0, 0, 1)",
    ];
    heatmap.set("gradient", heatmap.get("gradient") ? null : gradient);
}

function changeRadius() {
    heatmap.set("radius", heatmap.get("radius") ? null : 50);
}

function changeOpacity() {
    heatmap.set("opacity", heatmap.get("opacity") ? null : 0.2);
}


function getPoints() {


    $.ajax({
        url: "https://localhost:15618/DeviceStats", success: function (result) {
           
            for (var i = 0; i < result.length; i++) {
                devices.push(new google.maps.LatLng(result[i].lat, result[i].lon));
            }
            map = new google.maps.Map(document.getElementById("map"), {
                zoom: 13,
                center: { lat: -26.2041, lng: 28.046822 },
                mapTypeId: "satellite",
            });
            heatmap = new google.maps.visualization.HeatmapLayer({
                data: devices,
                map: map,
            });
        }
    });
    return [];
    
}

