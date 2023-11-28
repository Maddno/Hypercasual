using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadDefaultImage : MonoBehaviour
{
    [SerializeField] private Image avatar;

    private void Start()
    { 
        LoadDefaultImagePath();
    }

    private void LoadDefaultImagePath()
    {
        // Загружаем строку из PlayerPrefs
        string imageString = PlayerPrefs.GetString("AvatarImage", "");

        if (!string.IsNullOrEmpty(imageString))
        {
            // Преобразуем строку обратно в байты
            byte[] imageData = Convert.FromBase64String(imageString);

            // Создаем текстуру и загружаем в нее изображение
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);

            // Создаем спрайт и устанавливаем его для отображения в элементе Image
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            avatar.sprite = sprite;
        }
    }
}
