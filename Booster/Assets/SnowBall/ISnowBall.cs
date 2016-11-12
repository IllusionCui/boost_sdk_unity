using UnityEngine;
using System.Collections;

namespace com.snowball.sdk
{
    public interface ISnowBall
    {
        void Start (string appKey, string sceneName);
        void CreateDeeplink (string title, string contentDescription, string image, string channel, string campaign, string payloadJson, string rewardsJson);
        void GetRewardWithRewardKey (string key);
        void GetRewardsWithType (string type);
        void GetAllReward();
        void GetLockedRewardWithRewardKey(string key);
        void GetAllLockedRewards();
        void GetUnclaimedLockedRewards();
        void RequestRewardWithRewardKey(string key);
        void RequestAndClaimRewardRewardKey(string key);
        void ClaimLockedRewardWithId(int key);
        void ClaimLockedRewardBatchWithIds(string idJson);
        void ClaimAllLockedReward();

        void RecordEvent (string eventToken);
        void Login(string uId);
        void SignUp(string uId);
        void Logout();
    }
}
