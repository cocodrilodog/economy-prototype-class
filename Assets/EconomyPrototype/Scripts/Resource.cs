namespace EconomyPrototype {

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public struct Resource {


		#region Public Fields

		[SerializeField]
        public float A;

        [SerializeField]
        public float B;

        [SerializeField]
        public float C;

		#endregion


		#region Operators

		public static Resource operator +(Resource resource1, Resource resource2) {
            Resource resultingResource = new Resource();
            resultingResource.A = resource1.A + resource2.A;
            resultingResource.B = resource1.B + resource2.B;
            resultingResource.C = resource1.C + resource2.C;
            return resultingResource;
        }

        public static Resource operator -(Resource resource1, Resource resource2) {
            Resource resultingResource = new Resource();
            resultingResource.A = resource1.A - resource2.A;
            resultingResource.B = resource1.B - resource2.B;
            resultingResource.C = resource1.C - resource2.C;
            return resultingResource;
        }

        #endregion


    }

}