using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{

    public bool filled;

    [SerializeField]
    private Sprite filledSprite;
    [SerializeField]
    private Sprite emptySprite;

    [SerializeField]
    private Image containerImage;


    void Start()
    {
        if (!containerImage)
        {
            containerImage = GetComponent<Image>();
        }
    }

    public void SetState(bool newState)
    {
        if (newState)
        {
            filled = newState;

            containerImage.sprite = filledSprite;

        }
        else
        {
            filled = newState;

            containerImage.sprite = emptySprite;

        }
    }
}
