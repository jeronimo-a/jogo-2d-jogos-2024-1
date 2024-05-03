using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    private bool start = true;
    public float duration = 1f;

    private float timepassed = 0f;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if(timepassed < 3f){
            if(start){
                float timepassed = 0f;
                start = false;
                StartCoroutine(Shaking());
            }      
            timepassed += Time.deltaTime;     
        }
        

    }

    IEnumerator Shaking(){
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while(elapsedTime < duration){
        elapsedTime += Time.deltaTime;
        transform.position = startPosition + Random.insideUnitSphere;
        yield return null;
        }
        transform.position = startPosition;
    }
    
}
