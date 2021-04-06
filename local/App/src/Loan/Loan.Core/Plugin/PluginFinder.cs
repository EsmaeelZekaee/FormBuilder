namespace Loan.Core.Plugin
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class PluginFinder
    {
        public PluginFinder()
        {

        }

        public IEnumerable<IPlugin> FindAllPlugins()
        {
            var root = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plugins");
            if (Directory.Exists(root))
            {
                var dlls = Directory.GetFiles(root, "*.dll");
                foreach (var item in dlls)
                {
                    var q = Assembly.LoadFile(item).GetTypes().FirstOrDefault(x => x.IsAssignableTo(typeof(IPlugin)));
                    if (q == null)
                        continue;
                    yield return (IPlugin)System.Activator.CreateInstanceFrom(item, q.FullName).Unwrap();
                }
            }
        }
    }
}