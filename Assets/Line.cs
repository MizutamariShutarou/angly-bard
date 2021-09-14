using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Line : MonoBehaviour
{
    Rigidbody2D rb2d = null;
    Vector2 s_Vec;
    Vector2 m_Vec;
    private float speed;
    private Camera mainCamera = null;
    [SerializeField]
    private LineRenderer direction = null;
    [SerializeField] GameObject arrowPos;
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.speed = 500;
        this.mainCamera = Camera.main;
    }
    private Vector2 GetMousePosition()
    {
        // マウスから取得できないZ座標を補完する
        Vector2 arrowPos = Input.mousePosition;
        //position.z = this.mainCameraTransform.position.z;
        arrowPos = this.mainCamera.ScreenToWorldPoint(arrowPos);
        //position.z = 0;
        return arrowPos;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.s_Vec = Input.mousePosition;
            this.m_Vec = this.GetMousePosition();
            this.direction.enabled = true;
            this.direction.SetPosition(0, this.GetMousePosition());
            //this.direction.SetPosition(1, new Vector2(this.rb2d.position.x, this.rb2d.position.y * -1));
            //this.direction.SetPosition(0, this.rb2d.position);
            this.direction.SetPosition(1, new Vector2((this.GetMousePosition().x + this.m_Vec.x), this.GetMousePosition().y + this.m_Vec.y) * -1);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            Vector2 startDirection = -1 * (endPos - s_Vec).normalized;
            this.rb2d.AddForce(startDirection * speed);
            this.direction.enabled = false;
        }
    }
    void FixedUpdate()
    {
        this.rb2d.velocity *= 0.995f;
    }
}












