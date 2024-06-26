﻿using Reveal.Sdk;
using Reveal.Sdk.Data;
using Reveal.Sdk.Dom;
using Sandbox.Factories;
using Sandbox.Helpers;
using System;
using System.IO;
using System.Windows;

namespace Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string _dashboardFilePath = Path.Combine(Environment.CurrentDirectory, "Dashboards");

        //readonly string _readFilePath = Path.Combine(_dashboardFilePath, DashboardFileNames.Marketing);
        readonly string _readFilePath = Path.Combine(_dashboardFilePath, "JB - New Infragistics Scorecard Test.rdash");

        readonly string _saveJsonToPath = Path.Combine(_dashboardFilePath, "MyDashboard.json");
        readonly string _saveRdashToPath = Path.Combine(_dashboardFilePath, DashboardFileNames.MyDashboard);

        public MainWindow()
        {
            InitializeComponent();

            //RevealSdkSettings.EnableNewCharts = true;
            RevealSdkSettings.AuthenticationProvider = new AuthenticationProvider();
            RevealSdkSettings.DataSources.RegisterMicrosoftSqlServer().RegisterMicrosoftAnalysisServices();

            _revealView.LinkedDashboardProvider = (string dashboardId, string linkTitle) =>
            {
                var path = Path.Combine(_dashboardFilePath, $"{dashboardId}.rdash");
                if (File.Exists(path))
                    return new RVDashboard(path);

                return null;
            };

            _revealView.DashboardSelectorRequested += RevealView_DashboardSelectorRequested;
        }

        private void RevealView_DashboardSelectorRequested(object sender, DashboardSelectorRequestedEventArgs e)
        {
            e.Callback("Campaigns");
        }

        private async void RevealView_SaveDashboard(object sender, DashboardSaveEventArgs e)
        {
            //var json = _revealView.Dashboard.ExportToJson();
            var path = Path.Combine(Environment.CurrentDirectory, $"Dashboards/{e.Name}.rdash");
            var data = await e.Serialize();
            var json = _revealView.Dashboard.ExportToJson();
            using (var output = File.Open(path, FileMode.Open))
            {
                output.Write(data, 0, data.Length);
            }

            e.SaveFinished();
        }

        private void Load_Dashboard(object sender, RoutedEventArgs e)
        {
            _revealView.Dashboard = new RVDashboard(_readFilePath);
        }

        private void Clear_Dashboard(object sender, RoutedEventArgs e)
        {
            _revealView.Dashboard = new RVDashboard();
        }

        private async void Read_Dashboard(object sender, RoutedEventArgs e)
        {
            var document = RdashDocument.Load(_readFilePath);
            var json = document.ToJsonString();
            _revealView.Dashboard = await RVDashboard.LoadFromJsonAsync(json);
        }

        private async void Create_Dashboard(object sender, RoutedEventArgs e)
        {
            //var document = MarketingDashboard.CreateDashboard();
            //var document = SalesDashboard.CreateDashboard();
            //var document = CampaignsDashboard.CreateDashboard();
            //var document = HealthcareDashboard.CreateDashboard();
            //var document = ManufacturingDashboard.CreateDashboard();
            var document = CustomDashboard.CreateDashboard();
            //var document = RestDataSourceDashboards.CreateDashboard();
            //var document = SqlServerDataSourceDashboards.CreateDashboard();
            //var document = DashboardLinkingDashboard.CreateDashboard();

            //document.Save(_saveRdashToPath);

            var json = document.ToJsonString();
            //json.Save(_saveJsonToPath);
            _revealView.Dashboard = await RVDashboard.LoadFromJsonAsync(json);
        }
    }
}
