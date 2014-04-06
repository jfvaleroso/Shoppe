

var invoice = function () {
    return {
        create: function (url) {
            window.location = url;
        },
        manage: function (url) {
            window.location = url;
        },
        calculate: function (element) {
            debugger;
            var qty = $(element).closest('tr').find('td.quantity input').val();
            var rate = $(element).closest('tr').find('td.rate input').val();
            var grams = $(element).closest('tr').find('td.grams input').val();
            var cost_input = $(element).closest('tr').find('td.cost input');
            var bonus_input = $(element).closest('tr').find('td.bonus input');
            var total_input = $(element).closest('tr').find('td.total input');

            var bonusRate=  $('td.bonus span.percent').attr('data-result');

            var cost = qty * rate * grams;
            var bonus = cost / 100 * 0;
            var total = cost + bonus;

            cost_input.val(cost.toFixed(2));
            bonus_input.val(bonus.toFixed(2));
            total_input.val(total.toFixed(2));
            invoice.updateSummary(cost_input, bonus_input, total_input);
        },
        updateSummary: function (cost, bonus, total) {
            cost = $('#invoice tr td.cost input');
            bonus = $('#invoice tr td.bonus input');
            total = $('#invoice tr td.total input');
            var total_cost = 0;
            var total_bonus = 0;
            var grand_total = 0;

            cost.each(function () {
                if ($(this).val() != '') {
                    total_cost += parseFloat($(this).val());
                }
            });
            bonus.each(function () {
                if ($(this).val() != '') {
                    total_bonus += parseFloat($(this).val());
                }
            });
            total.each(function () {
                if ($(this).val() != '') {
                    grand_total += parseFloat($(this).val());
                }
            });
            $("#total_cost input").val(total_cost.toFixed(2));
            $("#total_bonus input").val(total_bonus.toFixed(2));
            $("#grand_total input").val(grand_total.toFixed(2));
        },
        reset: function () {
            $("#total_cost input").val('');
            $("#total_bonus input").val('');
            $("#grand_total input").val('');
        },
        removeItem: function (element) {
            //retain one row
            var items = $('#invoice tr.invoice-item').length;
            if (items > 1) {
                $(element).closest('tr').remove();
            }
            else {
                $(element).closest('tr').find('input').val('');
            }
            //create new variable
            var cost = $('#invoice tr td.cost input');
            var bonus = $('#invoice tr td.bonus input');
            var total = $('#invoice tr td.total input');
            //update latest cost
            invoice.updateSummary(cost, bonus, total);
        },
        cloneItem: function () {       
            $('#invoice tr.invoice-item:last td.product select').select2("destroy");
            var clone = $('#invoice tr.invoice-item:last').clone(true, true);
            clone.find('input').val('');
            clone.insertAfter('#invoice tr.invoice-item:last');         
            $("#invoice tr.invoice-item select").select2({
                placeholder: "Select one",
                allowClear: true
            });
        },
        populateProductRate: function (e, element) {        
        },
        saveInvoice: function () {
            var cost = $("#total_cost input").val();;
            var bonus = $("#total_bonus input").val();
            var grand = $("#grand_total input").val();
            var customer = $('div#customer input').attr('data-id');
            var invoiceNo = $('div#invoiceNo input').val();
            var appraiser = $('div#appraiser input').val();
            var cashier = $('#Cashier').val();
            var cashierId = $('#CashierId').val();
            var appraiserId = $('#Appraiser').attr('data-id');
            var store = $('#StoreId').val();

            var thisInvoice = JSON.stringify(
             {
                 'InvoiceNo': invoiceNo,
                 'SubTotal': cost,
                 'TotalBonus': bonus,
                 'GrandTotal': grand,
                 'StoreId': store,
                 'Cashier': cashierId,
                 'Appraiser': appraiserId,
                 'CustomerId': customer
 
             });
            $.ajax({
                url: invoice.getHost(window.location.origin) + '/api/invoice/PostInvoice/',
                type: "post",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: thisInvoice,
                cache: false,
                complete: function (data) {
                },
                error: function (data, textStatus, jqXHR) { alert(textStatus) },
                success: function (data) {

                    console.log(data);
                   // invoice.savePurchase(data);
                   
                }
            });



        },
        savePurchase: function (invoiceId) {
            var status;
            $('#invoice tr.invoice-item').each(function () {
                var thisInvoice = invoiceId;
                var quantity = $(this).find('td.quantity input').val();
                var grams = $(this).find('td.grams input').val();
                var rate = $(this).find('td.rate input').val();
                var cost = $(this).find('td.cost input').val();
                var bonus = $(this).find('td.bonus input').val();
                var total = $(this).find('td.total input').val();
                var product = $(this).find('td.product select').select2('val');
               

                if (quantity != '' && grams != '' && grams > 0 && quantity > 0 && product!='') {
                    var purchase = JSON.stringify(
                   {
                       'Quantity': quantity,
                       'Grams': grams,
                       'Rate': rate,
                       'Cost': cost,
                       'Bonus': bonus,
                       'Total': total,
                       'Description': 'none',
                       'ProductId': product,
                       'InvoiceId': thisInvoice
                   });
                  
                   
                    $.ajax({
                        url: invoice.getHost(window.location.origin) + '/api/purchase/PostPurchase/',
                        type: "post",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: purchase,
                        cache: false,
                        complete: function (data) {                       
                        },
                        error: function (data, textStatus, jqXHR) { },
                        success: function (data) {
                            alert('success');
                            status = 'success';
                        }
                    });
                }
                else {
                    alert('add values');
                }
            });

            //redirect to view invoice
            if (status = 'success')
            {
                window.location = '/buy/view/' + invoiceId;
            }
            
        },
        modifyInvoice: function (id) {
            var cost = $("#total_cost input").val();;
            var bonus = $("#total_bonus input").val();
            var grand = $("#grand_total input").val();
            var customer = $('div#customer input').attr('data-id');
            var invoiceNo = $('div#invoiceNo input').val();
            var appraiser = $('div#appraiser input').val();
            var cashier = $('#Cashier').val();
            var cashierId = $('#CashierId').val();
            var appraiserId = $('#Appraiser').attr('data-id');
            var store = $('#StoreId').val();

            var thisInvoice = JSON.stringify(
             {
                 'Id': id,
                 'InvoiceNo': invoiceNo,
                 'SubTotal': cost,
                 'TotalBonus': bonus,
                 'GrandTotal': grand,
                 'StoreId': store,
                 'Cashier': cashierId,
                 'Appraiser': appraiserId,
                 'CustomerId': customer

             });

            $.ajax({
                url: invoice.getHost(window.location.origin) + '/api/invoice/PutInvoice/',
                type: "post",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: thisInvoice,
                cache: false,
                complete: function (data) {
                },
                error: function (data, textStatus, jqXHR) { alert(textStatus) },
                success: function (data) {
                    //remove purchases
                    //save purchases
                    invoice.savePurchase(data);

                }
            });



        },
        getRequest: function (url, title) {
                $.ajax({
                    url: url,
                    context: document.body,
                    cache: false,
                    success: function (data) {
                        $('#mainModal').modal('show');
                        $('#mainModal .modal-body').html(data);
                        $('#mainModal .modal-body .combobox').select2();
                        $('#mainModal .modal-header .modal-title').empty().append(title);
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
        },
        getRequestWithParameter: function (url, title, index) {
            $.ajax({
                url: url,
                context: document.body,
                cache: false,
                success: function (data) {
                    $('#mainModal').modal('show');
                    $('#mainModal .modal-body').html(data);
                    $('#mainModal .modal-body .combobox').select2();
                    $('#mainModal .modal-header .modal-title').empty().append(title);
                    $('#mainModal .modal-body').attr('data-index', index);
                  
                },
                error: function (err) {
                    alert(err);
                }
            });
        },
        searchEmployee: function (query, process) {
            names = [];
            map = {};
            $.ajax({
                url: 'buy/SearchEmployee',
                dataType: "json",
                data: { searchString: query },
                dataFilter: function (data) { return data; },
                success: function (data) {
                    $.each(data, function (i, employee) {
                        map[employee.name] = employee;
                        names.push(employee.name, employee.id);
                    });
                    process(names);
                }
            });
        },
        searchCustomer: function (query, process) {
            names = [];
            map = {};
            $.ajax({
                url: 'buy/SearchCustomer',
                dataType: "json",
                data: { searchString: query },
                dataFilter: function (data) { return data; },
                success: function (data) {
                    $.each(data, function (i, customer) {
                        map[customer.name] = customer;
                        names.push(customer.name, customer.id);
                    });
                    process(names);
                }
            });
        },
        serachPassCode: function (elment) {
            $.ajax({
                url: 'buy/SearchPassCode',
                dataType: "json",
                data: { searchString: $('#PassCode').val() },
                beforeSend: function () {
                    $('#invoice-bonus form').validate().form();
                },
                error: function (data, textStatus, jqXHR) { alert(textStatus) },
                success: function (data) {
                    if (data.code == '009') {
                        $('#alert').removeClass('hide');
                        $('#notification').addClass('validation-summary-errors');

                    }
                    if (data.code == '008') {

                        var index = $('#mainModal .modal-body').attr('data-index');
                        var cost = $('tr.invoice-item:eq' + '(' + index + ')').find('td.cost input').val();


                        var bonus = data.result.Bonus * 100;
                        var bonusCost = bonus * cost;

                        $('tr.invoice-item:eq' + '(' + index + ')').find('td.bonus input').val(bonusCost.toFixed(2));
                        $('td.bonus span.percent').attr('data-result', data.result.Bonus);
                        $('td.bonus span.percent').attr('data-id', data.result.Id);
                        $('td.bonus span.percent').empty().append(bonus + '%');
                        $('#mainModal').modal('hide');
                    }
                    if (data.code == '007') {
                        $('#alert').removeClass('hide');
                        $('#notification').addClass('validation-summary-errors');
                        $('#notification').empty().append('<ul><li>Invalid passcode.</li></ul>');

                    }
                }
            });
        },
       
        popup: function () {
            alert('teste');
        },
         getHost: function (url) {
                return url.toString().replace(/^(.*\/\/[^\/?#]*).*$/,"$1");
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
    var inputs = $('#invoice tr td.quantity input, #invoice tr td.rate input,#invoice tr td.grams input');
    var cost_inputs = $('#invoice tr td.cost input');
    var bonus_inputs = $('#invoice tr td.bonus input');
    var total_inputs = $('#invoice tr td.total input');
    var remove = $('#invoice tr td.delete a');
    //calculate on key up
    $(document).on("keyup change", '#invoice tr td.quantity input, #invoice tr td.rate input,#invoice tr td.grams input,#invoice tr td.bonus input', function (e) {
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
    $(document).on("click", "#main-invoice #btnAdd,#main-invoice-edit #btnAdd", function (e) {
        e.preventDefault();
        invoice.cloneItem();
        return false;
    });
    //populate product cost on add
    $('#main-invoice .combobox').on("select2-selected", function (e, element) {        
        //e.object.id
        //alert(e.val);
        var r = 0, q = 0, g = 0.0;
        element = this;
        $.ajax({
            url: invoice.getHost(window.location.origin) + '/api/purchase/GetProductById/',
            type: "get",
            data: { id: e.val },
            cache: false,
            complete: function (data) {
            },
            error: function (data) {
                alert('error');
            },
            success: function (data) {
                r = data.Rate;
                q = 1;
                g = 0.0;
                $(element).closest('tr').find('td.rate input').val(r);
                $(element).closest('tr').find('td.quantity input').val(q);
                $(element).closest('tr').find('td.grams input').val(g);
                invoice.calculate(element);
            }
        });
    });
    //populate product cost on edit
    $('#main-invoice-edit .combobox').on("select2-selected", function (e, element) {
        //e.object.id
        //alert(e.val);
        var r = 0, q = 0, g = 0.0;
        element = this;
        $.ajax({
            url: invoice.getHost(window.location.origin) + '/api/purchase/GetProductById/',
            type: "get",
            data: { id: e.val },
            cache: false,
            complete: function (data) {
            },
            error: function (data) {
                alert('error');
            },
            success: function (data) {
                r = data.Rate;
                q = 1;
                $(element).closest('tr').find('td.rate input').val(r);
                $(element).closest('tr').find('td.quantity input').val(q);
                invoice.calculate(element);
            }
        });
    });
    //remove
    $('#main-invoice .combobox,#main-invoice-edit .combobox').on("select2-removed", function (e) {
        //e.object.id
        //alert(e.val);
        $(this).closest('tr').find('td.quantity input').val(0);
        $(this).closest('tr').find('td.rate input').val(0);
        invoice.calculate(this);
    });
    //add purchase
    $('#btnDraft').on("click", function (e) {
        e.preventDefault();
        invoice.savePurchase(22);
    });
    //pop up customer view
    $('#customer').on("click", function (e) {
        e.preventDefault();
        var url ='buy/customer';
        invoice.getRequest(url, "Customer Information");
        return false;
    });
    //pop up customer view
    $('#btnAddBonus').on("click", function (e) {
        e.preventDefault();
        var url = 'buy/bonus';
        var index = $(this).parents('tr').index();
        invoice.getRequestWithParameter(url, "Bonus", index); 
        return false;
    });
    //serach employee
    $('#Appraiser').typeahead({
        source: function (query, process) {
            invoice.searchEmployee(query, process);
        },
        updater: function (item) {
            //selectedName = map[item].name;
            //return item;
            selectedId = map[item].id;
            $('#Appraiser').attr('data-id', selectedId);
            return item;
        },
        matcher: function (item) {
            if (item.toLowerCase().indexOf(this.query.trim().toLowerCase()) != -1) {
                return true;
            }
        },
        sorter: function (items) {
            return items.sort();
        },
        highlighter: function (item) {
            var regex = new RegExp('(' + this.query + ')', 'gi');
            return item.replace(regex, "<strong>$1</strong>");
        }
    });
    //save and approve invoice
    $('#btnSaveAndApprove').on("click", function (e) {
        e.preventDefault();
        $(this).empty().append('Saving your invoice...');
        $(this).attr('disabled', 'disabled');
        invoice.saveInvoice();
        return false;
    });
    //save and approve invoice
    $('#btnSaveChangesAndApprove').on("click", function (e) {
        e.preventDefault();
        invoice.modifyInvoice();
        return false;
    });

    //print
    $('#btnConfirmAndPrint').on("click", function (e) {
        e.preventDefault();
       window.location = '/buy/test/51'
        return false;
    });
    $("#btnCancelInvoice").click(function (event) {
        event.preventDefault();
        window.location = "/buy/";
    });



   
});