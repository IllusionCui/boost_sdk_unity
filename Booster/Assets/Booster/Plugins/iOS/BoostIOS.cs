using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace com.boost.sdk
{
    #if UNITY_IOS
    public class BoostIOS : IBoost {
        #region External methods
        [DllImport ("__Internal")]
        private static extern void _BoostStartWithAppKey (string appToken);

        [DllImport ("__Internal")]
        private static extern void _BoostRecordEvent (string eventToken);

        [DllImport ("__Internal")]
        private static extern void _BoostHandleLogin (string uId);

        [DllImport ("__Internal")]
        private static extern void _BoostHandleLogout ();

        #endregion


        public void start (string appKey) {
            _BoostStartWithAppKey(appKey);
        }

        public void trackEvent (string eventToken) {
            _BoostRecordEvent(eventToken);
        }

        public void Login(string uId) {
            _BoostHandleLogin(uId);
        }

        public void Logout() {
            _BoostHandleLogout();
        }
    }
    #endif
}
