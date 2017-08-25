(function () {
	'use strict';

	angular.module('templates', []);

	var app = angular.module('app', [
		'ngRoute',
		'ngAnimate',
		'templates',
		'app.services',
		'app.directives',
		'app.controllers',
		'ui.bootstrap',
		'bw.paging'
	]);

	app.config(['$routeProvider', function ($routeProvider) {
		$routeProvider
			.when('/', {
				templateUrl: 'home.html'
			}).otherwise({ redirectTo: '/' });
	}]);
}());
