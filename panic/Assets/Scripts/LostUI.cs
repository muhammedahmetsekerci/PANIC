using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LostUI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int i = 0;
        if(collision.gameObject.tag == "Meteor")
        {
            i++;
            if (i == 4)
            {
                
            }
        }
    }

}
