﻿using Fss.Graph.Demo.App01.Helpers;
using Fss.Graph.Demo.App01.ViewModels.Interfaces;
using Fss.Graph.Demo.Library.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fss.Graph.Demo.App01.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IUniverseGraphViewModel graphViewModel) 
        {
            GraphViewModel = graphViewModel;
        }

        private void InitializeCommands()
        {
            var viewUniverseDataRelayCommand = new RelayCommand(() => LoadUniverseData(), () => HasUniverseData);
            ViewUniverseDataCommand = new CommandViewModelBase<RelayCommand>("View Universe Data", viewUniverseDataRelayCommand);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }


        private IUniverseGraphViewModel _graphViewModel;
        public IUniverseGraphViewModel GraphViewModel
        {
            get { return _graphViewModel; }
            set { Set(ref _graphViewModel, value); }
        }


        public bool HasUniverseData { get { return true; } }
        public void LoadUniverseData()
        {

        }

        public CommandViewModelBase<RelayCommand> ViewUniverseDataCommand { get; set; }
    }
}
