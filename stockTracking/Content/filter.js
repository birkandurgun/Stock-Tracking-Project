const table = document.getElementById("table");
const searchBoxName = document.getElementById("productName");
const searchBoxDescription = document.getElementById("description");
const searchBoxBrand = document.getElementById("brand");
const searchBoxCategory = document.getElementById("category");
const searchBoxQuantityMin = document.getElementById("quantityMin");
const searchBoxQuantityMax = document.getElementById("quantityMax");
const searchBoxPrice = document.getElementById("price");

searchBoxName.addEventListener("keyup", filterTableByName);
searchBoxDescription.addEventListener("keyup", filterTableByDescription);
searchBoxBrand.addEventListener("keyup", filterTableByBrand);
searchBoxCategory.addEventListener("keyup", filterTableByCategory);
searchBoxQuantityMin.addEventListener("keyup", filterTableByQuantityMin);
searchBoxQuantityMax.addEventListener("keyup", filterTableByQuantityMax);
searchBoxPrice.addEventListener("keyup", filterTableByPrice);


function filterTableByName() {
    let search = searchBoxName.value.toLowerCase().replace(/\s+/g, ' ').trim();
    let rows = table.getElementsByTagName("tr");

    for (var i = 0; i < rows.length; i++) {
        var nameData = rows[i].getElementsByTagName("td")[0];
        if (nameData) {
            if (nameData.textContent.toLowerCase().includes(search)) {
                rows[i].style.display = "";
            } else {
                rows[i].setAttribute("style", "display: none !important");
            }
        }
    }

}

function filterTableByDescription() {
    let search = searchBoxDescription.value.toLowerCase().replace(/\s+/g, ' ').trim();
    let rows = table.getElementsByTagName("tr");

    for (var i = 0; i < rows.length; i++) {
        var dData = rows[i].getElementsByTagName("td")[1];
        if (dData) {
            if (dData.textContent.toLowerCase().includes(search)) {
                rows[i].style.display = "";
            } else {
                rows[i].setAttribute("style", "display: none !important");
            }
        }
    }


}

function filterTableByBrand() {
    let search = searchBoxBrand.value.toLowerCase().replace(/\s+/g, ' ').trim();
    let rows = table.getElementsByTagName("tr");

    for (var i = 0; i < rows.length; i++) {
        var brands = rows[i].getElementsByTagName("td")[4];
        if (brands) {
            if (brands.textContent.toLowerCase().includes(search)) {
                rows[i].style.display = "";
            } else {
                rows[i].setAttribute("style", "display: none !important");
            }
        }
    }


}

function filterTableByCategory() {
    let search = searchBoxCategory.value.toLowerCase().replace(/\s+/g, ' ').trim();
    let rows = table.getElementsByTagName("tr");

    for (var i = 0; i < rows.length; i++) {
        var categories = rows[i].getElementsByTagName("td")[5];
        if (categories) {
            if (categories.textContent.toLowerCase().includes(search)) {
                rows[i].style.display = "";
            } else {
                rows[i].setAttribute("style", "display: none !important");
            }
        }
    }


}

function filterTableByQuantityMin() {
    let search = parseInt(searchBoxQuantityMin.value);
    let rows = table.getElementsByTagName("tr");

    for (var i = 0; i < rows.length; i++) {
        var quantities = rows[i].getElementsByTagName("td")[2];
        if (quantities) {
            if (parseInt(quantities.textContent) > search) {
                rows[i].style.display = "";
            } else {
                rows[i].setAttribute("style", "display: none !important");
            }
        }
    }


}

function filterTableByQuantityMax() {
    let search = parseInt(searchBoxQuantityMax.value);
    let rows = table.getElementsByTagName("tr");

    for (var i = 0; i < rows.length; i++) {
        var quantities = rows[i].getElementsByTagName("td")[2];
        if (quantities) {
            if (parseInt(quantities.textContent) < search) {
                rows[i].style.display = "";
            } else {
                rows[i].setAttribute("style", "display: none !important");
            }
        }
    }


}

function filterTableByPrice() {
    let search = parseInt(searchBoxPrice.value);
    let rows = table.getElementsByTagName("tr");

    for (var i = 0; i < rows.length; i++) {
        var prices = rows[i].getElementsByTagName("td")[3];
        if (prices) {
            if (parseInt(prices.textContent) < search) {
                rows[i].style.display = "";
            } else {
                rows[i].setAttribute("style", "display: none !important");
            }
        }
    }


}