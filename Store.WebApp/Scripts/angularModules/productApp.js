var products = {};


var productsApp = angular.module('productsApp', ['ngRoute', 'ui.bootstrap']);


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

        $scope.go = function (id) {
            $location.path("details:" + id);
        };

    });

productsApp.controller('productDetailController',
    function ($scope, $routeParams, productsFactory) {
        var product = $scope.product = productsFactory.find($routeParams.id);

        $scope.noWrapSlides = false;
        $scope.active = 0;
        var slides = $scope.slides = [];
        var currIndex = 0;

        $scope.addSlide = function (index) {
             slides.push({
                image: product.Attachments[index].Path,
                id: currIndex++
            });
        };

        for (var i = 0; i < product.Attachments.length; i++) {
            $scope.addSlide(i);
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
            })
            .when('/details:id',
                {
                    templateUrl: "Products/Details",
                    controller: "productDetailController"
                });
    }
]);