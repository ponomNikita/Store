var products = {};


var productsApp = angular.module('productsApp', ['ngRoute']);


productsApp.factory("productsFactory",
    function ($http) {
        return {
            getProducts: function (callback) {
                $http.get("Products/GetContent")
                    .then(callback);
            },
            find : function(id) {
                var result = products.find(function(entity) {
                    return ':' + entity.Data.Id === id;
                });

                return result;
            }
        };
    });


productsApp.controller('productsController',
    function ($scope, productsFactory, $location) {

        if (typeof products[0] === 'undefined') {
            productsFactory.getProducts(function (response) {
                products = response.data;
                $scope.products = response.data;
            });
        } else {
            $scope.products = products;
        }
        console.log($scope.products);
        $scope.go = function (id) {
            $location.path("details:" + id);
        };

    });

productsApp.controller('productDetailController',
    function ($scope, $routeParams, productsFactory) {
        $scope.product = productsFactory.find($routeParams.id);
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
            })
            .when('/details:id',
                {
                    templateUrl: "Products/Details",
                    controller: "productDetailController"
                });
    }
]);