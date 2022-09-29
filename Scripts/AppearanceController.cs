using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AppearanceController : MonoBehaviour
{
    [SerializeField] private Scriptable cube;
    [SerializeField] public MeshRenderer theRenderer;
    [SerializeField] private AssetReferenceTexture[] LoadedTexture;
   

    

    public void OnStart(int index)
    {
        theRenderer.material.color = cube.sphereData[index].color;
        cube.sphereData[0].assetReferenceTextures.LoadAssetAsync<Texture>().Completed += handle => 
        { 
            Texture texture = handle.Result;
            LoadedTexture[0] = cube.sphereData[index].assetReferenceTextures;
            theRenderer.material.mainTexture = texture;
           cube.sphereData[index].assetReferenceTextures.ReleaseAsset();
        };
    }
   
    public void ColorChange(int index, Scriptable scriptCube, MeshRenderer theRenderer)
    {
       theRenderer.sharedMaterial.color = scriptCube.sphereData[index].color;
    }
    public void Change(SphereClass sp)
    { 
        int Index= 0;
       for( int i=0; i<cube.sphereData.Length; i++)
       {
           if (cube.sphereData[i]==sp){
            Index=i;
           }
       }
       ColorChange(Index, cube, theRenderer);
       TextureChange (Index, cube);
    }
   
    public void TextureChange(int index,Scriptable scriptCube)
    {
        scriptCube.sphereData[index].assetReferenceTextures.LoadAssetAsync<Texture>().Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {

                Texture texture = handle.Result;
                theRenderer.sharedMaterial.mainTexture = texture;
                LoadedTexture[index] = scriptCube.sphereData[index].assetReferenceTextures;
               scriptCube.sphereData[index].assetReferenceTextures.ReleaseAsset();
            }
        };
    }
    
    /*private  void ReleaseTextures(int index,Scrip)
    {
         cube.sphereData[index].assetReferenceTextures.ReleaseAsset();
        /*if (index > 0)
        {
            RemovableIndex = index - 2;
            cube.sphereData[RemovableIndex].assetReferenceTextures.ReleaseAsset();
         
        }
        if (index ==0)
        {
         cube.sphereData[4].assetReferenceTextures.ReleaseAsset();
         cube.sphereData[5].assetReferenceTextures.ReleaseAsset();
        }*/

         
    

}


      
    
      

 