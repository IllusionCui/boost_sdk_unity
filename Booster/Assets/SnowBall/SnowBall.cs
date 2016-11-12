using UnityEngine;
using System.Collections;

namespace com.snowball.sdk
{
    public class SnowBall : MonoBehaviour
    {
        public bool debug = true;
        public bool auto = true;
        public string appToken = "{Your App Token}";

        private static ISnowBall _instance = null;

        public virtual void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);

            if (auto)
            {
                StartSnowBall(appToken); 
            }
        }

        public void StartSnowBall(string appKey)
        {
            if (SnowBall._instance != null)
            {
                Debug.LogWarning("SnowBall:[StartSnowBall] _instance != null.");
            }

            #if UNITY_EDITOR
            SnowBall._instance = null;
            #elif UNITY_IOS
            SnowBall._instance = new SnowBallIOS ();
            #elif UNITY_ANDROID
            SnowBall._instance = null;
            #else
            SnowBall._instance = null;
            #endif

            if (SnowBall._instance != null)
            {
                SnowBall._instance.Start(appKey, gameObject.name);
            }
        }

        #region function

        public static void Start(string appKey, string sceneName)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.Start(appKey, sceneName);
        }

        public static void CreateDeeplink(string title, string contentDescription, string image, string channel, string campaign, string payloadJson, string rewardsJson)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.CreateDeeplink(title, contentDescription, image, channel, campaign, payloadJson, rewardsJson);
        }

        public static void GetRewardWithRewardKey(string key)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.GetRewardWithRewardKey(key);
        }

        public static void GetRewardsWithType(string type)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.GetRewardsWithType(type);
        }

        public static void GetAllReward()
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.GetAllReward();
        }

        public static void GetLockedRewardWithRewardKey(string key)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.GetLockedRewardWithRewardKey(key);
        }

        public static void GetAllLockedRewards()
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.GetAllLockedRewards();
        }

        public static void GetUnclaimedLockedRewards()
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.GetUnclaimedLockedRewards();
        }

        public static void RequestRewardWithRewardKey(string key)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.RequestRewardWithRewardKey(key);
        }

        public static void RequestAndClaimRewardRewardKey(string key)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.RequestAndClaimRewardRewardKey(key);
        }

        public static void ClaimLockedRewardWithId(int key)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.ClaimLockedRewardWithId(key);
        }

        public static void ClaimLockedRewardBatchWithIds(string idJson)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.ClaimLockedRewardBatchWithIds(idJson);
        }

        public static void ClaimAllLockedReward()
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.ClaimAllLockedReward();
        }

        public static void RecordEvent(string eventToken)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.RecordEvent(eventToken);
        }

        public static void Login(string uId)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.Login(uId);
        }

        public static void SignUp(string uId)
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.SignUp(uId);
        }

        public static void Logout()
        {
            if (SnowBall._instance == null)
            {
                Debug.LogWarning("SnowBall: _instance == null.");
                return;
            }
            SnowBall._instance.Logout();
        }

        #endregion

        #region callback

        public void OnStartWithAppKeySucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnStartWithAppKeySucc] param = {0}.", param));
        }

        public void OnStartWithAppKeyFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnStartWithAppKeyFailed] param = {0}.", param));
        }

        public void OnCreateDeeplinkSucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnCreateDeeplinkSucc] param = {0}.", param));
        }

        public void OnCreateDeeplinkFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnCreateDeeplinkFailed] param = {0}.", param));
        }

        public void OnGetRewardWithRewardKeySucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetRewardWithRewardKeySucc] param = {0}.", param));
        }

        public void OnGetRewardWithRewardKeyFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetRewardWithRewardKeyFailed] param = {0}.", param));
        }

        public void OnGetRewardsWithTypeSucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetRewardsWithTypeSucc] param = {0}.", param));
        }

        public void OnGetRewardsWithTypeFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetRewardsWithTypeFailed] param = {0}.", param));
        }

        public void OnGetAllRewardsSucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetAllRewardsSucc] param = {0}.", param));
        }

        public void OnGetAllRewardsFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetAllRewardsFailed] param = {0}.", param));
        }

        public void OnGetLockedRewardWithRewardKeySucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetLockedRewardWithRewardKeySucc] param = {0}.", param));
        }

        public void OnGetLockedRewardWithRewardKeyFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetLockedRewardWithRewardKeyFailed] param = {0}.", param));
        }

        public void OnGetAllLockedRewardsSucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetAllLockedRewardsSucc] param = {0}.", param));
        }

        public void OnGetAllLockedRewardsFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetAllLockedRewardsFailed] param = {0}.", param));
        }

        public void OnGetUnclaimedLockedRewardsSucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetUnclaimedLockedRewardsSucc] param = {0}.", param));
        }

        public void OnGetUnclaimedLockedRewardsFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnGetUnclaimedLockedRewardsFailed] param = {0}.", param));
        }

        public void OnRequestRewardWithRewardKeySucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnRequestRewardWithRewardKeySucc] param = {0}.", param));
        }

        public void OnRequestRewardWithRewardKeyFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnRequestRewardWithRewardKeyFailed] param = {0}.", param));
        }

        public void OnRequestAndClaimRewardRewardKeySucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnRequestAndClaimRewardRewardKeySucc] param = {0}.", param));
        }

        public void OnRequestAndClaimRewardRewardKeyFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnRequestAndClaimRewardRewardKeyFailed] param = {0}.", param));
        }

        public void OnClaimLockedRewardWithIdSucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnClaimLockedRewardWithIdSucc] param = {0}.", param));
        }

        public void OnClaimLockedRewardWithIdFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnClaimLockedRewardWithIdFailed] param = {0}.", param));
        }

        public void OnClaimLockedRewardBatchWithIdsSucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnClaimLockedRewardBatchWithIdsSucc] param = {0}.", param));
        }

        public void OnClaimLockedRewardBatchWithIdsFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnClaimLockedRewardBatchWithIdsFailed] param = {0}.", param));
        }

        public void OnClaimAllLockedRewardSucc(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnClaimAllLockedRewardSucc] param = {0}.", param));
        }

        public void OnClaimAllLockedRewardFailed(string param)
        {
            if (debug)
                Debug.Log(string.Format("SnowBall:[OnClaimAllLockedRewardFailed] param = {0}.", param));
        }

        #endregion
    }
}
