namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName ="Economy Prototype/Activity Profile")]
    public class ActivityProfile : ScriptableObject {


		#region Public Fields

		[SerializeField]
        public Resource ResourceConsumptionSpeed;

		#endregion


	}

}
