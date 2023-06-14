$(document).ready(function () {
    if (sessionStorage.getItem('success') === 'true') {
        if (sessionStorage.getItem('message') !== null) {
            SuccessToast(sessionStorage.getItem('message'), 'Obaveštenje')
        }
        else {
            SuccessToast('Akcija uspešno izvršena', 'Obaveštenje')
        }
    }
    else if (sessionStorage.getItem('success') === 'false') {
        if (sessionStorage.getItem('message') !== null) {
            AlertError()
        }
        else {
            SuccessToast('Obaveštenje', 'Akcija uspešno izvršena')
        }
    }
    sessionStorage.clear()
})

function SuccessToast(text, title) {
    if (title === undefined) {
        title = 'Obaveštenje'
    }
    if (text === undefined) {
        text = 'Akcija uspešno izvršena'
    }
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "4000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    toastr["success"](text, title)
}
function ErrorToast(text, title) {
    if (title === undefined) {
        title = 'Obaveštenje'
    }
    if (text === undefined) {
        text = 'Akcija uspešno izvršena'
    }

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "4000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr["error"](text, title)
}