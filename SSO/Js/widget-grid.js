var app = angular.module('base', ['ngResource']);
app.directive("grid", function () {
    var grid = {
        restrict: 'EA',
        replace: true,
        templateUrl: 'grid.html',
        scope: {
            list: "="
        },
        link: function (scope, element, attr) {
            scope.toggle = function () {
                //  window.location = scope.item.id;
                console.log(element);
            }
        }
    }
    return grid;
});