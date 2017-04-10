# XamarinTizenMC
Test App for Mobile Center Tizen

## Test CURL request

curl -v --insecure -XPOST -H 'App-Secret: 209af5d5-8faf-4ec2-bafa-5d0e4bb38109' -H 'Install-ID: e574af5d-21b3-eec6-961f-dc0d09bedac8' -H "Content-type: application/json" -d '{
   "logs": [
     {
       "type": "start_session",
       "toffset": 162,
       "sid": "e95be1ec-c17a-4c24-856e-dfc4835bd6e8",
       "device": {
         "sdk_name": "mobilecenter.uwp",
         "sdk_version": "1.2.3.4",
         "model": "Z3",
         "oem_name": "Z3-oem-name",
         "os_name": "Tizen",
        "os_version": "3.0",
       "os_build": "20170321",
         "locale": "en-US",
         "time_zone_offset": 540,
        "screen_size": "800x600",
         "app_version": "1.2",
         "app_build": "Tizen-Build-Id",
         "app_namespace": "mobilecenter.tizen.app"
       }
     }
   ]
}' 'https://in.mobile.azure.com/logs?api_version=1.0.0-preview20160914'


###Some App secrets

```

54aa94d6-753f-40c3-b3f7-5af2767c7a42   HelloTizen

209af5d5-8faf-4ec2-bafa-5d0e4bb38109   HelloTizen2

c54568b6-e782-4b35-9abf-f81cc2700855   HelloTizen3

7532674f-eb96-401e-ab2b-0f296db3a71e   HelloMobileCenter
```
