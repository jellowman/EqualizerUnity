using System;
using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour 
{
    //Keeps count of the number of each type of object in the level
    private int numSquares;
    private int numTriangles;
    private int numCircles;

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
        numSquares = 0;
        numTriangles = 0;
        numCircles = 0;

        squares = new ArrayList();
        triangles = new ArrayList();
        circles = new ArrayList();

        numSquares = 6;
        reDrawSquares();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    //Called everytime a new square enemy is made to tell the UI how many there are now.
    public void updateSquares(GameObject square)
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
            squares.Remove(square);
            Destroy(square);
        }

        for(int i = 0; i < numSquares; i++)
        {
            GameObject newSquare = Instantiate(squareImage);
            newSquare.transform.SetParent(this.gameObject.transform);
            newSquare.transform.localPosition = new Vector3(i + 0.5f , 0.6f);
        }

    }

    private void reDrawCircles()
    {

    }

    private void reDrawTriangles()
    {

    }
}
