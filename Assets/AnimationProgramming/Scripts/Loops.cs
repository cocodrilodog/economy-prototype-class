namespace AnimationProgramming {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Loops : MonoBehaviour {

        #region Public Fields

        public GameObject Prefab;

        #endregion


        #region Unity Methods

        // Start is called before the first frame update
        void Start() {
            Debug.Log("Just a for");

            //Standard for loop
            for (int counter = 0; counter < 10; counter++) {
                Debug.Log(Time.time + " i = " + counter);
            }

            Debug.Log("Reverse for");

            //Standard loop in reverse
            for (int counter = 9; counter >= 0; counter--) {
                Debug.Log(Time.time + " i = " + counter);
            }

            // While loop
            Debug.Log("While loop");

            // Declaring a variable
            int i = 0;
            // Evaluate the contidion
            while (i < 10) {
                // Increasing the counter
                i++;
                Debug.Log(Time.time + " i = " + i);
            }

            // Instantiate 10 cubes
            for (int j = 0; j < 10; j++) {
                GameObject clone = Instantiate(Prefab);
                clone.transform.localPosition = new Vector3(j * 2, 0, 0);
            }

        }

        #endregion


    }

}