using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    bool alreadyCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!alreadyCollided)
        {
            collision.gameObject.GetComponentInParent<ChMovement>().FallDown();
            alreadyCollided = true;
        }
    }
}
