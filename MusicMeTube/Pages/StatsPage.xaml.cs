﻿using System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.BackgroundTransfer;
using System.IO.IsolatedStorage;
using Resources;

namespace MusicMeTube.Pages
{
    public partial class StatsPage : PhoneApplicationPage
    {
        public StatsPage()
        {
            InitializeComponent();
            Loaded += new System.Windows.RoutedEventHandler(StatsPage_Loaded);
        }

        void StatsPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateUsageData();
        }

        private void UpdateUsageData()
        {
            long avstor = IsolatedStorageFile.GetUserStoreForApplication().AvailableFreeSpace / 1024 / 1024;
            long totald = 0;
            long sessiond = 0;
            IsolatedStorageSettings.ApplicationSettings.TryGetValue("total_data", out totald);
            IsolatedStorageSettings.ApplicationSettings.TryGetValue("session_data", out sessiond);
            totald = totald + (long)0.3 * totald;
            sessiond = sessiond + (long)0.3 * sessiond;
            avstorage.Text = avstor.ToString();
            totaldata.Text = totald.ToString();
            sessiondata.Text = sessiond.ToString();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

    }
}