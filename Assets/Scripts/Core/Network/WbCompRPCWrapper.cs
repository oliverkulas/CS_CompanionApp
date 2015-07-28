﻿using UnityEngine;
using System.Collections;
using Wb.Companion.Core.Inputs;

namespace Wb.Companion.Core.WbNetwork {

    public class WbCompRPCWrapper : MonoBehaviour {

        public static WbCompRPCWrapper instance;
        public NetworkView networkView;

        // ------------------------------------------------------------------------

        public static WbCompRPCWrapper getInstance() {
            return WbCompRPCWrapper.instance;
        }

        // ------------------------------------------------------------------------
        // MonoBehaviour
        // ------------------------------------------------------------------------

        public void Awake() {
            WbCompRPCWrapper.instance = this;
        }

        void Start() {
            this.networkView = GetComponent<NetworkView>();
        }

        void Update() {

            // Tilt Input
            if (InputManager.getInstance().activeConnection && InputManager.getInstance().activeTiltInput) {
                float tiltValue = InputManager.getInstance().CalcAxisValue(InputManager.TiltAxis.sideways);
                //Debug.Log(tiltValue);
                //sendRPCTiltInput(tiltValue);
            }

        }

        // ------------------------------------------------------------------------

        public void disconnectBtn() {
            NetworkManager.disconnect();
        }

        public void launchServerBtn() {
            NetworkManager.launchServer("4", "25000", "pw");
        }

        public void connectionInfoBtn() {
            NetworkManager.connectionInfo();
        }

        //---------------------------------------------------------------------

        public void setThrottle(string input, float value) {
            //NetworkViewID viewID = Network.AllocateViewID();
            networkView.RPC("setThrottleInput", RPCMode.AllBuffered, input, value);
        }

        public void setNextCamera(string input) {
            networkView.RPC("setRPCNextCamera", RPCMode.AllBuffered, input);
        }

        public void setGetIntoVehicle(string input) {
            networkView.RPC("setRPCGetIntoVehicle", RPCMode.AllBuffered, input);
        }

        //---------------------------------------------------------------------
        // Remote Procedure Calls
        //---------------------------------------------------------------------

        //public void sendRPCTiltInput(float value) {
        //    networkView.RPC("tiltInput", RPCMode.AllBuffered, value);
        //}

        [RPC]
        public void setRPCThrottleInput(string txt, float value) {
            //Debug.Log(txt);
        }

        [RPC]
        public void setRPCNextCamera(string txt) {
            //Debug.Log(txt);
        }

        [RPC]
        public void setRPCGetIntoVehicle(string txt) {
            //Debug.Log(txt);
        }

        [RPC]
        public void setRPCTiltInput(float value) {
            //Debug.Log ("TiltInput: " + value);
        }
    }

}