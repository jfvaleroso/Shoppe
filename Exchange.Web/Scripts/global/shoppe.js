var shoppe = function () {
    return {
        create: function (url) {
            window.location = url;
        },
        manage: function (url) {
            window.location = url;
        },
        remove: function(id, action)
        {
            $.ajax({
                url: action,
                type: "post",
                data: { id: id },
                complete: function (data) {
                },
                error: function (data) {
                    alert('error');
                },
                success: function (data) {
                    //deleted
                    if (data.code == '002') {
                        $('#mainModal').modal('hide');
                        $('#DataTable').jtable('load');
                        //add notification
                        $('#panel-status').removeClass().addClass('panel fade in panel-success');
                        $('#general-status').empty().append(data.message + $('#Item').val());
                        //hide modal
                        $("#modalConfirmation").modal('hide');
                        $("#panel-status").delay(20000).fadeOut('slow');
                    }
                        //error
                    else {
                        $('#alert').removeClass('hide');
                        $('#notification').empty().append('Error has occured!' + data.message);
                    }
                }
            });
        },
        save: function (action) {
            $.ajax({
                url: action,
                type: "post",
                cache: false,
                data: $('#transaction form').serialize(),
                beforeSend: function () {
                    $('#transaction form').validate().form();
                },
                complete: function (data) {
                },
                error: function (data) {
                    $('#alert').removeClass('hide');
                    $('#notification').empty().append('Error has occured!' + data.message);
                },
                success: function (data) {
                    //saved
                    if (data.code == '000') {
                        $('#mainModal').modal('hide');
                        //add notification
                        $('#panel-status').removeClass().addClass('panel fade in panel-success');
                        $('#panel-status').find('em').addClass('success');
                        $('#general-status').empty().append(data.message + data.content);
                        $('#alert').addClass('hide');
                    }
                        //invalid
                    else if (data.code == "007") {
                        $('#alert').removeClass('hide');
                    }
                        //existed
                    else if (data.code == "003") {
                        $('#alert').removeClass('hide');
                        $('#notification').empty().append('Item already exists!');
                    }
                        //error
                    else if (data.code == "005") {
                        $('#alert').removeClass('hide');
                        $('#notification').empty().append('Error has occured!' + data.message);
                    }

                }
            });
        },
        saveChanges: function (action) {
            $.ajax({
                url: action,
                type: "post",
                data: $('#transaction form').serialize(),
                beforeSend: function () {
                    $('#transaction form').validate().form();
                },
                complete: function (data) {
                },
                error: function (data) {
                    $('#alert').removeClass('hide');
                    $('#notification').empty().append('Error has occured!' + data.message);
                },
                success: function (data) {
                    //modified
                    if (data.code == '001') {
                        //add notification
                        $('#panel-status').removeClass().addClass('panel fade in panel-warning');
                        $('#general-status').empty().append(data.message + data.content);
                        $('#alert').addClass('hide')
                 
                    }
                        //invalid
                    else if (data.code == "007") {
                        $('#alert').removeClass('hide').removeClass('alert-warning').fadeIn().addClass('alert-danger');
                        $('#alert span').remove();
                     
                     
                    }
                        //existed
                    else if (data.code == "003") {
                        $('#alert').removeClass('hide').removeClass('alert-danger').addClass('alert-warning');
                        $('#notification').addClass('small alert-warning').empty().append('<ul><li>No changes made.</li></ul>');
                        $('#panel-status').addClass('hide')
                    }
                        //error
                    else if (data.code == "005") {
                        $('#alert').removeClass('hide');
                        $('#notification').empty().append('Error has occured!');
                    }
                }
            });
        },
        valdiateCode: function (param,action) {
            $.ajax({
                url: action,
                type: "post",
                data: { param: param },
                complete: function (data) {
                },
                error: function (data) {
                    alert(data.code);
                },
                success: function (data) {
                    if (data.code == '008') {
                        $('#status').empty().append('Code is available!');
                        $('#status').addClass('alert').removeClass('alert-warning').addClass('alert-success').addClass('fade-in');
                    }
                    else if (data.code == '003') {
                        $('#status').empty().append('Code already exists!');
                        $('#status').addClass('alert').removeClass('alert-success').addClass('alert-warning').addClass('fade-in');
                    }
                    else {
                        $('#status').empty().append('Verify if Code exists.!');
                        $('#status').removeClass('alert').removeClass('alert-warning').removeClass('alert-success').removeClass('fade-in');
                    }
                }
            });
        },
        searchDataTable: function(param){
            $('#DataTable').jtable('load', {
                searchString: param
            });
        },
        searchDatTableById: function(id){
            $('#DataTable').jtable('load', {
                id: id != "" ? id : "0"
            });
        },
        goBack: function ()
        {
            window.history.back();
        }


    };
}();



$(function () {


    
    var create = $("#New").val();
    var manage = $("#Manage").val();

    $('#DataTable').tooltip({
        selector: "[data-toggle=tooltip]",
        container: "body"
    })
   
    $(".combobox").select2({
        placeholder: "Select one",
        allowClear: true
    });
    //search
    $('#btnSearch').click(function (e) {
        e.preventDefault();
        shoppe.searchDataTable($('#searchString').val());
        return false;
    });
    //search
    $('div.alphabet ul li a').click(function (e) {
        e.preventDefault();
        shoppe.searchDataTable($(this).attr('id'))
        return false;
    });
    //activate search
    $('#btnSearch').click();
    //new page for new
    $("#btnNew").click(function () {
        shoppe.create(create);
        return false;
    });
    //manage
    $("#btnManage").click(function () {
        shoppe.create(manage);
        return false;
    });
    //delete
    $("#btnDelete").click(function (event) {
        event.preventDefault();
        shoppe.remove($('#Id').val(), $('#Delete').val());
    });
    //save
    $("#btnSave").click(function (event) {
        event.preventDefault();
        shoppe.save($('#New').val());
    });
    //save changes
    $("#btnSaveChanges").click(function (event) {
        event.preventDefault();
        shoppe.saveChanges($('#Manage').val());
    });
    //check code if exists
    $("#Code").focusout(function () {
        event.preventDefault();
        shoppe.valdiateCode($("#Code").val(),$("#CheckAvailability").val());
    });
    //cancel
    $("#btnCancel").click(function (event) {
        event.preventDefault();
        shoppe.goBack();
    });





   
});