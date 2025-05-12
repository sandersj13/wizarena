using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public GameObject OptionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        OptionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            OptionsMenu.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        OptionsMenu.SetActive(true);

    }
}
