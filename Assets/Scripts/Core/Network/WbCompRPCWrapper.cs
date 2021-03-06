﻿using UnityEngine;
using System.Collections;
using Wb.Companion.Core.Inputs;

namespace Wb.Companion.Core.WbNetwork {

    public class WbCompRPCWrapper : MonoBehaviour {

        public static WbCompRPCWrapper instance;
        public NetworkView networkView;

		public bool debugging = false;

		//private float currentSpeed; 
		//private float currentRPM;

		private string backViewCameraFrameBase64 = "empty";
		private byte[] backViewCameraFrameByteArray;
		public int imgPart;
		public int imgWidth;
		public int imgHeight;
		public int imgSlices;

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

        }

        //---------------------------------------------------------------------
        // Remote Procedure Calls
        //---------------------------------------------------------------------
		// OUT GOING RPCs
		//---------------------------------------------------------------------

        [RPC]
		public void addItemToShoppingListExternal(string location, string retailerItem, int amount) {
            // does stuff on server side
        }

        [RPC]
        public void executeExternalPurchase() {
            // does stuff on server side
        }

	 	[RPC]
		public void toggleCompanionAppInput(){
			// does stuff on server side
		}

		[RPC]
		public void switchBroadcastingCamera(){
			// does stuff on server side
		}

		[RPC]
		public void switchVehicleMode(){
			// does stuff on server side
		}

		[RPC]
		public void resetVehicle(){
			// does stuff on server side
		}

		[RPC]
		public void connectHookCargo(){
			// does stuff on server side
		}

		[RPC]
		public void toggleCameraBroadcasting(){
			// does stuff on server side
		}

		//---------------------------------------------------------------------
		// INCOMING RPCs
		//---------------------------------------------------------------------

		[RPC]
		public void sendRPCbroadcastCamera(string imgData, int part, int width, int height, int slices){
			backViewCameraFrameBase64 = imgData;
			imgPart = part;
			imgWidth = width;
			imgHeight = height;
			imgSlices = slices;
		}

		//------ SETTER / GETTER ---------------------------------------------

		public string getBackViewCameraFrameAsB64String(){
			return backViewCameraFrameBase64;
		}

		public void toggleCompanionAppInputRPC(){
			this.networkView.RPC("toggleCompanionAppInput", RPCMode.Server);
		}

		public void switchBroadcastingCameraRPC(){
			this.networkView.RPC("switchBroadcastingCamera", RPCMode.Server);
		}
		
		public void switchVehicleModeRPC(){
			this.networkView.RPC("switchVehicleMode", RPCMode.Server);
		}

		public void resetVehicleRPC(){
			this.networkView.RPC("resetVehicle", RPCMode.Server);
		}

		public void connectHookCargoRPC(){
			this.networkView.RPC("connectHookCargo", RPCMode.Server);
		}

		public void toggleCameraBroadcastingRPC(){
			this.networkView.RPC("toggleCameraBroadcasting", RPCMode.Server);
		}
	
    }

}