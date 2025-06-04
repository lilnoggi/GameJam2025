using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleSpriteAnimator : MonoBehaviour
{
    public Sprite[] sprites;  // Sprite-Frames im Inspector zuweisen!
    public float frameDelay = 0.1f; // Zeit zwischen Frames

    private Image image;
    private int currentIndex = 0;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        while (true)
        {
            // Nächstes Sprite anzeigen
            image.sprite = sprites[currentIndex];

            // Index zurücksetzen, wenn Ende erreicht
            currentIndex = (currentIndex + 1) % sprites.Length;

            // Warte für den nächsten Frame
            yield return new WaitForSeconds(frameDelay);
        }
    }
}