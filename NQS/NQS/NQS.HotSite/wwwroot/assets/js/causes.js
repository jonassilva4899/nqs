$(document).ready(function ($) {
    loadCart();

    $(".cause-item-button > a").on("click", function (event) {
        event.stopImmediatePropagation();
    });

    $('body').on('click', ".cause-item-box", function () {
        $(this).toggleClass('selected');

        if ($(this).hasClass('selected')) {
            addCart(this);
        }
        else {
            removeCart(this);
        }

        updateStatus();
    });

    function addCart(element) {
        var data = {
            campanhaid: $(element).data('campanhaid'),
            nome: $(element).data('nome'),
            beneficiario: $(element).data('beneficiario'),
            valor: $(element).data('valorminimo')
        }

        $.ajax({
            async: false,
            data: data,
            method: 'post',
            dataType: 'json',
            url: '/basket/add',
            success: function (result) {
            }
        });
    }

    function removeCart(element) {
        var data = {
            campanhaid: $(element).data('campanhaid')
        }

        $.ajax({
            async: false,
            data: data,
            method: 'post',
            dataType: 'json',
            url: '/basket/remove',
            success: function (result) {
            }
        });
    }

    function updateStatus() {
        $.ajax({
            async: false,
            method: 'post',
            dataType: 'json',
            url: '/basket/get',
            success: function (result) {
                if (result.campanhas.length == 0) {
                    $("#btnDoar").val('QUERO DOAR!');
                    $("#btnDoar").removeClass('active');
                    $("#btnDoar").attr("disabled", true);
                }
                else {
                    $("#btnDoar").val('DOAR! ( ' + result.campanhas.length + ' )');
                    $("#btnDoar").addClass('active');
                    $("#btnDoar").attr("disabled", false);
                }
            }
        });
    }

    function loadCart() {
        $.ajax({
            async: false,
            method: 'post',
            dataType: 'json',
            url: '/basket/get',
            success: function (result) {
                if (result.campanhas.length == 0) {
                    $("#btnDoar").val('QUERO DOAR!');
                    $("#btnDoar").removeClass('active');
                    $("#btnDoar").attr("disabled", true);
                }
                else {
                    $(result.campanhas).each(function (index, element) {
                        $("#causa_" + element.campanhaid).addClass('selected');
                    });

                    $("#btnDoar").val('DOAR! ( ' + result.campanhas.length + ' )');
                    $("#btnDoar").addClass('active');
                    $("#btnDoar").attr("disabled", false);
                }
            }
        });
    }
});

function showCart() {
    $.ajax({
        async: false,
        method: 'get',
        url: '/basket/index',
        success: function (result) {
            $("#modalCart").html(result);
        }
    });
}