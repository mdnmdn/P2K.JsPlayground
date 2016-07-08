"use strict";
// Immediately Invoked Function
(function () {
    

    var showTime = {
        init: function() {
            $('#btnShowTime').on('click', showTime.callTimeAjax);
            showTime.callTimeAjax();

            console.log('ajax1 init');
        },

        callTimeAjax: function (event) {
            if(event) event.preventDefault();

            var url = 'http://p2k.smarthings.net/Tools/Now';
            $.get(url, showTime.onTimeAjaxCompleted);
            $('#timeContainer').html('loading...');
        },

        onTimeAjaxCompleted: function(data){
            //console.log('onTimeAjaxCompleted', data);
            $('#timeContainer').html(data);
        }

    };
    

    $(showTime.init);



    //$('#btnShowTime').on('click', function (event) {
    //    event.preventDefault();

    //    var url = 'http://p2k.smarthings.net/Tools/Now';
    //    $.get(url, function (data) {
    //        $('#timeContainer').html(data);
    //    });
    //    $('#timeContainer').html('loading...');
    //});


})();

