using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueVsReference_Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // REFERENCE TYPE

        // I'm creating one instance, but two variables that point
        // towards that same instance.

        Pet someOtherPet = new Pet(); // <- Here the instace is created
        someOtherPet.Species = "Kangaroo";

        // This is the second variable, pointing to the same instance
        Pet possiblyIllegalPet = someOtherPet;

        // Here we can see they are equal
        Debug.Log($"someOtherPet:{someOtherPet.Species}");
        Debug.Log($"possiblyIllegalPet:{possiblyIllegalPet.Species}");

        // Testing what happens if I change the species in one of the 
        // variables
        possiblyIllegalPet.Species = "Koala";

        // But here we can confirm that both variables are referencing
        // the same instance
        Debug.Log($"someOtherPet:{someOtherPet.Species}");
        Debug.Log($"possiblyIllegalPet:{possiblyIllegalPet.Species}");

        // VALUE TYPE

        // Vector3 is a value type
        // Here I create a value
        Vector3 somePosition = new Vector3(1, 2, 3);
        // And here I assign it to other variable
        Vector3 otherPosition = somePosition;

        // Here I check that they are equal
        Debug.Log($"somePosition:{somePosition}");
        Debug.Log($"otherPosition:{otherPosition}");

        // I chage x to one of them
        otherPosition.x = -10;

        // In this case, here I confirm they are different entities.
        //
        // This happened because when I assigned somePosition to
        // otherPosition, a copy of the vector was created. Now they
        // are different and can have unique values.
        Debug.Log($"somePosition:{somePosition}");
        Debug.Log($"otherPosition:{otherPosition}");

    }

}
