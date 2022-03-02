namespace EconomyPrototype {

    using Cinemachine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
	using TMPro;
    using UnityEngine;

	/// <summary>
	/// This controls the activity game objects and is owned by
	/// <see cref="ActivitiesManager"/>.
	/// </summary>
	/// <remarks>
	/// This is in charge of creating a playback-like behaviour 
	/// to run the activities.
	/// </remarks>
    public class ActivityController : MonoBehaviour {


		#region Public Fields

		[Header("Data")]

		/// <summary>
		/// This is a reference to the <see cref="AppState"/> asset.
		/// </summary>
		[Tooltip("This is a reference to AppState asset.")]
		[SerializeField]
		public AppState AppState;

		/// <summary>
		/// This is the profile that will be used by this activity.
		/// </summary>
		[Tooltip("This is the profile that will be used by this activity")]
		[SerializeField]
		public ActivityProfile Profile;

		[Header("External Game Objects")]

		/// <summary>
		/// This is a reference to the UI object that is showing the current 
		/// resources status.
		/// </summary>
		[Tooltip(
			"This is a reference to the UI object that is showing the current " +
			"resources status"
		)]
		[SerializeField]
		public ResourcesDisplay ResourcesDisplay;

		[SerializeField]
		public ActivityChecks ActivityChecks;

		#endregion


		#region Public Methods

		/// <summary>
		/// Provides a reference to the internal virtual camera that belongs to 
		/// this activity.
		/// </summary>
		/// <returns></returns>
		public CinemachineVirtualCamera GetVCam() {
            return m_VCam;
		}

		/// <summary>
		/// Deactivates the activity playback controls.
		/// </summary>
		/// <remarks>
		/// This will stop the activity.
		/// </remarks>
		public void Deactivate() {
			m_PlaybackControls.SetActive(false);
			m_PauseButton.SetActive(false);
		}

		/// <summary>
		/// Actives the playback controls.
		/// </summary>
		public void Activate() {
			m_PlaybackControls.SetActive(true);
		}

		/// <summary>
		/// Stops the activity from running.
		/// </summary>
		/// <remarks>
		/// It makes the consumption of the resources to stop and
		/// it also resets the time of the playback.
		/// </remarks>
		public void Stop() {
			if (PlaybackTime > 0) {

				PlaybackTime = 0;
				
				Debug.Log("Stop");
				m_IsPlaying = false;
				m_PlayButton.SetActive(true);
				m_PauseButton.SetActive(false);

				AppState.CompletedActivities++;
				ActivityChecks.EnableChecks(AppState.CompletedActivities);

			}
		}

		/// <summary>
		/// Makes the activity to start running.
		/// </summary>
		public void Play() {
			Debug.Log("Play");
			m_IsPlaying = true;
			m_PlayButton.SetActive(false);
			m_PauseButton.SetActive(true);
			StartCoroutine(UpdatePlaybackTime());
		}

		/// <summary>
		/// Pauses the activity.
		/// </summary>
		public void Pause() {
			Debug.Log("Pause");
			m_IsPlaying = false;
			m_PlayButton.SetActive(true);
			m_PauseButton.SetActive(false);
		}

		#endregion


		#region Unity Methods

		private void Start() {
			Deactivate();
		}

		#endregion


		#region Private Fields - Serialized

		[Header("Components")]

		[Tooltip("The virtual camera that shows this activity when the activity is selected.")]
		[SerializeField]
		private CinemachineVirtualCamera m_VCam;

		[Tooltip("This contains the playback buttons")]
		[SerializeField]
		private GameObject m_PlaybackControls;

		[Tooltip("This shows the current time of the activity with time format.")]
		[SerializeField]
		private TMP_Text m_PlaybackTimeText;

		[Tooltip("The play button")]
		[SerializeField]
		private GameObject m_PlayButton;

		[Tooltip("The pause button")]
		[SerializeField]
		private GameObject m_PauseButton;

		#endregion


		#region Private Fields - Non Serialized

		[NonSerialized]
		private float m_PlaybackTime;

		[NonSerialized]
		private bool m_IsPlaying;

		#endregion


		#region Private Properties

		private float PlaybackTime {
			get {
				return m_PlaybackTime;
			}
			set {

				m_PlaybackTime = value;

				TimeSpan ts = TimeSpan.FromSeconds(m_PlaybackTime);
				m_PlaybackTimeText.text = string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds);

			}
		}

		#endregion


		#region Private Methods

		private IEnumerator UpdatePlaybackTime() {
			while (m_IsPlaying) {
				PlaybackTime += Time.deltaTime;
				AppState.CurrentResources = AppState.CurrentResources - Profile.ResourceConsumptionSpeed * Time.deltaTime;
				ResourcesDisplay.OnResourceChange();
				yield return null;
			}
		}

		#endregion


	}

}