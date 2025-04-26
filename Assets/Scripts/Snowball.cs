using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask layers;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
