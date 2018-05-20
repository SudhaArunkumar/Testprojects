using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

using System.Web.Http;

namespace ChunckAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
       // public string Get(string id)
        public string Post([FromBody] dynamic jsonstring)
        {
            int partLength = 25;
            //string id1 =
            //   "Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 " +
            //   "characters. The program should try to break on complete sentences or punctuation marks if possible.  " +
            //   "If a comma or sentence break occurs within 5 characters of the max line length, the line should be broken early.  " +
            //   "The exception to this rule is when the next line will only contain 5 characters.  Redundant whitespace should " +
            //   "not be counted between lines, and any duplicate   spaces should be removed.  " +
            //   "Does this make sense? If not please ask for further clarification, an array containing " +
            //   "the desired outcome has been provided below. Any text beyond this point is not part of the instructions, " +
            //   "it's only here to ensure test converge. Finish line. Aaa asdf asdfjk las, asa.";
            string convert = jsonstring;
            string[] words = convert.Split(' ');
            List<string> list = new List<string>(words);
            //List<APIOutput> outputlist = new List<APIOutput>();

            List<string> outputlist = new List<string>();
            StringBuilder builder = new StringBuilder();
            string part = string.Empty;


           // string part = string.Empty;

            bool sentencebreak = false;
            string tocheck = string.Empty;
            int length = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (part.Length + list[i].Length <= partLength)
                {
                    if (sentencebreak)
                    {
                        part = string.Empty;
                        sentencebreak = false;
                    }
                    part += string.IsNullOrEmpty(part) ? list[i] : " " + list[i];
                    tocheck = list[i];
                    list[i] = string.Empty;
                    if (tocheck.Contains(",") || tocheck.Contains("."))
                    {
                        var poscomma = part.IndexOf(',');
                        var posstop = part.IndexOf('.');
                        if (poscomma >= 21 || posstop >= 21)
                        {
                            foreach (string w in list)
                            {
                                if (!string.IsNullOrEmpty(w))
                                {
                                    length += w.Length;
                                }
                            }
                            if (length > 5)
                            {


                                builder.Append(part).AppendLine();
                                //outputlist.Add(new APIOutput { chunckoutput = part });
                                sentencebreak = true;
                                part = string.Empty;
                            }
                        }
                    }
                }
                else
                {

                    // outputlist.Add(new APIOutput { chunckoutput = part });
                    builder.Append(part).AppendLine();
                    part = list[i];

                }

            }

            // outputlist.Add(new APIOutput { chunckoutput = part });
            builder.Append(part).AppendLine();
            string output = builder.ToString();
            return output;
            

        }

        //public List<string> Get(string para)
        //{
        //    List<string> outputlist = new List<string>();
        //    return outputlist;
        //}

        // POST api/values
       // public String Post([FromBody]string value)
      //  {

       //     return "Sucess";
       // }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class APIOutput
    {
        public string chunckoutput { get; set; }

    }
}