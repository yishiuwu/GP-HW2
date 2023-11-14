using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using Image = UnityEngine.UI.Image;

[RequireComponent(typeof(Image))]
public class ColorEffect : MonoBehaviour
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    IEnumerator Fade(Color to, float duration, System.Action callback) {
        float startTime = Time.time;
        float t = (Time.time - startTime)/duration;
        Color from = image.color;
        while (t < 1) {
            image.color = Color.Lerp(from, to, t);
            yield return null;
            t = (Time.time - startTime)/duration;
        }
        callback?.Invoke();
    }

    public void SetColor(Color color) {
        image.color = color;
    }
    public void StartFade(Color to, float duration, System.Action callback = null) {
        StartCoroutine(Fade(to, duration, callback));
    }
}
