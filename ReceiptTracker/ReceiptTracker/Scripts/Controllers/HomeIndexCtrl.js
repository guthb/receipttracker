//HomeIndexCtrl.js
'use strict';

var module = angular.module("HomeIndex", []);

module.config(function ($routeProvider) {
    $routeProvider.when("/", {

        controller: "HomeIndex",
        url: "/Views/Home/Index.cshtml"
    });

    $routeProvider.otherwise("/");
});