using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHealth : Health
{
    [SerializeField] float _lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        SelfDestroy(_lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelfDestroy(float timer)
    {
        Destroy(gameObject, timer);
    }
}
