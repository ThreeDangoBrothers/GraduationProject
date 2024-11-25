using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private int _randomRotation;
    private MoveCube3_copy _moveCube3_copy;

    void Start()
    {
        // Find the MoveCube3 script instance in the scene
        _moveCube3_copy = GameObject.FindObjectOfType<MoveCube3_copy>();

        
        
    }

    void Update()
    {
        
        transform.Translate(new Vector3(0, 0, 0.005f));

        
        if (_moveCube3_copy != null)
        {
            
            if (_moveCube3_copy._objectDetected) 
            {
                transform.LookAt(_moveCube3_copy.pp);
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