using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promtText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(string promptMessage)
    {
        promtText.text = promptMessage;
    }
}
