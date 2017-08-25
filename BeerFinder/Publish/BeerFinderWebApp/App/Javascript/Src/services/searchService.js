(function () {
	'use strict';

	var appServices = angular.module('app.services', []);
	appServices.factory('searchService', ['$http', '$q', function ($http, $q) {
		//var API_KEY = '34413dca2e90874d297dc41d77bb527a';
		var BASE_URL = 'http://localhost:49165/';
		var SERVICE = 'BeerFinderService.svc'
		//var maxResults = 20;
		var modalData = null;
		var searchService = {
			searchBeers: searchBeers,
			setData: setData,
			getData: getData,
			getGlasswares: getGlasswares,
			getCategories: getCategories
		};

		function setData(data) {
			modalData = data;
		}

		function getData() {
			return modalData;
		}


		function searchBeers(query, page, glasswareId, categoryId) {
			var searchQueryParam = "searchQuery=" + query;
			var pageNumberParam = "pageNumber=" + page;
			var glasswareParam = "glasswareId=" + glasswareId;
			var categoryParam = "categoryId=" + categoryId;
			console.log(categoryId);
			var url = BASE_URL + SERVICE + '/getBeers?' + searchQueryParam + "&";
			if (page != undefined || page != null) url += pageNumberParam + "&";
			if (glasswareId != undefined || glasswareId != null) url += glasswareParam + "&";

			if (categoryId != undefined || categoryId != null) url += categoryParam;
			console.log(url);
			var deferred = $q.defer();
			$http.get(url).success(function (resp) {
				deferred.resolve(JSON.parse(resp));
			}).error(function () {
				deferred.resolve(-1);
			});
			return deferred.promise;
		}

		function getGlasswares() {
			var deferred = $q.defer();
			var url = BASE_URL + SERVICE + '/getGlasswareFilterData';
			$http.get(url).success(function (resp) {
				deferred.resolve(JSON.parse(resp));
			}).error(function () {
				deferred.resolve(-1);
			});
			return deferred.promise;
		}

		function getCategories() {
			var deferred = $q.defer();
			var url = BASE_URL + SERVICE + '/getCategoryFilterData';
			$http.get(url).success(function (resp) {
				deferred.resolve(JSON.parse(resp));
			}).error(function () {
				deferred.resolve(-1);
			});
			return deferred.promise;
		}
		return searchService;
	}]);
}());
