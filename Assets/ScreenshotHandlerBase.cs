using UnityEngine;

public abstract class ScreenshotHandlerBase : MonoBehaviour
{
	protected bool m_bTakeScreenshotNextFrame;
	protected System.Action<Texture2D> onScreenshotTaken;

	protected Vector2Int m_RequestSize;
	protected Camera m_Camera;
	protected virtual void setCameraTargetTexture(int _iWidth, int _iHeight)
	{
		m_RequestSize = new Vector2Int(_iWidth, _iHeight);
		if (m_Camera != null)
		{
			m_Camera.targetTexture = RenderTexture.GetTemporary(
				_iWidth,
				_iHeight, 16);
		}
	}

	public bool TakeScreenshot(int _iWidth, int _iHeight, System.Action<Texture2D> _onTaken)
	{
		if (m_bTakeScreenshotNextFrame)
		{
			Debug.LogError("Screen Shot can 1 time by 1 Render!");
			return false;
		}
		setCameraTargetTexture(_iWidth, _iHeight);

		m_bTakeScreenshotNextFrame = true;
		onScreenshotTaken = _onTaken;
		return true;
	}
	public bool TakeScreenshot(int _iWidth, int _iHeight)
	{
		return TakeScreenshot(_iWidth, _iHeight, (tex2d) => { });
	}

	public bool TakeScreenshotScreenSize(System.Action<Texture2D> _onTake)
	{
		return TakeScreenshot(Screen.width, Screen.height, _onTake);
	}

	public bool SaveScreenshot(int _iWidth, int _iHeight, string _strFilePath, System.Action _onFinished)
	{
		return TakeScreenshotScreenSize((tex2d) => {
			byte[] byteArr = tex2d.EncodeToPNG();
			System.IO.File.WriteAllBytes(_strFilePath, byteArr);
			_onFinished.Invoke();
		});
	}

	public bool SaveScreenshotScreenSize(string _strFilePath, System.Action _onFinished)
	{
		return SaveScreenshot(Screen.width, Screen.height, _strFilePath, _onFinished);
	}

	public void SaveScreenshotSimple()
	{
		SaveScreenshotScreenSize(Application.dataPath + "/current.png" , ()=> { });
	}
}
