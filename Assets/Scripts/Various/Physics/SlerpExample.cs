using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SlerpExample : MonoBehaviour
{

    [SerializeField]
    private Transform from;
    [SerializeField]
    private Transform to;
    [Range(0,1)]
    [SerializeField]
    private float t;

    private void Update() {
        if (from == null || to == null) return;
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, t);
    }

}
