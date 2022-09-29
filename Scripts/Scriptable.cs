using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "New Cube", menuName = "Colors/Textures/Options")]
public class Scriptable : ScriptableObject
{
    public SphereClass[] sphereData;
}

[System.Serializable]
public class SphereClass
{
    public Color color;
    public Texture2D texture;
    public AssetReferenceTexture assetReferenceTextures;
    public float RotateSpeed;
    public Vector3 Scale;
} 
