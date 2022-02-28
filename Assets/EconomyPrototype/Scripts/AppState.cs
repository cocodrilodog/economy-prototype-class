namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// This is a <see cref="ScriptableObject"/> that will store 
    /// the application variables that define the app state.
    /// </summary>
    [CreateAssetMenu(menuName = "Economy Prototype/App State")]
    public class AppState : ScriptableObject {


        #region Public Fields

        /// <summary>
        /// The amount of resources that are available at any moment in the life 
        /// cycle of the app.
        /// </summary>
        [Tooltip(
            "The amount of resources that are available at any moment in the " +
            "life cycle of the app"
        )]
        [SerializeField]
        public Resource CurrentResources;

        #endregion


        #region Public Methods

        /// <summary>
        /// Resets the app state to the desired default values.
        /// </summary>
        /// <remarks>
        /// Since the values of this scriptable object will change at runtime
        /// this method will help us to keep the default values stored in a place
        /// and reset them whenever we need to do so.
        /// </remarks>
        public void Restore() {
            CurrentResources.A = 100;
            CurrentResources.B = 100;
            CurrentResources.C = 100;
        }

        #endregion


        #region Unity Methods

        private void Awake() {
			Restore();
		}

		#endregion


	}

}