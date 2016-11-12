//
//  Boostinsider.h
//  Boostinsider
//
//  Created by 顺然 贾 on 12/30/15.
//  Copyright © 2015 顺然 贾. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface DeeplinkObj : NSObject
@property (nonatomic, strong) NSString *title;
@property (nonatomic, strong) NSString *contentDescription;
@property (nonatomic, strong) NSString *image;
@property (nonatomic, strong) NSString *channel;
@property (nonatomic, strong) NSString *campaign;
@property (nonatomic, strong) NSDictionary *payload;
@property (nonatomic, strong) NSArray *rewards;
@end


@interface SnowballSDK : NSObject

+ (void) startWithAppKey:(NSString *)appKey Callback:(void(^)(NSDictionary *dic))callback Failure:(void(^)())failure;
+ (void) startWithAppKey:(NSString *)appKey;
+ (BOOL) continueUserActivity:(NSUserActivity *)userActivity;

+ (void) handleLogin:(NSString *)accountId;
+ (void) handleSignUp:(NSString *)accountId;
+ (void) handleLogout;

+ (void) recordEvent:(NSString *)eventName;
+ (void) recordEvent:(NSString *)eventName payload:(NSDictionary *)payload;

+ (void) createDeeplink:(DeeplinkObj *)obj success:(void(^)(NSString *link))success failure:(void(^)())failure;


+ (void)getRewardWithRewardKey:(id )rewardKey Success:(void (^)(id ))success Failure:(void (^)())failure;
+ (void)getRewardsWithType: (id)type Success:(void (^)(id ))success Failure:(void (^)())failure;
+ (void)getAllRewards:(void (^)(id ))success Failure:(void (^)())failure;

+ (void)getLockedRewardWithRewardKey:(id )rewardKey Success:(void (^)(id ))success Failure:(void (^)())failure;
+ (void)getAllLockedRewards:(void (^)(id ))success Failure:(void (^)())failure;
+ (void)getUnclaimedLockedRewards:(void (^)(id ))success Failure:(void (^)())failure;

+ (void)requestRewardWithRewardKey:(id )rewardKey Success:(void (^)(id ))success Failure:(void (^)())failure;
+ (void)requestAndClaimRewardRewardKey:(id )rewardKey Success:(void (^)(id ))success Failure:(void (^)())failure;

+ (void)claimLockedRewardWithId:(int)lockedRewardId Success:(void (^)(id ))success Failure:(void (^)())failure;
+ (void)claimLockedRewardBatchWithIds:(NSArray *)array Success:(void (^)(id ))success Failure:(void (^)())failure;
+ (void)claimAllLockedReward:(void (^)(id ))success Failure:(void (^)())failure;



@end
