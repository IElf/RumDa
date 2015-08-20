var app = angular.module('app.controllers');
//app.animation('.info', [
//    function() {
//        return {
//            // make note that other events (like addClass/removeClass)
//            // have different function input parameters
//            enter: function(element, doneFn) {
//                jQuery(element).fadeIn(1000, doneFn);

//                // remember to call doneFn so that angular
//                // knows that the animation has concluded
//            },

//            move: function(element, doneFn) {
//                jQuery(element).fadeIn(1000, doneFn);
//            },

//            leave: function(element, doneFn) {
//                jQuery(element).fadeOut(1000, doneFn);
//            }
//        }
//    }
//]);
app.directive("info", [
function () {
    return {
        restrict: 'EA',
        replace: false,
        transclude: false,
        require: '^?accordion',
        scope: {
            title: '=expanderTitle'
        },
        link: function (scope, element, attrs, accordionController) {
            $(element).hover(
  		function () {
  		    $(this).children().stop(false, true);
  		    $(this).children(".serBoxOn").fadeIn("slow");
  		    $(this).children(".pic1").animate({ right: -110 }, 400);
  		    $(this).children(".pic2").animate({ left: 41 }, 400);
  		    $(this).children(".txt1").animate({ left: -240 }, 400);
  		    $(this).children(".txt2").animate({ right: 0 }, 400);
  		},
  		function () {
  		    $(this).children().stop(false, true);
  		    $(this).children(".serBoxOn").fadeOut("slow");
  		    $(this).children(".pic1").animate({ right: 41 }, 400);
  		    $(this).children(".pic2").animate({ left: -110 }, 400);
  		    $(this).children(".txt1").animate({ left: 0 }, 400);
  		    $(this).children(".txt2").animate({ right: -240 }, 400);
  		}
	);
        }

    }


}
]);