using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorEffect : MonoBehaviour
{
    private Image image;
    void Awake()
    {
        image = GetComponent<Image>();
        // Debug.Log(image.ToString());
    }

    IEnumerator Fade(Color to, float duration, System.Action callback) {
        float startTime = Time.time;
        float t = (Time.time - startTime)/duration;
        Color from = image.color;
        Debug.Log(t);
        while (t < 1) {
            image.color = Color.Lerp(from, to, t);
            yield return null;
            t = (Time.time - startTime)/duration;
            // Debug.Log(t);
        }
        callback?.Invoke();
    }

    public void SetColor(Color color) {
        // Debug.Log(color.ToString());
        image.color = color;
    }
    public void StartFade(Color to, float duration, System.Action callback = null) {
        // Debug.Log("start fade");
        StartCoroutine(Fade(to, duration, callback));
    }
}
