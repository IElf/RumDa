var app = angular.module('app.controllers', ['ngResource']);
app.controller('BaseCtrl', [
    '$scope', '$resource', '$location', function($scope, $resource, $location) {
        var res = $resource('http://www.elf.webapi.com/api/dbs/',
        {},
        {
            query: { method: 'GET', params: {}, isArray: false }
        });
        function load () {
            res.query().$promise.then(function success(data) {
                
                $scope.list = data.ListT;
                console.log($scope.list.length);
            }, function error(msg) {
                alert(msg.Message);
            });
        };

        load();
    }
]);
