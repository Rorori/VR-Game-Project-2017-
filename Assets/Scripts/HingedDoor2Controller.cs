using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingedDoor2Controller : MonoBehaviour {

	private VRTK.VRTK_InteractableObject interactScript;

	// Use this for initialization
	void Start () {
		interactScript = GetComponent<VRTK.VRTK_InteractableObject> ();
		interactScript.isGrabbable = false;
	}

	// Door is unlocked and can be grabbed
	void UnlockHingedDoor2() {
		interactScript.isGrabbable = true;
	}

	// Called when object containing script is created or enabled
	void OnEnable() {
		FinalBoxPuzzleController.onFinalPuzzleSolved += UnlockHingedDoor2;
	}

	// Called when object is disabled or destroyed
	void OnDisable() {
		FinalBoxPuzzleController.onFinalPuzzleSolved -= UnlockHingedDoor2;
	}
}
