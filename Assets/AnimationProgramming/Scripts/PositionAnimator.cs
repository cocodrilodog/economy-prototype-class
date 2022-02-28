namespace AnimationProgramming {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class PositionAnimator : MonoBehaviour {


		#region Public Fields

		public Vector3 TargetPosition;
		public float Duration;
		public AnimationCurve Curve;
		public bool AnimateOnStart;

		#endregion


		#region Public Methods

		public void Animate() {
			StartCoroutine(_Animate());
		}

		#endregion


		#region Unity Methods

		private void Start() {
			if (AnimateOnStart) {
				Animate();
			}
		}

		#endregion


		#region Private Methods

		private IEnumerator _Animate() {

			Vector3 currentPosition = transform.position;
			float time = 0;

			while (time < Duration) {
				time += Time.deltaTime;
				float progress = time / Duration;
				transform.localPosition = Vector3.Lerp(currentPosition, TargetPosition, Curve.Evaluate(progress));
				yield return null;
			}

		}

		#endregion


	}

}