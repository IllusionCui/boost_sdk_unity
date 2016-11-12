//
//  BoostUnity.mm
//  
//
//  Created by illusion on 2016/9/30.
//
//

#include "SnowballSDK.h"

static char * snowBallSceneName = nil;

// Method for converting JSON stirng parameters into NSDictionary object.
NSDictionary* ConvertDictionaryParameters (const char* cStringJsonDictionaryParameters) {
    if (cStringJsonDictionaryParameters == NULL) {
        return nil;
    }
    
    NSString *stringJsonDictionaryParameters = [NSString stringWithUTF8String:cStringJsonDictionaryParameters];
    
    NSError *error = nil;
    NSDictionary *dictionaryParameters = nil;
    
    
    if (dictionaryParameters != nil) {
        NSData *dataJson = [stringJsonDictionaryParameters dataUsingEncoding:NSUTF8StringEncoding];
        dictionaryParameters = [NSJSONSerialization JSONObjectWithData:dataJson options:0 error:&error];
    }
    
    if (error != nil) {
        NSString *errorMessage = @"Failed to parse dictionary json parameters!";
        NSLog(@"%@", errorMessage);
    }
    
    return dictionaryParameters;
}

// Method for converting JSON stirng parameters into NSArray object.
NSArray* ConvertArrayParameters (const char* cStringJsonArrayParameters) {
    if (cStringJsonArrayParameters == NULL) {
        return nil;
    }
    
    NSString *stringJsonArrayParameters = [NSString stringWithUTF8String:cStringJsonArrayParameters];
    
    NSError *error = nil;
    NSArray *arrayParameters = nil;
    
    
    if (stringJsonArrayParameters != nil) {
        NSData *dataJson = [stringJsonArrayParameters dataUsingEncoding:NSUTF8StringEncoding];
        arrayParameters = [NSJSONSerialization JSONObjectWithData:dataJson options:0 error:&error];
    }
    
    if (error != nil) {
        NSString *errorMessage = @"Failed to parse array json parameters!";
        NSLog(@"%@", errorMessage);
    }
    
    return arrayParameters;
}

