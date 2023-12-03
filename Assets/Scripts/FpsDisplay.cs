using TMPro;
using UnityEngine;

public class FpsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private float pollingTime = 0.2f;

    private float time;
    private int frameCount;


    void Update()
    {
        time += Time.deltaTime;
        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = $"FPS: {frameRate}";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
