'use strict';

angular.module('app', ['ui.router', 'ngResource', 'ngAnimate', 'app.services', 'app.controllers'])


.run(function($rootScope, $state) {

$rootScope.$on('$stateChangeStart', function (event, next) {


});

})


.config(function($stateProvider, $urlRouterProvider) {

    $stateProvider
          .state('about', {
              url: '/about',
    
            templateUrl: 'views/default.html',
            controller: 'infoCtrl'
        })
        .state('dbs', {
            url: '/dbs',
            templateUrl: 'views/dbs.html',
            controller: 'BaseCtrl'
        })
       ;


    $urlRouterProvider.otherwise('about');

});
