namespace EconomyPrototype {

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// The unit that will help us to count the consumption of the resources.
    /// </summary>
    [Serializable]
    public struct Resource {


        #region Public Fields

        /// <summary>
        /// Any resource. For the example it is named "A".
        /// </summary>
        [Tooltip("Any resource. For the example it is named \"A\" ")]
		[SerializeField]
        public float A;

        /// <summary>
        /// Any resource. For the example it is named "B".
        /// </summary>
        [Tooltip("Any resource. For the example it is named \"B\" ")]
        [SerializeField]
        public float B;

        /// <summary>
        /// Any resource. For the example it is named "C".
        /// </summary>
        [Tooltip("Any resource. For the example it is named \"C\" ")]
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

        public static Resource operator *(Resource resource, float value) {
            Resource product = new Resource();
            product.A = resource.A * value;
            product.B = resource.B * value;
            product.C = resource.C * value;
            return product;
        }

		public static Resource operator *(float value, Resource resource) {
			Resource product = new Resource();
			product.A = resource.A * value;
			product.B = resource.B * value;
			product.C = resource.C * value;
			return product;
		}

		#endregion


	}

}