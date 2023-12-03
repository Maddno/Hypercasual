using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#elif UNITY_ANDROID
using UnityEngine.Android;
#endif

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
        // Проверяем, работаем ли мы в Unity Editor (ПК)
        // или на Android-устройстве
#if UNITY_EDITOR
        OpenFilePanel();
#elif UNITY_ANDROID
        // Убедимся, что у нас есть необходимые разрешения на Android
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
            return;
        }
        OpenGallery();
#endif
    }

    private void OpenFilePanel()
    {
#if UNITY_EDITOR
        string path = UnityEditor.EditorUtility.OpenFilePanel("Выберите изображение", "", "png,jpg,jpeg");
        if (!string.IsNullOrEmpty(path))
        {
            PlayerPrefs.SetString(ImagePathKey, path);
            StartCoroutine(LoadImageFromPath(path));
        }
#endif
    }

    private void OpenGallery()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (!string.IsNullOrEmpty(path))
            {
                PlayerPrefs.SetString(ImagePathKey, path);
                StartCoroutine(LoadImageFromPath(path));
            }
        }, "Выберите изображение в формате PNG или JPEG", "image/*");

        // Обработка статуса разрешения (только для Android)
        if (permission == NativeGallery.Permission.Denied)
        {
            Debug.LogError("Отказано в разрешении на доступ к галерее");
        }
        else if (permission == NativeGallery.Permission.ShouldAsk)
        {
            Debug.Log("Необходимо запросить разрешение на доступ к галерее");
        }
    }

    IEnumerator LoadImageFromPath(string path)
    {
        byte[] imageData = File.ReadAllBytes(path);

        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(imageData);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;

        yield return null;
    }
}