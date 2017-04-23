﻿using UnityEngine; 
using System.Collections; 
using Vuforia; 
using System.Diagnostics; 
using Debug= UnityEngine.Debug;

public class detect : MonoBehaviour,
Vuforia.ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	public static int st=0;

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged (TrackableBehaviour.Status newStatus)
	{
		OnTrackableStateChanged (default(TrackableBehaviour.Status), newStatus);
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == null)
			throw new System.ArgumentNullException ("newStatus");
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			st=1;
			Application.LoadLevel("ControllerScene");
			print ("found");
		}        
		else
		{

		}
	}   
	static void print(){
		Debug.Log("st :" + st);
		print("st :" + st);
	}
}