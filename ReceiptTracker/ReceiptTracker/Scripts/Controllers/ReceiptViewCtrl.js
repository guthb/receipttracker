//ReceiptViewCtrl.js
'use strict';

angular.module("ReceiptTracker");
app.controller("ReceiptView", function ($scope, $http) {

    var viewModel = this;
    viewModel.title = "Receipts";
    viewModel.User = null;
    
    $scope.init = function (user) {
        viewModel.User = user;
    }

    viewModel.receipts = [];
    

    viewModel.errorMessage = "";
    viewModel.isBusy = false;
    viewModel.errorMessage = "";

    console.log("in receiptview controller");

    //calls the database to return the receipts
    
    viewModel.isBusy = true;
    //$http.get("/api/receipt/user", {params:{ "user" : viewModel.User}})
    console.log ("user from viewmodel ", viewModel.User )
    $http.get("/api/receipt/user/" + viewModel.User)
            .then(function (response) {
                //Success
                console.log("ressponsefromapi", response);
                viewModel.receipts = response.data;
                viewModel.isBusy = false;
            }, function (error) {
                //Failure
                console.log("ressponsefromgetapifailure", response);
                viewModel.errorMessage = "Failed to load data: " + error;          
            })
        .finally(function () {          
        });

 


    //add or edit receipt for purpose
        viewModel.updatePurpose = function (id, newPurpose) {
            console.log("in update purpose function");
            viewModel.isBusy = true;
            $http.put("/api/update",
                        {
                            "id": id,
                            "purpose": newPurpose
                        }
                      )
                .then(function (response) {
                    //Success
                    viewModel.isBusy = false;
                    console.log("response from PUT api ", response);
                   
                }, function (error) {
                    //Failure
                    viewModel.errorMessage = "Failed to save Purpose " + error;
                    viewModel.isBusy = false;
                })

            .finally(function () {
                viewModel.isBusy = false;
            });
        };
});