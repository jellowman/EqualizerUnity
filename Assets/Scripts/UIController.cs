using System;
using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour 
{
    //Keeps count of the number of each type of object in the level
    public float offset;
    public int numSquares;
    public int numTriangles;
    public int numCircles;
    public int maxNumShapes;
    public Transform transPanel;
    public Transform transRedBar;

    public GameObject squareImage;
    public GameObject circleImage;
    public GameObject triangleImage;

    private ArrayList squares;
    private ArrayList triangles;
    private ArrayList circles;

	// Use this for initialization
	void Start () 
    {
		GameState.gameState.UI = this;

        maxNumShapes = 10;
        offset = 0.5f;
        reDrawFrame();
        squares = new ArrayList();
        triangles = new ArrayList();
        circles = new ArrayList();

		numSquares = 0;
        reDrawSquares();

        numTriangles = 0;
        reDrawTriangles();

        numCircles = 0;
        reDrawCircles();
	}
	
	// Update is called once per frame
	void Update () 
    {
        /*if(Input.GetKeyDown("g"))
        {
            reDrawSquares();
            reDrawCircles();
            reDrawTriangles();
            reDrawFrame();
        }*/
	}

    

    //Called everytime a new square enemy is made to tell the UI how many there are now.
    public void setNumSquares(int num)
    {
        numSquares = num;
        reDrawSquares();
    }

    //Called everytime a circle dies or is born
    public void setNumCircles(int num)
    {
        numCircles = num;
        reDrawCircles();
    }

    //Called everytime a triangle dies or is born
    public void setNumTriangles(int num)
    {
        numTriangles = num;
        reDrawTriangles();
    }

    //Called everytime the max limit of shapes is raised
    public void setMaxNumShapes(int num)
    {
        maxNumShapes = num;
        reDrawFrame();
    }

    private void reDrawSquares()
    {
        foreach (GameObject square in squares)
        {
            Destroy(square);
        }
        squares.RemoveRange(0, squares.Count);

        for(int i = 0; i < numSquares; i++)
        {
            GameObject newSquare = Instantiate(squareImage);
            newSquare.transform.SetParent(this.gameObject.transform);
            newSquare.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            newSquare.transform.localPosition = new Vector3(offset * (i + 0.5f), 0f);
            squares.Add(newSquare);
        }
    }

    private void reDrawTriangles()
    {
        foreach (GameObject triangle in triangles)
        {
            Destroy(triangle);
        }
        triangles.RemoveRange(0, triangles.Count);

        for (int i = 0; i < numTriangles; i++)
        {
            GameObject newTriangle = Instantiate(triangleImage);
            newTriangle.transform.SetParent(this.gameObject.transform);
            newTriangle.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            newTriangle.transform.localPosition = new Vector3(offset * (i + 0.5f), -0.5f);
            triangles.Add(newTriangle);
        }
    }

    private void reDrawCircles()
    {
        foreach (GameObject circle in circles)
        {
            Destroy(circle);
        }
        circles.RemoveRange(0, circles.Count);

        for (int i = 0; i < numCircles; i++)
        {
            GameObject newCircle = Instantiate(circleImage);
            newCircle.transform.SetParent(this.gameObject.transform);
            newCircle.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            newCircle.transform.localPosition = new Vector3(offset*(i + 0.5f), -1f);
            circles.Add(newCircle);
        }
    }

    private void reDrawFrame()
    {
        
        //Transform transPanel = transform.Find("Panel");
        //Transform transRedBar = transform.Find("Red Bar");

        //Debug.Log("Yo whatup");

        float panelLength = maxNumShapes*offset;
        float panelPosition = panelLength/2 - 0.5f;
        transPanel.localPosition = new Vector3(panelPosition, -0.5f);
        transPanel.localScale = new Vector3(panelLength, 2f, 1f);

        transRedBar.localPosition = new Vector3(panelLength - 0.5f*offset, -0.5f);
        transRedBar.localScale = new Vector3(offset, 2f, 1f);
    }
}
