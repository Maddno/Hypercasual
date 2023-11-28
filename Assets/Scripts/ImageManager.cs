using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public const string ImagePathKey = "SelectedImagePath";
    private static ImageManager instance;

    // Этот метод позволяет получить доступ к объекту ImageManager из любого места кода
    public static ImageManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Ищем объект ImageManager в сцене
                instance = FindObjectOfType<ImageManager>();

                // Если объект не найден, создаем новый
                if (instance == null)
                { 
                    GameObject managerObject = new GameObject("ImageManager");
                    instance = managerObject.AddComponent<ImageManager>();
                }
            }
            return instance;
        }
    }

    private string selectedImagePath;

    private void Awake()
    {
        // Переносим объект между сценами
        DontDestroyOnLoad(gameObject);
    }

    public void SetSelectedImagePath(string path)
    {
        selectedImagePath = path;
    }

    public string GetSelectedImagePath()
    {
        return selectedImagePath;
    }
}
