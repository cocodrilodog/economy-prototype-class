namespace EconomyPrototype {

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Cinemachine;
    using UnityEngine.UI;

    /// <summary>
    /// The main object that will manage the activities app.
    /// </summary>
    /// <remarks>
    /// This chooses which is the current activity.
    /// </remarks>
    public class ActivitiesManager : MonoBehaviour {


        #region Public Fields

        [Header("Data")]

        /// <summary>
        /// A reference to the <see cref="EconomyPrototype.AppSettings"/> asset.
        /// </summary>
        [Tooltip("A reference to the AppSettings asset")]
		[SerializeField]
        public AppSettings AppSettings;

        /// <summary>
        /// A reference to the <see cref="EconomyPrototype.AppState"/> asset.
        /// </summary>
        [Tooltip("A reference to the AppState asset")]
		[SerializeField]
        public AppState AppState;

        [Header("UI")]

        /// <summary>
        /// An image that fills radially, like a clock
        /// </summary>
        [Tooltip("An image that fills radially, like a clock")]
        [SerializeField]
        public Image Clock;

        /// <summary>
        /// The popup that is shown at the end of the game.
        /// </summary>
        [Tooltip("The popup that is shown at the end of the game.")]
        [SerializeField]
        public GameEndPopup GameEndPopup;

		#endregion


		#region Public Methods

        /// <summary>
        /// Closes the the current activity.
        /// </summary>
		public void CloseCurrentActivity() {
            CurrentActivityController = null;
		}

        /// <summary>
        /// Handles the click event raised by each of the activities.
        /// </summary>
        /// <param name="newActivityController">
        /// The activity controller that raised the event.
        /// </param>
		public void Activity_PointerClick(ActivityController newActivityController) {
            if(newActivityController == CurrentActivityController) {
                // If the new activity is the current one we go back to the main camera
                CurrentActivityController = null;
            } else {
                // If the new activity is different from the current one, we choose its camera
                CurrentActivityController = newActivityController;
			}
		}

		#endregion


		#region Unity Methods

		private void Start() {
            GameEndPopup.gameObject.SetActive(false);
            StartCoroutine(UpdateSession());
            StartCoroutine(CheckResources());
		}

		private void OnDestroy() {
            AppState.Restore();
		}

		#endregion


		#region Private Fields

		[NonSerialized]
        private ActivityController m_CurrentActivity;

		#endregion


		#region Private Properties

		private ActivityController CurrentActivityController {
            get {
                return m_CurrentActivity;
			}
			set {

                // If there is one current activity, I want to deactivate its camera
				if (m_CurrentActivity != null) {
                    m_CurrentActivity.GetVCam().Priority = 9;
                    m_CurrentActivity.Stop();
                    m_CurrentActivity.Deactivate();
                }

                // Now we are receiving the new activity which can be an activity or null
                m_CurrentActivity = value;

                // If the new activity is not null, its camera becomes the one with the highest priority
                if(m_CurrentActivity != null) {
                    m_CurrentActivity.GetVCam().Priority = 11;
                    m_CurrentActivity.Activate();
                }

                // The main camera has a priority of 10 which we are using as a middle point
                // The logic here is to change the priority of the activity cameras to be either
                // higher or lower than the main vcam (9 or 11)

                // In this example, The Current camera is the activity #1 vcam
                //------------------------------------------------
                // P 11         [A2 VCam]
                //------------------------------------------------
                // P 10                 [M VCam]
                //------------------------------------------------
                // P 9      [A1 VCam]           [A3 VCam] 
                //------------------------------------------------


                // In this example, The Current camera is null, so the main camera renders the scene
                //------------------------------------------------
                // P 11         
                //------------------------------------------------
                // P 10                 [M VCam]
                //------------------------------------------------
                // P 9      [A1 VCam]   [A2 VCam]   [A3 VCam] 
                //------------------------------------------------

            }
        }

		#endregion


		#region Private Methods

        private IEnumerator UpdateSession() {

            // This is my time variable
            float time = 0;

            // The while loop will repeat itself until time reaches the session duration
			while (time < AppSettings.SessionDuration) { 

                // Increase the time here
                time = time + Time.deltaTime;

                // A number from 0 to 1 that shows the progress of the time
                // with respect to the duration
                float progress = time / AppSettings.SessionDuration;
                // Now we use that number to fill the clock
                Clock.fillAmount = progress;

                // Make the while loop to wait for one frame to continue
                yield return null;

			}

            // The session ends here
            TimeOut();

		}

        private void TimeOut() {

            // Freeze time
            Time.timeScale = 0;
            // Show popup
            GameEndPopup.gameObject.SetActive(true);

            if (AppState.CompletedActivities >= AppSettings.MinActivities && 
                AppState.CurrentProceeds >= AppSettings.MinProceeds) {
                // Here I win
                GameEndPopup.ShowMessage(
                    $"You won!\nYou completed {AppSettings.MinActivities} activities or more and you collected {AppSettings.MinProceeds} proceeds."
                );
			} else {
                // Here I lose
                //
                // Create a composite string
                string message = "You Lose :(";
                // It may be due to few activities
                if(AppState.CompletedActivities < AppSettings.MinActivities) {
                    message += $"\nYou didn't complete at least {AppSettings.MinActivities} activities.";
                }
                // and / or because not enough proceeds
                if (AppState.CurrentProceeds < AppSettings.MinProceeds) {
                    message += $"\nYou didn't collect at least {AppSettings.MinProceeds} proceeds.";
                }
                GameEndPopup.ShowMessage(message);
            }

        }

        private IEnumerator CheckResources() {
            // This will be running as long as the 3 resources are greater than 0.
            while(AppState.CurrentResources.A > 0 && AppState.CurrentResources.B > 0 && AppState.CurrentResources.C > 0) {
                // We can check this less frequently than every frame, so every 0.2 secs
                yield return new WaitForSeconds(0.2f);
			}
            // When that condition is not met anymore, the following line will run.
            // This is when any resource was fully spent
            OutOfResources();
		}

        private void OutOfResources() {

            // Freeze time
            Time.timeScale = 0;
            // Show popup
            GameEndPopup.gameObject.SetActive(true);

            GameEndPopup.ShowMessage($"You lose :(\nYou ran out of resources.");

        }

		#endregion


	}

}
