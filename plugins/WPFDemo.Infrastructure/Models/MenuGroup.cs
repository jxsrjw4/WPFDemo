using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WPFDemo.Infrastructure.Models
{
    public class ModuleGroup
    {
        private IList<BasePluginInfo> _modules = new List<BasePluginInfo>();
        private string _groupIcon = "Default";
        private string _groupName = "";
        private ModuleType _moduleType;
        private int groupid;

        /// <summary>
        /// 子模块集合
        /// </summary>
        public IList<BasePluginInfo> Modules
        {
            get => _modules;
            set { _modules = value; }
        }

        /// <summary>
        /// 模块ICO
        /// </summary>
        public string GroupIcon
        {
            get { return _groupIcon; }
            set { _groupIcon = value;  }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        /// <summary>
        /// 模块类型
        /// </summary>
        public ModuleType ModuleType
        {
            get { return _moduleType; }
            set { _moduleType = value; }
        }

        /// <summary>
        /// 父模块ID
        /// </summary>
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value;}
        }

    }
}
