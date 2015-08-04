"use strict";

/**
 * @ngdoc overview
 * @name webApp
 * @description
 * # webApp
 *
 * Main module of the application.
 */
angular.module("base", [
    "ngAnimate",
    "ngCookies",
    "ngResource",
    "ngRoute",
    "ngSanitize",
    "ngTouch"
])
  .config(function ($routeProvider) {
      $routeProvider
        .when("/", {
            redirectTo: "/database"
        })
        .when("/database", {
            templateUrl: "index.html",
            controller: "baseCtrl"
        })
        .when("/token", {
            templateUrl: "index.html",
            controller: "tokenCtrl"
        })
        .otherwise({
            redirectTo: "/"
        });
  });
