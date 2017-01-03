//UserModifyCtrl.js
'use strict';

angular.module("ReceiptTracker");
app.controller("UserModify", function ($scope, $http) {


    var uvm = this;  //user view model

    uvm.title = "Modfy User";
    uvm.errorMessage = "";
    uvm.isBusy = false;
    uvm.errorMessage = "";
    uvm.user = [];

    console.log("in user modify controller");

    //calls the database to return the user
    uvm.isBusy = true;
    $http.get("/api/user")
        .then(function (response) {
            //Success
            console.log("ressponsefromuserapi", response);
            uvm.user = response.data;
            viewModel.isBusy = false;
        }, function (error) {
            //Failure
            viewModel.errorMessage = "Failed to load data: " + error;
        })
    .finally(function () {
    });

    



})
