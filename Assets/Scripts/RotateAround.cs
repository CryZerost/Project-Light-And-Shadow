using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
    }


}
