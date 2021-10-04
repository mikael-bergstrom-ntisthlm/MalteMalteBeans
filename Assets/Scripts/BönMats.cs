using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BönMats : MonoBehaviour
{
    public Material[] bönMats;
    public GameObject beanContainer;
    public int bön;
    
    void Start()
    {
        foreach (Transform item in beanContainer.transform)
        {
            int x = Random.Range(0, 4);
            bön++;
            item.gameObject.GetComponent<Renderer>().material = bönMats[x];
        }
        Debug.Log("Amount of colored beans:   " + bön);
    }
}
