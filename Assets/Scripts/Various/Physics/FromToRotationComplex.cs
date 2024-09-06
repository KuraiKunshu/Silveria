using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FromToRotationComplex : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, 1)) return;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
    }
}
