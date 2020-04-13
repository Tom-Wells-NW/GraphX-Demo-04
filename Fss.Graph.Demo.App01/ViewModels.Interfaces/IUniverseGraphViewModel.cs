using Fss.Graph.Demo.Library.Models;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace Fss.Graph.Demo.App01.ViewModels.Interfaces
{
    public interface IUniverseGraphViewModel
    {
        IList<UniverseEdge> Edges { get; set; }
        string Name { get; set; }
        int UniverseCount { get; set; }
        UniverseGraph UniverseGraph { get; set; }
        UniverseEdge SelectedEdge { get; set; }
        UniverseVertex SelectedVertex { get; set; }
        string SetVerticesIsSelectedCommandName { get; set; }
        RelayCommand SetVerticesIsSelectedCommand { get; }
        string UnsetVerticesIsSelectedCommandName { get; set; }
        RelayCommand UnsetVerticesIsSelectedCommand { get; }
        IList<UniverseVertex> Vertices { get; set; }
    }
}