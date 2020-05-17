using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showeffect : MonoBehaviour
{
    // Start is called before the first frame update
    public int framelimit = 5;
    public int rangeofshadows = 40;
    private int frame = 0;
    private int x;
    private int y;
    private float alpha;

    public Shadow shadow;
    void Update()
    {
        if (frame >= framelimit){
            x = Random.Range(-rangeofshadows, rangeofshadows);
            y = Random.Range(-rangeofshadows, rangeofshadows);
            shadow.effectDistance = new Vector2(x,y);
            frame = 0;
        }
        frame++;
    }
}
