/// <reference path="../data/infos.js" />
var app = angular.module('app.controllers', ['ngResource']);
app.controller('infoCtrl', [
    '$scope', '$resource', '$location', function($scope, $resource, $location) {
        var res = $resource('scripts/data/infos.js',
        {},
        {
            query: { method: 'GET', params: {}, isArray: false }
        });

        function load() {
            res.query().$promise.then(function success(data) {

                $scope.items = data.infos;

            }, function error(msg) {
                alert(msg.Message);
            });
        };

        load();
    }
]);

