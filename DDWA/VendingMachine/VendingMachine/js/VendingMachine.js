$(document).ready(function () {
    $('#defaultValue').val(0);
    populateItems();
});

function setItem(newId) {
    $('#itemId').val(newId);
}

function makePurchase() {
    if (!(/\b\d+/).test($('#itemId').val())) {
        $('#messageBox').val('Invalid item ID, please try again.');
    } else {
        buyItem(($('#defaultValue').val() * 0.01), parseInt($('#itemId').val()));
    }
}

function buyItem(money, itemID) {
    $.ajax({
        type: 'POST',
        url: 'http://tsg-vending.herokuapp.com/money/' + money + '/item/' + itemID,
        success: function (data) {
            $('#messageBox').val("Thank you!");
            $('#changeBox').val('' + data.quarters + ' quarter(s), ' + data.dimes + ' dime(s), ' + data.nickels + ' nickel(s), and ' + data.pennies + ' penny' +' is your change.');
            $('#defaultValue').val(0);
            addMoney(0);
        },
        statusCode: {
            422: function (xhr) {
                $('#messageBox').val($.parseJSON(xhr.responseText).message);
            }
        }
    });
}

function populateItems() {
    $.ajax({
        type: 'GET',
        url: 'http://tsg-vending.herokuapp.com/items',
        success: function (data) {
            $('#itemBoxes').text('');
            $.each(data, function (index, item) {
                var itemDiv = '<div class="col-4 border bg-light item-option" onclick="setItem(';
                itemDiv += item.id;
                itemDiv += ')">';
                itemDiv += '<div class="text-left" style="font-size:12pt;">';
                itemDiv += item.id;
                itemDiv += '</div>';
                itemDiv += '<div class="text-center">';
                itemDiv += item.name;
                itemDiv += '<br/>$';
                itemDiv += parseFloat(item.price).toFixed(2);
                itemDiv += '<br/>Quantity Left: ';
                itemDiv += item.quantity;
                itemDiv += '</div>';
                itemDiv += "</div>";
                $('#itemBoxes').append(itemDiv);
            });
        },
        error: function () {
            alert('Try again');
        }
    });
}

function addMoney(amount) {
    $('#defaultValue').val(parseInt($('#defaultValue').val()) + amount);
    $('#money').text(($('#defaultValue').val() * 0.01).toFixed(2));
}

function takeChange() {
    $('#itemID').val('');
    $('#messageBox').val('');
    populateItems();
    if ($('#defaultValue').val() == 0) {
        $('#changeBox').val('');
    } else {
        var quarter = Math.floor(parseInt($('#defaultValue').val()) / 25);
        $('#defaultValue').val(parseInt($('#defaultValue').val()) % 25);
        var dime = Math.floor(parseInt($('#defaultValue').val()) / 10);
        $('#defaultValue').val(parseInt($('#defaultValue').val()) % 10);
        var nickel = Math.floor(parseInt($('#defaultValue').val()) / 5);
        var penny = parseInt($('#defaultValue').val()) % 5;
        $('#changeBox').val('' + quarter + ' quarter(s), ' + dime + ' dime(s), ' + nickel + ' nickel(s), and ' + penny + ' penny');
        $('#defaultValue').val(0);
        addMoney(0);
    }
}