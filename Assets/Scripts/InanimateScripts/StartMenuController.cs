using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour {


    public void DisableStartMenu()
    {
        foreach(Transform tran in this.gameObject.transform)
        {
            tran.gameObject.SetActive(false);
        }
    }
}
