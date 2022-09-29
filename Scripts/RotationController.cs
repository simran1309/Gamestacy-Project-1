using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public bool isRotating;
    [SerializeField] public float rotateSpeed;
    [SerializeField] private AppearanceController sphere;
    [SerializeField ] private Scriptable scriptable;
  
    
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        this.transform.Rotate(0,rotateSpeed*Time.deltaTime,0);
    }
    public void RotateandScale(int index,float rotateSpeed ,Scriptable scriptCube )
    {
        isRotating = true;
     
        rotateSpeed = scriptCube.sphereData[index].RotateSpeed;
        this.transform.localScale = scriptCube.sphereData[index].Scale;
      
    }
   
  
}
