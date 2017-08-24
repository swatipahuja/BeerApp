(function() {
    'use strict';

    var appDirectives = angular.module('app.directives', []);

    appDirectives.directive('searchInput', ['searchService', '$location', function(searchService, $location) {
        return {
            restrict: 'E',
            transclude: true,
            replace: true,
            scope: {
                results: '=ngModel',
                order: '=orderProp',
                query: '=value'
            },
            templateUrl:'App/Templates/search-input.html',
            link: function(scope) {
                scope.changedvalue = function() {
                    console.log(scope.order);
                    scope.option = true;
                };
                scope.isLoading = false;
                scope.search = function(valid, query, startIndex) {
                    if (valid) {
                        scope.isLoading = true;
                        searchService.searchBeers(query, startIndex).then(function(resp) {
                            console.log(resp);
                            scope.results = resp;
                            scope.isLoading = false;
                            $location.search('q', query);
                        });
                    }
                };
                if ($location.search().q !== undefined) {
                    scope.query = $location.search().q;
                    scope.search(true, $location.search().q, 1);
                }
            }
        };
    }]);
}());
