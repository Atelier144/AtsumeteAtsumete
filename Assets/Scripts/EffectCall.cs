using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCall : MonoBehaviour {

    [SerializeField] Sprite[] sprites = new Sprite[5];

    SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSprite(int s)
    {
        GetComponent<SpriteRenderer>().sprite = sprites[s];
    }

    public void UnsetActive()
    {
        gameObject.SetActive(false);
    }
}
