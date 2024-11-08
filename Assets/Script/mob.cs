using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 wayPoint;
    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        SetRandomColor(); 
        SetRandomWaypoint();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, moveSpeed * Time.deltaTime);
        
        if ((Vector2)transform.position == wayPoint)
        {
            SetRandomWaypoint();
        }

        Vector2 moveInput = wayPoint - (Vector2)transform.position;

        if (moveInput.x > 0)
        {
            myAnimator.Play("right");
        }
        else if (moveInput.x < 0)
        {
            myAnimator.Play("left");
        }
        else if (moveInput.y > 0)
        {
            myAnimator.Play("top");
        }
        else if (moveInput.y < 0)
        {
            myAnimator.Play("down");
        }
    }

    void SetRandomWaypoint()
    {
        wayPoint = new Vector2(Random.Range(-6f, 6f), Random.Range(-6f, 6f));
    }

    void SetRandomColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        spriteRenderer.color = randomColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected"); 
        if (collision.gameObject.CompareTag("wall"))
        {
            wayPoint = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        }
        else if (collision.gameObject.CompareTag("mob"))
        {
            Vector3 playerSize = transform.localScale;
            Vector3 mobSize = collision.transform.localScale;

            if (mobSize.x < playerSize.x && mobSize.y < playerSize.y)
            {
                transform.localScale += new Vector3(mobSize.x, mobSize.y, mobSize.z);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("eat1"))
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("eat2"))
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("eat3"))
        {
            transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("pronos"))
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            
            Destroy(other.gameObject);
        }
    }
}
