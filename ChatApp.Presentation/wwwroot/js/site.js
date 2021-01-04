$(function () {
    $('.modal').on('hidden.bs.modal', function () {
        $(".modal-body input").val("");
    });

    $(".alert .close").on('click', function () {
        $(this).parent().hide();
    });
});