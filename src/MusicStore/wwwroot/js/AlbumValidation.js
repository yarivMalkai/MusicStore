function ValidateAlbumForm() {
    var priceTxt = document.getElementById("Price").value;
    var price = parseInt(priceTxt);
    var yearTxt = document.getElementById("Year").value;
    var year = parseInt(yearTxt);
    var ok = (price > 0 && year > 0);
    if (!ok)
        alert("Invalid fields");
    return ok;
}