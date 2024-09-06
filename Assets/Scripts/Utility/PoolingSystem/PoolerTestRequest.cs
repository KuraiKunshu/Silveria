using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolerTestRequest : MonoBehaviour
{

    [SerializeField]
    private PoolData data;

    private void Awake() {
        Pooler.Instance.AddToPool(data);
    }

}
