using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class EnableSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public GameObject selector;

	public void OnPointerEnter (PointerEventData eventData)
	{
		selector.SetActive (true);
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		selector.SetActive (false);
	}
}