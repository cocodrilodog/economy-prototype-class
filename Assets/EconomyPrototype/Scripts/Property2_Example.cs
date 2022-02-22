using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property2_Example : MonoBehaviour
{

    private bool m_Up;

	private void Start() {
		//SetUp(true);
		Up = true;
		Debug.Log(Up);
	}

	public bool Up {
		get { 
			return m_Up;
		}
		set {
			m_Up = value;
			if (m_Up) {
				transform.position = new Vector3(3, 4, 0);
			} else {
				transform.position = new Vector3(3, 0, 0);
			}
		}
	}

	//public void SetUp(bool value) {
	//	// Assign the value
	//	m_Up = value;
	//	// Here I do some additional actions
	//	if (m_Up) {
	//		transform.position = new Vector3(3, 4, 0);
	//	} else {
	//		transform.position = new Vector3(3, 0, 0);
	//	}
	//}

	//public bool GetUp() {
	//	// Here I just return the value
	//	return m_Up;
	//}

}
