var app = angular.module('base', ['ngResource']);
app.controller('BaseGet', [
    '$scope', '$resource', '$location', function($scope, $resource, $location) {
        var res = $resource('database.ashx',
        {},
        {
            query: { method: 'GET', params: {}, isArray: true }
        });
        $scope.list = res.query();
        //$scope.To = function(route) {
        //    $location.path('/' + route);
        //};
    }
]);
