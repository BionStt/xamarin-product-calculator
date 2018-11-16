#!/bin/sh

export PATH=/Library/Frameworks/Mono.framework/Versions/Current/Commands:$PATH
export PROJECT_NAME=ProductCalculator
export PROJECT_NAME_UNDERSCORE=ProductCalculator
export APK_NAME=net.junian.productcalculator

# NOTE: This is the path to installed android SDK
# On macOS, install using `brew cask install android-sdk`
export ANDROID_HOME=/usr/local/share/android-sdk

# NOTE: KEYSTORE_FILE is used to sign Android APK file
#       KEYSTORE_ALIAS is defined when you create a new Android key.
#       STORE_PASS is password to sign keystore file.
export KEYSTORE_FILE=/Users/junian/Library/Developer/Xamarin/Keystore/net.junian/net.junian.keystore
export KEYSTORE_ALIAS=net.junian
export STORE_PASS=yourpassword

export INPUT_APK=$PWD/${PROJECT_NAME}.Android/bin/Release/${APK_NAME}.apk
export SIGNED_APK=$PWD/${PROJECT_NAME}.Android/bin/Release/${APK_NAME}-signed.apk
export FINAL_APK=$PWD/Builds/${APK_NAME}.apk

# increment this number for new version
export BUILD_NUMBER=1

# restore NuGet packages
nuget restore

# build iOS .ipa file
msbuild ${PROJECT_NAME}.sln \
 /t:${PROJECT_NAME_UNDERSCORE}_iOS \
 /p:Configuration="Release" \
 /p:BuildIpa=true \
 /p:Platform="iPhone" \
 /p:IpaPackageDir="$PWD/Builds" \
 /p:IsAutoVersion=true \
 /p:BuildNumber=${BUILD_NUMBER} \
 /p:AssemblyPath="$PWD/${PROJECT_NAME}/bin/Release/${PROJECT_NAME}.dll"

# build Android .apk file
msbuild ${PROJECT_NAME}.sln \
 /t:${PROJECT_NAME_UNDERSCORE}_Android:SignAndroidPackage \
 /p:Configuration="Release" \
 /p:IsAutoVersion=true \
 /p:BuildNumber=${BUILD_NUMBER} \
 /p:AssemblyPath="$PWD/${PROJECT_NAME}/bin/Release/${PROJECT_NAME}.dll"

# sign android .apk file
# NOTE: `zipalign` binary is located under $ANDROID_HOME/build-tools/{version}.
#       You need to change it in case it doesn't work.
jarsigner -verbose -sigalg MD5withRSA -digestalg SHA1 -keystore $KEYSTORE_FILE -storepass $STORE_PASS -signedjar $SIGNED_APK $INPUT_APK $KEYSTORE_ALIAS
$ANDROID_HOME/build-tools/25.0.3/zipalign -f -v 4 $SIGNED_APK $FINAL_APK
