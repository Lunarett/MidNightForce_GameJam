using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = Input.mousePosition;

        Vector3 targetPos =  tmp - new Vector3(Screen.width*0.5f,Screen.height*0.5f,0);

        Vector3 targetVector = (targetPos ).normalized;
        this.transform.right = targetVector;
    }
}
