//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Sample script showing how easy it is to implement a standard button that swaps sprites.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Image Button Alt")]
public class UIImageButtonAlt : MonoBehaviour
{
	public UISprite target;
	public string normalSprite;
	public string altSprite;
	public string hoverSprite;
	public string pressedSprite;
	public string disabledSprite;
	
	public UILabel label;
	public Color normalColor = Color.white;
	public Color altColor = Color.white;
	public Color pressedColor = Color.white;
	public Color disabledColor = Color.white;
	public Color hoverColor = Color.white;
		
	[HideInInspector][SerializeField] public bool altState = false;
	
	public bool isEnabled
	{
		get
		{
			Collider col = collider;
			return col && col.enabled;
		}
		set
		{
			Collider col = collider;
			if (!col) return;

			if (col.enabled != value)
			{
				col.enabled = value;
				UpdateImage();
			}
		}
	}

	void Awake () { if (target == null) target = GetComponentInChildren<UISprite>(); }
	void OnEnable () { UpdateImage(); }
	
	void UpdateImage()
	{
		string baseSprite = normalSprite;
		if (altState == true)
			baseSprite = altSprite;
		
		Color baseCol = normalColor;
		if (altState == true)
			baseCol = altColor;
			
		if (target != null)
		{
			if (isEnabled)
			{
				target.spriteName = UICamera.IsHighlighted(gameObject) ? hoverSprite : baseSprite;
				if (label != null)
					label.color = UICamera.IsHighlighted(gameObject) ? hoverColor : baseCol;
			}
			else
			{
				target.spriteName = disabledSprite;
				if (label != null)
					label.color = disabledColor;
			}	
			target.MakePixelPerfect();
		}
	}

	void OnHover (bool isOver)
	{
		string baseSprite = normalSprite;
		if (altState == true)
			baseSprite = altSprite;
		
		Color baseCol = normalColor;
		if (altState == true)
			baseCol = altColor;
			
		if (isEnabled && target != null)
		{
			target.spriteName = isOver ? hoverSprite : baseSprite;
			if (label != null)
				label.color = isOver ? hoverColor : baseCol;
			target.MakePixelPerfect();
		}
	}
	
	public void SetAltState(bool alt)
	{
		altState = alt;
				
		UpdateImage();
	}

	void OnPress (bool pressed)
	{
		if (altState)
			return;
		
		if (pressed)
		{
			target.spriteName = pressedSprite;
			if (label != null)
				label.color = pressedColor;
			target.MakePixelPerfect();
		}
		else UpdateImage();
	}
}
