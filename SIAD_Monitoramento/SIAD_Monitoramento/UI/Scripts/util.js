var editorprops = { toolbar:
		    [
			    { name: 'basicstyles', items: ['FontSize', 'Bold', 'Italic', 'Underline'] },
			    { name: 'paragraph', items: ['NumberedList', 'BulletedList', 'Outdent', 'Indent', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
			    { name: 'tools', items: ['Maximize','Source'] }
		    ], forcePasteAsPlainText: true, height: '200px'
};
var mask_date = "99/99/9999";
var mask_cep = "99999-999";
var mask_phone = "(99) 9999-9999?9";
var mask_cpf = "999.999.999-99";
var mask_cnpj = "99.999.999/9999-99";
var mask_number = "9?999";

//$.datepicker.setDefaults($.datepicker.regional['pt']);


$(document).ready(function () {

    $('[placeholder]').focus(function () {
        var input = $(this);
        if (input.val() == input.attr('placeholder')) {
            input.val('');
            input.removeClass('placeholder');
        }
    }).blur(function () {
        var input = $(this);
        if (input.val() == '' || input.val() == input.attr('placeholder')) {
            input.addClass('placeholder');
            input.val(input.attr('placeholder'));
        }
    }).blur();

    configTypehead();

});

function confirm_delete() {
    return confirm(MSG_CONFIRM_DELETE);
}

function go(url) {
    location.href = url;
}

function edit(row) {
    $(row).find(".row-link")[0].click();
}


function configTypehead() {
    $('.typeahead').each(function () {
        var $this = $(this);
        $this
        .attr('autocomplete', 'off')
        .focus(function () {
            $('#' + $this.attr('data-typeahead-target')).val("");
            $(this).val("");
        })
        .blur(function () {
            if ($('#' + $this.attr('data-typeahead-target')).val() == "")
                $(this).val("");
        })
        .typeahead(
        {
            minLength: 3,
            source: function (typeahead, query) {
                var typeaheadArray = [];

                $('ul.typeahead').css('z-index', '9999');

                $.ajax({
                    url: '../ajax/user.aspx',
                    dataType: 'json',
                    async: false,
                    data: 's=' + typeahead + '',
                    success: function (data) {
                        inpCodUserNames = [];
                        inpCodUserNamesAndCodes = [];
                        $.each(data, function (i, o) {
                            var code, name, email;

                            if (o.indexOf('___') > -1) {
                                var info = o.split('___');
                                code = info[1]; //o.substring(o.indexOf('___') + 3);
                                name = info[0]; //o.substring(0, o.indexOf('___'));
                                email = info[2]; //o.substring(0, o.indexOf('___'));
                                inpCodUserNames.push(name);
                                inpCodUserNamesAndCodes.push({ "code": code, "name": name, "email":email });
                            }

                        });
                        typeaheadArray = inpCodUserNames;
                    }
                });
                return typeaheadArray;
            },
            updater: function (data) {

                $.each(inpCodUserNamesAndCodes, function (i, o) {
                    if (o.name == data) {
                        $('#' + $this.attr('data-typeahead-target')).val(o.code);
                        $('#' + $this.attr('data-typeahead-email')).val(o.email);
                    }
                });
                return data;
            }
        });
    });
}