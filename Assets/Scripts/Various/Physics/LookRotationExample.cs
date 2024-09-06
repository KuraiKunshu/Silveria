using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LookRotationExample : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    private void Update() {
        if (target == null) return;
        transform.rotation = Quaternion.LookRotation((target.position - transform.position).normalized, Vector3.up);
    }

}
