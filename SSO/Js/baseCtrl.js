var app = angular.module('base', ['ngResource']);
app.controller('BaseGet', [
    '$scope', '$resource', function($scope, $resource) {
        var res = $resource('database.ashx',
        {},
        {
            query: { method: 'GET', params: {}, isArray: true }
        });
        $scope.list = res.query();
    }
])