using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Huddl_Web
{
    public partial class _Default : Page
    {

        private const string TogglTasksUrl = "https://www.toggl.com/api/v8/tasks.json";
        private const string TogglAuthUrl = "https://www.toggl.com/api/v8/sessions";

        private const string AuthenticationType = "Basic";
        private const string ApiToken = "f24b848ec008a3672bf694b19c3cfb98";
        private const string Password = "api_token";

        public static void Main()
        {
            CookieContainer container = new CookieContainer();
            var authRequest = (HttpWebRequest)HttpWebRequest.Create(TogglAuthUrl);

            authRequest.Credentials = CredentialCache.DefaultCredentials;
            authRequest.Method = "POST";
            authRequest.ContentType = "application/x-www-form-urlencoded";
            authRequest.CookieContainer = container;

            string value = Password + "=" + ApiToken;
            authRequest.ContentLength = value.Length;
            using (StreamWriter writer = new StreamWriter(authRequest.GetRequestStream(), Encoding.ASCII))
            {
                writer.Write(value);
            }

            var authResponse = (HttpWebResponse)authRequest.GetResponse();
            using (var reader = new StreamReader(authResponse.GetResponseStream(), Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
            }

            HttpWebRequest tasksRequest = (HttpWebRequest)HttpWebRequest.Create(TogglTasksUrl);
            tasksRequest.CookieContainer = container;

            var jsonResult = string.Empty;
            var tasksResponse = (HttpWebResponse)tasksRequest.GetResponse();
            using (var reader = new StreamReader(tasksResponse.GetResponseStream(), Encoding.UTF8))
            {
                jsonResult = reader.ReadToEnd();
            }

            var tasks = JsonConvert.DeserializeObject<Task[]>(jsonResult);

            foreach (var task in tasks)
            {
                Console.WriteLine(
                    "{0} - {1}: {2} starting {3:yyyy-MM-dd HH:mm}",
                    task.Project.Name,
                    task.Description,
                    TimeSpan.FromSeconds(task.Duration),
                    task.Start);
            }
        }

        public class Task
        {
            [JsonProperty(PropertyName = "start")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime Start { get; set; }

            [JsonProperty(PropertyName = "stop")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime Stop { get; set; }

            [JsonProperty(PropertyName = "duration")]
            public int Duration { get; set; }

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "project")]
            public Project Project { get; set; }
        }

        public class Project
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "client_project_name")]
            public string Client { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Main();

        }
    }
}



public class Program
{
    
}