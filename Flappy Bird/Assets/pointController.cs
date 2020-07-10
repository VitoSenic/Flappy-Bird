using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        BirdController controller = col.gameObject.GetComponent<BirdController>();

        if (controller != null)
        {
            controller.updateScore(1);
        }
    }
}
