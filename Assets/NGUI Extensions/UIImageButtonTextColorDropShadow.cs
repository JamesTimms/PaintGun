//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Sample script showing how easy it is to implement a standard button that swaps colors must be used with UIImageButton.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Image Button Text Color DropShadow")]
public class UIImageButtonTextColorDropShadow : MonoBehaviour
{
	public UILabel[] target1;
	public UISprite[] target2;
	public Color normalColor = Color.white;
	public Color hoverColor = Color.white;
	public Color pressedColor = Color.white;
	public Color disabledColor = Color.white;
	public Color normalEffect = Color.black;
	public Color hoverEffect = Color.black;
	public Color pressedEffect = Color.black;
	public Color disabledEffect = Color.black;

	
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
			{
				l.color = UICamera.IsHighlighted(gameObject) ? hoverColor : normalColor;
				l.effectColor = UICamera.IsHighlighted(gameObject) ? hoverEffect : normalEffect;
			}
			foreach (UISprite s in target2)
				s.color = UICamera.IsHighlighted(gameObject) ? hoverColor : normalColor;
		}
		else
		{
			foreach (UILabel l in target1)
			{
				l.color = disabledColor;
				l.effectColor = disabledEffect;
			}
			foreach (UISprite s in target2)
				s.color = disabledColor;
		}	
	}

	void OnHover (bool isOver)
	{
		if (isEnabled)
		{
			foreach (UILabel l in target1)
			{
				l.color = isOver ? hoverColor : normalColor;
				l.effectColor = isOver ? hoverEffect : normalEffect;
			}
			foreach (UISprite s in target2)
				s.color = isOver ? hoverColor : normalColor;
		}
	}

	void OnPress (bool pressed)
	{
		if (pressed)
		{
			foreach (UILabel l in target1)
			{
				l.color = pressedColor;
				l.effectColor = pressedEffect;
			}
			foreach (UISprite s in target2)
				s.color = pressedColor;
		}
		else UpdateImage();
	}
}
