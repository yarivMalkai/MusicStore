function ValidateSongForm() {
    var orderTxt = document.getElementById("Order").value;
    var order = parseInt(orderTxt);
    var ok = (order > 0);
    if (!ok)
        alert("Invalid fields");
    return ok;
}