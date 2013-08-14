//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Sample script showing how easy it is to implement a standard button that swaps colors must be used with UIImageButton.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Image Button Text Color")]
public class UIImageButtonTextColor : MonoBehaviour
{
	public UILabel[] target1;
	public UISprite[] target2;
	public Color normalColor = Color.white;
	public Color hoverColor = Color.white;
	public Color pressedColor = Color.white;
	public Color disabledColor = Color.white;
	
	public bool isEnabled
	{
		get
		{
			Collider col = collider;
			return col && col.enabled;
		}
	}

	void OnEnable () 
	{ 
		UpdateImage(); 
	}
	
	void UpdateImage()
	{
		if (isEnabled)
		{
			foreach (UILabel l in target1)
				l.color = UICamera.IsHighlighted(gameObject) ? hoverColor : normalColor;
			foreach (UISprite s in target2)
				s.color = UICamera.IsHighlighted(gameObject) ? hoverColor : normalColor;
		}
		else
		{
			foreach (UILabel l in target1)
				l.color = disabledColor;
			foreach (UISprite s in target2)
				s.color = disabledColor;
		}	
	}

	void OnHover (bool isOver)
	{
		if (isEnabled)
		{
			foreach (UILabel l in target1)
				l.color = isOver ? hoverColor : normalColor;
			foreach (UISprite s in target2)
				s.color = isOver ? hoverColor : normalColor;
		}
	}

	void OnPress (bool pressed)
	{
		if (pressed)
		{
			foreach (UILabel l in target1)
				l.color = pressedColor;
			foreach (UISprite s in target2)
				s.color = pressedColor;
		}
		else UpdateImage();
	}
}
