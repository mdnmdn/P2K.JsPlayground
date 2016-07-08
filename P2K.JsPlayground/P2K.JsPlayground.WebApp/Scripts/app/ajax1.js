"use strict";
// Immediately Invoked Function
(function () {
    //console.log('Run!');

    var timeAjax = {

        init: function () {
            $('#btnShowTime').on('click', timeAjax.requestTime);
            timeAjax.requestTime();
            //console.log('init ok');
        },

        requestTime: function (ev) {
            if (ev) ev.preventDefault();

            var url = 'http://p2k.smarthings.net/Tools/Now';
            $.get(url, timeAjax.updateTime);
            $('#timeContainer').html('loading...');
        },

        updateTime: function (data) {
            $('#timeContainer').html(data);
        }
    };

    $(timeAjax.init);

})();

