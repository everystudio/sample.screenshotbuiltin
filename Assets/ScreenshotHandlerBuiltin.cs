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
		if (m_bTakeScreenshotNextFrame == false)
		{
			return;
		}

		m_bTakeScreenshotNextFrame = false;

		RenderTexture renderTexture = m_Camera.targetTexture;

		Texture2D renderResult = new Texture2D(
			renderTexture.width,
			renderTexture.height,
			TextureFormat.ARGB32,
			false);
		Rect rect = new Rect(0f, 0f, renderTexture.width, renderTexture.height);
		renderResult.ReadPixels(rect, 0, 0);

		onScreenshotTaken?.Invoke(renderResult);
		m_Camera.targetTexture = null;
	}
}
