namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class ResourcesDisplay : MonoBehaviour {


		#region Unity Methods

		private void Start() {
			m_Meters[0].fillAmount = 0.25f;
			m_Meters[1].fillAmount = 0.5f;
			m_Meters[2].fillAmount = 0.75f;
		}

		#endregion


		#region Private Fields

		[SerializeField]
        private Image[] m_Meters;

		#endregion


	}

}