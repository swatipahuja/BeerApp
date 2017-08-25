(function () {
	'use strict';

	var appServices = angular.module('app.services', []);
	appServices.factory('searchService', ['$http', '$q', function ($http, $q) {
		//var API_KEY = '34413dca2e90874d297dc41d77bb527a';
		var BASE_URL = 'http://localhost:49164/';
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
			var url = BASE_URL + SERVICE + '/getBeers?' + searchQueryParam + "&";
			if (page != undefined || page != null) url += pageNumberParam + "&";
			if (glasswareId != undefined || glasswareId != null) url += glasswareParam + "&";
			if (page != undefined || page != null) url += categoryParam;
			//var url = 'http://api.brewerydb.com/v2/search?type=beer&q=' + query + '&p=' + page + '&key=34413dca2e90874d297dc41d77bb527a';
			var deferred = $q.defer();
			$http.get(url).success(function (resp) {
				deferred.resolve(JSON.parse(resp));
				//deferred.resolve(resp);
			}).error(function () {
				deferred.resolve(-1);
			});
			return deferred.promise;
		}

		function getGlasswares() {
			var deferred = $q.defer();
			var url = BASE_URL + SERVICE + '/getGlasswareFilterData';
			//var url = 'http://api.brewerydb.com/v2/glassware?key=34413dca2e90874d297dc41d77bb527a';
			$http.get(url).success(function (resp) {
				console.log("glass");
				console.log(resp);
				deferred.resolve(JSON.parse(resp));
				//deferred.resolve(resp);
			}).error(function () {
				deferred.resolve(-1);
			});
			return deferred.promise;
		}

		function getCategories() {
			var deferred = $q.defer();
			var url = BASE_URL + SERVICE + '/getCategoryFilterData';
			//var url = 'http://api.brewerydb.com/v2/categories?key=34413dca2e90874d297dc41d77bb527a';
			$http.get(url).success(function (resp) {
				console.log("categoies");
				console.log(resp);
				deferred.resolve(JSON.parse(resp));
				//deferred.resolve(resp);
			}).error(function () {
				deferred.resolve(-1);
			});
			return deferred.promise;
		}
		return searchService;
	}]);
}());
