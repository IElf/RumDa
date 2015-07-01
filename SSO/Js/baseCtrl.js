var app = angular.module('cache', ['ngResource']);
app.controller('CackeGet', ['$scope', '$resource', function ($scope, $resource) {
    var res = $resource('database.ashx',
    {},
    {
        query: { method: 'GET', params: {}, isArray: true }
    });
    $scope.list = res.query();
}
]);