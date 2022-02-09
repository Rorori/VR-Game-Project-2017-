using UnityEngine;

public class FinalBoxPuzzleController : MonoBehaviour {

	public delegate void OnFinalSolved ();

	public static event OnFinalSolved onFinalPuzzleSolved;

	public float tolerance;

	private GameObject mPlatform;
	private GameObject mBlock;
	private float mPlatHeight;

	// Use this for initialization
	void Start () {
		mPlatform = transform.Find ("Platform2").gameObject;
		mBlock = transform.Find ("Base").gameObject;
		mPlatHeight = mPlatform.GetComponent<Renderer> ().bounds.size.y;
	}


	//Return true if puzzle is solved.
	bool finalIsSolved() {
		Vector3 PlatPosition = mPlatform.transform.position;
		Vector3 BlockPosition = mBlock.transform.position;

		if (BlockPosition.y > PlatPosition.y
			&& (BlockPosition.y - PlatPosition.y) < mPlatHeight + tolerance
			&& Mathf.Abs (BlockPosition.x - PlatPosition.x) < tolerance
			&& Mathf.Abs (BlockPosition.z - PlatPosition.z) < tolerance) {
			// Block on top of platform

			if (onFinalPuzzleSolved != null) {
				// notify other game objects that the puzzle is solved
				onFinalPuzzleSolved ();
			}

			return true;
		}

		return false;
	}

	// Update is called once per frame
	void Update () {
		if (finalIsSolved () == true) {
			// the puzzle is solved. Turn the block's color a different color
			mBlock.GetComponent<Renderer> ().material.color = Color.green;
		}
	}
}
