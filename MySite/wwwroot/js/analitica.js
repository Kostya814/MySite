

let table = new DataTable('#myTable');

const response = await fetch('https://countryapi.io/api/all/?apikey=q0wj7CJmrMvABF8ZpUWR5Wxd77jNqGlC5ynHScwt');
var myJson = await response.json();
$.each(myJson, function (index, v) {
    table.row
        .add([
            v.name,
            v.official_name,
            v.region
        ])
        .draw(false);
})





