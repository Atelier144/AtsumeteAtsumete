using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    MainManager mainManager;

    [SerializeField] GameObject prefabFallEffect;

    [SerializeField] Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rBody2D;

    [SerializeField] int itemCode;

    // Use this for initialization
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody2D = GetComponent<Rigidbody2D>();

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rBody2D.velocity = new Vector2(rBody2D.velocity.x, -300.0f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(prefabFallEffect, new Vector3(transform.position.x, -250.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            mainManager.OnMissingItem(itemCode);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Tray")
        {
            mainManager.OnGettingItem(itemCode);
            Destroy(gameObject);
        }
    }

    public void ForciblyDestroy()
    {
        if (itemCode == 2)
        {
            Instantiate(prefabFallEffect, transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            mainManager.OnMissingItem(itemCode);
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {

    }
}
