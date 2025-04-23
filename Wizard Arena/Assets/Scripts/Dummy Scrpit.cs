using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScrpit : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
       if(col.gameObject.name == "Target Dummy")
        {
            Destroy(col.gameObject);
        }
    }

}
