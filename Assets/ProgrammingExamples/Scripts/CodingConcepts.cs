using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingConcepts : MonoBehaviour
{

    // Class fields are defined in the class scope (inside the class brackets)
    // Public fields are visible insida and outside the class
    public string GreetMessage = "Hello";

    // Private fields are only visible in the class
    private string Password = "********";

    // Unity methods such as Start and Update are normally called automatically by the engine
    // Start is called at the beginning
    void Start()
    {
        // Local variables are inside of a method and are only visible from within that method

        string myName = "Juan";
        int myAge = 18;

        // The can be initialized
        float myHeight;
        myHeight = 1.75f;

        bool amIColombian = true;

        // Class fields are visible to all methods of a class
        Debug.Log(GreetMessage);

        // Test the different types of methods
        Greet(myName);
        PrintDate();
        float powerOfTwoOf10 = PowerOfTwo(10);
        Debug.Log("Result: " + powerOfTwoOf10);

    }
    
    // Update is called every frame
    private void Update()
    {

    }

    private void OtherMethod()
    {
        // Class fields are visible to all methods of a class
        Debug.Log(GreetMessage);
        // myName was defined in Start, so we can not see it here
        //Debug.Log(myName);
    }

    // A method with parameter and without return
    private void Greet(string name)
    {
        Debug.Log(GreetMessage + ", " + name);
    }

    // A method without parameter and without return
    private void PrintDate()
    {
        DateTime date = new DateTime();
        Debug.Log(date);
    }

    // A method with parameter and return
    private float PowerOfTwo(float baseNumber)
    {
        float result = baseNumber * baseNumber;

        // This is where we return a value!
        return result;
    }

}
