using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Http.Headers;

namespace mockServer.Controllers
{
    public class HttpcodeController : ApiController
    {
        // GET: api/Httpcode
        public String errorMessage = "Please input valid http status code like 200, 401, 403, 500";
        public IEnumerable<string> Get()
        {
            return new string[] { errorMessage };
        }

        public HttpResponseMessage Get(string id, string name)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            //extract request
            string head = Request.Headers.ToString();
            string headertext = "Get Request header - Status code is " + id;
            String logtime = GetTimestamp(DateTime.Now);
            string requesturl = Request.RequestUri.ToString();
            //Get parameters as KeyValuePair
            var parameters = Request.GetQueryNameValuePairs();
            //Show parameters
            foreach (var p in parameters)
            {
                string key = p.Key;
                string value = p.Value;
                //todo: we can compare the parameters we can just look at the url in the log. But we can get the value and key here anyway.
            }

            try
            {
                int statusid = Convert.ToInt32(id);
                response.StatusCode = (HttpStatusCode)statusid;
                WriteLogFile(logtime + " " + headertext + " Sending URL is: " + requesturl, name);
                WriteLogFile(head, name);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
                WriteLogFile(logtime + " " + errorMessage + " but your input is " + id + " Sending URL is: " + requesturl, name);
            }

            string path = @"D:\" + name + ".log";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            //stream.Close();
            return response;
            /*
            catch (Exception ex)
            {
                response.StatusCode = (HttpStatusCode)200;
                response.Content = new StringContent(statusid.ToString() + " is not standard http status code");
                //
                return response;
            }
            */

        }

        private string GetTimestamp(DateTime now)
        {
            string nowtime = now.ToString();
            return nowtime;
        }


        // POST: api/Httpcode
        public HttpResponseMessage Post(string id, string name)
        {
            byte[] body = Request.Content.ReadAsByteArrayAsync().Result;

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(body);
            //extract request
            string head = Request.Headers.ToString();
            string headertext = "Post Request header - Status code is " + id;
            String logtime = GetTimestamp(DateTime.Now);
            string requestbody = System.Text.Encoding.Default.GetString(body);
            try
            {
                int statusid = Convert.ToInt32(id);
                response.StatusCode = (HttpStatusCode)statusid;
                WriteLogFile(headertext + " " + logtime, name);
                WriteLogFile(head, name);
                string bodytext = "Post body is below";
                WriteLogFile(bodytext, name);
                WriteLogFile(requestbody, name);

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
                WriteLogFile(errorMessage + " but your input is " + id + " " + logtime, name);

            }
            string path = @"D:\" + name + ".log";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            //stream.Close();
            return response;
        }

        // PUT: api/Httpcode/5
        public HttpResponseMessage Put(string id, string name)
        {
            byte[] body = Request.Content.ReadAsByteArrayAsync().Result;

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(body);
            //extract request
            string head = Request.Headers.ToString();
            string headertext = "Put Request header - Status code is " + id;
            String logtime = GetTimestamp(DateTime.Now);
            string requestbody = System.Text.Encoding.Default.GetString(body);
            try
            {
                int statusid = Convert.ToInt32(id);
                response.StatusCode = (HttpStatusCode)statusid;
                WriteLogFile(headertext + " " + logtime, name);
                WriteLogFile(head, name);
                string bodytext = "Put body is below";
                WriteLogFile(bodytext, name);
                WriteLogFile(requestbody, name);

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
                WriteLogFile(errorMessage + " but your input is " + id + " " + logtime, name);
            }
            string path = @"D:\" + name + ".log";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            //stream.Close();
            return response;
        }

        // DELETE: api/Httpcode/5
        public HttpResponseMessage Delete(string id, string name)
        {
            byte[] body = Request.Content.ReadAsByteArrayAsync().Result;

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(body);
            //extract request
            string head = Request.Headers.ToString();
            string headertext = "Delete Request header - Status code is " + id;
            String logtime = GetTimestamp(DateTime.Now);
            string requestbody = System.Text.Encoding.Default.GetString(body);
            try
            {
                int statusid = Convert.ToInt32(id);
                if (statusid == 666)
                {
                    File.Delete(@"D:\" + name + ".log");
                }
                response.StatusCode = (HttpStatusCode)statusid;
                WriteLogFile(headertext + " " + logtime, name);
                WriteLogFile(head, name);
                string bodytext = "Delete body is below";
                WriteLogFile(bodytext, name);
                WriteLogFile(requestbody, name);

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
                WriteLogFile(errorMessage + " but your input is " + id + " " + logtime, name);
            }
            string path = @"D:\" + name + ".log";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            //stream.Close();
            return response;
        }

        public HttpResponseMessage Patch(string id, string name)
        {
            byte[] body = Request.Content.ReadAsByteArrayAsync().Result;

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(body);
            //extract request
            string head = Request.Headers.ToString();
            string headertext = "Patch Request header - Status code is " + id;
            String logtime = GetTimestamp(DateTime.Now);
            string requestbody = System.Text.Encoding.Default.GetString(body);
            try
            {
                int statusid = Convert.ToInt32(id);
                response.StatusCode = (HttpStatusCode)statusid;
                WriteLogFile(headertext + " " + logtime, name);
                WriteLogFile(head, name);
                string bodytext = "Patch body is below";
                WriteLogFile(bodytext, name);
                WriteLogFile(requestbody, name);

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
                WriteLogFile(errorMessage + " but your input is " + id + " " + logtime, name);
            }
            string path = @"D:\" + name + ".log";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            //stream.Close();
            return response;
        }
        public void WriteLogFile(string log, string username)
        {
            string path = @"D:\" + username + ".log";
            if (!File.Exists(path))
            {
                var myfile = File.Create(path);
                myfile.Close();
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine("everything begins here");
                string linecutter = "**********************************************************************************************************************************************************************";
                tw.WriteLine(linecutter);
                tw.WriteLine(log);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    string linecutter = "**********************************************************************************************************************************************************************";
                    tw.WriteLine(linecutter);
                    tw.WriteLine(log);
                }
            }

        }


    }
}
