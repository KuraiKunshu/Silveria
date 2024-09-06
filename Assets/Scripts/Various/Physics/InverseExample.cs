using UnityEngine;

[ExecuteInEditMode]
public class InverseExample : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("Rotation before: " + transform.rotation);
            transform.rotation = Quaternion.Inverse(transform.rotation);
            Debug.Log("Rotation after: " + transform.rotation);
        }
    }
}
