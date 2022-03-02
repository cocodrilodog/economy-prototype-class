namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// The general settings of the app.
    /// </summary>
    /// <remarks>
    /// These would normally be the variables that won't change during the app usage.
    /// </remarks>
    [CreateAssetMenu(menuName = "Economy Prototype/App Settings")]
    public class AppSettings : ScriptableObject {

        /// <summary>
        /// The duration of the session.
        /// </summary>
        [Tooltip("The duration of the session")]
        [SerializeField]
        public float SessionDuration;

        /// <summary>
        /// The minimum activities that the player must run in order not to lose when the time is over.
        /// </summary>
        [Tooltip("The minimum activities that the player must run in order not to lose when the time is over")]
        [SerializeField]
        public float MinActivities;

        /// <summary>
        /// The minimum proceeds that the player must collect in order not to lose when the time is over.
        /// </summary>
        [Tooltip("The minimum proceeds that the player must collect in order not to lose when the time is over")]
        [SerializeField]
        public float MinProceeds;

    }

}
