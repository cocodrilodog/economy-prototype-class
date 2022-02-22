using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFormatting_Example : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

        string myName = "Gollum";
        int myAge = 360;

        string str1 = "My name is " + myName + " and I'm " + myAge + " years old.";
        Debug.Log(str1);

        string str2 = string.Format("My name is {0} and I'm {1} years old.", myName, myAge);
        Debug.Log(str2);

        string str3 = $"My name is {myName} and I'm {myAge} years old.";
        Debug.Log(str3);

    }

}
