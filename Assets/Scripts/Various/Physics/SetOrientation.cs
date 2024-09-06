using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrientation : MonoBehaviour
{

    [SerializeField]
    private Quaternion startOrientation;

    private void Start() {
        transform.rotation = startOrientation;
    }

}
