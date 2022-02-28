namespace ProgrammingExamples {

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ArrayAndList_Example : MonoBehaviour {

        [SerializeField]
        public GameObject Prefab;

        public void ShrinkSphere(int index) {
            // Choose the sphere at the index and make it smaller
            m_SpheresArray[index].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        public void ShrinkHalfOfTheSpheres() {
            // Make half of the spheres smaller
            for (int i = 0; i < m_SpheresArray.Length / 2; i++) {
                m_SpheresArray[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }

        public void AddSphere() {

            // Create a new sphere
            GameObject newSphere = Instantiate(Prefab);

            // This is the number of the last sphere in the list
            int lastSphereIndex = m_SpheresList.Count - 1;

            // Now that we have the index, we can use it to obtain a
            // reference to the last sphere
            GameObject lastSphere = m_SpheresList[lastSphereIndex];

            // We copy the position of the loast sphere
            Vector3 pos = lastSphere.transform.position;

            // Move it one unit to the right
            pos.x = pos.x + 1;

            // Assign it to the new sphere
            newSphere.transform.position = pos;

            // Add it to the list. Now this one becomes the last one of the list.
            m_SpheresList.Add(newSphere);

        }

        public void RemoveSphere() {

            // Obtain tha last index in the list or the index of the last sphere
            int lastSphereIndex = m_SpheresList.Count - 1;

            // Use that index to obtain a reference to the sphere object
            GameObject lastSphere = m_SpheresList[lastSphereIndex];

            // This is one way of removing the entry from the list, but this
            // doesn't destroy the sphere
            //m_SpheresList.Remove(lastSphere);

            // This is another way of removing the entry on the list. It doesn't
            // destroy the sphere either
            m_SpheresList.RemoveAt(lastSphereIndex);

            // Once I have removed that entry from the list I can destroy the 
            // sphere game object
            Destroy(lastSphere);

        }

        private void Start() {

            // This is an array of game objects. Here we initialize it.
            // Arrays have fixed size.
            m_SpheresArray = new GameObject[10]; // 10 is the size of the array

            // Now that we know the length or size of the array, we can do a for loop
            // to assign values to each of the positions in the array
            for (int i = 0; i < m_SpheresArray.Length; i++) {
                m_SpheresArray[i] = Instantiate(Prefab);
                m_SpheresArray[i].transform.position = new Vector3(i, 0, 0);
            }

            // This is a list which is another way of storing a ste of objects.
            // One key difference is that it can change its size with the Add/Remove
            // methods.
            m_SpheresList = new List<GameObject>();

            // Here we create 3 spheres to begin with.
            for (int i = 0; i < 3; i++) {
                // Create the sphere instance and store it in a local variable
                GameObject sphere = Instantiate(Prefab);
                // Add it to the list
                m_SpheresList.Add(sphere);
                sphere.transform.position = new Vector3(i, 2, 0);
                // Now that it has been added you can access it through the [i] way
                Debug.Log(m_SpheresList[i]);
            }

        }

        [NonSerialized]
        private GameObject[] m_SpheresArray;

        [NonSerialized]
        private List<GameObject> m_SpheresList;

    }

}
