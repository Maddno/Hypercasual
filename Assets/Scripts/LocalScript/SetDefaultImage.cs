using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetDefaultImage : MonoBehaviour
{
    [SerializeField] private Image defaultPhoto;
    [SerializeField] private Image avatar;

    private void Start()
    {
        SetDefaultImagePath();
    }

    public void SetDefaultImagePath()
    {
        if (defaultPhoto.sprite != null)
        {
            string ImagePathKey = "SelectedImagePath";
            string defaultImagePath = Application.dataPath + "/Images/" + defaultPhoto.sprite.name + ".png";
             
            PlayerPrefs.SetString(ImagePathKey, defaultImagePath);
            PlayerPrefs.Save();

            StartCoroutine(LoadImageFromPath(defaultImagePath));
        }
        else
        {
            Debug.LogError("Default photo sprite is not set!");
        }
    }

    private IEnumerator LoadImageFromPath(string path)
    {
        byte[] imageData = File.ReadAllBytes(path);

        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageData);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        avatar.sprite = sprite;

        yield return null;
    }
}
