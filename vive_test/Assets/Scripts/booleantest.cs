using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System;

public class booleantest : MonoBehaviour
{
    //インターフェースUIボタンが押されているかを判定するためにIuiという関数に格納している。
    private SteamVR_Action_Boolean Iui = SteamVR_Actions.default_InteractUI;
    //結果の格納用関数
    private Boolean interacrtui;

    //GrabGripボタン（初期設定は側面ボタン）が押されてるのかを判定するためのGrabという関数にSteamVR_Actions.default_GrabGripを固定
    private SteamVR_Action_Boolean GrabG = SteamVR_Actions.default_GrabGrip;
    //結果の格納用Boolean型関数grapgrip
    private Boolean grapgrip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //1フレーム毎に呼び出されるUpdateメゾット
    void Update()
    {
        //結果をGetStateで取得してinteracrtuiに格納
        //SteamVR_Input_Sources.機器名（今回は左コントローラ）
        interacrtui = Iui.GetState(SteamVR_Input_Sources.LeftHand);
        //InteractUIが押されているときにコンソールにInteractUIと表示
        if (interacrtui)
        {
            Debug.Log("InteractUI");
        }

        //結果をGetStateで取得してgrapgripに格納
        //SteamVR_Input_Sources.機器名（今回は左コントローラ）
        grapgrip = GrabG.GetState(SteamVR_Input_Sources.LeftHand);
        //GrabGripが押されているときにコンソールにGrabGripと表示
        if (grapgrip)
        {
            Debug.Log("GrabGrip");
        }

    }
}
