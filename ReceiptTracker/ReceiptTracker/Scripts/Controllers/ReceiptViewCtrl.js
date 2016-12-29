//ReceiptViewCtrl.js
'use strict';

angular.module("ReceiptTracker");
app.controller("ReceiptView", function ($scope, $http) {

    var viewModel = this;
    viewModel.title = "Receipts";
    
    
    //reset any data already on the scope
    $scope.viewModel = {
        ReceiptCapturedId: "",
        ReceiptType: "",
        Receipt: "",
        Retailer: "",
        PurchaseDate: "",
        S3BuckedId: "",
        Purpose: ""
    };

   
    
    viewModel.receipts = [];
    //viewModel.receipts = [{
    //    ReceiptCapturedId: "1",
    //    ReceiptType: "url",
    //    Receipt: "somthing",
    //    Retailer: "lowes",
    //    PurchaseDate: Date.now,
    //    S3BuckedId: "rrrrrrrrrr",
    //    Purpose: "nothing"
    //}, {
    //    ReceiptCapturedId: "2",
    //    ReceiptType: "html",
    //    Receipt: "somthing2",
    //    Retailer: "homedepot",
    //    PurchaseDate: Date.now,
    //    S3BuckedId: "sssssssss",
    //    Purpose: "something"
    //}];

    viewModel.newReceiptPurpose = {};
    viewModel.errorMessage = "";
    viewModel.isBusy = false;
    viewModel.errorMessage = "";

    console.log("in recieptview controller")

    //calls the database to return the receipts
    //function ReceiptView($scope, $http) {
        viewModel.isBusy = true;
        $http.get("/api/receipt")
            .then(function (response) {
                //Success
                console.log("ressponsefromapi", response);
                angular.copy(response.data, $scope.viewModel.receipts)
                viewModel.isBusy = false;
            }, function (error) {
                //Failure
                viewModel.errorMessage = "Failed to load data: " + error;
                
            })

        .finally(function () {
           
        });

    //}


    //add or edit receipt for purpose
    viewModel.updatePurpose = function () {
        //viewModel.Purpose.push({ Purpose: viewModel.newReceiptPurpose})
        //viewModel.Purpose = {};
        viewModel.isBusy = true;
        $http.post("/api/receipt", viewModel.newReceiptPurpose)
            .then(function (response) {
                //Success
                viewModel.Purpose.push(response.data);
                viewModel.newReceiptPurpose = {};
            }, function (error) {
                //Failure
                viewModel.errorMessage = "Failed to save Purpose";
            })

        .finally(function () {
            viewModel.isBusy = false;
        });

    }

});