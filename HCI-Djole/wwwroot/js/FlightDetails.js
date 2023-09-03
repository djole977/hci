$(document).ready(function () {
    $('#reviewsTable').DataTable({
        'bFilter': false,
        'iDisplayLength': 3,
        'info': false,
        'dom': 'rtip',
        'language': {
            url: '/lib/datatables/sr-lat.json'
        }
    })
    $('#reviewsTable thead').remove()
})
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