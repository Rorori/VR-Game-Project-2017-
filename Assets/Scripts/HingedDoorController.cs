using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingedDoorController : MonoBehaviour {

	private VRTK.VRTK_InteractableObject interactScript;

	// Use this for initialization
	void Start () {
		interactScript = GetComponent<VRTK.VRTK_InteractableObject> ();
		interactScript.isGrabbable = false;
	}

	// Door is unlocked and can be grabbed
	void UnlockHingedDoor() {
		interactScript.isGrabbable = true;
	}

	// Called when object containing script is created or enabled
	void OnEnable() {
		BoxPuzzleController.onPuzzleSolved += UnlockHingedDoor;
	}

	// Called when object is disabled or destroyed
	void OnDisable() {
		BoxPuzzleController.onPuzzleSolved -= UnlockHingedDoor;
	}
}
