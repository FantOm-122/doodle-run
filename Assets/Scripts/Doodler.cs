using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Doodler: MonoBehaviour
{
   public event Action OnDoodlerDestroyed;

   public float JumpForce;
   public float speed;
   public float StartJumpForce;
   public GameObject BulletPrefab;
   public float ShootForce;
   public TMP_Text EndText;
   public TMP_Text InfoText;

   private Rigidbody2D _rigidbody2D;
   private Transform _transform;
   private Vector3 _startScale;
   [SerializeField]private float _borderPositionX=4.05f;
   private Camera _camera;
   private GameManager _gameManager;

   
   private void Awake()
   {
    _transform=GetComponent<Transform>();
    _rigidbody2D=GetComponent<Rigidbody2D>();
    _startScale=_transform.localScale; // в переменную _startScale сохраняем состояние дудлера с исходным Scale при старте игры (берём его разово)
    _camera= Camera.main;
    _gameManager=FindObjectOfType<GameManager>();
   }

   void Start()
   {
     _rigidbody2D.AddForce(Vector3.up*StartJumpForce,ForceMode2D.Impulse);
   }

   void Update()
   {
      DoodlerMoviement();
      ChangeDoodlerSprite1();
      JumpThroughBorders();
      Shoot();
   }

   private void OnDestroy()
   {
      OnDoodlerDestroyed?.Invoke();
      EndText.text="Game Over";
      InfoText.text="press F to retry";
      ReloadGame.Instance.GameEnded=true;
   }

   public void OnCollisionEnter2D(Collision2D collision)
   {
      _rigidbody2D.velocity=Vector3.zero;
      _rigidbody2D.AddForce(Vector3.up*JumpForce,ForceMode2D.Impulse);   

      if(collision.gameObject.CompareTag("enemy"))
      {
        if(_transform.position.y>collision.collider.transform.position.y+0.5f)
        {
           Destroy(collision.gameObject);
        }     
        else
        {
         Destroy(gameObject);
        }

      
      }
   }

   void DoodlerMoviement()
   {
      float horizontal = Input.GetAxis("Horizontal");
       _transform.Translate(Vector3.right*speed*Time.deltaTime*horizontal);
   }

   void ChangeDoodlerSprite1()
   {
      float horizontal = Input.GetAxis("Horizontal");
      if(horizontal>0)
      {
         _transform.localScale=_startScale; // в текущий Scale дудлера (работаем в методе Update) сохраняем данные, которые взяли при старте игры и говорим, что оно равно _startScale
      }
      if(horizontal<0)
      {
         _transform.localScale=new Vector3(-_startScale.x,_startScale.y,_startScale.z);
      }
      
   }
   void JumpThroughBorders()
   {
      if(_transform.position.x > _borderPositionX)
      {
         _transform.position=new Vector3(-_borderPositionX,_transform.position.y,_transform.position.z);
      }

      if(_transform.position.x < -_borderPositionX)
      {
         _transform.position=new Vector3(_borderPositionX,_transform.position.y,_transform.position.z);
      }
   }

   public void Shoot()
   {

      if(Input.GetKeyDown(KeyCode.Mouse0) && !_gameManager.IsMenuActive() && !_gameManager.IsTimeFrozen())
      {
         var mousePosition=_camera.ScreenToWorldPoint(Input.mousePosition);
         mousePosition.z = 0; 
         var shootDirection= (mousePosition-_transform.position).normalized;
         Rigidbody2D bulletRB=Instantiate(BulletPrefab,_transform.position + Vector3.up * 0.2f,Quaternion.identity).GetComponent<Rigidbody2D>();
         bulletRB.velocity=shootDirection*ShootForce;
      }      
   }

   




   

}
