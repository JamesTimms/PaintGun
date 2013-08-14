//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// Inspector class used to edit UISprites.
/// </summary>

[CustomEditor(typeof(UIImageButtonAlt))]
public class UIImageButtonAltInspector : Editor
{
	UIImageButtonAlt mButton;
	UISprite mSprite;
	UILabel mLabel;
	/// <summary>
	/// Atlas selection callback.
	/// </summary>

	void OnSelectAtlas (MonoBehaviour obj)
	{
		if (mButton.target != null)
		{
			NGUIEditorTools.RegisterUndo("Atlas Selection", mButton.target);
			mButton.target.atlas = obj as UIAtlas;
			mButton.target.MakePixelPerfect();
		}
	}

	public override void OnInspectorGUI ()
	{
		EditorGUIUtility.LookLikeControls(80f);
		mButton = target as UIImageButtonAlt;
		mSprite = EditorGUILayout.ObjectField("Sprite", mButton.target, typeof(UISprite), true) as UISprite;
		mLabel = EditorGUILayout.ObjectField("Label", mButton.label, typeof(UILabel), true) as UILabel;
		
		if (mButton.target != mSprite)
		{
			NGUIEditorTools.RegisterUndo("Image Button Change", mButton);
			mButton.target = mSprite;
			if (mSprite != null) mSprite.spriteName = mButton.normalSprite;
		}
		
		if (mButton.label != mLabel)
		{
			NGUIEditorTools.RegisterUndo("Image Button Change", mButton);
			mButton.label = mLabel;
		}
		
		

		if (mSprite != null)
		{
			ComponentSelector.Draw<UIAtlas>(mSprite.atlas, OnSelectAtlas);

			if (mSprite.atlas != null)
			{
				NGUIEditorTools.SpriteField("Normal", mSprite.atlas, mButton.normalSprite, OnNormal);
				NGUIEditorTools.SpriteField("Alt", mSprite.atlas, mButton.altSprite, OnAlt);
				NGUIEditorTools.SpriteField("Hover", mSprite.atlas, mButton.hoverSprite, OnHover);
				NGUIEditorTools.SpriteField("Pressed", mSprite.atlas, mButton.pressedSprite, OnPressed);
				NGUIEditorTools.SpriteField("Disabled", mSprite.atlas, mButton.disabledSprite, OnDisabled);
			}
		}
		
		if (mLabel != null)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("Normal Text Color", GUILayout.Width(120f));
			mButton.normalColor = EditorGUILayout.ColorField(mButton.normalColor);
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.Label("Alt Text Color", GUILayout.Width(120f));
			mButton.altColor = EditorGUILayout.ColorField(mButton.altColor);
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.Label("Pressed Text Color", GUILayout.Width(120f));
			mButton.pressedColor = EditorGUILayout.ColorField(mButton.pressedColor);
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.Label("Diabled Text Color", GUILayout.Width(120f));
			mButton.disabledColor = EditorGUILayout.ColorField(mButton.disabledColor);
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.Label("Hover Text Color", GUILayout.Width(120f));
			mButton.hoverColor = EditorGUILayout.ColorField(mButton.hoverColor);
			GUILayout.EndHorizontal();
		}
	}

	void OnNormal (string spriteName)
	{
		NGUIEditorTools.RegisterUndo("Image Button Change", mButton, mButton.gameObject, mSprite);
		mButton.normalSprite = spriteName;
		mSprite.spriteName = spriteName;
		mSprite.MakePixelPerfect();
		if (mButton.collider == null || (mButton.collider is BoxCollider)) NGUITools.AddWidgetCollider(mButton.gameObject);
		Repaint();
	}
	
	void OnAlt (string spriteName)
	{
		NGUIEditorTools.RegisterUndo("Image Button Change", mButton, mButton.gameObject, mSprite);
		mButton.altSprite = spriteName;
		Repaint();
	}

	void OnHover (string spriteName)
	{
		NGUIEditorTools.RegisterUndo("Image Button Change", mButton, mButton.gameObject, mSprite);
		mButton.hoverSprite = spriteName;
		Repaint();
	}

	void OnPressed (string spriteName)
	{
		NGUIEditorTools.RegisterUndo("Image Button Change", mButton, mButton.gameObject, mSprite);
		mButton.pressedSprite = spriteName;
		Repaint();
	}
	
	void OnDisabled(string spriteName)
	{
		NGUIEditorTools.RegisterUndo("Image Button Change", mButton, mButton.gameObject, mSprite);
		mButton.disabledSprite = spriteName;
		Repaint();
	}
}
