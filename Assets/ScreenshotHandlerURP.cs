using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScreenshotHandlerURP : ScreenshotHandlerBase
{
	public string m_cameraName;

	void OnEnable()
	{
		RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
	}

	void OnDisable()
	{
		RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
	}

	void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
	{
		if (camera.gameObject.name == m_cameraName)
		{
			m_Camera = camera;
		}
	}

	void OnRenderObject()
	{
		if (m_Camera != null)
		{
			takeScreenshot(m_Camera);
		}
	}
}

