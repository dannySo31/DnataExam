

app.service('hotelService', function ($rootScope,$http, $q) {

    this.getAll = function () {

        var request = $http.get('/hotels.json');
        return request.then(function (response) {
            return response.data;
        },

            function (failed) {
                return ($q.reject(response.data.message));
            });

    };
    this.getStars = function () {
        return [
            { value: '-1', text: 'Any' },
            { value: '0', text: '0' },
            { value: '1', text: '1' },
            { value: '2', text: '2' },
            { value: '3', text: '3' },
            { value: '4', text: '4' },
            { value: '5', text: '5' }
          
        ];
    };
    this.search = function (opt) {
        $rootScope.$broadcast('searchEvent',opt);
    }

});