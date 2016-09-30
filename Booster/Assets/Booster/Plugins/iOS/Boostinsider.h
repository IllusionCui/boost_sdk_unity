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
@end


@interface Boostinsider : NSObject

+ (void) startWithAppKey:(NSString *)appKey Callback:(void(^)(NSDictionary *dic))callback NoDeeplink:(void(^)())noDeeplink;
+ (void) startWithAppKey:(NSString *)appKey;

+ (void) handleLogin:(NSString *)accountId;
+ (void) handleSignUp:(NSString *)accountId;
+ (void) handleLogout;

+ (void) recordEvent:(NSString *)eventName;
+ (void) recordEvent:(NSString *)eventName payload:(NSDictionary *)payload;

+ (void) createDeeplink:(DeeplinkObj *)obj success:(void(^)(NSString *link))success failure:(void(^)())failure;


@end
