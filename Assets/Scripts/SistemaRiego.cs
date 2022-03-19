using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaRiego : MonoBehaviour
{
    public bool activar;
  
    // Start is called before the first frame update
    void Start()
    {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
    }

    // Update is called once per frame
    
    
    public void upDate()
    {
        var exp = GetComponent<ParticleSystem>();
        
        if (activar == true)
        {
            exp.Play();
        }   
    }

    public bool playSistema()
    {
        return activar;
    }
   
}
