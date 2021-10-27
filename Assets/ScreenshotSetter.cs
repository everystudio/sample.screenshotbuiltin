using UnityEngine;
using UnityEngine.UI;

public class ScreenshotSetter : MonoBehaviour
{
	[SerializeField]
	private ScreenshotHandlerBuiltin m_screenshotHandler;
	[SerializeField]
	private RawImage m_img;

	public void TakeScreenshot()
	{
		m_screenshotHandler.TakeScreenshot(100,100,(tex2d) =>
		{
			Texture2D temp = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			temp.LoadImage(tex2d.EncodeToPNG());
			m_img.texture = temp;
		});
	}

}
