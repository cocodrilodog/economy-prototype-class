namespace AnimationProgramming {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ColorAnimator : MonoBehaviour {


		#region Public Fields

		public Renderer Renderer;
		public string ColorName = "_BaseColor";
		public Color TargetColor;
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

			Color currentColor = Renderer.material.GetColor(ColorName);
			float time = 0;

			while (time < Duration) {
				time += Time.deltaTime;
				float progress = time / Duration;
				Renderer.material.SetColor(ColorName, Color.Lerp(currentColor, TargetColor, progress));
				yield return null;
			}

		}

		#endregion


	}

}