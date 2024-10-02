using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Doodler;
    private Transform _cameraTransform;
    // Start is called before the first frame update
    void Start()
    {  
        _cameraTransform=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Doodler==null)
        {
            return;
        }
        if(Doodler.position.y > _cameraTransform.position.y)
        {
            _cameraTransform.position=new Vector3(_cameraTransform.position.x,Doodler.position.y,_cameraTransform.position.z);
        }

        /*if(Doodler.position.x > _cameraTransform.position.x)
        {
            _cameraTransform.position=new Vector3(Doodler.position.x,_cameraTransform.position.y,_cameraTransform.position.z);
        }

        if(Doodler.position.x < _cameraTransform.position.x)
        {
            _cameraTransform.position=new Vector3(Doodler.position.x,_cameraTransform.position.y,_cameraTransform.position.z);
        }

       // _cameraTransform.position=new Vector3(Doodler.position.x,_cameraTransform.position.y,_cameraTransform.position.z);*/

    }
}
