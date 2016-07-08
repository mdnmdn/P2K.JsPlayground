"use strict";

// Immediately Invoked Function
(function () {
    


    console.log('NW!');

    var baseUrl = 'http://p2k.smarthings.net/odata/';

    var common = {
        handleAjaxError: function (err, xhr) {
            console.log('err:', err, xhr);
        },

        addCell: function (row, html) {
            var cell = $('<td></td>').html(html);
            row.append(cell);
            return cell;
        }
    };

    var customerList = {
        init: function () {
            console.log('NW.customerList.init');
            customerList.loadApiData();
        },


        loadApiData: function () {
            $.ajax({
                url: baseUrl + 'Customers',
                method: 'GET',
                success: customerList.prepareTable,
                error: common.handleAjaxError
            });
            console.log('loadApiData call started...');
        },
        
        prepareTable: function (data) {
            var table = $('#customer-list table');
            console.log('preparing table',table);

            $.each(data.value, function () {
                //console.log(this);

                var row = $('<tr></tr>');
                //row.append($('<td></td>').html(this.CustomerID));
                common.addCell(row, this.CustomerID);
                common.addCell(row, this.CompanyName);
                common.addCell(row, this.ContactName);
                common.addCell(row, this.Country);
                common.addCell(row, this.City);

                table.append(row);
            });

            console.log('preparing done');
        }
    };

   
    $(customerList.init);

})();

