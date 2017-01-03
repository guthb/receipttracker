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
            uvm.isBusy = false;
        }, function (error) {
            //Failure
            uvm.errorMessage = "Failed to load data: " + error;
        })
    .finally(function () {
    })

    
    //calls the database to delete account for the id of the user
    uvn.deleteUser = function(id) {
        uvm.isBusy = true;
        $http.delete("/api/user", 
                { 
                    "id": id
                }       
            )
            .then(function (response) {
                // success
                uvm.errorMessage = "User has been deleted, you will be logged out";
                
                uvm.isBusy = false;

            }, function(error){
                //failure
                uvm.errorMessage = "Failed to delete user error is: " + error;
            })

    }
})