using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemA : MonoBehaviour {

    MainManager mainManager;

    [SerializeField] GameObject prefabFallEffect;

    [SerializeField] Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rBody2D;
	// Use this for initialization
	void Start () {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody2D = GetComponent<Rigidbody2D>();

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        rBody2D.velocity = new Vector2(0.0f, -120.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Instantiate(prefabFallEffect, new Vector3(transform.position.x, -250.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Tray")
        {
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {

    }
}
