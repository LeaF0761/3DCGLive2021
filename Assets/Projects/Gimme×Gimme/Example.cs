using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Example : MonoBehaviour
{
  public AudioSpectrum spectrum;
  [SerializeField] UnityEngine.VFX.VisualEffect effect;
  public float scale;
  public Transform[] cubes;


  private void Update()
  {
   

    for (int i = 0; i < cubes.Length; i++)

    {
      float vol = spectrum.PeakLevels[i] * scale;
      effect.SetFloat("Vol",vol );
       effect.SendEvent("OnPlay");

      var cube = cubes[i];
      var localScale = cube.localScale;

      localScale.y = 1+spectrum.MeanLevels[i] * scale/5;
      localScale.z =  1+spectrum.MeanLevels[i] ;
      localScale.x =1+  spectrum.MeanLevels[i] ;
      cube.localScale = localScale;

    }
   
  }
}