using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    MainManager mainManager;

    [SerializeField] GameObject prefabItemA;
    [SerializeField] GameObject prefabItemRaimbowA; //誤植だけど気にしない
    [SerializeField] GameObject prefabItemB;

    int updateCount;
    int generateCount;
    int changeACount;
    int restOfRainbowA = 10;
    int restOfA = 50;

	// Use this for initialization
	void Start () {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (mainManager.IsPlaying())
        {
            updateCount++;
            if(updateCount % 30 == 0)
            {
                generateCount++;
                if (generateCount % 15 == 0 && restOfRainbowA > 0)
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            GenerateItemRainbowA(-300.0f);
                            GenerateItemB(0.0f);
                            GenerateItemB(300.0f);
                            break;
                        case 1:
                            GenerateItemB(-300.0f);
                            GenerateItemRainbowA(0.0f);
                            GenerateItemB(300.0f);
                            break;
                        case 2:
                            GenerateItemB(-300.0f);
                            GenerateItemB(0.0f);
                            GenerateItemRainbowA(300.0f);
                            break;
                    }
                }
                else if (((generateCount % 3 != 2 && Random.Range(0, 3) != 0) || changeACount > 0) && restOfA > 0) 
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            GenerateItemA(Random.Range(-350.0f, 350.0f));
                            break;
                        case 1:
                            GenerateItemA(Random.Range(-350.0f, -100.0f));
                            GenerateItemB(Random.Range(100.0f, 350.0f));
                            break;
                        case 2:
                            GenerateItemA(Random.Range(100.0f, 350.0f));
                            GenerateItemB(Random.Range(-350.0f, -100.0f));
                            break;
                    }
                    changeACount--;
                }
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            GenerateItemB(Random.Range(-350.0f, 350.0f));
                            break;
                        case 1:
                            GenerateItemB(Random.Range(-350.0f, -100.0f));
                            GenerateItemB(Random.Range(100.0f, 350.0f));
                            break;
                        case 2:
                            GenerateItemB(-300.0f);
                            GenerateItemB(0.0f);
                            GenerateItemB(300.0f);
                            break;
                    }
                }
            }
        }
    }

    void GenerateItemA(float positionX)
    {
        Instantiate(prefabItemA, new Vector3(positionX, 500.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        restOfA--;
    }

    void GenerateItemRainbowA(float positionX)
    {
        Instantiate(prefabItemRaimbowA, new Vector3(positionX, 500.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        restOfRainbowA--;
    }

    void GenerateItemB(float positionX)
    {
        Instantiate(prefabItemB, new Vector3(positionX, 500.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
    }

    public void ChangeA()
    {
        restOfA += 20;
        changeACount = 10;
    }

    public bool DoesAExist()
    {
        return restOfA > 0 || restOfRainbowA > 0;
    }
}
