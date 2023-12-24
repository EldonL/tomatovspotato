using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;
using Firebase.Extensions;
using Firebase;

namespace UnityFirebaseLearning
{
    public class FirebaseAnalyticsLearning : MonoBehaviour
    {
       // private Firebase.FirebaseApp app;
        // Start is called before the first frame update
        void Start()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                var app = FirebaseApp.DefaultInstance;
            });
            //Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            //    var dependencyStatus = task.Result;
            //    if (dependencyStatus == Firebase.DependencyStatus.Available)
            //    {
            //        // Create and hold a reference to your FirebaseApp,
            //        // where app is a Firebase.FirebaseApp property of your application class.
            //        app = Firebase.FirebaseApp.DefaultInstance;
            //        Debug.Log($"firebase dependency availalbe: {dependencyStatus}");
            //        // Set a flag here to indicate whether Firebase is ready to use by your app.
            //    }
            //    else
            //    {
            //        UnityEngine.Debug.LogError(System.String.Format(
            //          "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            //        // Firebase Unity SDK is not safe to use here.
            //    }
            //});

            //// Log an event with no parameters.
            //Firebase.Analytics.FirebaseAnalytics
            //  .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);

            //// Log an event with a float parameter
            //Firebase.Analytics.FirebaseAnalytics
            //  .LogEvent($"progress{Application.platform}", "percent", 0.4f);
        }


    }
}

