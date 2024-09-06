using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulQuaternion : MonoBehaviour
{

    [SerializeField]
    private Quaternion mul;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            transform.rotation *= mul;
        }
    }

}
