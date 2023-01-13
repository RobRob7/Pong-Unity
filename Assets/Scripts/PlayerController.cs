using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    Transform playerTransform;
    Rigidbody2D playerRigidBody2D;
    Vector2 position;
    RigidbodyConstraints2D original;

    void Awake()
    {
        _speed = 7;
        playerTransform = GetComponent<Transform>();
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        position = playerRigidBody2D.position;
        original = playerRigidBody2D.constraints;

    }

    // Start is called before the first frame update
    void Start()
    {
        if(playerRigidBody2D.position.x < 0){
            tag = "Player1";
        }
        else
        {
            tag = "Player2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        AssignPlayers();
    }

    public void ResetPlayerPosition()
    {
        //playerRigidBody2D.position = position;
        Debug.Log("Resetting paddles");
    }

    void AssignPlayers()
    {
        if(tag == "Player1")
        {

            //Debug.Log("This is Player1!");
            KeyCode wKey = KeyCode.W;
            KeyCode sKey = KeyCode.S;

            var vel = playerRigidBody2D.velocity;

            if(Input.GetKey(wKey) && !Input.GetKey(sKey))
            {
                vel.y = _speed;
                playerTransform.Translate(Vector2.up * vel.y * Time.deltaTime);
            }
            else if(Input.GetKey(sKey) && !Input.GetKey(wKey))
            {
                vel.y = _speed;
                playerTransform.Translate(Vector2.down * vel.y * Time.deltaTime);
            }
            else
            {
                vel.y = 0;
                Vector2 position = playerRigidBody2D.position;
                playerTransform.Translate(position * vel.y * Time.deltaTime);
            }
        }
        else if(tag == "Player2")
        {
            //Debug.Log("This is Player2!");
            KeyCode upKey = KeyCode.UpArrow;
            KeyCode downKey = KeyCode.DownArrow;

            var vel = playerRigidBody2D.velocity;

            if(Input.GetKey(upKey) && !Input.GetKey(downKey))
            {
                vel.y = _speed;
                playerTransform.Translate(Vector2.up * vel.y * Time.deltaTime);
            }
            else if(Input.GetKey(downKey) && !Input.GetKey(upKey))
            {
                vel.y = _speed;
                playerTransform.Translate(Vector2.down * vel.y * Time.deltaTime);
            }
            else
            {
                vel.y = 0;
                Vector2 position = playerRigidBody2D.position;
                playerTransform.Translate(position * vel.y * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision targetObj)
    {   
        //Transform ballTransform = targetObj.GetComponent<Transform>();
        
        if(targetObj.collider.CompareTag("Ball"))
        {

            playerRigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            playerRigidBody2D.constraints = original;
        } 
    }
}
