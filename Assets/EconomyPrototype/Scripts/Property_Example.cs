using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property_Example : MonoBehaviour
{
    // The property style
    public bool Up {
		get {
            Debug.Log("(Property style): Getting the value of Up: " + m_Up);
            return m_Up;
		}
		set {
            // value is the value that I'm assigning when I write Up = true
            m_Up = value;
            // Additional to setting a value, I can do some more actions
            if (m_Up) {
                // Like moving the object up
                transform.position = new Vector3(0, 4, 0);
            } else {
                // Or moving it down
                transform.position = new Vector3(0, 0, 0);
            }
            Debug.Log("(Property style): Setting a value of Up: " + m_Up);
		}
	}

    // The methods style
    public bool GetUp() {
        Debug.Log("(Method style): Getting the value of Up: " + m_Up);
        return m_Up;
    }

    public void SetUp(bool value) {
        m_Up = value;
        if (m_Up) {
            transform.position = new Vector3(0, 4, 0);
        } else {
            transform.position = new Vector3(0, 0, 0);
        }
        Debug.Log("(Method style): Setting a value of Up: " + m_Up);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Here I read the value of the property which in turn executes the "get" part
        bool localUp = Up;
        // This is the same as
        localUp = GetUp();

        // Here I write the value of the property which in turn executes the "set" part
        Up = true;
        // This is the same as
        SetUp(true);

    }

    private bool m_Up;

}
