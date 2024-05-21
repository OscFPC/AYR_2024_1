using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float velocidadRotacion = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
