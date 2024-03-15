using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PHelth : MonoBehaviour
{

    private float Health;
    private float lerpTimer;

    [Header("Helth Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;

    public Image frontHelthBar;
    public Image backHelthBar;
    [SerializeField]
    private TextMeshProUGUI helthText;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;


    void Start()
    {
        Health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }


    void Update()
    {
        Health = Mathf.Clamp(Health, 0, maxHealth);
        UpdateHealthUI();


        // overlay fade
        if(overlay.color.a > 0 )
        {
            if (Health < 30)
            {
                return;
            }
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(Health);
        UpdateText(Convert.ToString(Health) + " / 100");
        float fillF = frontHelthBar.fillAmount;
        float fillB = backHelthBar.fillAmount;
        float hFranction = Health / maxHealth;
        if (fillB > hFranction)
        {
            frontHelthBar.fillAmount = hFranction;
            backHelthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentCompleate = lerpTimer / chipSpeed;
            backHelthBar.fillAmount = Mathf.Lerp(fillB, hFranction, percentCompleate);
        }
        if (fillF < hFranction)
        {
            backHelthBar.color = Color.green;
            backHelthBar.fillAmount = hFranction;
            lerpTimer += Time.deltaTime;
            float percentCompleate = lerpTimer / chipSpeed;
            percentCompleate = percentCompleate * percentCompleate;
            frontHelthBar.fillAmount = Mathf.Lerp(fillF, backHelthBar.fillAmount, percentCompleate);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }

    public void RestoreHealth(float healAmout)
    {
        Health += healAmout;
        lerpTimer = 0f;
    }

    public void UpdateText(string promptMessage)
    {
        helthText.text = promptMessage;
    }
}
