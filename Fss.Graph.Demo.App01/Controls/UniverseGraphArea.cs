﻿using System;
using System.Windows;
using Fss.Graph.Demo.Library.Models;
using GraphX.Controls;
using QuickGraph;

namespace Fss.Graph.Demo.App01.Controls
{
    //Layout visual class
    public class UniverseGraphArea : GraphArea<UniverseVertex, UniverseEdge, BidirectionalGraph<UniverseVertex, UniverseEdge>>
    {
        public UniverseGraphArea() : base()
        {
            this.SourceUpdated += UniverseGraphArea_SourceUpdated;
            AutoAssignMissingDataId = false;
        }

        private void UniverseGraphArea_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            Console.WriteLine("UniverseGraphArea_SourceUpdated...");
            HasGraphData = true;
        }

        

        public static readonly DependencyProperty HasGraphDataProperty = DependencyProperty.Register
            (
                "HasGraphData", typeof(Boolean),
                typeof(UniverseGraphArea)
            );

        public bool HasGraphData
        {
            get { return (bool)GetValue(HasGraphDataProperty); }
            set { SetValue(HasGraphDataProperty, value); }
        }
    }
}
