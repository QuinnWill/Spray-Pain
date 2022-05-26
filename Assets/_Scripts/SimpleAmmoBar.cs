using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAmmoBar : MonoBehaviour
{

    public ASpraypaint sprayPaint;

    [SerializeField]
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        if (!image)
        {
            image = GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = sprayPaint.ammo / sprayPaint.maxAmmo;
    }
}
