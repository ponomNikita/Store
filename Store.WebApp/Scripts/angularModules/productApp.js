var products = {};


var productsApp = angular.module('productsApp', ['ngRoute']);


productsApp.factory("productsFactory",
    function ($http) {
        return {
            getProducts: function (callback) {
                $http.get("Products/GetContent")
                    .then(callback);
            }
        };
    });


productsApp.controller('productsController',
    function ($scope, productsFactory) {

        if (typeof products[0] === 'undefined') {
            productsFactory.getProducts(function (response) {
                products = response.data;
                $scope.products = response.data;
            });
        } else {
            $scope.products = products;
        }
    });

productsApp.config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {
        //$locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('!');

        $routeProvider
            .when('/',
            {
                templateUrl: "Products/Content",
                controller: "productsController"
            });
    }
]);