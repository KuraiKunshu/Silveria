using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EulerExample : MonoBehaviour
{

    [SerializeField]
    private Vector3 eulerAngles;

    private void Update() {
        transform.rotation = Quaternion.Euler(eulerAngles);
    }

}
