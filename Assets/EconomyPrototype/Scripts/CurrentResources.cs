namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Economy Prototype/Current Resources")]
    public class CurrentResources : ScriptableObject {


        #region Public Fields

        [SerializeField]
        public Resource Current;

        #endregion


        #region Public Methods

        public void Restore() {
            Current.A = 100;
            Current.B = 100;
            Current.C = 100;
        }

        #endregion


        #region Unity Methods

        private void Awake() {
			Restore();
		}

		#endregion


	}

}