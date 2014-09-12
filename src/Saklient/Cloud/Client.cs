using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Client = Saklient.Cloud.Client;

namespace Saklient.Cloud {
	
	public class Client {
		
		private string token;
		private string secret;
		private string apiRoot;
		private string apiRootSuffix;
		private string authorization;
		public object additionalParams;
		
		public Client(string token, string secret)
		{
			this.apiRoot = "https://secure.sakura.ad.jp/cloud/";
			this.apiRootSuffix = null;
			this.SetAccessKey(token, secret);
		}
		
		public Client CloneInstance()
		{
			Client ret = new Client(this.token, this.secret);
			ret.SetApiRoot(this.apiRoot);
			ret.SetApiRootSuffix(this.apiRootSuffix);
			return ret;
		}
		
		public void SetApiRoot(string url)
		{
			this.apiRoot = url;
		}
		
		public void SetApiRootSuffix(string suffix)
		{
			this.apiRootSuffix = suffix;
		}
		
		public void SetAccessKey(string token, string secret)
		{
			this.token = token;
			this.secret = secret;
			
			this.authorization = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(token+":"+secret));
		}
		
		public object Request(string method, string path, object parameters=null)
		{
			method = method.ToUpper();
			path = (new Regex(@"/$")).Replace(path, "");
			string json = null;
			if (parameters != null) json = Util.EncodeJson(parameters);
			if (path.Substring(0,4) != "http") {
				string urlRoot = this.apiRoot;
				if (this.apiRootSuffix != null) {
					urlRoot += this.apiRootSuffix;
					urlRoot = (new Regex(@"/?$")).Replace(urlRoot, "/");
				}
				path = urlRoot + "api/cloud/1.1" + path;
			}
			if (method == "GET" && json != null) {
				path += "?" + Util.UrlEncode(json);
				json = null;
			}
			//
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
			req.Method = method != "GET" ? "POST" : "GET";
			req.ContentType = "application/x-www-form-urlencoded";
			req.UserAgent = "sacloud-client-cs";
			req.Headers.Add(HttpRequestHeader.Authorization, this.authorization);
			req.Headers.Add("X-Requested-With", "XMLHttpRequest");
			req.Headers.Add("X-Sakura-No-Authenticate-Header", "1");
			req.Headers.Add("X-Sakura-HTTP-Method", method);
			req.Headers.Add("X-Sakura-Request-Format", "json");
			req.Headers.Add("X-Sakura-Response-Format", "json");
			req.Headers.Add("X-Sakura-Error-Level", "warning");
			if (json != null) {
				req.ContentType = "application/json";
				req.ContentLength = json.Length;
				Stream stream = req.GetRequestStream();
				StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("UTF-8"));
				writer.Write(json, 0, json.Length);
				writer.Flush();
				writer.Dispose();
				stream.Close();
			}
			
			System.Net.WebResponse response = req.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
			string dataSrc = reader.ReadToEnd();
			reader.Close();
			object data = Util.DecodeJson(dataSrc);
			return data;
			
		}
		
	}
	
}
