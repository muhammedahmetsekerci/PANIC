using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Barrier.Instance.onMeteorFell += gameManagerTwoOnMeteorFell;
    }

    private void gameManagerTwoOnMeteorFell(object sender, EventArgs e)
    {
        Vector2 newPosition = new Vector2(UnityEngine.Random.Range(-16f, 16), UnityEngine.Random.Range(7f, 13f));
        gameObject.transform.position = newPosition;
    }

}
