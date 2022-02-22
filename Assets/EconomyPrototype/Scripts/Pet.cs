using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet
{
	// Static members reside in the class itself. If we stick to the 
	// mould-piece metaphor, a static member resides on the mould
	// whereas non-static members exist on the instances.
	//
	// There is only one copy of this property
	public static string DefaultSpecies = "Dog";

	public static float DefaultWeight = 1;

	public static Color DefaultColor = Color.white;

	// Non-static members exist on the instances and each instance can
	// have a unique value.
	//
	// In other words, each instance have its own copy of the non-static fields

	public string Species;

	public float Weight;

	public Color Color;

	// This is the constructor. It is optional and you may implement it if you
	// want to do some actions to initialize the instance.
	public Pet() {
		Debug.Log("Constructor of the pet");
		// Instances can use static members or in other words,
		// the created pieces have access to the information in the mould.
		Species = DefaultSpecies;
		Weight = DefaultWeight;
		Color = DefaultColor;
	}

}
