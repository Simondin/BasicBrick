﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

	public void Quit(){
	
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#elif
		Application.Quit();
		#endif

	}
}