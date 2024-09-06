using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FromToRotation : MonoBehaviour
{

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
        }
    }

}
