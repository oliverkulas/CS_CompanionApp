﻿/**
* @brief		MapMarker Manager for controlling all map marker behaviours
* @author		Oliver Kulas (oli@weltenbauer-se.com)
* @date			Sep 2015
*/

//-----------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Wb.Companion.Core.WbAdministration;
using Wb.Companion.Core.WbCamera;
using Wb.Companion.Core.WbNetwork;

namespace Wb.Companion.Core.Game {

    public class WbCompMapManager : MonoBehaviour {

        private WbCompMapMarker[] mapMarkers;
		public bool isActive = false;
		public bool offlineBypass = false;
		public float dampingFactor = 1.0f;
        public List<WbCompMapVehicle> vehicleMapMarkers = new List<WbCompMapVehicle>();

        //-------------------------------------------------------------------------
        // MonoBehaviour
        //-------------------------------------------------------------------------

        void Start() {
            this.mapMarkers = WbCompMapMarker.FindObjectsOfType(typeof(WbCompMapMarker)) as WbCompMapMarker[];

            // register WbCompMapManager at SceneManager
            SceneManager.getInstance().setMapManager(this);
        }
   
        //-------------------------------------------------------------------------

        void Update() {

			if((NetworkManager.getInstance().isActiveConnection && this.isActive) || offlineBypass){
				setVehiclePositions();
			}

		}

        //-------------------------------------------------------------------------

        public void OnTouchMapMarker(Vector2 screenPos){

            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            //Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3000f)) {
                Debug.Log("HIT: " + hit.transform.gameObject.name);
            }
        }

		//-------------------------------------------------------------------------

		// get current received map position of vehicle and set the vehiclemarkes accordingly
		public void setVehiclePositions() {

			foreach(WbCompMapVehicle vehicle in vehicleMapMarkers){

				// Positions
				foreach(KeyValuePair<VehicleID, Vector3> vehiclePositions in WbCompStateSyncReceiving.getInstance().getVehicleMapPositionList()){
					
					if(vehiclePositions.Key.Equals(vehicle.vehicleId)){

						Vector3 pos = vehicle.transform.position;
						vehicle.transform.position = Vector3.Lerp (pos, vehiclePositions.Value, Time.deltaTime * dampingFactor);
					}
				}

				// Rotations
				foreach(KeyValuePair<VehicleID, Vector3> vehicleRotations in WbCompStateSyncReceiving.getInstance().getVehicleMapRotationList()){
					
					if(vehicleRotations.Key.Equals(vehicle.vehicleId)){
					
						// Rotations
						Quaternion rot = vehicle.transform.rotation;
						
						Quaternion newRotation = Quaternion.Euler(vehicleRotations.Value.x, vehicleRotations.Value.y, vehicleRotations.Value.z);
						vehicle.transform.rotation = Quaternion.Lerp (rot, newRotation, Time.deltaTime * dampingFactor);
					}
				}
			}
		}
        
        //-------------------------------------------------------------------------
        // SETTER / GETTER
        //-------------------------------------------------------------------------

        public WbCompMapMarker[] getMapMarkers() {
            return this.mapMarkers;
        }
    }
}
