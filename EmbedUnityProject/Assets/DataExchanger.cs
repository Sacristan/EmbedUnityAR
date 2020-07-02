using UnityEngine;
using UnityEngine.UI;

public class DataExchanger : MonoBehaviour
{
    Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void ShowMessage(string message)
    {
        _text.text = message;
    }

    public void PassDataToAndroid()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        activity.CallStatic("setDataFromUnity", new object[] { _text.text });
    }
}