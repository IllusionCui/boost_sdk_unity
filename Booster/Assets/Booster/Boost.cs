using UnityEngine;
using System.Collections;

namespace com.boost.sdk
{
    public class Boost : MonoBehaviour
    {
        public string appToken = "{Your App Token}";

        private static IBoost instance = null;

        public virtual void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);

            Boost.start(appToken);
        }

        public static void start(string appKey)
        {
            if (Boost.instance != null)
            {
                Debug.Log("boost: Error, SDK already started.");
                return;
            }

            #if UNITY_EDITOR
            Boost.instance = null;
            #elif UNITY_IOS
            Boost.instance = new BoostIOS ();
            #elif UNITY_ANDROID
            Boost.instance = null;
            #else
            Boost.instance = null;
            #endif

            if (Boost.instance == null)
            {
                Debug.Log("boost: SDK can only be used in iOS.");
                return;
            }
            Boost.instance.start(appKey);
        }

        public static void trackEvent(string eventToken)
        {
            if (Boost.instance == null)
            {
                Debug.Log("Boost.instance == null");
                return;
            }
            Boost.instance.trackEvent(eventToken);
        }

        public static void Login(string eventToken)
        {
            if (Boost.instance == null)
            {
                Debug.Log("Boost.instance == null");
                return;
            }
            Boost.instance.Login(eventToken);
        }

        public static void Logout()
        {
            if (Boost.instance == null)
            {
                Debug.Log("Boost.instance == null");
                return;
            }
            Boost.instance.Logout();
        }
    }
}
