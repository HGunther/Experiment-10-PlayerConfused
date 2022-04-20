using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenClose : MonoBehaviour
{
    private bool fade = false;
    private float currentFadeTime;
    public float fadeTime = 1f;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (!sprite)
        {
            Debug.LogError("ShowWhenClose could not find a sprite renderer");
            return;
        }
    }

    void FixedUpdate()
    {
        if (fade)
        {
            currentFadeTime -= Time.fixedDeltaTime;
            var ratio = currentFadeTime / fadeTime;
            var alpha = Mathf.Lerp(0, 1, ratio);
            if (alpha <= 0.01)
            {
                fade = false;
                Hide();
                return;
            }
            SetAlpha(alpha);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Fade();
        }
    }

    public void Show()
    {
        fade = false;
        sprite.enabled = true;
        SetAlpha(1f);
    }
     public void Hide()
    {
        fade = false;
        sprite.enabled = false;
    }

    public void Fade()
    {
        fade = true;
        currentFadeTime = fadeTime;
    }

    void SetAlpha(float alpha)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
    }

}
