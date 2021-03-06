﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Wb.Companion.Core.Game;
using Wb.Companion.Core.WbAdministration;
using Wb.Companion.Core.WbNetwork;

public class WbCompStateSyncReceiving : MonoBehaviour, ICompNetworkOwner {

	public static WbCompStateSyncReceiving instance;
	public NetworkView networkView;

	// Tachometer Values ------------------------------------------------------
	public float vehicleSpeed = 0f;
	public float vehicleRPM = 0f;

    // VEHICLE MAP POSITIONS ---------------------------------------------------
    public Vector3 wbConcreteMixerPosition = Vector3.zero;
    public Vector3 wbConcretePumpPosition = Vector3.zero;
    public Vector3 wbDepositTipperPosition = Vector3.zero;
    public Vector3 wbEscortSchleicherPosition = Vector3.zero;
    public Vector3 wbExcavatorPosition = Vector3.zero;
    public Vector3 wbFlatbedTruckPosition = Vector3.zero;
    public Vector3 wbFlatTopCranePosition = Vector3.zero;
    public Vector3 wbForkLiftPosition = Vector3.zero;
    public Vector3 wbFrontLoaderPosition = Vector3.zero;
    public Vector3 wbGeneratorTrailerPosition = Vector3.zero;
    //public Vector3 HalfpipeTrailerPosition = Vector3.zero;
    public Vector3 wbHalfpipeTruckPosition = Vector3.zero;
    public Vector3 wbHeavyDutyTrailerPosition = Vector3.zero;
    public Vector3 wbLittleFlabBedTruckPosition = Vector3.zero;
    public Vector3 wbLittleHalfpipeTruckPosition = Vector3.zero;
    public Vector3 wbLowLoaderTrailerPosition = Vector3.zero;
    public Vector3 wbMiniExcavatorPosition = Vector3.zero;
    public Vector3 wbPlattmakerPosition = Vector3.zero;
    public Vector3 wbRotaryDrillingRigPosition = Vector3.zero;
    public Vector3 wbTowerCranePosition = Vector3.zero;
    public Vector3 wbTrailerPosition = Vector3.zero;
    //public Vector3 wbTrailerDrawbarFlatbedPosition = Vector3.zero;
    public Vector3 wbTrailerFlatbedPosition = Vector3.zero;
    public Vector3 wbTrailerSmallPosition = Vector3.zero;
    public Vector3 wbTruckCranePosition = Vector3.zero;

	// VEHICLE MAP ROTATIONS  ---------------------------------------------------
	public Quaternion wbConcreteMixerRotation;
	public Quaternion wbConcretePumpRotation;
	public Quaternion wbDepositTipperRotation;
	public Quaternion wbEscortSchleicherRotation;
	public Quaternion wbExcavatorRotation;
	public Quaternion wbFlatbedTruckRotation;
	public Quaternion wbFlatTopCraneRotation;
	public Quaternion wbForkLiftRotation;
	public Quaternion wbFrontLoaderRotation;
	public Quaternion wbGeneratorTrailerRotation;
	//public Quaternion HalfpipeTrailerRotation;
	public Quaternion wbHalfpipeTruckRotation;
	public Quaternion wbHeavyDutyTrailerRotation;
	public Quaternion wbLittleFlabBedTruckRotation;
	public Quaternion wbLittleHalfpipeTruckRotation;
	public Quaternion wbLowLoaderTrailerRotation;
	public Quaternion wbMiniExcavatorRotation;
	public Quaternion wbPlattmakerRotation;
	public Quaternion wbRotaryDrillingRigRotation;
	public Quaternion wbTowerCraneRotation;
	public Quaternion wbTrailerRotation;
	//public Quaternion wbTrailerDrawbarFlatbedRotation;
	public Quaternion wbTrailerFlatbedRotation;
	public Quaternion wbTrailerSmallRotation;
	public Quaternion wbTruckCraneRotation;

	// Debug helpers
	public bool debugging = false;
	public float timeSinceLastStart = 0f;

    //---------------------------------------------------------------------
    // Singleton
    //---------------------------------------------------------------------

    public static WbCompStateSyncReceiving getInstance() {
		return WbCompStateSyncReceiving.instance;
	}
	
	//---------------------------------------------------------------------
	// Mono Behaviour
	//---------------------------------------------------------------------
	
	public void Awake() {
		WbCompStateSyncReceiving.instance = this;
	}
	
	void Start () {
		networkView = GetComponent<NetworkView>();
	}

	void Update () {
	}

