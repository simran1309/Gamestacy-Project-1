using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AdapterViewItem : MonoBehaviour
{    
    //public Text titleText;
    public Image backgroundImage; 
    public RawImage TextureImage;
    public Button button;
    public AppearanceController ap;

    public void UpdateView(SphereClass sp)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => Change(sp));
        backgroundImage.color=sp.color;
        TextureImage.texture= sp.texture;
    }
    public void Change(SphereClass sp)
    {
      ap.Change(sp) ;
     
    } 
   
}
