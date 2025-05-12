using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10);//target.transform.position;
            transform.position = targetPosition;
        }
    }
}
