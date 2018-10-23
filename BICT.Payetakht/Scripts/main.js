"use strict";
jQuery(document).ready(function ($) {
    $(window).load(function () {
        $("#loading").fadeOut(500);
    });
    $('#navbar-menu').find('a[href*=#]:not([href=#])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: (target.offset().top - 80)
                }, 1000);
                if ($('.navbar-toggle').css('display') != 'none') {
                    $(this).parents('.container').find(".navbar-toggle").trigger("click");
                }
                return false;
            }
        }
    });
    var wow = new WOW({
        mobile: false
    });
    wow.init();
    $('.popup-img').magnificPopup({
        type: 'image',
        gallery: {
            enabled: true
        }
    });
    $('.video-link').magnificPopup({
        type: 'iframe'
    });
    //$(".hello_slid").slick({
    //    dots: true,
    //    infinite: false,
    //    slidesToShow: 1,
    //    slidesToScroll: 1,
    //    arrows: true,
    //    prevArrow: "<i class='glyphicon glyphicon-chevron-left nextprevleft'></i>",
    //    nextArrow: "<i class='glyphicon glyphicon-chevron-right nextprevright'></i>",
    //    autoplay: true,
    //    autoplaySpeed: 2000
    //});
    $(".audit_slid").slick({
        dots: true,
        infinite: false,
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        prevArrow: "<i class='glyphicon glyphicon-chevron-left nextprevleft'></i>",
        nextArrow: "<i class='glyphicon glyphicon-chevron-right nextprevright'></i>",
        autoplay: true,
        autoplaySpeed: 6000
    });
    $(".business_items").slick({
        dots: true,
        infinite: false,
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        prevArrow: "<i class='glyphicon glyphvicon-chevron-left nextprevleft'></i>",
        nextArrow: "<i class='glyphicon glyphicon-chevron-right nextprevright'></i>",
        autoplay: true,
        autoplaySpeed: 2000
    });
    $('.scrollup').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 1000);
        return false;
    });
});
