using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFreeze : MonoBehaviour
{
    private bool isFrozen = false;
    private float originalSpeed;
    public float moveSpeed = 2f;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Freeze(float duration)
    {
        if (!isFrozen)
        {
            StartCoroutine(FreezeCoroutine(duration));
        }
    }
    private IEnumerator FreezeCoroutine(float duration)
    {
        isFrozen = true;
        moveSpeed = 0;

        spriteRenderer.color = Color.cyan;

        yield return new WaitForSeconds(duration);

        moveSpeed = originalSpeed;
        spriteRenderer.color = Color.white;
        isFrozen = false;
    }

}
