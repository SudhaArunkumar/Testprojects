using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InputAppForAPI
{
    public partial class _Default : Page
    {

        List<string> result = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncallapi_Click(object sender, EventArgs e)
        {
            List<APIOutput> input = new List<APIOutput>();
            string jsonString = JsonConvert.SerializeObject(txtarea.Text);

            string URL = "http://localhost:54157/api/values/";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = jsonString.Length;
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(jsonString);
            requestWriter.Close();





            // input.Add(new APIOutput { chunckoutput = txtarea.Text });
            // APIOutput objapi = new APIOutput();
            // objapi.chunckoutput = txtarea.Text;
            //dynamic obj = JsonConvert.SerializeObject(objapi);
          //  string URL = "http://localhost:54157/api/values/" + jsonString;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
           // request.Method = "POST";
           // request.ContentType = "application/json";
            
            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();

                string myObject = response;

                string frist = response.Replace("\\r", "\r");

                string sec = frist.Replace("\\n", "\n");

                Txtlbl.Text = sec.Replace("\r\n", "<br/>");
              //  grdJSON2Grid.DataSource = myObject;
               // grdJSON2Grid.DataBind();

                
                responseReader.Close();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(ex.Message);
            }


        }


    }

    public class APIOutput
    {
        public string chunckoutput { get; set; }

    }
}