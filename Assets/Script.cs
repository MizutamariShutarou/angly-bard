using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    Vector2 startPos;
    [SerializeField]
    private LineRenderer direction = null;

    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.speed = 250;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            Vector2 startDirection = -1 * (endPos - startPos).normalized;
            this.rb2d.AddForce(startDirection * speed);
        }
        //テスト用
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.speed = 100.0f;
            this.rb2d.velocity *= 0;

        }
    }

    void FixedUpdate()
    {
        this.rb2d.velocity *= 0.995f;
    }
}
