using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetImageFromFile : MonoBehaviour
{
    public const string ImagePathKey = "SelectedImagePath";
    [SerializeField] private Image image;

    void Start()
    {
        if (PlayerPrefs.HasKey(ImagePathKey))
        {
            string savedPath = PlayerPrefs.GetString(ImagePathKey);
            StartCoroutine(LoadImageFromPath(savedPath));
        }
    }

    public void LoadImage()
    {
        var fileDialog = new GameObject("FileDialog").AddComponent<FileDialog>();
        fileDialog.OpenFileDialog((path) =>
        {
            if (!string.IsNullOrEmpty(path))
            {
                PlayerPrefs.SetString(ImagePathKey, path);

                StartCoroutine(LoadImageFromPath(path));
            }

            Destroy(fileDialog.gameObject); 
        });
    }
     
    IEnumerator LoadImageFromPath(string path)
    {
        byte[] imageData = File.ReadAllBytes(path);

        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageData);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;

        yield return null;
    }
}
