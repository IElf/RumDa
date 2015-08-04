
//app.run(['$rootScope', '$location', function ($rootScope, $location) {
//      $rootScope.$on('$routeChangeStart', function (evt, next, current) {
//          console.log('route begin change');
//      });
//}]);

angular.module('base', ["ngResource"])
  .run(['$rootScope', '$location', function ($rootScope, $location) {
      $rootScope.$on('$routeChangeSuccess', function (evt, current, previous) {
          console.log('route have already changed');
      });
  }])