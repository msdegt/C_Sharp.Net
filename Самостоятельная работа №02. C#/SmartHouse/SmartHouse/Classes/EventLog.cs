using System;
using System.IO;

namespace SmartHouse
{
     class EventLog : ILog
    {
        public void EventDevice(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                ("Exception: " + e.Message).ToString();
            }
        }
    }
}
