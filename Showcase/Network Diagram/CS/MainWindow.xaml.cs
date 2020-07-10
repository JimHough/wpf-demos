#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Network_Diagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void LoadedEvent(object sender, RoutedEventArgs e)
        {
            ((Diagram.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandViewModel>).RemoveAt(0);
            ((Diagram.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandViewModel>).RemoveAt(1);
#if WPF
            this.LoadDiagramFromFile(@"..\..\PredefinedDiagram\OfficeNetworkDiagram.xml");
#else
            this.LoadDiagramFromFile(@"..\..\..\PredefinedDiagram\OfficeNetworkDiagram.xml");
#endif
        }

        private void LoadDiagramFromFile(string file)
        {
            (Diagram.Nodes as ObservableCollection<CustomNode>).Clear();
            (Diagram.Connectors as ObservableCollection<ConnectorViewModel>).Clear();
            if (Diagram.Info != null)
            {
                using (FileStream fileStream = File.OpenRead(file))
                {
                    (Diagram.Info as IGraphInfo).Load(fileStream);
                }
            }
        }
    }

    //Collection of Symbols
    public class SymbolCollection : ObservableCollection<object>
    {
    }
}