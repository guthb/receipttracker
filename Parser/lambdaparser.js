'use strict';

exports.handler = (event, context, callback) => {

    var http = require('http');
    var data = JSON.stringify({
        'fileName': event.Records[0].ses.mail.messageId,
    });

    var options = {
        host: 'my.host',
        port: '80',
        path: '/my/path',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8',
            'Content-Length': data.length
        }
    };

    var req = http.request(options, function(res) {
        var msg = '';

        res.setEncoding('utf8');
        res.on('data', function(chunk) {
            msg += chunk;
        });
        res.on('end', function() {
            console.log(JSON.parse(msg));
            context.succeed();
        });
    });

    req.write(data);
    req.end();
};
