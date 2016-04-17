using System;
using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour 
{
    //Keeps count of the number of each type of object in the level
    public float OFFSET = 0.5f;
    public int numSquares;
    public int numTriangles;
    public int numCircles;

    public GameObject squareImage;
    public GameObject circleImage;
    public GameObject triangleImage;

    private ArrayList squares;
    private ArrayList triangles;
    private ArrayList circles;

    private static int maxShapesAllowed;
    private RectTransform rectT;
    private float width;
	// Use this for initialization
	void Start () 
    {
        /*numSquares = 0;
        numTriangles = 0;
        numCircles = 0;*/

        squares = new ArrayList();
        triangles = new ArrayList();
        circles = new ArrayList();

        numSquares = 6;
        reDrawSquares();

        numTriangles = 3;
        reDrawTriangles();

        numCircles = 8;
        reDrawCircles();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown("g"))
        {
            reDrawSquares();
            reDrawCircles();
            reDrawTriangles();
        }
	}

    

    //Called everytime a new square enemy is made to tell the UI how many there are now.
    public void updateSquares()
    {
        //Get num of squares from GameState
        //numSquares =
        reDrawSquares();
    }

    //Called everytime a circle dies or is born
    public void updateCircles()
    {
        //numCircles = 
        reDrawCircles();
    }

    //Called everytime a triangle dies or is born
    public void updateTriangles()
    {
        //numTriangles = 
        reDrawTriangles();
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
            newSquare.transform.localPosition = new Vector3(i*OFFSET + 0.5f , 0f);
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
            newTriangle.transform.localPosition = new Vector3(i*OFFSET + 0.5f, -0.5f);
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
            newCircle.transform.localPosition = new Vector3(i*OFFSET + 0.5f, -1f);
            circles.Add(newCircle);
        }
    }
}
