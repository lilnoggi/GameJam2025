using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleSpriteAnimator : MonoBehaviour
{
    public Sprite[] sprites;  // assign the sprite frames in the editor 
    public float frameDelay = 0.1f; // time between frames

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
            // show next sprite
            image.sprite = sprites[currentIndex];

            // reseting the index
            currentIndex = (currentIndex + 1) % sprites.Length;

            // wait for next frame
            yield return new WaitForSeconds(frameDelay);
        }
    }
}