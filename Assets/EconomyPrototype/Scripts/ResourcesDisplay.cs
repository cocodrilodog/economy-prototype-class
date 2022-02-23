namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class ResourcesDisplay : MonoBehaviour {


		#region Public Fields

		[SerializeField]
		public CurrentResources CurrentResources;

		#endregion


		#region Public Methods

		public void OnResourceChange() {
			m_Meters[0].fillAmount = CurrentResources.Current.A / 100;
			m_Meters[1].fillAmount = CurrentResources.Current.B / 100;
			m_Meters[2].fillAmount = CurrentResources.Current.C / 100;
		}

		#endregion


		#region Private Fields

		[SerializeField]
        private Image[] m_Meters;

		#endregion


	}

}