	//---------------------------------------------------------------------
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {

		// SENDING
		if (stream.isWriting) {

		} 
		
		// RECEIVING
		else{
			// Tachometer Values
			stream.Serialize(ref vehicleSpeed);
			stream.Serialize(ref vehicleRPM);

            // Vehicle Positions
            stream.Serialize(ref wbConcreteMixerPosition);
            stream.Serialize(ref wbConcretePumpPosition);
            stream.Serialize(ref wbDepositTipperPosition);
            stream.Serialize(ref wbEscortSchleicherPosition);
            stream.Serialize(ref wbExcavatorPosition);
            stream.Serialize(ref wbFlatbedTruckPosition);
            stream.Serialize(ref wbFlatTopCranePosition);
            stream.Serialize(ref wbForkLiftPosition);
            stream.Serialize(ref wbFrontLoaderPosition);
            stream.Serialize(ref wbGeneratorTrailerPosition);
            stream.Serialize(ref wbHalfpipeTruckPosition);
			stream.Serialize(ref wbHeavyDutyTrailerPosition);
            stream.Serialize(ref wbLittleFlabBedTruckPosition);
            stream.Serialize(ref wbLittleHalfpipeTruckPosition);
            stream.Serialize(ref wbLowLoaderTrailerPosition);
            stream.Serialize(ref wbMiniExcavatorPosition);
            stream.Serialize(ref wbPlattmakerPosition);
            stream.Serialize(ref wbRotaryDrillingRigPosition);
            stream.Serialize(ref wbTowerCranePosition);
            stream.Serialize(ref wbTrailerPosition);
            stream.Serialize(ref wbTrailerFlatbedPosition);
			stream.Serialize(ref wbTrailerSmallPosition);
            stream.Serialize(ref wbTruckCranePosition);

			// Vehicle Rotations
			stream.Serialize(ref wbConcreteMixerRotation);
			stream.Serialize(ref wbConcretePumpRotation);
			stream.Serialize(ref wbDepositTipperRotation);
			stream.Serialize(ref wbEscortSchleicherRotation);
			stream.Serialize(ref wbExcavatorRotation);
			stream.Serialize(ref wbFlatbedTruckRotation);
			stream.Serialize(ref wbFlatTopCraneRotation);
			stream.Serialize(ref wbForkLiftRotation);
			stream.Serialize(ref wbFrontLoaderRotation);
			stream.Serialize(ref wbGeneratorTrailerRotation);
			stream.Serialize(ref wbHalfpipeTruckRotation);
			stream.Serialize(ref wbHeavyDutyTrailerRotation);
			stream.Serialize(ref wbLittleFlabBedTruckRotation);
			stream.Serialize(ref wbLittleHalfpipeTruckRotation);
			stream.Serialize(ref wbLowLoaderTrailerRotation);
			stream.Serialize(ref wbMiniExcavatorRotation);
			stream.Serialize(ref wbPlattmakerRotation);
			stream.Serialize(ref wbRotaryDrillingRigRotation);
			stream.Serialize(ref wbTowerCraneRotation);
			stream.Serialize(ref wbTrailerRotation);
			stream.Serialize(ref wbTrailerFlatbedRotation);
			stream.Serialize(ref wbTrailerSmallRotation);
			stream.Serialize(ref wbTruckCraneRotation);
        }
	}

	//---------------------------------------------------------------------
	// Interface Implementations
	//---------------------------------------------------------------------
	
	public void setAsOwner(){
		Debug.Log ("Set WbCompStateSyncSending as Owner");
		NetworkViewID newViewId = Network.AllocateViewID();
		this.networkView.RPC("allocateNewNetworkViewID", RPCMode.All, newViewId);
	}
	
	//---------------------------------------------------------------------
	
	[RPC]
	public void allocateNewNetworkViewID(NetworkViewID newId){
		Debug.Log ("Change Owner for Sender");
		this.networkView.viewID = newId;
	}

	//----------------------------------------------------------------------

