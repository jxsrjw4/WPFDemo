using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace WPFDemo.Common
{
    public class PluginLoaderContext : AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;
        public PluginLoaderContext(string mainAssemblyToLoadPath) : base(isCollectible: true)
        {
            _resolver = new AssemblyDependencyResolver(mainAssemblyToLoadPath);
        }
        protected override Assembly Load(AssemblyName name)
        {
            string assemblyPath = _resolver.ResolveAssemblyToPath(name);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }
            return null;
        }
    }
}
