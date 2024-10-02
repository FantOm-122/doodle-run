using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    private Animator _animator;
    private BoxCollider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        _animator=GetComponent<Animator>();
        _collider=GetComponent<BoxCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _collider.enabled=false;
            _animator.SetBool("Fall",true);
            Destroy(gameObject,3f);
        }
    }

   

   
}
