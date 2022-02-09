using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialBlockController : MonoBehaviour {
    //units move doors per degree of dial rotation
	public float unitsPerDegree = 0.001f;

	//axis the doors will move on
	public Vector3 axis = Vector3.up;

	private GameObject mDoors;
	private GameObject mAntiDoors;
	private GameObject mDial;
	private Vector3 mPrevDialRotation;
	private float initDoorPosition;
	private float initAntiDoorPosition;
	private bool hasAntiDoorPassed = false;

	// Use this for initialization
	void Start () {
		//get references to our dial and block game objects
		mDoors = transform.Find ("Doors").gameObject;
		mAntiDoors = transform.Find ("AntiDoors").gameObject;
		GameObject handController = transform.Find ("HandController").gameObject;
		GameObject controllerBase = handController.transform.Find ("Base").gameObject;
		mDial = controllerBase.transform.Find ("Dial").gameObject;
		//get initial rotation angle of dial
		mPrevDialRotation = mDial.transform.localEulerAngles;
		initDoorPosition = mDoors.transform.position.y;
		initAntiDoorPosition = mAntiDoors.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		//get current rotation angle of dial
		Vector3 curDialRotation = mDial.transform.localEulerAngles;
		// IF the dial has rotated since the last frame update the position
		// of the block. Dial is rotating around the Y axis.
		if (curDialRotation != mPrevDialRotation) {
			float dialRotation = curDialRotation.y - mPrevDialRotation.y;


			//check if dial was rotated pase 12 oclock
			if (mPrevDialRotation.y > 270 && curDialRotation.y < 90) {
				// dial rotated clockwise past 12 oclock
				dialRotation += 360;

			} else if (mPrevDialRotation.y < 90 && curDialRotation.y > 270) {
				//dial rotated counterclockwise past 12 oclock
				dialRotation -= 360;
			}


			float doorsMoveDist;
			// take the value of the magnitude
			if (dialRotation < 0) {
				doorsMoveDist = unitsPerDegree * dialRotation * -1;
			} else {
				doorsMoveDist = unitsPerDegree * dialRotation;
			}


			//Move the doors
			if (mAntiDoors.transform.position.y <= initDoorPosition) {
				hasAntiDoorPassed = true;
			}
			if (mDoors.transform.position.y <= initDoorPosition) {
				hasAntiDoorPassed = false;
			}

			if (hasAntiDoorPassed) {
				mDoors.transform.Translate (axis * doorsMoveDist * -3);
				mAntiDoors.transform.Translate (axis * doorsMoveDist * 3);
			}
			else {
				mDoors.transform.Translate (axis * doorsMoveDist * 3);
				mAntiDoors.transform.Translate (axis * doorsMoveDist * -3);
			}

			mPrevDialRotation = curDialRotation;
		}
	}
}
