using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace com.snowball.sdk
{
    #if UNITY_IOS
    public class SnowBallIOS : ISnowBall {
        #region External methods
        [DllImport ("__Internal")]
        private static extern void _SnowBallStartWithAppKey (string appToken, string sceneName);

        [DllImport ("__Internal")]
        private static extern void _SnowBallCreateDeeplink (string title, string contentDescription, string image, string channel, string campaign, string payload, string rewards);

        [DllImport ("__Internal")]
        private static extern void _SnowBallGetRewardWithRewardKey(string key);

        [DllImport ("__Internal")]
        private static extern void _SnowBallGetRewardsWithType(string key);

        [DllImport ("__Internal")]
        private static extern void _SnowBallGetAllRewards();

        [DllImport ("__Internal")]
        private static extern void _SnowBallGetLockedRewardWithRewardKey(string key);

        [DllImport ("__Internal")]
        private static extern void _SnowBallGetAllLockedRewards();

        [DllImport ("__Internal")]
        private static extern void _SnowBallGetUnclaimedLockedRewards();

        [DllImport ("__Internal")]
        private static extern void _SnowBallRequestRewardWithRewardKey(string key);

        [DllImport ("__Internal")]
        private static extern void _SnowBallRequestAndClaimRewardRewardKey(string key);

        [DllImport ("__Internal")]
        private static extern void _SnowBallClaimLockedRewardWithId(int key);

        [DllImport ("__Internal")]
        private static extern void _SnowBallClaimLockedRewardBatchWithIds(string keys);

        [DllImport ("__Internal")]
        private static extern void _SnowBallClaimAllLockedReward();

        [DllImport ("__Internal")]
        private static extern void _SnowBallRecordEvent(string eventToken);

        [DllImport ("__Internal")]
        private static extern void _SnowBallHandleLogin(string uId);

        [DllImport ("__Internal")]
        private static extern void _SnowBallSignUp(string uId);

        [DllImport ("__Internal")]
        private static extern void _SnowBallHandleLogout();
        #endregion

        public void Start (string appKey, string sceneName)
        {
            _SnowBallStartWithAppKey (appKey, sceneName);
        }

        public void CreateDeeplink (string title, string contentDescription, string image, string channel, string campaign, string payloadJson, string rewardsJson)
        {
            _SnowBallCreateDeeplink (title, contentDescription, image, channel, campaign, payloadJson, rewardsJson);
        }

        public void GetRewardWithRewardKey (string key)
        {
            _SnowBallGetRewardWithRewardKey(key);
        }

        public void GetRewardsWithType (string type)
        {
            _SnowBallGetRewardsWithType(type);
        }

        public void GetAllReward()
        {
            _SnowBallGetAllRewards();
        }

        public void GetLockedRewardWithRewardKey(string key)
        {
            _SnowBallGetLockedRewardWithRewardKey(key);
        }

        public void GetAllLockedRewards()
        {
            _SnowBallGetAllLockedRewards();
        }

        public void GetUnclaimedLockedRewards()
        {
            _SnowBallGetUnclaimedLockedRewards();
        }

        public void RequestRewardWithRewardKey(string key)
        {
            _SnowBallRequestRewardWithRewardKey(key);
        }

        public void RequestAndClaimRewardRewardKey(string key)
        {
            _SnowBallRequestAndClaimRewardRewardKey(key);
        }

        public void ClaimLockedRewardWithId(int key)
        {
            _SnowBallClaimLockedRewardWithId(key);
        }

        public void ClaimLockedRewardBatchWithIds(string idJson)
        {
            _SnowBallClaimLockedRewardBatchWithIds(idJson);
        }

        public void ClaimAllLockedReward()
        {
            _SnowBallClaimAllLockedReward();
        }

        public void RecordEvent (string eventToken)
        {
            _SnowBallRecordEvent(eventToken);
        }

        public void Login(string uId)
        {
            _SnowBallHandleLogin(uId);
        }

        public void SignUp(string uId)
        {
            _SnowBallSignUp(uId);
        }

        public void Logout()
        {
            _SnowBallHandleLogout();
        }
    }
    #endif
}
