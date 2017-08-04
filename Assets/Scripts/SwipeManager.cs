using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection {
	None = 0,
	Up = 1
}

public class SwipeManager : MonoBehaviour {

	public float yResistance = 10.0f;
	public SwipeDirection Direction{get;set;}

	private static SwipeManager instance;
	public static SwipeManager GetInstance {get { return instance;}}

	private void Awake (){
		instance = this;
	}

	// Update is called once per frame
	void Update () {
		Direction = SwipeDirection.None;
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {				
				if (touch.phase == TouchPhase.Ended && touch.deltaPosition.y > yResistance) {
					Direction = SwipeDirection.Up;
				}
			}
		}
	}

	public bool IsSwiping() {
		return Direction != SwipeDirection.None;
	}
}
