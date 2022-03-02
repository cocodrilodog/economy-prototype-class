namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// A profile for each activity.
    /// </summary>
    [CreateAssetMenu(menuName ="Economy Prototype/Activity Profile")]
    public class ActivityProfile : ScriptableObject {


		#region Public Fields

        /// <summary>
        /// How fast will the related activity spend resources.
        /// </summary>
        [Tooltip("How fast will the related activity spend resources")]
		[SerializeField]
        public Resource ResourceConsumptionSpeed;

        /// <summary>
        /// How fast will the related activity produce earnings.
        /// </summary>
        [Tooltip("How fast will the related activity produce earnings")]
        [SerializeField]
        public float ProceedsSpeed;

		#endregion


	}

}
