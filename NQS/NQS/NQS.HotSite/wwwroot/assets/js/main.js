// Causas Home (uses the Owl Carousel library)
function buildCauseCarousel() {
    $("#cause-item-container.owl-carousel").owlCarousel({
        //autoplay: true,
        dots: true,
        loop: true,
        //margin: 15,
        touchDrag: false,
        mouseDrag: false,
        nav: !0,
        navText: ["<i class='left-marcas'></i>", "<i class='right-marcas'></i>"],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            900: {
                items: 4
            }
        }
    });
}

// Datatable custom defaults
$.extend($.fn.dataTable.defaults, {
    responsive: true,
    language: { url: "/assets/lib/datatables/language/pt-BR.json" },
    columns: [
        {
            name: 'currency',
            type: 'currency',
            mRender: "function () { return $.fn.dataTable.render.number(',', '.', 2, 'R$ '); }"
        }
    ]
});

// Validator custom defaults
$.validator.setDefaults({
    ignore: ':hidden, [readonly=readonly], [disabled], [readonly]'
});

// Inputmask custom defauts
Inputmask.extendDefaults({
    'removeMaskOnSubmit': true
});

// Custom inputmask alias
Inputmask.extendAliases({
    'currency': {
        "prefix": "R$ ",
        "digits": 2,
        "digitsOptional": false,
        //"decimalProtect": true,
        "groupSeparator": ".",
        "radixPoint": ",",
        "radixFocus": true,
        "autoGroup": true,
        "autoUnmask": true,
        "removeMaskOnSubmit": true,
        onUnMask: function (maskedValue, unmaskedValue) {
            return unmaskedValue.replace(',', '.');
        }
    }
});

Inputmask.extendAliases({
    'numeric': {
        "digits": 0,
        "autoUnmask": true,
        "removeMaskOnSubmit": true
    }
});

Inputmask.extendAliases({
    'phone': {
        "mask": "(99) 9999[9]-9999",
        "autoUnmask": true,
        "removeMaskOnSubmit": true
    }
});

Inputmask.extendAliases({
    'card': {
        "mask": "99999999999999[99]",
        "autoUnmask": true,
        "removeMaskOnSubmit": true
    }
});

Inputmask.extendAliases({
    'cvv': {
        "mask": "999[9]",
        "autoUnmask": true,
        "removeMaskOnSubmit": true
    }
});

Inputmask.extendAliases({
    'cpf': {
        "mask": "999.999.999-99",
        "autoUnmask": true,
        "removeMaskOnSubmit": true
    }
});

Inputmask.extendAliases({
    'cnpj': {
        "mask": "99.999.999/9999-99",
        "autoUnmask": true,
        "removeMaskOnSubmit": true
    }
});

Inputmask.extendAliases({
    'parcela': {
        "mask": "99",
        "min": 1,
        "max": 12,
        "autoUnmask": true,
        "removeMaskOnSubmit": true
    }
});

// extend range validator method to treat checkboxes differently
var defaultRangeValidator = $.validator.methods.range;
$.validator.methods.range = function (value, element, param) {
    if (element.type === 'checkbox') {
        // if it's a checkbox return true if it is checked
        return element.checked;
    } else {
        // otherwise run the default validation function
        return defaultRangeValidator.call(this, value, element, param);
    }
}

// Apply mask to inputs
$().ready(function () {
    $("input").inputmask();
});

//!(function ($) {
//    "use strict";

//    return;

//    // Header fixed on scroll
//    $(window).scroll(function () {
//        if ($(this).scrollTop() > 20) {
//            $('#header').addClass('header-scrolled');
//        } else {
//            $('#header').removeClass('header-scrolled');
//        }
//    });

//    if ($(window).scrollTop() > 20) {
//        $('#header').addClass('header-scrolled');
//    }

//    // Smooth scroll for the navigation menu and links with .scrollto classes
//    $(document).on('click', '.nav-menu a, .mobile-nav a, .scrollto', function (e) {
//        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
//            e.preventDefault();
//            var target = $(this.hash);
//            if (target.length) {

