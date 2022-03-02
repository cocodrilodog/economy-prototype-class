namespace EconomyPrototype {

	using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ActivityChecks : MonoBehaviour {


        #region Public Fields

		[SerializeField]
		public AppSettings AppSettings;

        [SerializeField]
        public GameObject CheckPrefab;

		#endregion


		#region Public Fields

		public void EnableChecks(int count) {
			for(int i = 0; i < m_Checks.Count; i++) {
				if (i < count) {
					m_Checks[i].SetActive(true);
				} else {
					m_Checks[i].SetActive(false);
				}
			}
		}

		#endregion


		#region Unity Methods

		private void Awake() {

			// Create the list
			m_Checks = new List<GameObject>();

			for (int i = 0; i < AppSettings.MinActivities; i++) {
				
				// Create the activity GO instance
				GameObject activityCheck = Instantiate(CheckPrefab, transform);
				activityCheck.transform.localPosition = new Vector3(i * 120, 0, 0);

				// Find the child that has a check image by the name of the game object: "Check"
				Transform checkTransform = activityCheck.transform.Find("Check");

				// Store the check GO into a list
				m_Checks.Add(checkTransform.gameObject);

			}

			EnableChecks(0);

		}

		#endregion


		#region Private Fields

		[NonSerialized]
		private List<GameObject> m_Checks;

		#endregion


	}

}