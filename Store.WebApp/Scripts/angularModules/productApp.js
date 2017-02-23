var products = {};
var loginModal;

var loginModel = {
    isAuthorize: null,
    userName: ""
}

var productsApp = angular.module('productsApp', ['ngRoute', 'ui.bootstrap', 'blockUI', 'ngSanitize']);


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

productsApp.factory("accountFactory",
    function ($http) {
        return {
            SetupLoginModel: function () {
                $http.get("Account/IsAuthorized")
                    .then(function (response) {
                        loginModel.isAuthorize = response.data.IsAuthorized;
                        loginModel.userName = response.data.UserName;
                    });
            }
        };
    });


productsApp.controller('productsController',
    function ($scope, productsFactory, $location, blockUI) {

        var blockProducts = blockUI.instances.get('productBlock');

        if (typeof products[0] === 'undefined') {
            blockProducts.start();

            productsFactory.getProducts(function (response) {
                products = response.data;
                $scope.products = response.data;

                blockProducts.stop();
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

productsApp.controller('accountController', function ($scope, $uibModal, $log, $document, $http, accountFactory) {

    accountFactory.SetupLoginModel();

    $scope.animationsEnabled = true;

    $scope.open = function (size, parentSelector) {
        var parentElem = parentSelector ?
          angular.element($document[0].querySelector('.modal-demo ' + parentSelector)) : undefined;
        loginModal = $uibModal.open({
            animation: $scope.animationsEnabled,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: 'Account/Login',
            controller: 'accountController',
            size: size,
            appendTo: parentElem
        });

        loginModal.opened.then(function () {
            
        });

        loginModal.result.then(function () {
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.Login = function () {
        $http.post('/Account/Login', $scope.model)
            .then(function (data, status, headers, config) {
                    if (data.data.Status !== 0) {
                        $("#AuthorizationMessages").html("<span>Неверный адрес электронной почты или пароль</span>");
                    } else {
                        loginModel.userName = data.data.UserName;
                        loginModel.isAuthorize = true;
                        loginModal.close();
                    }
                })
            .catch(function (data, status, header, config) {
                alert(data);
            });
    };

    $scope.Logout = function () {
        $http.get('/Account/Logout')
            .then(function (data, status, headers, config) {
                accountFactory.SetupLoginModel();
            })
            .catch(function (data, status, header, config) {
                alert(data);
            });
    };

    $scope.loginModel = loginModel;

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

/**
 * angular block ui config
 */
productsApp.config(function (blockUIConfig) {
    blockUIConfig.message = 'Загрузка...';

});

