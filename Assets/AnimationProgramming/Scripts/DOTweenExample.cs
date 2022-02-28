namespace AnimationProgramming {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using DG.Tweening;

	public class DOTweenExample : MonoBehaviour {


		#region Public Fields

		public Renderer Renderer;

		public Color TargetColor;

		#endregion


		#region Unity Methods

		// Start is called before the first frame update
		void Start() {

			// Generic way
			//DOTween.To(() => transform.localPosition, p => transform.localPosition = p, new Vector3(3, 0, 0), 2);

			// Shortcuts way
			transform.DOMoveX(3, 2).SetEase(Ease.OutElastic).SetDelay(1).OnComplete(() => Debug.Log("Complete"));
			Renderer.material.DOColor(TargetColor, 2).SetDelay(1);

		}

		#endregion


	}

}