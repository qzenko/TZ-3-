using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ds.test.impl
{
    public interface IPlugin
    {
        string PluginName { get; }
        string Version { get; }
        //Image Image { get; }
        string Description { get; }
        int Run(int input1, int input2);
    }

    public static class Plugins
    {
        private static List<IPlugin> _plugins = new List<IPlugin>();

        public static int PluginsCount => _plugins.Count;

        public static string[] GetPluginNames => _plugins.Select(p => p.PluginName).ToArray();

        public static IPlugin GetPlugin(string pluginName)
        {
            return _plugins.FirstOrDefault(p => p.PluginName == pluginName);
        }

        public static void RegisterPlugin(IPlugin plugin)
        {
            _plugins.Add(plugin);
        }
    }

    abstract class BasePlugin : IPlugin
    {
        public abstract string PluginName { get; }
        public abstract string Version { get; }
        //public abstract Image Image { get; }
        public abstract string Description { get; }
        public abstract int Run(int input1, int input2);
    }

    // Пример реализации конкретного плагина
    class MyMathPlugin : BasePlugin
    {
        public override string PluginName => "MyMathPlugin";
        public override string Version => "1.0";
        //public override Image Image => null; 
        public override string Description => "Предоставляет базовые математические операции.";

        public override int Run(int input1, int input2)
        {
            return input1 + input2; // Пример: Сложение
        }
    }

    // Дополнительные плагины могут быть реализованы аналогичным образом

    // Использование:
    // MyMathPlugin mathPlugin = new MyMathPlugin();
    // Plugins.RegisterPlugin(mathPlugin);
}