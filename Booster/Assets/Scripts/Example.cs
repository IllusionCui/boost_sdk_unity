using UnityEngine;
using System.Collections;
using com.snowball.sdk;

public class Example : MonoBehaviour {
    SnowBall snowball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDeepLink()
    {
        SnowBall.CreateDeeplink("title", "contentDescription", "http://a4.mzstatic.com/us/r30/Purple62/v4/7e/89/20/7e8920e2-0ce8-befd-998c-14c36dc66e6f/screen696x696.jpeg", "channel1", "campaign1", "", "");
    }

    public void OnReward()
    {
        SnowBall.GetAllReward();
        SnowBall.GetRewardsWithType("FIRST_INSTAL");
    }

    public void OnRequestReward()
    {
        SnowBall.RequestRewardWithRewardKey("FIRST_INSTAL");
    }

    public void OnRequestAndClaimReward()
    {
        SnowBall.RequestAndClaimRewardRewardKey("FIRST_INSTAL");
    }

    public void OnLockReward()
    {
        SnowBall.GetAllLockedRewards();
        SnowBall.ClaimAllLockedReward();
    }
}
