using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace PCTracker
{
    /// <summary>
    /// IP Tracker keep tracks the global IP of laptop
    /// </summary>
    public class IPTracker : Tracker
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Interval">Interval of IP tracking</param>
        public IPTracker(int Interval)
            : base(Interval)
        { }

        /// <summary>
        /// Timer Action
        /// </summary>
        protected override void TimerAction()
        {
            Console.WriteLine(DateTime.Now + " : ");
            string pub_ip = GetPublicIP();
            IPAddress PublicIP;
            if (IPAddress.TryParse(pub_ip, out PublicIP))
            {
                Console.WriteLine("\tIP:" + PublicIP.ToString());
            }
        }

        /// <summary>
        /// Retreive public ip address
        /// </summary>
        /// <returns></returns>
        string GetPublicIP()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(@"http://checkip.dyndns.org");
                string publicIPAddress;
                request.Method = "GET";
                using (WebResponse response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        publicIPAddress = reader.ReadToEnd();
                    }
                }
                string toReturn = publicIPAddress.Replace("\n", "");
                return toReturn.Substring(76).Replace("</body></html>", "").Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
