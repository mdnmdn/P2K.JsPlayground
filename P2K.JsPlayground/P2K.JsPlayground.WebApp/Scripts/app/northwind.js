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

        show: function (customerId) {
            $('#customer-list').show();
            
            // refresh ajax data
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
                row.attr('id', 'row-' + this.CustomerID)
                    .attr('data-id', this.CustomerID)
                    .data('id', this.CustomerID);

                var cmdCell = common.addCell(row,'');
                //row.append($('<td></td>').html(this.CustomerID));
                common.addCell(row, this.CustomerID);
                common.addCell(row, this.CompanyName);
                common.addCell(row, this.ContactName);
                common.addCell(row, this.Country);
                common.addCell(row, this.City);

                table.append(row);


                var detailLink = $('<a href="#"></a>').html('<span class="glyphicon glyphicon-search"></span>');
                var ordersLink = $('<a href="#"></a>').html('<span class="glyphicon glyphicon-tasks"></span>');

                detailLink.on('click', customerList.showDetail.bind(null, this.CustomerID));
                ordersLink.on('click', customerList.showOrders.bind(null, this.CustomerID));

                cmdCell.append(detailLink);
                cmdCell.append(ordersLink);
            });

            console.log('preparing done');
        },

        showDetail: function(customerId){
            $('#customer-list').hide();
            customerDetail.show(customerId);
        },

        showOrders: function(customerId){
            console.log("showOrders", customerId);
        }

    };


    var customerDetail = {

        init: function(){
            $('#btn-show-customer-list').on('click',customerDetail.backToList);
        },

        show: function (customerId) {
            $('#customer-detail').show();

            console.log('customer-detail.show', customerId);
            // load ajax data
        },

        backToList: function () {
            $('#customer-detail').hide();
            customerList.show();
        }
    };
   
    $(customerList.init);
    $(customerDetail.init);

})();

