using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float movespeed = 4f;
    public float jumpspeed = 300f;
    public bool isjump = false;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * movespeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isjump == false)
        {
            isjump = true;
            rigidbody2D.AddForce(Vector2.up * jumpspeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isjump = false;

        if (collision.gameObject.CompareTag("Àå¾Ö¹°"))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Item Speed"))
        {
            Destroy(collision.gameObject);

            movespeed += 2f;
        }
        else if (collision.gameObject.name.Equals("Item Jump"))
        {
            Destroy(collision.gameObject);

            jumpspeed += 200f;
        }
        else if (collision.gameObject.name.Equals("Portal"))
        {
            SceneManager.LoadScene(1);

        }
    }
}
