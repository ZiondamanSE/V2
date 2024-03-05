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

    public float maxHealth = 100f;
    public float chipSpeed = 2f;

    public Image frontHelthBar;
    public Image backHelthBar;
    [SerializeField]
    private TextMeshProUGUI helthText;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, maxHealth);
        UpdateHealthUI();
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
