using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletScript : MonoBehaviour
{

    private void Awake() {
        Debug.Log("Creato " + gameObject.name);
    }

    private void OnDestroy() {
        Debug.Log("Distrutto " + gameObject.name);
    }

}
