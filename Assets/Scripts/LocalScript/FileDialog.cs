using SFB;
using System.Collections;
using UnityEngine;

public class FileDialog : MonoBehaviour
{
    public void OpenFileDialog(System.Action<string> callback)
    {
        StartCoroutine(ShowDialog(callback));
    }

    IEnumerator ShowDialog(System.Action<string> callback)
    {
        string path = StandaloneFileBrowser.OpenFilePanel("Выберите изображение", "", "png,jpg,jpeg", false)[0];

        callback.Invoke(path);

        yield return null;
    }
}
