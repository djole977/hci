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