using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   [SerializeField] private int currentIndex = 0;
    [SerializeField]private AppearanceController ap;
    [SerializeField] public MeshRenderer theRenderer;
    [SerializeField] private RotationController rotation;
    [SerializeField] private Scriptable cube;
    [SerializeField] private Button next, previous;
 
    void Start() {
        next.onClick.AddListener(() => Next(currentIndex, cube, theRenderer,rotation,ap));
        previous.onClick.AddListener(() => Previous(currentIndex, cube,  theRenderer,rotation,ap));                                                                            
        ap.OnStart(currentIndex);
    }
     public void Next(int index,Scriptable scriptcube, MeshRenderer renderer,RotationController Rotate,AppearanceController ap)
    {
        index++;
       
        if (index >= scriptcube.sphereData.Length-1)
        {
            index = 0;
        }
        currentIndex=index;
        ap.ColorChange(index, scriptcube, renderer);
        ap.TextureChange(index,scriptcube);
        Rotate.RotateandScale(index,0.0f,scriptcube);
    }

    public void Previous(int index, Scriptable scriptcube, MeshRenderer renderer,RotationController Rotate,AppearanceController ap)
    {
    
        index--;
        
        if (index < 0)
        {
            index = scriptcube.sphereData.Length - 1;
        }
         currentIndex=index;
        ap.ColorChange(index, scriptcube,  renderer);
        ap.TextureChange(index,scriptcube);
        Rotate.RotateandScale(index,0.0f,scriptcube);
    }
}
