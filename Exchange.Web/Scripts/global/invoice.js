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

            var cost = qty * rate * grams;
            var bonus = cost / 100 * 20;
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
        reseet: function () {
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
        savePurchase: function () {
            $('#invoice tr.invoice-item').each(function () {
                debugger;
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
                       'ProductId' :product
                   });
                  
                 
                    $.ajax({
                        url: 'api/purchase/PostPurchase/',
                        type: "post",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: purchase,
                        cache: false,
                        complete: function (data) {                       
                        },
                        error: function (data, textStatus, jqXHR) { alert(jqXHR) },
                        success: function (data) {
                            alert('success');
                        }
                    });
                }
                else {
                    alert('add values');
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
                        $('#mainModal .modal-header .modal-title').empty().append(title);
                       
       
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
        },

        test: function () {

            alert('test');
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
    //calculate
    $(document).on("keyup", '#invoice tr td.quantity input, #invoice tr td.rate input,#invoice tr td.grams input', function (e) {
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
    $('#main-invoice .combobox').on("select2-selected", function (e, element) {        
        //e.object.id
        //alert(e.val);
        var r = 0, q = 0, g = 0.0;
        element = this;
        $.ajax({
            url: 'api/purchase/GetProductById/',
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
                invoice.calculate('#main-invoice .combobox');
            }
        });
    });
    //remove
    $('#main-invoice .combobox').on("select2-removed", function (e) {
        //e.object.id
        //alert(e.val);
        $(this).closest('tr').find('td.quantity input').val(0);
        $(this).closest('tr').find('td.rate input').val(0);
        invoice.calculate(this);
    });
    //add purchase
    $('#btnDraft').on("click", function (e) {
        e.preventDefault();
        invoice.savePurchase();
    });
    //pop up customer view
    $('#customer').on("click", function (e) {
        e.preventDefault();
        var url ='buy/addcustomer';
        invoice.getRequest(url, "Customer Information");
        return false;
    });
    //Search Employee
    //run autocomplete
    $("#Appraiser").autocomplete({
        source: function (request, response) {
            debugger;
            $.ajax({
                url: 'buy/SearchEmployee',
                dataType: "json",
                data: { searchString: request.term },
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.label,
                            value: item.value
                        };
                    }));
                }

            });
        },
        minLength: 2,
        select: function (event, ui) {
          
        }
    });
 
    



   
});