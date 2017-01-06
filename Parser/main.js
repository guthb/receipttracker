var MailParser = require("mailparser").MailParser;
var mailparser = new MailParser();

var AWS = require('aws-sdk');
var s3 = new AWS.S3();

var bucketName = 'guthbtestemail';

//sample JSON

/*{
   "receiptCapturedId": 1,
   "receiptType": "html",
   "receipt": "html",
   "retailer": "Test1",
   "purchaseDate": "2017-01-05T00:00:00",
   "s3BuckedId": "1",
   "purpose": "test",
   "userId": 1
 }*/


mailparser.on("end", function(mail_object){
    console.log("Subject:", mail_object.subject);
    var receipt = {};
    receipt.receiptCapturedId = "";
    receipt.receiptType = "html";
    receipt.retailer = mail_object.from;
    receipt.purchaseDate = new Date();
    receipt.s3BuckedId = 1;
    receipt.purpose = "unknown"



});

exports.handler = function(event, context, callback) {
    console.log('Process email');

    var sesNotification = event.Records[0].ses;
    console.log("SES Notification:\n", JSON.stringify(sesNotification, null, 2));

    // Retrieve the email from your bucket
    s3.getObject({
            Bucket: bucketName,
            Key: 'rawemail/' + sesNotification.mail.messageId
        }, function(err, data) {
            if (err) {
                console.log(err, err.stack);
                callback(err);
            } else {
                console.log("Raw email:\n" + data.Body);

                // Custom email processing goes here

                // send the email source to the parser
                mailparser.write(data.Body);
                mailparser.end();

                callback(null, null);
            }
        });
};
