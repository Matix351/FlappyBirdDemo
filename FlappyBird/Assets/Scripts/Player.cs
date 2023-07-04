using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float stregnt = 5f;

    private bool isFalling = true;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * stregnt;
            if (isFalling == true)
            {
                transform.Rotate(0, 0, 45);
                isFalling = false;
            }
        }
        
        direction.y += gravity * Time.deltaTime;
        if(transform.position.y > direction.y && isFalling == false)
        {
            transform.Rotate(0, 0, -45);
            isFalling = true;

        }
        transform.position += direction * Time.deltaTime;
        
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }



    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag ==  "Obstacle")
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
        else if (collision.gameObject.tag == "Scoring")
        {
            FindAnyObjectByType<GameManager>().IncreaseScore();
        }
    }




}