//                var scrollto = target.offset().top;

//                if ($('#header').length) {
//                    scrollto -= $('#header').outerHeight();
//                }

//                if ($(this).attr("href") == '#header') {
//                    scrollto = 0;
//                }

//                $('html, body').animate({
//                    scrollTop: scrollto
//                }, 1500, 'easeInOutExpo');

//                if ($(this).parents('.nav-menu, .mobile-nav').length) {
//                    $('.nav-menu .active, .mobile-nav .active').removeClass('active');
//                    $(this).closest('li').addClass('active');
//                }

//                if ($('body').hasClass('mobile-nav-active')) {
//                    $('body').removeClass('mobile-nav-active');
//                    $('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
//                    $('.mobile-nav-overly').fadeOut();
//                }
//                return false;
//            }
//        }
//    });

//    // Mobile Navigation
//    if ($('.nav-menu').length) {
//        var $mobile_nav = $('.nav-menu').clone().prop({
//            class: 'mobile-nav d-lg-none'
//        });
//        $('body').append($mobile_nav);
//        $('body').prepend('<button type="button" class="mobile-nav-toggle d-lg-none"><i class="icofont-navigation-menu"></i></button>');
//        $('body').append('<div class="mobile-nav-overly"></div>');

//        $(document).on('click', '.mobile-nav-toggle', function (e) {
//            $('body').toggleClass('mobile-nav-active');
//            $('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
//            $('.mobile-nav-overly').toggle();
//        });

//        $(document).on('click', '.mobile-nav .drop-down > a', function (e) {
//            e.preventDefault();
//            $(this).next().slideToggle(300);
//            $(this).parent().toggleClass('active');
//        });

//        $(document).click(function (e) {
//            var container = $(".mobile-nav, .mobile-nav-toggle");
//            if (!container.is(e.target) && container.has(e.target).length === 0) {
//                if ($('body').hasClass('mobile-nav-active')) {
//                    $('body').removeClass('mobile-nav-active');
//                    $('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
//                    $('.mobile-nav-overly').fadeOut();
//                }
//            }
//        });
//    } else if ($(".mobile-nav, .mobile-nav-toggle").length) {
//        $(".mobile-nav, .mobile-nav-toggle").hide();
//    }

//    // Back to top button
//    $(window).scroll(function () {
//        if ($(this).scrollTop() > 100) {
//            $('.back-to-top').fadeIn('slow');
//        } else {
//            $('.back-to-top').fadeOut('slow');
//        }
//    });

//    $('.back-to-top').click(function () {
//        $('html, body').animate({
//            scrollTop: 0
//        }, 1500, 'easeInOutExpo');
//        return false;
//    });

//    // Porfolio isotope and filter
//    $(window).on('load', function () {
//        var portfolioIsotope = $('.portfolio-container').isotope({
//            itemSelector: '.portfolio-item',
//            layoutMode: 'fitRows'
//        });

//        $('#portfolio-flters li').on('click', function () {
//            $("#portfolio-flters li").removeClass('filter-active');
//            $(this).addClass('filter-active');

//            portfolioIsotope.isotope({
//                filter: $(this).data('filter')
//            });
//        });

//        // Initiate venobox (lightbox feature used in portofilo)
//        $(document).ready(function () {
//            $('.venobox').venobox();
//        });
//    });

//    // Initi AOS
//    AOS.init({
//        duration: 800,
//        easing: "ease-in-out"
//    });


//    jQuery.fn.extend({
//        toggleText: function (a, b) {
//            var that = this;
//            if (that.text() != a && that.text() != b) {
//                that.text(a);
//            }
//            else
//                if (that.text() == a) {
//                    that.text(b);
//                }
//                else
//                    if (that.text() == b) {
//                        that.text(a);
//                    }
//            return this;
//        }
//    });

//    $(document).on('click', '.btn__causa--filter', function (e) {
//        e.preventDefault();
//        $('#menu-filter').toggleClass('d-none');
//        $(this).toggleClass('active');
//        $(this).toggleText('Filtrar', 'Selecionar filtro:');
//    });


//})(jQuery);