	public Dictionary<VehicleID, Vector3> getVehicleMapPositionList(){

		Dictionary<VehicleID, Vector3> vehicleMapPositions = new Dictionary<VehicleID, Vector3>();
	
		vehicleMapPositions.Add (VehicleID.wbConcreteMixer, wbConcreteMixerPosition);
		vehicleMapPositions.Add (VehicleID.wbConcretePump, wbConcretePumpPosition);
		vehicleMapPositions.Add (VehicleID.wbDepositTipper, wbDepositTipperPosition);
		vehicleMapPositions.Add (VehicleID.wbEscortSchleicher, wbEscortSchleicherPosition);
		vehicleMapPositions.Add (VehicleID.wbExcavator, wbExcavatorPosition);
		vehicleMapPositions.Add (VehicleID.wbFlatbedTruck, wbFlatbedTruckPosition);
		vehicleMapPositions.Add (VehicleID.wbFlatTopCrane, wbFlatTopCranePosition);
		vehicleMapPositions.Add (VehicleID.wbForklift, wbForkLiftPosition);
		vehicleMapPositions.Add (VehicleID.wbFrontLoader, wbFrontLoaderPosition);
		vehicleMapPositions.Add (VehicleID.wbGeneratorTrailer, wbGeneratorTrailerPosition);
		vehicleMapPositions.Add (VehicleID.wbHalfpipeTruck, wbHalfpipeTruckPosition);
		vehicleMapPositions.Add (VehicleID.wbHeavyDutyTrailer, wbHeavyDutyTrailerPosition);
		vehicleMapPositions.Add (VehicleID.wbLittleFlatbedTruck, wbLittleFlabBedTruckPosition);
		vehicleMapPositions.Add (VehicleID.wbLittleHalfpipeTruck, wbLittleHalfpipeTruckPosition);
		vehicleMapPositions.Add (VehicleID.wbLowLoaderTrailer, wbLowLoaderTrailerPosition);
		vehicleMapPositions.Add (VehicleID.wbMiniExcavator, wbMiniExcavatorPosition);
		vehicleMapPositions.Add (VehicleID.wbPlattmaker, wbPlattmakerPosition);
		vehicleMapPositions.Add (VehicleID.wbRotaryDrillingRig, wbRotaryDrillingRigPosition);
		vehicleMapPositions.Add (VehicleID.wbTowerCrane, wbTowerCranePosition);
		vehicleMapPositions.Add (VehicleID.wbTrailer, wbTrailerPosition);
		vehicleMapPositions.Add (VehicleID.wbTrailerFlatbed, wbTrailerFlatbedPosition);
		vehicleMapPositions.Add (VehicleID.wbTruckCrane, wbTruckCranePosition);

		return vehicleMapPositions;
	}

	//----------------------------------------------------------------------
	
	public Dictionary<VehicleID, Quaternion> getVehicleMapRotationList(){
		
		Dictionary<VehicleID, Quaternion> vehicleMapRotations = new Dictionary<VehicleID, Quaternion>();
		
		vehicleMapRotations.Add (VehicleID.wbConcreteMixer, wbConcreteMixerRotation);
		vehicleMapRotations.Add (VehicleID.wbConcretePump, wbConcretePumpRotation);
		vehicleMapRotations.Add (VehicleID.wbDepositTipper, wbDepositTipperRotation);
		vehicleMapRotations.Add (VehicleID.wbEscortSchleicher, wbEscortSchleicherRotation);
		vehicleMapRotations.Add (VehicleID.wbExcavator, wbExcavatorRotation);
		vehicleMapRotations.Add (VehicleID.wbFlatbedTruck, wbFlatbedTruckRotation);
		vehicleMapRotations.Add (VehicleID.wbFlatTopCrane, wbFlatTopCraneRotation);
		vehicleMapRotations.Add (VehicleID.wbForklift, wbForkLiftRotation);
		vehicleMapRotations.Add (VehicleID.wbFrontLoader, wbFrontLoaderRotation);
		vehicleMapRotations.Add (VehicleID.wbGeneratorTrailer, wbGeneratorTrailerRotation);
		vehicleMapRotations.Add (VehicleID.wbHalfpipeTruck, wbHalfpipeTruckRotation);
		vehicleMapRotations.Add (VehicleID.wbHeavyDutyTrailer, wbHeavyDutyTrailerRotation);
		vehicleMapRotations.Add (VehicleID.wbLittleFlatbedTruck, wbLittleFlabBedTruckRotation);
		vehicleMapRotations.Add (VehicleID.wbLittleHalfpipeTruck, wbLittleHalfpipeTruckRotation);
		vehicleMapRotations.Add (VehicleID.wbLowLoaderTrailer, wbLowLoaderTrailerRotation);
		vehicleMapRotations.Add (VehicleID.wbMiniExcavator, wbMiniExcavatorRotation);
		vehicleMapRotations.Add (VehicleID.wbPlattmaker, wbPlattmakerRotation);
		vehicleMapRotations.Add (VehicleID.wbRotaryDrillingRig, wbRotaryDrillingRigRotation);
		vehicleMapRotations.Add (VehicleID.wbTowerCrane, wbTowerCraneRotation);
		vehicleMapRotations.Add (VehicleID.wbTrailer, wbTrailerRotation);
		vehicleMapRotations.Add (VehicleID.wbTrailerFlatbed, wbTrailerFlatbedRotation);
		vehicleMapRotations.Add (VehicleID.wbTruckCrane, wbTruckCraneRotation);
		
		return vehicleMapRotations;
	}
}
