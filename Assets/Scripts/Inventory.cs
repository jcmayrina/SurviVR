using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Inventory setInventory;
    // Start is called before the first frame update
    void Awake()
    {
        setInventory.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void active() {
        setInventory.gameObject.SetActive(true);
    }
}
