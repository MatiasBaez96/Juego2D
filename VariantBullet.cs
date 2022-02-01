using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantBullet : MonoBehaviour
{

    [SerializeField] private Rigidbody2D BulletVariant;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       Invoke("DestroyBulletVariant", 1.3f);
    }
    public void DestroyBulletVariant()
    {
       Destroy(gameObject);
    }
    public static void FuncionPrueba()
    {
        
    }
}
