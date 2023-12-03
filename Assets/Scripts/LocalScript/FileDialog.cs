#if UNITY_EDITOR
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
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Выберите изображение", "", "png,jpg,jpeg", false);

        if (paths.Length > 0 && !string.IsNullOrEmpty(paths[0]))
        {
            callback.Invoke(paths[0]);
        }

        yield return null;
    }
}
#endif
