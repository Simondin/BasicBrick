using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour {

	public float paddleSpeed = 1f;
	public GameObject ball;
	public float yInitPos = -9.5f;
	public static float xPos = 0f;

	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);


	void Update () 
	{
		#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if(Input.mousePresent){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
				xPos = hit.point.x;
			}
		} else {
			xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);	
		}


		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		if(Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Stationary) || Input.GetTouch(0).TouchPhase == TouchPhase.Moved){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
				xPos = hit.point.x;
			}
		}

		#endif

		playerPos = new Vector3 (Mathf.Clamp (xPos, -7.5f, 7.5f), yInitPos, 0f);
		transform.position = playerPos;
	}

	void OnDestroy() {
		Destroy (ball);
	}
}
