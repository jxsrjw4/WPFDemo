using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WPFDemo.Infrastructure.ServerInteraction
{
    public interface IPlugin
    {
        public void PreViewCommand(string command);

        public void SendToStatusBar(string Message);
        public void ChangeProgressBar(int Maximum, int Value);
        public DataSet GetDataSetWithSQLString(string SQLString);

    }
}
