using System.Windows.Controls;
using Interfaces;
using System.ComponentModel.Composition;

namespace LocalSeriesAddin
{
    [Export(typeof (ITabAddin))]
    public class LocalSeries : ITabAddin
    {
        public void Initialisierung(TabControl tabControl)
        {
            TabItem tabItem = new TabItem
            {
                Header = "LocalSeriesAddin"
            };
            tabControl.Items.Add(tabItem);
        }
    }
}
