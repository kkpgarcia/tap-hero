using UnityEngine;
using System.Collections;

public class RectTransformAnchorPositionTweener : Vector3Tweener 
{
	RectTransform RectTransform;
	
	void Awake ()
	{
		RectTransform = transform as RectTransform;
	}

	protected override void OnUpdate ()
	{
		base.OnUpdate ();
		RectTransform.anchoredPosition = CurrentTweenValue;
	}
}