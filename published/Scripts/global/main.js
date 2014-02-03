$(function () {


    var item = $("#Item").val();
    var home = $("#Home").val();
    var create = $("#New").val();
    var manage = $("#Manage").val();
    var remove = $("#Delete").val();
    var id = $("#Id").val();

    $('.combobox').combobox();

    $("#btnCancel").click(function (event) {
        event.preventDefault();
        $('#modalWaiting').modal('show');
        setTimeout(function () {
            $('#modalWaiting').on('hidden.bs.modal', function () {
                window.history.back();
            }).modal('hide')
        }, 500);
    });


    $("#btnBackToList").click(function (event) {
        event.preventDefault();
        $('#modalWaiting').modal('show');
        setTimeout(function () {
            $('#modalWaiting').on('hidden.bs.modal', function () {
                window.location = home;
            }).modal('hide')
        }, 500);
    });

    //$("#home").find("#btnSave").click(function (event) {
    $("#btnSave").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: create,
            type: "post",
            data: $("form").serialize(),
            beforeSend: function () {
                $('form').validate().form();
            },
            complete: function (data) {
            },
            error: function (data) {
            },
            success: function (data) {
                if (data.result != "") {
                    $('#modalSaving').modal('show');
                    setTimeout(function () {
                        $('#modalSaving').on('hidden.bs.modal', function () {
                            window.location = item + "/" + data.result;
                        }).modal('hide')
                    }, 500);
                }
            }
        });
    });


    $("#btnSaveChanges").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: manage,
            type: "post",
            data: $("form").serialize(),
            beforeSend: function () {
                $('form').validate().form();
            },
            complete: function (data) {
            },
            error: function (data) {
            },
            success: function (data) {
                if (data.result != '') {
                    $('#modalSaving').modal('show');
                    setTimeout(function () {
                        $('#modalSaving').on('hidden.bs.modal', function () {
                            window.location = item + "/" + data.result;
                        }).modal('hide')
                    }, 500);
                }
            }
        });
    });


    $("#btnConfirmation").click(function (event) {
        event.preventDefault();
        $('#modalConfirmation').modal('show');
    });

    $("#btnDelete").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: remove,
            type: "post",
            data: $("form").serialize(),
            complete: function (data) {
            },
            error: function (data) {
            },
            success: function (data) {
                if (data.result != '') {
                    $('#modalConfirmation').modal('hide');
                    $('#modalDeleting').modal('show');
                    setTimeout(function () {
                        $('#modalDeleting').on('hidden.bs.modal', function () {
                            window.location = home;
                        }).modal('hide')
                    }, 500);


                }
            }
        });
    });


    $("#btnNew").click(function (event) {
        event.preventDefault();
        $('#modalWaiting').modal('show');
        setTimeout(function () {
            $('#modalWaiting').on('hidden.bs.modal', function () {
                window.location = create;
            }).modal('hide')
        }, 500);
    });





















});