extern "C"
{
    void _SnowBallStartWithAppKey(const char* appToken, const char* sceneName) {
        NSString *stringAppToken = [NSString stringWithUTF8String:appToken];
        NSString *stringSceneName = [NSString stringWithUTF8String:sceneName];
        
        if (sceneName != NULL && [stringSceneName length] > 0) {
            snowBallSceneName = strdup(sceneName);
        }
        
        [SnowballSDK startWithAppKey:stringAppToken Callback:^(NSDictionary *dic) {
            NSData *dataDic = [NSJSONSerialization dataWithJSONObject:dic options:0 error:nil];
            NSString *stringDic = [[NSString alloc] initWithBytes:[dataDic bytes]
                                                                   length:[dataDic length]
                                                                 encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnStartWithAppKeySucc", [stringDic UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnStartWithAppKeyFailed", "");
        }];
    }
    
    void _SnowBallCreateDeeplink(const char* title, const char* contentDescription, const char* image, const char* channel, const char* campaign, const char* payload, const char* rewards) {
        NSString *stringTitle = [NSString stringWithUTF8String:title];
        NSString *stringContentDescription = [NSString stringWithUTF8String:contentDescription];
        NSString *stringImage = [NSString stringWithUTF8String:image];
        NSString *stringChannel = [NSString stringWithUTF8String:channel];
        NSString *stringCampaign = [NSString stringWithUTF8String:campaign];
        NSDictionary *dicPayload = ConvertDictionaryParameters(payload);
        NSArray *arrayRewards = ConvertArrayParameters(rewards);
        
        DeeplinkObj *obj = [DeeplinkObj new];
        obj.title = stringTitle;
        obj.contentDescription = stringContentDescription;
        obj.image = stringImage;
        obj.rewards = arrayRewards;
        obj.payload = dicPayload;
        
        [SnowballSDK createDeeplink:obj success:^(NSString *link) {
            UnitySendMessage(snowBallSceneName, "OnCreateDeeplinkSucc", [link UTF8String]);
        } failure:^{
            UnitySendMessage(snowBallSceneName, "OnCreateDeeplinkFailed", "");
        }];
    }
    
    void _SnowBallGetRewardWithRewardKey(const char* key) {
        NSString *stringKey = [NSString stringWithUTF8String:key];
        [SnowballSDK getRewardWithRewardKey:stringKey Success:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                           length:[dataData length]
                                                         encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnGetRewardWithRewardKeySucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnGetRewardWithRewardKeyFailed", "");
        }];
    }
    
    void _SnowBallGetRewardsWithType(const char* key) {
        NSString *stringKey = [NSString stringWithUTF8String:key];
        [SnowballSDK getRewardsWithType:stringKey Success:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnGetRewardsWithTypeSucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnGetRewardsWithTypeFailed", "");
        }];
    }
    
    void _SnowBallGetAllRewards() {
        [SnowballSDK getAllRewards:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnGetAllRewardsSucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnGetAllRewardsFailed", "");
        }];
    }
    
    void _SnowBallGetLockedRewardWithRewardKey(const char* key) {
        NSString *stringKey = [NSString stringWithUTF8String:key];
        [SnowballSDK getLockedRewardWithRewardKey:stringKey Success:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnGetLockedRewardWithRewardKeySucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnGetLockedRewardWithRewardKeyFailed", "");
        }];
    }
    
    void _SnowBallGetAllLockedRewards() {
        [SnowballSDK getAllLockedRewards:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnGetAllLockedRewardsSucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnGetAllLockedRewardsFailed", "");
        }];
    }
    
    void _SnowBallGetUnclaimedLockedRewards() {
        [SnowballSDK getUnclaimedLockedRewards:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnGetUnclaimedLockedRewardsSucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnGetUnclaimedLockedRewardsFailed", "");
        }];
    }
    
    void _SnowBallRequestRewardWithRewardKey(const char* key) {
        NSString *stringKey = [NSString stringWithUTF8String:key];
        [SnowballSDK requestRewardWithRewardKey:stringKey Success:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnRequestRewardWithRewardKeySucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnRequestRewardWithRewardKeyFailed", "");
        }];
    }
    
    void _SnowBallRequestAndClaimRewardRewardKey(const char* key) {
        NSString *stringKey = [NSString stringWithUTF8String:key];
        [SnowballSDK requestAndClaimRewardRewardKey:stringKey Success:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnRequestAndClaimRewardRewardKeySucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnRequestAndClaimRewardRewardKeyFailed", "");
        }];
    }
    
    void _SnowBallClaimLockedRewardWithId(int key) {
        [SnowballSDK claimLockedRewardWithId:key Success:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnClaimLockedRewardWithIdSucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnClaimLockedRewardWithIdFailed", "");
        }];
    }
    
    void _SnowBallClaimLockedRewardBatchWithIds(const char* keys) {
        NSArray *arrayKeys = ConvertArrayParameters(keys);
        [SnowballSDK claimLockedRewardBatchWithIds:arrayKeys Success:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnClaimLockedRewardBatchWithIdsSucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnClaimLockedRewardBatchWithIdsFailed", "");
        }];
    }
    
    void _SnowBallClaimAllLockedReward() {
        [SnowballSDK claimAllLockedReward:^(id data) {
            NSData *dataData = [NSJSONSerialization dataWithJSONObject:data options:0 error:nil];
            NSString *stringData = [[NSString alloc] initWithBytes:[dataData bytes]
                                                            length:[dataData length]
                                                          encoding:NSUTF8StringEncoding];
            UnitySendMessage(snowBallSceneName, "OnClaimAllLockedRewardSucc", [stringData UTF8String]);
        } Failure:^{
            UnitySendMessage(snowBallSceneName, "OnClaimAllLockedRewardFailed", "");
        }];
    }

    void _SnowBallRecordEvent(const char* eventToken) {
        NSString *stringEventToken = [NSString stringWithUTF8String:eventToken];
        [SnowballSDK recordEvent:stringEventToken];
    }
    
    void _SnowBallHandleLogin(const char* uId) {
        NSString *stringUId = [NSString stringWithUTF8String:uId];
        [SnowballSDK handleLogin:stringUId];
    }
    
    void _SnowBallSignUp(const char* uId) {
        NSString *stringUId = [NSString stringWithUTF8String:uId];
        [SnowballSDK handleSignUp:stringUId];
    }
    
    void _SnowBallHandleLogout() {
        [SnowballSDK handleLogout];
    }
}
