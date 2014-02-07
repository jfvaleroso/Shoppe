var invoice = function () {
    return {
        create: function (url) {
            window.location = url;
        },
        manage: function (url) {
            window.location = url;
        },
        calculate: function (element) {
            var qty = $(element).closest('tr').find('td.quantity input').val();
            var rate = $(element).closest('tr').find('td.rate input').val();
            var amount_input = $(element).closest('tr').find('td.amount input');
            var vat_input = $(element).closest('tr').find('td.vat input');
            var subtotal_input = $(element).closest('tr').find('td.subtotal input');

            var amount = qty * rate;
            var vat = amount / 100 * 20;
            var subtotal = amount + vat;

            amount_input.val(amount.toFixed(2));
            vat_input.val(vat.toFixed(2));
            subtotal_input.val(subtotal.toFixed(2));
            invoice.updateSummary(amount_input, vat_input, subtotal_input);
        },
        updateSummary: function (amount, vat, subtotal) {
            amount = $('#invoice tr td.amount input');
            vat = $('#invoice tr td.vat input');
            subtotal = $('#invoice tr td.subtotal input');
            var amttoal = 0;
            var vattotal = 0;
            var grandtotal = 0;

            amount.each(function () {
                if ($(this).val() != '') {
                    amttoal += parseFloat($(this).val());
                }
            });
            vat.each(function () {
                if ($(this).val() != '') {
                    vattotal += parseFloat($(this).val());
                }
            });
            subtotal.each(function () {
                if ($(this).val() != '') {
                    grandtotal += parseFloat($(this).val());
                }
            });
            $("#total_amount input").val(amttoal.toFixed(2));
            $("#total_vat input").val(vattotal.toFixed(2));
            $("#grand_total input").val(grandtotal.toFixed(2));
        },
        reseet: function () {
            $("#total_amount input").val('');
            $("#total_vat input").val('');
            $("#grand_total input").val('');
        },
        removeItem: function (element) {
            //retain one row
            var items = $('#invoice tr.invoice-item').length;
            if (items > 1) {
                $(element).closest('tr').remove();
            }
            //create new variable
            var amount = $('#invoice tr td.amount input');
            var vat = $('#invoice tr td.vat input');
            var subtotal = $('#invoice tr td.subtotal input');
            //update latest cost
            invoice.updateSummary(amount, vat, subtotal);
        },
        cloneItem: function () {       
            $('#invoice tr.invoice-item:last td.product select').select2("destroy");
            var clone = $('#invoice tr.invoice-item:last').clone(true, true);
            clone.find('input').val('');
            clone.insertAfter('#invoice tr.invoice-item:last');
            $('#invoice select').select2();
        }

       


    };
}();



$(function () {


    //global settings
    //activate table sorting
    $("#invoice").tableDnD();
    //hover
    $("#invoice tr").hover(function () {
        $(this.cells[7]).addClass('remove');
    }, function () {
        $(this.cells[7]).removeClass('remove');
    });
    //pointer
    $("#invoice tr").hover(function () {
        $(this.cells[5]).addClass('pointer');
    }, function () {
        $(this.cells[5]).removeClass('pointer');
    });
    //none
    $("#invoice tr").hover(function () {
        $(this.cells[0]).addClass('pointer');
    }, function () {
        $(this.cells[0]).removeClass('pointer');
    });
    //allow only numbers
    $('#invoice input.number').numeric();

    //global variables
    var inputs = $('#invoice tr td.quantity input, #invoice tr td.rate input');
    var amount_inputs = $('#invoice tr td.amount input');
    var vat_inputs = $('#invoice tr td.vat input');
    var subtotal_inputs = $('#invoice tr td.subtotal input');
    var remove = $('#invoice tr td.delete a');
    //calculate
    $(document).on("keyup", '#invoice tr td.quantity input, #invoice tr td.rate input', function (e) {
        e.preventDefault();
        invoice.calculate(this);
        return false;
    });
    //remove item
    $(document).on("click", "#invoice tr td.delete a", function (e) {
        e.preventDefault();
        invoice.removeItem(this);
        return false;
    });
    //add blank row
    $(document).on("click", "#main-invoice #btnAdd", function (e) {
        e.preventDefault();
        invoice.cloneItem();
        return false;
    });
    //test
    $('#main-invoice .combobox').on("select2-selecting", function (e) {
        //e.object.id
        //alert(e.val);
        var r, q;
        $.ajax({
            url: 'api/invoice/GetProductById/',
            type: "get",
            data: { id: e.val },
            complete: function (data) {
            },
            error: function (data) {
                alert('error');
            },
            success: function (data) {
                r = data.Rate;
                q = 1;
            }
        });
        $(this).closest('tr').find('td.quantity input').val(q);
        $(this).closest('tr').find('td.rate input').val(r);
        invoice.calculate(this);
    });
    //remove
    $('#main-invoice .combobox').on("select2-removed", function (e) {
        //e.object.id
        //alert(e.val);
        $(this).closest('tr').find('td.quantity input').val(0);
        $(this).closest('tr').find('td.rate input').val(0);
        invoice.calculate(this);
    });

   
});