$(document).ready(function () {
    $(".js-range-slider").ionRangeSlider({
        type: "double",
        min: 0,
        max: 1000,
        from: 200,
        to: 500,
        grid: true,
        postfix: " €"
    });
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
    if ($('#success').val() !== '') {
        if ($("#message").val() !== '') {
            SuccessToast($('#message').val(), 'Obaveštenje')
        }
    }
    $('#companiesSelect').select2()
})

function GoToFlightDetails(id) {
    window.location.href = $('#flightDetailsUrl').val() + '?flightId=' + id
}

function FilterFlights() {
    var range = $(".js-range-slider").data("ionRangeSlider");
    var priceFrom = parseInt(range.old_from)
    var priceTo = range.old_to
    var companies = $("#companiesSelect :selected").map(function (i, el) {
        return $(el).data('id');
    }).get();
    var cityFrom = $("#cityFromSelect :selected").data('id')
    var cityTo = $("#cityToSelect :selected").data('id')
    var flightCategory = $("#flightClassSelect :selected").val()
    $.ajax({
        type: 'POST',
        data: { priceFrom: priceFrom, priceTo: priceTo, companies: companies, cityFrom: cityFrom, cityTo: cityTo, flightCategory: flightCategory },
        url: $('#filterFlightsUrl').val(),
        success: function (returnData) {
            $('#flightsContainer').empty()
            $('#flightsContainer').html(returnData)
        }
    })
}
function ReserveModal(id) {
    $.confirm({
        type: 'green',
        title: 'Da li ste sigurni?',
        content: 'Klikom na dugme \'Rezerviši\' let će biti dodat u \'Moje karte\'',
        buttons: {
            Rezerviši: {
                btnClass: 'btn btn-green',
                action: function () {
                    $.blockUI()
                    $.ajax({
                        type: 'POST',
                        url: $('#reserveFlightUrl').val(),
                        data: { flightId: id },
                        success: function (returnData) {
                            if (returnData.success === 'true') {
                                sessionStorage.setItem('success', 'true')
                                sessionStorage.setItem('message', 'Let uspešno rezervisan')
                                location.reload()
                            }
                            else {
                                sessionStorage.setItem('success', 'false')
                                sessionStorage.setItem('message', returnData.error)
                            }
                        },
                        complete: function () {
                            $.unblockUI()
                        }
                    })
                }
            },
            Odustani: {

            }
        }
    })
}
function CancelModal(id) {
    $.confirm({
        type: 'red',
        title: 'Da li ste sigurni?',
        content: 'Otkazivanjem leta gubite pravo na putovanje.',
        buttons: {
            Otkaži: {
                btnClass: 'btn btn-red',
                action: function () {
                    $.blockUI()
                    $.ajax({
                        type: 'POST',
                        url: $('#cancelFlightUrl').val(),
                        data: { ticketId: id },
                        success: function (returnData) {
                            if (returnData.success === 'true') {
                                sessionStorage.setItem('success', 'true')
                                sessionStorage.setItem('message', 'Let uspešno otkazan')
                                location.reload()
                            }
                            else {
                                sessionStorage.setItem('success', 'false')
                                sessionStorage.setItem('message', returnData.error)
                            }
                        },
                        complete: function () {
                            $.unblockUI()
                        }
                    })
                }
            },
            Ne: {

            }
        }
    })
}