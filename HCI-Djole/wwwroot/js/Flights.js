$(document).ready(function () {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
    if ($('#success').val() !== '') {
        if ($("#message").val() !== '') {
            SuccessToast($('#message').val(), 'Obaveštenje')
        }
    }
})