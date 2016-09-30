//
//  BoostUnity.mm
//  
//
//  Created by illusion on 2016/9/30.
//
//

#include "Boostinsider.h"

extern "C"
{
    void _BoostStartWithAppKey(const char* appToken) {
        NSString *stringAppToken = [NSString stringWithUTF8String:appToken];
        [Boostinsider startWithAppKey:stringAppToken Callback:^(NSDictionary *dic) {
            NSLog(@"BoostStartWithAppKey %@ WithDeeplink view_id = %@, product_id = %@", stringAppToken, [dic objectForKey:@"view_id"], [dic objectForKey:@"product_id"]);
        } NoDeeplink:^{
            NSLog(@"BoostStartWithAppKey %@ NoDeeplink", stringAppToken);
        }];
    }
    
    void _BoostRecordEvent(const char* eventToken) {
        NSString *stringEventToken = [NSString stringWithUTF8String:eventToken];
        [Boostinsider recordEvent:stringEventToken];
    }
    
    void _BoostHandleLogin(const char* uId) {
        NSString *stringUId = [NSString stringWithUTF8String:uId];
        [Boostinsider handleLogin:stringUId];
    }
    void _BoostHandleLogout() {
        [Boostinsider handleLogout];
    }
}
