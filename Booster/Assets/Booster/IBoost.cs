using UnityEngine;
using System.Collections;

namespace com.boost.sdk
{
    public interface IBoost
    {
        void start (string appKey);
        void trackEvent (string eventToken);
        void Login(string uId);
        void Logout();
    }
}
