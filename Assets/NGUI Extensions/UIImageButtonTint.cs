//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Sample script showing how easy it is to implement a standard button that swaps colors must be used with UIImageButton.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Image Button Tint")]
public class UIImageButtonTint : MonoBehaviour
{
	public UISprite target;
	public Color normalColor = Color.white;
	public Color hoverColor = Color.white;
	public Color pressedColor = Color.white;
	public Color disabledColor = Color.white;
	public Collider col;
	
	public bool isEnabled
	{
		get
		{
			return col && col.enabled;
		}
	}

	void Awake () { if (target == null) target = GetComponentInChildren<UISprite>(); }
	void OnEnable () { UpdateImage(); }
	void OnDisable () { UpdateImage(); }
	
	public void UpdateImage()
	{
		if (target != null)
		{
			if (isEnabled)
			{
				target.color = UICamera.IsHighlighted(gameObject) ? hoverColor : normalColor;
			}
			else
			{
				target.color = disabledColor;
			}	
			target.MakePixelPerfect();
		}
	}

	void OnHover (bool isOver)
	{
		if (isEnabled && target != null)
		{
			target.color = isOver ? hoverColor : normalColor;
			target.MakePixelPerfect();
		}
	}

	void OnPress (bool pressed)
	{
		if (pressed)
		{
			target.color = pressedColor;
			target.MakePixelPerfect();
		}
		else UpdateImage();
	}
}
