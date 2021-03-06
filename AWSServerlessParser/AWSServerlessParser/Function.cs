using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System.IO;
using Amazon.S3;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSServerlessParser
{
    public class Functions
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions( )
        {
        }

        public string myTestExample(Stream sesEvent)
        {
            StreamReader sesReader = new StreamReader(sesEvent);

            return sesReader.ReadToEnd();
        }
        


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        //public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        //{
        //    context.Logger.LogLine("Get Request\n");

            

        //    var response = new APIGatewayProxyResponse
        //    {
        //        StatusCode = (int)HttpStatusCode.OK,
        //        Body = "Hello AWS Serverless",
        //        Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
        //    };

        //    return response;
        //}
    }
}
