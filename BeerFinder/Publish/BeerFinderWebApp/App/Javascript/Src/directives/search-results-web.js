(function() {
    'use strict';

    var appDirectives = angular.module('app.directives');

    appDirectives.directive('searchResultsWeb', ['searchService', '$location', '$modal', function(searchService, $location, $modal) {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                results: '=ngModel',
                order: '=orderProp'
            },
            templateUrl:'App/Templates/search-results.html',
            link: function(scope, $rootScope) {
                scope.showDetails = function(data) {
                    searchService.setData(data);
                    $rootScope.modalInstance = $modal.open({
                        templateUrl: 'App/Templates/details.html',
                        size: 'lg',
                        controller: 'DetailController',
                        resolve: {}
                    });
                    $rootScope.modalInstance.result.then(function() {
                    }, function() {
                    })['finally'](function() {
                        $rootScope.modalInstance = undefined;
                    });
                };
                scope.changePage = function(startIndex) {
                    var query = $location.search().q;
                    searchService.searchBeers(query, startIndex).then(function(resp) {
                        scope.results = resp;
                    });
                };
				scope.selectedCategory = function (option) {
					scope.chosenCategory = option.id;
					var query = $location.search().q;
					searchService.searchBeers(query, 1, scope.chosenGlassware, option.id).then(function (resp) {
						scope.results = resp;
					});                   
                };
				scope.selectedGlassware = function (option) {
					scope.chosenGlassware = option.id;
					var query = $location.search().q;
					searchService.searchBeers(query, 1, option.id, scope.chosenCategory).then(function (resp) {
						scope.results = resp;
					});
                };
                searchService.getCategories().then(function(resp) {
                    scope.categories = resp.data;
                });
                searchService.getGlasswares().then(function(resp) {
                    scope.glasswares = resp.data;
                });
            }
        };
    }]);
}());
