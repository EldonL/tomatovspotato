using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityFirebaseLearning
{
    public class FirebaseLogin : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.L))
            {
                var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
                auth.CreateUserWithEmailAndPasswordAsync("deyicel893@vasteron.com", "12345678").ContinueWith(task => {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                        return;
                    }

                    // Firebase user has been created.
                    Firebase.Auth.AuthResult result = task.Result;
                    Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                        result.User.DisplayName, result.User.UserId);
                });
            }

        }
    }

}
