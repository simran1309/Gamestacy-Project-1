using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class EditorTests
{
   
    private SphereClass sphereClass1;
    private AppearanceController ap;
    private GameManager gameManager;
    private Scriptable cube;
    private MeshRenderer theRenderer;
    [SerializeField] private RotationController rotation;
    private float RotateSpeed;
   
   
    [SetUp]
    public void SetUp()
    {
        ap = new GameObject().AddComponent<AppearanceController>();
        rotation = new GameObject().AddComponent<RotationController>();
        gameManager=new GameObject().AddComponent<GameManager>();
        
        cube = ScriptableObject.CreateInstance<Scriptable>();
        sphereClass1 = new SphereClass
        {
            color = Color.white,
            assetReferenceTextures = new AssetReferenceTexture("Assets/Textures/new wall.png")
        };
        cube.sphereData = new SphereClass[]
        {
          sphereClass1
        };
        
        theRenderer = ap.gameObject.AddComponent<MeshRenderer>();
        theRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        
      
    }


    [Test]
    public void TestColor()
    {
        
        ap.ColorChange(0, cube, theRenderer);
 
        Assert.AreEqual(theRenderer.sharedMaterial.color, cube.sphereData[0].color);

    }

    [Test]
    [TestCase(0)]
    public void TestNext(int index)
    {
      
        gameManager.Next(index, cube,  theRenderer,rotation,ap);
       
        Assert.AreEqual(theRenderer.sharedMaterial.color,cube.sphereData[index].color);
       // rotation.RotateandScale(index, RotateSpeed, cube);
        // Assert.AreEqual(RotateSpeed, cube.sphereData[index].RotateSpeed); 
    }
    [Test]
    [TestCase(0)]
    public void TestRotation(int index)
    {
      
        rotation.RotateandScale(index, RotateSpeed, cube);
         Assert.AreEqual(RotateSpeed, cube.sphereData[index].RotateSpeed); 

    }
    [Test]
    [TestCase(0)]
    

    public void TestPrevious(int index)
    {

        gameManager.Previous(index, cube,  theRenderer,rotation,ap);
        Assert.AreEqual(theRenderer.sharedMaterial.color, cube.sphereData[index].color);


    }
    [UnityTest]
    
    public IEnumerator TextureChangeTest()
    {
       
        var handle = cube.sphereData[0].assetReferenceTextures.LoadAssetAsync<Texture>();
        yield return handle;
         Assert.AreEqual(handle.Status , AsyncOperationStatus.Succeeded);
        
    }
}

