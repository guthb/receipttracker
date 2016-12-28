//HomeIndexCtrl.js
'use strict';

var module = angular.module("HomeIndex", []);

module.config(function ($routeProvider) {
    $routeProvider.when("/", {

        controller: "ReceiptView",
        url: "/Views/Home/Index.cshtml"
    });

    $routeProvider.otherwise("/");
});