var defaultSearch = {

    name: $,
    userRating: $,
    selectedStar: $,
    minCost: $
};

var app = angular.module('hotelsApp', ['angularUtils.directives.dirPagination']);

app.filter('hotelSearch', function () {
    return function (items, searchParams) {
        var filtered = [];
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            var trimmedName = $.trim(searchParams.Name);
            var trimmedUserRating = $.trim(searchParams.UserRating);
            var trimmedUserRatingStars = $.trim(searchParams.Stars);
            var trimmedMinCost = $.trim(searchParams.MinCost);
            if (trimmedName!= '') {
                if (item.Name.indexOf(trimmedName) === -1) {
                    continue;
                }
            }
            if (trimmedUserRating != "") {
                if (isNaN(trimmedUserRating)) {
                    continue;
                } else {
                    if (item.UserRating < parseInt(trimmedUserRating)) {
                        continue;
                    }
                }
            }
            if (trimmedUserRatingStars != "" && trimmedUserRatingStars != "-1") {
                if (isNaN(trimmedUserRatingStars)) {
                    continue;
                } else {
                    if (item.Stars != parseInt(trimmedUserRatingStars)) {
                        continue;
                    }
                }
            }
            if (trimmedMinCost != "") {
                if (isNaN(trimmedMinCost)) {
                    continue;
                } else {
                    if (item.MinCost < parseInt(trimmedMinCost)) {
                        continue;
                    }
                }
            }
            filtered.push(item);
        }

        return filtered;
    }
});
app.controller('hotelsController', function ($scope, hotelService, pagerService) {
    var that = this;
    that.hotels = [];
    that.sortKey = "Name";
    that.reverse = false;
    that.searchParams = defaultSearch;
    that.initialize = function () {
        hotelService.getAll().then(function (data) {
            that.hotels = data.Establishments;
           
        });
    };
    that.sort = function (keyName) {
        
        that.sortKey = keyName; 
        that.reverse = !that.reverse;
    };

    $scope.$on('searchEvent', function (event, opt) {
        console.log(opt);
        that.searchParams = {

            Name: opt.Name,
            UserRating: opt.UserRating,
            Stars: opt.SelectedStar ,
            MinCost: opt.MinCost
        };

    });
    that.initialize();
});

app.controller('hotelSearchController', function ($scope, hotelService) {
    var that = this
    that.Name = '';
    that.UserRating = 0;

    that.Stars = hotelService.getStars();
    that.SelectedStar = '-1';
    
    that.MinCost = 0;

    that.search = function () {
        hotelService.search({
            Name: that.Name,
            UserRating: that.UserRating,
            SelectedStar: that.SelectedStar,
            MinCost: that.MinCost
        });
       
    };
});

app.controller('pagerController', function ($scope, pagerService) {
    var vm = this;
    vm.items
});