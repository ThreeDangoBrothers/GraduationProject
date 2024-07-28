using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private int _randomRotation;
    private MoveCube3 _moveCube3;

    void Start()
    {
        // Find the MoveCube3 script instance in the scene
        _moveCube3 = GameObject.FindObjectOfType<MoveCube3>();

        
        
    }

    void Update()
    {
        
        transform.Translate(new Vector3(0, 0, 0.005f));

        
        if (_moveCube3 != null)
        {
            
            if (_moveCube3._objectDetected) 
            {
                transform.LookAt(_moveCube3.pp);
            }
        }

        
        // if (Input.GetMouseButtonUp(0))
        // {
        //     transform.Rotate(new Vector3(_randomRotation, 180, 0));
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("fish"))
        {
            _randomRotation = Random.Range(-12, 12);
            transform.Rotate(new Vector3(_randomRotation, 180, 0));
        }

        
        if (other.gameObject.CompareTag("food"))
        {
            _randomRotation = Random.Range(-12, 12);
            transform.Rotate(new Vector3(_randomRotation, 180, 0));
        }
    }
}