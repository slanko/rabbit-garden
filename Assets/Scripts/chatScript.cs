using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatScript : MonoBehaviour
{
    public GameObject bubble;
    public InputField input;
    public Text bubbleText;
    public GameObject bubbleObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(input.text != null)
            {
                bubbleObject = Instantiate(bubble, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.25f, gameObject.transform.position.z), gameObject.transform.rotation);
                bubbleObject.name = bubbleObject.name + " " + Random.Range(0, 10000);
                bubbleText = GameObject.Find(bubbleObject.name + "ChatBubble/Canvas/Text").GetComponent<Text>();
                bubbleText.text = input.text;
                input.text = null;
            }
        }
    }
}
