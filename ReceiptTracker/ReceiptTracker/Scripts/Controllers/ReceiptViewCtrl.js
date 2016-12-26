'use strict';


app.controller("ReceiptView", function($scope, $http, $rootScope){

    $scope.title = "Reciepts";
    $scope.display = [];
    $rootscope.selecteReciept = {};
    $rootscope.EditMode = false;

    $scope.newReceipt = {
        ReceiptCapturedId: "",
        ReceiptType: "",
        Receipt: "",
        Retailer: "",
        PurchaseDate: "",
        S3BuckedId: "",
        Purpose: ""
    };





    //calls the database to return the receipts
    $scope.name = function () {

    };



    //edits receipt for purpose

    $scope.EditReceiptPurpose = function (_recieptPurpose) {

        $rootScope.selecteReciept = _recieptPurpose;
        //location or API call

    };



});



