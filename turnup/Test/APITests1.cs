using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace turnup.Test
{
    class APITests1
    {
        [Test]
        public void PostRequest()
        {
            var client = new RestClient("https://jsonblob.com/api/jsonBlob");

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            //request.AddBody("{\"people\":[\"bill\",\"steve\",\"bob\"]}");
            request.AddParameter("application/json", "{\"people\":[\"name1tests\", \"name2sdas\"]}", ParameterType.RequestBody);

            var response = client.Execute(request);
            Console.WriteLine("response.ResponseStatus " + response.ResponseStatus);

            foreach(var header in response.Headers)
                Console.WriteLine(header.Name + " " + header.Value);
            Console.WriteLine("\n response.StatusCode " + response.StatusCode);
            // Asserting the Status Code = 201, Created
            Assert.AreEqual(HttpStatusCode.Created,response.StatusCode);                       
        }

        [Test]
        public void GetRequest()
        {
            var client = new RestClient("https://jsonblob.com/api/jsonBlob");

            var request = new RestRequest("/df998870-6ca7-11e9-a526-5dcca1c1752a", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);

            Console.WriteLine("response.StatusCode " + response.StatusCode);

            //Assertion 
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void PutRequest()
        {
            var client = new RestClient("https://jsonblob.com/api/jsonBlob");
            var request = new RestRequest("/df998870-6ca7-11e9-a526-5dcca1c1752a", Method.PUT);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", "{\"Students\": [\"Ava\",\"Shanta\",\"harpeet\",\"minna\",\"maryann\",\"raj\"]}", ParameterType.RequestBody);

            var response = client.Execute(request);

            //Assertion 
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void DeleteRequest()
        {
            var client = new RestClient("https://jsonblob.com/api/jsonBlob");
            var request = new RestRequest("/df998870-6ca7-11e9-a526-5dcca1c1752a", Method.DELETE);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);

            //Assertion 
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);            

        }
    }
}
