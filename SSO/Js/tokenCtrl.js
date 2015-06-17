var app = angular.module('cache', []);
app.controller('CackeGet', ['$scope', '$resource', function ($scope, $resource) {
        var res = $resource('cache.ashx',
        {},
        {
            query: { method: 'GET', params: {}, isArray: true }


        });
        $scope.list = res.query();

    }
]);