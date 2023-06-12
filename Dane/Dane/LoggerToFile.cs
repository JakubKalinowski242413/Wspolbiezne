using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class LoggerToFile
    {
        readonly static string _filePath = "collision_logs_"+DateTime.Now.Hour.ToString()+"_"+ DateTime.Now.Minute.ToString() + "_" +
            DateTime.Now.Second.ToString() + ".txt";
        TextWriter _writer = new StreamWriter(_filePath, true);
        ArrayList _list = new ArrayList();

        public void clearLogFile()
        {
            _writer.Close();
            lock (this)
            {
                File.WriteAllText(_filePath, String.Empty);
            }
            _writer = new StreamWriter(_filePath, true);
        }

        public void writeLogs(String singleLog)
        {

            if (Monitor.TryEnter(this))
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    _writer.WriteLine(_list[i]);
                }
                _list.Clear();
                _writer.WriteLine(singleLog);
                _writer.Flush();
                Monitor.Exit(this);
            }
            else
            {
                _list.Add(singleLog);
            }
        }
    }

}

