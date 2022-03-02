namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

	/// <summary>
	/// The HUD object that displays the remaining amount of resources.
	/// </summary>
    public class ResourcesDisplay : MonoBehaviour {


		#region Public Fields

		/// <summary>
		/// A reference to the <see cref="EconomyPrototype.AppState"/> asset.
		/// </summary>
		[Tooltip("A reference to the AppState asset")]
		[SerializeField]
		public AppState AppState;

		#endregion


		#region Public Methods

		/// <summary>
		/// Updates the meter of each resource.
		/// </summary>
		/// <remarks>
		/// This is better than using Update, because updating UIs is expensive so we should
		/// only call this when the resources amount have changed. I this case, this is being
		/// called from <see cref="ActivityController.UpdatePlaybackTime"/>.
		/// </remarks>
		public void UpdateMeters() {
			m_Meters[0].fillAmount = AppState.CurrentResources.A / 100;
			m_Meters[1].fillAmount = AppState.CurrentResources.B / 100;
			m_Meters[2].fillAmount = AppState.CurrentResources.C / 100;
		}

		#endregion


		#region Private Fields

		[Tooltip("The image objects that will represent each resource")]
		[SerializeField]
        private Image[] m_Meters;

		#endregion


	}

}