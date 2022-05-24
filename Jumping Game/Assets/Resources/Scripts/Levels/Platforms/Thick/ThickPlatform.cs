using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThickPlatform : MonoBehaviour
{
    [SerializeField]
    public GameObject platform;
    public float xOriginal, yOriginal;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        xOriginal = platform.transform.position.x;
        yOriginal = platform.transform.position.y;
    }
    // Called once per frame
    public virtual void Update()
    {
        
    }
}
