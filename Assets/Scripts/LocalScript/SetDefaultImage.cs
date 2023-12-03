using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetDefaultImage : MonoBehaviour
{
    [SerializeField] private Image defaultPhoto;
    [SerializeField] private Image avatar;

    public const string ImagePathKey = "SelectedImagePath";


    public void OnClick()
    {
        
        SetDefaultImagePath();
    }

    private void SetDefaultImagePath()
    {
        string defaultImagePath = Application.dataPath + "/Images/" + defaultPhoto.sprite.name + ".png";

        PlayerPrefs.SetString(ImagePathKey, defaultImagePath);
        PlayerPrefs.Save();

        avatar.sprite = defaultPhoto.sprite;

    }


}
