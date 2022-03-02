namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// This is a <see cref="ScriptableObject"/> that will store the application 
    /// variables that define the app state.
    /// </summary>
    /// <remarks>
    /// This variables will be updated as the application is running and will reflect
    /// its status or "state" as it is called in the programming lingo.
    /// </remarks>
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

        /// <summary>
        /// The number of activities that have started and ended (played/stopped).
        /// </summary>
        [Tooltip("The number of activities that have started and ended (played/stopped)")]
        [SerializeField]
        public int CompletedActivities;

        /// <summary>
        /// The proceeds currently collected.
        /// </summary>
        [Tooltip("The proceeds currently collected")]
        [SerializeField]
        public float CurrentProceeds;

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

            CompletedActivities = 0;

            CurrentProceeds = 0;

        }

        #endregion


        #region Unity Methods

        // This will be invoked when the asset is created
        private void Awake() {
			Restore();
		}

		#endregion


	}

}