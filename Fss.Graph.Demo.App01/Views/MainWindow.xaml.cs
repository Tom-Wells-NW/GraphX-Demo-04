using Fss.Graph.Demo.App01.ViewModels;
using Fss.Graph.Demo.Library.Models;
using GraphX.Common.Enums;
using GraphX.Logic.Algorithms.LayoutAlgorithms;
using GraphX.Logic.Algorithms.OverlapRemoval;
using System.Windows;

namespace Fss.Graph.Demo.App01.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; ;
            //InitializeGraph();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeGraph();
        }

        public void InitializeGraph()
        {
            if (DataContext is MainViewModel)
            {
                var viewModel = (MainViewModel)DataContext;
                var logicCore = new GXLogicCoreUniverse();

                logicCore.DefaultLayoutAlgorithmParams =
                    logicCore.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.KK);

                // Unfortunately to change algo parameters you need to specify params type which is different 
                // for every algorithm.
                ((KKLayoutParameters)logicCore.DefaultLayoutAlgorithmParams).Width = 500;
                ((KKLayoutParameters)logicCore.DefaultLayoutAlgorithmParams).Height = 400;
                ((KKLayoutParameters)logicCore.DefaultLayoutAlgorithmParams).AdjustForGravity = false;

                // This property sets edge routing algorithm that is used to build route paths according to 
                // algorithm logic. For ex., SimpleER algorithm will try to set edge paths around vertices 
                // so no edge will intersect any vertex.
                //// logicCore.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.SimpleER;
                logicCore.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.SimpleER;

                //This property sets vertex overlap removal algorithm.
                //Such algorithms help to arrange vertices in the layout so no one overlaps each other.
                logicCore.DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA;
                //Setup optional params
                logicCore.DefaultOverlapRemovalAlgorithmParams =
                    logicCore.AlgorithmFactory.CreateOverlapRemovalParameters(OverlapRemovalAlgorithmTypeEnum.FSA);
                ((OverlapRemovalParameters)logicCore.DefaultOverlapRemovalAlgorithmParams).HorizontalGap = 20;
                ((OverlapRemovalParameters)logicCore.DefaultOverlapRemovalAlgorithmParams).VerticalGap = 20;

                logicCore.Graph = viewModel.GraphViewModel.UniverseGraph;

                universeGraphArea.LogicCore = logicCore;
                //nodesGraphArea.LogicCore.Graph = viewModel.NodeGraph;
                universeGraphArea.GenerateGraph();
                universeGraphArea.RelayoutGraph(true);
            }
        }
    }
}
