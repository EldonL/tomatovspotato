using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;

namespace UnityFirebaseLearning
{
    public class LevelLoggingBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart);
        }
        private void OnDestroy()
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd);
        }
    }

}

