using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP_Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // This changes the one and only copy of the static property
        // we are accessing it throught the class by typing Pet.DefaultSpecies
        Pet.DefaultSpecies = "Fish";

        // Here I create the first instance of the pet class (we can think of it
        // as the first piece out of the Pet mould)
        Pet myPet = new Pet();
		myPet.Species = "Cat";
		myPet.Color = Color.black;
        myPet.Weight = 4.5f;
        Debug.Log($"myPet: Species:{myPet.Species}; Color:{myPet.Color}; Weight:{myPet.Weight}");

        // Here I create the second instance of the Pet class or the second piece
        // out of the mould
        Pet brothersPet = new Pet();
		brothersPet.Species = "Parrot";
		brothersPet.Color = Color.green;
        brothersPet.Weight = 0.5f;
        Debug.Log($"brothersPet: Species:{brothersPet.Species}; Color:{brothersPet.Color}; Weight:{brothersPet.Weight}");

        // The third instance will get the default species value, as defined in the 
        // static field DefaulSpecies.
        //
        // Tha value is assigned in the constructor which is invoked like this: new Pet();
        Pet girlfriendsPet = new Pet();
        Debug.Log($"girlfriendsPet: Species:{girlfriendsPet.Species}; Color:{girlfriendsPet.Color}; Weight:{girlfriendsPet.Weight}");

    }

}
