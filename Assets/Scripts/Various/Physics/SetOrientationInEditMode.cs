using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetOrientationInEditMode : MonoBehaviour
{

    [SerializeField]
    private Quaternion oriantation;

    private void Update() {
        transform.rotation = oriantation;
    }

}
