// (C) 2013 Ancient Light Studios. All rights reserved.
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

public abstract class SMPostRenderTransitionWithMobileShader : SMPostRenderTransition
{
	/// <summary>
	/// If true a simplified version of the shader will be used.
	/// </summary>
	public bool useSimplifiedShader;

	/// <summary>
	/// The screenshot for the simplified shader.
	/// </summary>
	[NonSerialized]
	protected Texture2D simplifiedShaderScreenshot;

	/// <summary>
	/// The actually used shader material.
	/// </summary>
	[NonSerialized]
	protected Material shaderMaterial;

	/// <summary>
	/// The material used for drawing the background.
	/// </summary>
	[NonSerialized]
	protected Material backgroundMaterial;

	/// <summary>
	/// The time it took to make a screenshot. Since this could be >500ms it can noticeably affect the transition.
	/// Therefore subclasses should use this value to compensate for the lag in their calculations.
	/// </summary>
	protected float simplifiedShaderLagCompensation;

	/// <summary>
	/// The name of the full shader (for non-mobile platforms). Defaults to "Back Buffer Copy".
	/// </summary>
	protected virtual string FullShaderName {
		get {
			return "Scene Manager/Back Buffer Copy";
		}
	}

	/// <summary>
	/// The name of the simplified shader (for mobile platforms). Defaults to FullShaderName + " Mobile";
	/// </summary>
	/// <value>The name of the simplified shader.</value>
	protected virtual string SimplifiedShaderName {
		get {
			return FullShaderName + " Mobile";
		}
	}

	/// <summary>
	/// The name of the shader to be used for drawing the background texture.
	/// </summary>
	/// <value>The name of the background shader.</value>
	protected virtual string BackgroundShaderName {
		get {
			return "Unlit/Texture";
		}
	}

	/// <summary>
	/// The name of the screen contents texture in the simplified shader.
	/// </summary>
	protected virtual string ScreenContentTextureName {
		get {
			return "_ScreenContent";
		}
	}

	/// <summary>
	/// Function called before actually taking a screenshot for the given phase. Can be used to optimize
	/// rendering times on mobile platforms. If this returns false, no screenshot will be taken in the
	/// given phase.
	/// </summary>
	protected virtual bool NeedsScreenshotForPhase(SMTransitionState state) {
		return true;
	}

	/// <summary>
	/// Prepares the materials. Make sure you call this in sublclasses
	/// </summary>
	protected override sealed void Prepare ()
	{
		if (useSimplifiedShader) {
			shaderMaterial = new Material(Shader.Find (SimplifiedShaderName));
		} else {
			shaderMaterial = new Material(Shader.Find (FullShaderName));
		}


		backgroundMaterial = new Material(Shader.Find(BackgroundShaderName));
		backgroundMaterial.mainTexture = holdMaterial.mainTexture;

		simplifiedShaderScreenshot = null;
		simplifiedShaderLagCompensation = 0f;

		DoPrepare ();
	}

	protected virtual void DoPrepare () {

	}

	protected override sealed void OnRender ()
	{
		if (useSimplifiedShader && simplifiedShaderScreenshot == null ) {
			if (NeedsScreenshotForPhase(state)) {
				simplifiedShaderLagCompensation = Time.realtimeSinceStartup;
				simplifiedShaderScreenshot = new Texture2D (Screen.width, Screen.height);
				simplifiedShaderScreenshot.mipMapBias = -10;
				simplifiedShaderScreenshot.filterMode = FilterMode.Point;
				simplifiedShaderScreenshot.anisoLevel = 1;
				simplifiedShaderScreenshot.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
				simplifiedShaderScreenshot.Apply ();
				shaderMaterial.SetTexture (ScreenContentTextureName, simplifiedShaderScreenshot);
				// compensate for loading time
				simplifiedShaderLagCompensation = Time.realtimeSinceStartup - simplifiedShaderLagCompensation;
			}
		}
		DoRender ();

	}

	protected abstract void DoRender ();

	/// <summary>
	/// Function which draws the background.
	/// </summary>
	protected virtual void DrawBackground ()
	{
		GL.PushMatrix();
		GL.LoadOrtho ();
		GL.LoadIdentity ();
		
		for (var i = 0; i < backgroundMaterial.passCount; ++i) {
			backgroundMaterial.SetPass (i);
			GL.Begin (GL.QUADS);
			GL.TexCoord3 (0, 0, 0);
			GL.Vertex3 (0, 0, -100);
			GL.TexCoord3 (0, 1, 0);
			GL.Vertex3 (0, 1, -100);
			GL.TexCoord3 (1, 1, 0);
			GL.Vertex3 (1, 1, -100);
			GL.TexCoord3 (1, 0, 0);
			GL.Vertex3 (1, 0, -100);
			GL.End ();
		}	
		GL.PopMatrix();
	}
}

