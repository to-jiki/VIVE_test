using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;


public class pos : MonoBehaviour
{
    //HMDの位置座標格納用
    private Vector3 HMDPosition;
    //HMDの回転座標格納用（クォータニオン）
    private Quaternion HMDRotationQ;
    //HMDの回転座標格納用（オイラー角）
    private Vector3 HMDRotation;

    //左コントローラの位置座標格納用
    private Vector3 LeftHandPosition;
    //左コントローラの回転座標格納用（クォータニオン）
    private Quaternion LeftHandRotationQ;
    //左コントローラの回転座標格納用
    private Vector3 LeftHandRotation;

    //右コントローラの位置座標格納用
    private Vector3 RightHandPosition;
    //右コントローラの回転座標格納用（クォータニオン）
    private Quaternion RightHandRotationQ;
    //右コントローラの回転座標格納用
    private Vector3 RightHandRotation;
 


    // void FixedUpdate(){ 
    //     //XRnodeでデバイスのインスタンスの取得のチェック
    //     var HeadDevices = new List<UnityEngine.XR.InputDevice>();
    //     InputDevices.GetDevicesAtXRNode(XRNode.Head, HeadDevices);
        

    //     if(HeadDevices.Count == 1)
    //     {
    //         UnityEngine.XR.InputDevice device =HeadDevices[0];
    //         Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
    //     }
    //     else if(HeadDevices.Count > 1)
    //     {
    //         Debug.Log("head");
    //     }
    // }

    //1フレーム毎に呼び出されるUpdateメゾット
    void Update()
    {
        //頭デバイスのインスタンスを取得
        var HeadDevices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.Head, HeadDevices);
        UnityEngine.XR.InputDevice HeadDevice =HeadDevices[0];

        //左手デバイスのインスタンスを取得
        var LeftDevices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, LeftDevices);
        UnityEngine.XR.InputDevice LeftDevice =LeftDevices[0];

        //頭デバイスのインスタンスを取得
        var RightDevices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, RightDevices);
        UnityEngine.XR.InputDevice RightDevice =RightDevices[0];
        

        /*CommonUsage.devicePosition(XRNode.機器名)で機器の位置や向きを呼び出せる*/

        //Head（ヘッドマウンドディスプレイ）の情報を一時保管-----------
        //位置座標を取得
        HeadDevice.TryGetFeatureValue(CommonUsages.devicePosition, out HMDPosition);

        //回転座標をクォータニオンで値を受け取る
        HeadDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out HMDRotationQ);
        //取得した値をクォータニオン → オイラー角に変換
        HMDRotation = HMDRotationQ.eulerAngles;
        //--------------------------------------------------------------


        //LeftHand（左コントローラ）の情報を一時保管--------------------
        //位置座標を取得
        LeftDevice.TryGetFeatureValue(CommonUsages.devicePosition, out LeftHandPosition);
        //回転座標をクォータニオンで値を受け取る
        LeftDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out LeftHandRotationQ);
        //取得した値をクォータニオン → オイラー角に変換
        LeftHandRotation = LeftHandRotationQ.eulerAngles;
        //--------------------------------------------------------------


        //RightHand（右コントローラ）の情報を一時保管--------------------
        //位置座標を取得
        RightDevice.TryGetFeatureValue(CommonUsages.devicePosition, out RightHandPosition);
        //回転座標をクォータニオンで値を受け取る
        RightDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out RightHandRotationQ);
        //取得した値をクォータニオン → オイラー角に変換
        RightHandRotation = RightHandRotationQ.eulerAngles;
        //--------------------------------------------------------------


        //取得したデータを表示（HMDP：HMD位置，HMDR：HMD回転，LFHR：左コン位置，LFHR：左コン回転，RGHP：右コン位置，RGHR：右コン回転）
        Debug.Log("HMDP:" + HMDPosition.x + ", " + HMDPosition.y + ", " + HMDPosition.z + "\n" +
                    "HMDR:" + HMDRotation.x + ", " + HMDRotation.y + ", " + HMDRotation.z);
        Debug.Log("LFHP:" + LeftHandPosition.x + ", " + LeftHandPosition.y + ", " + LeftHandPosition.z + "\n" +
                    "LFHR:" + LeftHandRotation.x + ", " + LeftHandRotation.y + ", " + LeftHandRotation.z);
        Debug.Log("RGHP:" + RightHandPosition.x + ", " + RightHandPosition.y + ", " + RightHandPosition.z + "\n" +
                    "RGHR:" + RightHandRotation.x + ", " + RightHandRotation.y + ", " + RightHandRotation.z);
    }
}
