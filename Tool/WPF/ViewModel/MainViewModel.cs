using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Controls;
using System.Windows.Documents;
using GalaSoft.MvvmLight;
using Interfaces;

namespace WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        [ImportMany(typeof(ITabAddin))]
        private List<ITabAddin> _tabAddins = null; 
        
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            

            DirectoryCatalog catalog = new DirectoryCatalog(".");
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            foreach (ITabAddin tabAddin in _tabAddins)
            {
                tabAddin.Initialisierung(TabControl);
            }

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public TabControl TabControl { get; set; }
    }
}