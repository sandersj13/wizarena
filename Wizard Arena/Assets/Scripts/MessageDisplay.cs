using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageDisplay : MonoBehaviour
{

    public static MessageDisplay Instance;
    public GameObject panel;
    public TextMeshProUGUI messageText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        panel.SetActive(true);
    }

    public void HideMessage()
    {
        panel.SetActive(false);
    }
}
