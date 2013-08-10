//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using AnimationOrTween;

/// <summary>
/// Simple checkbox functionality. If 'option' is enabled, checking this checkbox will uncheck all other checkboxes with the same parent.
/// </summary>

[AddComponentMenu("NGUI/Interaction/RadioImage")]
public class UIRadioImage : MonoBehaviour
{
	static public UIRadioImage current;
	public UISprite target;
	public string normalSprite;
	public string pressedSprite;
	public delegate void OnStateChange (bool state);

	/// <summary>
	/// Whether the checkbox starts checked.
	/// </summary>

	public bool startsChecked = true;

	/// <summary>
	/// If the checkbox is part of a radio button group, specify the root object to use that all checkboxes are parented to.
	/// </summary>

	public Transform radioButtonRoot;

	/// <summary>
	/// Can the radio button option be 'none'?
	/// </summary>

	public bool optionCanBeNone = false;

	/// <summary>
	/// Generic event receiver that will be notified when the state changes.
	/// </summary>

	public GameObject eventReceiver;

	/// <summary>
	/// Function that will be called on the event receiver when the state changes.
	/// </summary>

	public string functionName = "OnActivate";

	/// <summary>
	/// Delegate that will be called when the checkbox's state changes. Faster than using 'eventReceiver'.
	/// </summary>

	public OnStateChange onStateChange;
	
	public Color normalColor = Color.white;
	public Color pressedColor = Color.white;
	public bool buttonEnabled = true;

	// Prior to 1.90 'option' was used to toggle the radio button group functionality
	[HideInInspector][SerializeField] bool option = false;

	bool mChecked = true;
	bool mStarted = false;
	Transform mTrans;

	Collider col;

	/// <summary>
	/// Whether the checkbox is checked.
	/// </summary>

	public bool isChecked
	{
		get { return mChecked; }
		set { if (radioButtonRoot == null || value || optionCanBeNone || !mStarted) Set(value); }
	}

	/// <summary>
	/// Legacy functionality support -- set the radio button root if the 'option' value was 'true'.
	/// </summary>

	void Awake ()
	{
		mTrans = transform;

		if (option)
		{
			option = false;
			if (radioButtonRoot == null) 
				radioButtonRoot = mTrans.parent;
		}
	}

	/// <summary>
	/// Activate the initial state.
	/// </summary>

	void Start ()
	{
		if (eventReceiver == null) 
			eventReceiver = gameObject;
		mChecked = !startsChecked;
		mStarted = true;
		if (target == null)
			target = GetComponentInChildren<UISprite>();
		col = gameObject.GetComponent<Collider>();
		col.enabled = buttonEnabled;
		enabled = buttonEnabled;

		Set(startsChecked);
		
	}

	/// <summary>
	/// Check or uncheck on click.
	/// </summary>

	void OnClick () { if (enabled) isChecked = !isChecked; }

	/// <summary>
	/// Fade out or fade in the checkmark and notify the target of OnChecked event.
	/// </summary>

	void Set (bool state)
	{
		if (!mStarted)
		{
			mChecked = state;
			startsChecked = state;
		}
		else 
		if (mChecked != state)
		{
			// Uncheck all other checkboxes
			if (radioButtonRoot != null && state)
			{
				UIRadioImage[] cbs = radioButtonRoot.GetComponentsInChildren<UIRadioImage>(true);

				for (int i = 0, imax = cbs.Length; i < imax; ++i)
				{
					UIRadioImage cb = cbs[i];
					if (cb != this && cb.radioButtonRoot == radioButtonRoot) cb.Set(false);
				}
			}

			// Remember the state
			mChecked = state;

			// Notify the delegate
			if (onStateChange != null) onStateChange(mChecked);

			// Send out the event notification
			if (eventReceiver != null && !string.IsNullOrEmpty(functionName))
			{
				current = this;
				eventReceiver.SendMessage(functionName, gameObject, SendMessageOptions.DontRequireReceiver);
			}
			target.spriteName = state ? pressedSprite : normalSprite;
			target.color = state ? pressedColor : col.enabled ? normalColor : Color.gray;
			target.MakePixelPerfect();
		}
	}

	public void ResetNormal()
	{
		target.spriteName = normalSprite;
		target.color = normalColor;
		target.MakePixelPerfect();
	}
}