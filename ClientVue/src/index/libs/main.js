/// <reference path="../libs/jquery-2.2.3.js" />
/// <reference path="../libs/jquery.waypoints.js" />

$(document).ready(function () {

    $('.section-mission').waypoint(function (direction) {
        if (direction === 'down') {
            $('nav').addClass('sticky');
        } else {
            $('nav').removeClass('sticky');
        }
    }, { offset: '60px' });

    $('a[href^="#"]').on('click', function (event) {
        var target = $(this.getAttribute('href'));
        if (target.length) {
            event.preventDefault();
            $('html, body').stop().animate({
                scrollTop: target.offset().top - 50
            }, 1000);
        }
    });

    $('.section-mission').waypoint(function (direction) {
        $('#missionFadeIn').addClass('animated fadeIn');
    }, { offset: '50%' });

    $('.section-process').waypoint(function (direction) {
        $('#phoneFadeIn').addClass('animated fadeInUp');
    }, { offset: '50%' });

    $('.section-pending').waypoint(function (direction) {
        $('#pendingFadeIn').addClass('animated fadeIn');
    }, { offset: '60%' });

});