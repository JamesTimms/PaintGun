//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Turns the popup list it's attached to into a language selection list.
/// </summary>

[RequireComponent(typeof(UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Select")]
public class LanguageSelect : MonoBehaviour
{
	UIPopupList mList;
	
	void Start()
	{
		mList = GetComponent<UIPopupList>();
		mList.eventReceiver = gameObject;
		mList.functionName = "OnLanguageSelection";
	}
	
	void OnLanguageSelection(string language)
	{
		if (Localization.instance != null)
		{
			for(int i = 0 ; i < mList.items.Count ; ++i)
				if (mList.items[i] == language)
				{
					Debug.Log(language + " " + Localization.instance.languages[i]);
					Localization.instance.currentLanguage = Localization.instance.languages[i].name;
				}
		}
	}
}