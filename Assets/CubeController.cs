using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class CubeController : MonoBehaviour {
    [SerializeField]
    int sw=10;//スワイプの変数値
    //現在の適正値　　　10
    // Use this for initialization
    void Start () {
		
	}


    void HandleTapped(object sender, System.EventArgs e)
    {
        Color color = Color.red;
        this.GetComponent<Renderer>().material.color = color;
    }
    private void OnEnable()
    {
        GetComponent<FlickGesture>().StateChanged += HandleFlick;
    }

    private void OnDisable()
    {
        GetComponent<FlickGesture>().Flicked += HandleFlick;
        GetComponent<FlickGesture>().MinDistance = 1f;
        GetComponent<FlickGesture>().FlickTime = 0.3f;
    }

    void HandleFlick(object sender, System.EventArgs e)
    {
        int sw = 10;
        var gesture = sender as FlickGesture;

        if (gesture.State != FlickGesture.GestureState.Recognized)
            return;

        if (gesture.ScreenFlickVector.x < -sw)
        {
            Left();
        }
        else if (gesture.ScreenFlickVector.x > sw)
        {
            Right();
        }
        if (gesture.ScreenFlickVector.y < -sw)
        {
            Up();
        }
        else if (gesture.ScreenFlickVector.y > sw)
        {
            Down();
        }
    }

    private void Right()
    {
        this.transform.position += new Vector3(0.1f, 0, 0);
    }
    private void Left()
    {
        this.transform.position += new Vector3(-0.1f, 0, 0);
    }
    private void Up()
    {
        this.transform.position += new Vector3(0f, -0.1f,0);
    }
    private void Down()
    {
        this.transform.position += new Vector3(0f, 0.1f,0);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
