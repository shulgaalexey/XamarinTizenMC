using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using windows.ui.core;

using Xamarin.Forms;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;


using System.Net;
using System.IO;

namespace XamarinTizenMC
{
    public class App : Application
    {
        public App()
        {
            var azureStatus = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Azure status"
            };
            var azureExtraStatus = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Azure extra-status"
            };

            var buttonIncreaseLogLevel = new Button
            {
                Text = "Increase Log Level",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonIncreaseLogLevel.Clicked += (object sender, EventArgs e) =>
            {
                azureStatus.Text = "Increasing Log Level...";
                MobileCenter.LogLevel = LogLevel.Debug;
                azureStatus.Text = "Increasing Log Level...Done: " + MobileCenter.LogLevel;
                azureExtraStatus.Text = "ok";
            };

            var buttonPrintLogLevel = new Button
            {
                Text = "Print Log Level",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonPrintLogLevel.Clicked += (object sender, EventArgs e) =>
            {
                azureStatus.Text = "Log Level is : " + MobileCenter.LogLevel;
                azureExtraStatus.Text = "ok";
            };

            var buttonGetIID = new Button
            {
                Text = "Get Install ID",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonGetIID.Clicked += (object sender, EventArgs e) =>
            {
                azureStatus.Text = "Getting IID...";
                try
                {
                    System.Guid installId = (System.Guid)MobileCenter.InstallId;
                    azureStatus.Text = "Getting IID...Done: " + installId.ToString();
                }
                catch (Exception exc)
                {
                    azureStatus.Text = "Getting IID EXCEPTION: " + exc.GetType();
                    azureExtraStatus.Text = exc.Message;
                }
            };

            var buttonStart = new Button
            {
                Text = "Configure & Start Me",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonStart.Clicked += (object sender, EventArgs e) =>
            {
                azureStatus.Text = "Starting...";
                try
                {
                    //MobileCenter.Start("7532674f-eb96-401e-ab2b-0f296db3a71e" // HelloMobileCenter
                    MobileCenter.Start("54aa94d6-753f-40c3-b3f7-5af2767c7a42" // HelloTizen
                    //MobileCenter.Start("209af5d5-8faf-4ec2-bafa-5d0e4bb38109" // HelloTizen2
                        , typeof(Analytics)
                        //, typeof(Crashes)
                        );
                    azureStatus.Text = "Starting...Done";
                    azureExtraStatus.Text = "Log level changed to: " + MobileCenter.LogLevel;

                } catch (Exception exc)
                {
                    azureStatus.Text = "Starting EXCEPTION: " + exc.GetType();
                    azureExtraStatus.Text = exc.Message;
                }
            };


            var buttonConfigure = new Button
            {
                Text = "Configure",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonConfigure.Clicked += (object sender, EventArgs e) =>
            {
                azureStatus.Text = "Configuring...";
                try
                {
                    //MobileCenter.Configure("209af5d5-8faf-4ec2-bafa-5d0e4bb38109");
                    MobileCenter.Configure("54aa94d6-753f-40c3-b3f7-5af2767c7a42");
                    azureStatus.Text = "Configuring ...Done";
                    azureExtraStatus.Text = "Log level: " + MobileCenter.LogLevel;

                }
                catch (Exception exc)
                {
                    azureStatus.Text = "Configuring EXCEPTION: " + exc.GetType();
                    azureExtraStatus.Text = exc.Message;
                }
            };


            var buttonStart2 = new Button
            {
                Text = "Start Analytics",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonStart2.Clicked += (object sender, EventArgs e) =>
            {
                azureStatus.Text = "Starting...";
                try
                {
                    MobileCenter.Start(typeof(Analytics)
                        //, typeof(Crashes)
                        );
                    azureStatus.Text = "Starting...Done";
                    azureExtraStatus.Text = "Log level: " + MobileCenter.LogLevel;

                }
                catch (Exception exc)
                {
                    azureStatus.Text = "Starting EXCEPTION: " + exc.GetType();
                    azureExtraStatus.Text = exc.Message;
                }
            };



            var buttonStartCrashes = new Button
            {
                Text = "Start Crashes",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonStartCrashes.Clicked += (object sender, EventArgs e) =>
            {
                azureStatus.Text = "Starting...";
                try
                {
                    MobileCenter.Start(typeof(Crashes));
                    azureStatus.Text = "Starting...Done";
                    azureExtraStatus.Text = "Log level: " + MobileCenter.LogLevel;

                }
                catch (Exception exc)
                {
                    azureStatus.Text = "Starting EXCEPTION: " + exc.GetType();
                    azureExtraStatus.Text = exc.Message;
                }
            };


            var buttonTrackCustomEvent = new Button
            {
                Text = "Track Event",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonTrackCustomEvent.Clicked += (object sender, EventArgs e) =>
            {
                try
                {
                    azureStatus.Text = "Analytics.TrackEvent...";
                    Analytics.TrackEvent("Video clicked", new Dictionary<string, string> { { "at", DateTime.Now.ToString("h:mm:ss tt") }, { "Category", "Music" }, { "FileName", "favorite.avi" } });
                    azureStatus.Text = "Analytics.TrackEvent...Done";
                    azureExtraStatus.Text = "Log level changed to: " + MobileCenter.LogLevel;
                } catch (Exception exc)
                {
                    azureStatus.Text = "Analytics.TrackEvent EXCEPTION " + exc.GetType();
                    azureExtraStatus.Text = exc.Message;
                }
            };


            var buttonGenerateCrash = new Button
            {
                Text = "Generate Test Crash",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonGenerateCrash.Clicked += (object sender, EventArgs e) =>
            {

                Crashes.GenerateTestCrash();

            };


            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        azureStatus,
                        buttonIncreaseLogLevel,
                        buttonPrintLogLevel,
                        buttonGetIID,
                        buttonStart,
                        buttonConfigure,
                        buttonStart2,
                        buttonStartCrashes,
                        buttonTrackCustomEvent,
                        buttonGenerateCrash,
                        azureExtraStatus
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //MobileCenter.Start("54aa94d6-753f-40c3-b3f7-5af2767c7a42",
            //        typeof(Analytics), typeof(Crashes));

            //MobileCenter.Configure("54aa94d6-753f-40c3-b3f7-5af2767c7a42");
            //MobileCenter.Start(typeof(Analytics), typeof(Crashes));

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
