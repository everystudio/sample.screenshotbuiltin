using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenshotHandlerBuiltin : ScreenshotHandlerBase
{
	private void Awake()
	{
		m_Camera = GetComponent<Camera>();
	}

	private void OnPostRender()
	{
		takeScreenshot(m_Camera);
	}

}
