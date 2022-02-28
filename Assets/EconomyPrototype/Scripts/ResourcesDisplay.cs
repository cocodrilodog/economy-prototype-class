namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class ResourcesDisplay : MonoBehaviour {


		#region Public Fields

		[SerializeField]
		public AppState CurrentResources;

		#endregion


		#region Public Methods

		public void OnResourceChange() {
			m_Meters[0].fillAmount = CurrentResources.CurrentResources.A / 100;
			m_Meters[1].fillAmount = CurrentResources.CurrentResources.B / 100;
			m_Meters[2].fillAmount = CurrentResources.CurrentResources.C / 100;
		}

		#endregion


		#region Private Fields

		[SerializeField]
        private Image[] m_Meters;

		#endregion


	}

}