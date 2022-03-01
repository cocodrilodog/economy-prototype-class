namespace EconomyPrototype {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using TMPro;

	public class GameEndPopup : MonoBehaviour {


		#region Public Methods

		public void ShowMessage(string message) {
			m_Text.text = message;
		}

		#endregion


		#region Private Fields

		[SerializeField]
		private TMP_Text m_Text;

		#endregion


	}

}