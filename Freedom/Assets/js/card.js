﻿(function ($) {
    'use strict';

    $('#card-basic').card({
        onRefresh: function () {
            setTimeout(function () { $('#card-basic').card({ refresh: false }); }, 2000);
        }
    });

    $('#card-advance').card({
        onRefresh: function () {
            setTimeout(function () { $('#card-advance').card({ error: "Something went terribly wrong. Just keep calm and carry on!" }); }, 2000);
        }
    });

    $('#card-linear').card({
        progress: 'bar', onRefresh: function () {
            setTimeout(function () { $('#card-linear').card({ refresh: false }); }, 2000);
        }
    });

    $('#card-circular').card({
        progress: 'circle', onRefresh: function () {
            setTimeout(function () { $('#card-circular').card({ refresh: false }); }, 2000);
        }
    });

    $('#card-circular-minimal').card({
        progress: 'circle-lg', overlayOpacity: 0.6, onRefresh: function () {
            setTimeout(function () { $('#card-circular-minimal').card({ refresh: false }); }, 2000);
        }
    });

    $('#card-error').card({
        onRefresh: function () {
            setTimeout(function () { $('#card-error').card({ error: "Something went terribly wrong" }); }, 2000);
        }
    });

    $('#card-linear-color').card({
        progress: 'bar', progressColor: 'success', onRefresh: function () {
            setTimeout(function () { $('#card-linear-color').card({ refresh: false }); }, 2000);
        }
    });

    $('#card-circular-color').card({
        progress: 'circle', progressColor: 'success', onRefresh: function () {
            setTimeout(function () { $('#card-circular-color').card({ refresh: false }); }, 2000);
        }
    });

    if (!jQuery().sortable) { return; }

    $(".sortable .row .col-lg-6").sortable({
        connectWith: ".sortable .row .col-lg-6",
        handle: ".card-header",
        cancel: ".card-close",
        placeholder: "sortable-box-placeholder round-all",
        forcePlaceholderSize: true,
        tolerance: 'pointer',
        forceHelperSize: true,
        revert: true,
        helper: 'original',
        opacity: 0.8,
        iframeFix: false
    });

})(window.jQuery);