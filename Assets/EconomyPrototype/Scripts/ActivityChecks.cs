namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ActivityChecks : MonoBehaviour {


        #region Public Fields

        [SerializeField]
        public GameObject CheckPrefab;

		#endregion


		#region Unity Methods

		private void Awake() {
			GameObject activityCheck = Instantiate(CheckPrefab, transform);
		}

		#endregion


	}

}