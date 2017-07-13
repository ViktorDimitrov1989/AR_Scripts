using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
    [System.Serializable]
    public class Cell {
        public bool visited;
        public GameObject north;//1
        public GameObject east;//2
        public GameObject west;//3
        public GameObject south;//4

    }

    public GameObject wall;
    public float wallLength = 1.0f;
    public int xSize = 5;
    public int ySize = 5;
    public GameObject wallHolder;

    private int currentCell = 0;
    private int visitedCells = 0;
    private int totalCells;
    private Cell[] cells;
    private Vector3 initialPosition;
    private bool startedBuilding = false;
    private int currentNeighbour = 0;
    private List<int> lastCells;
    private int backingUp = 0;
    private int wallToBrake = 0;

    // Use this for initialization
    void Start () {
        CreateWalls();
	}

    void CreateWalls()
    {
        initialPosition = new Vector3(-2.2f, 0.5f, 6.4f); //new Vector3((-xSize/2) + wallLength/2, 0.0f, (-ySize * 2) + wallLength / 2);
        Vector3 mypos = initialPosition;
        GameObject templWall;

        //For x axis
        for (int i = -1; i < ySize + 1; i++)
        {
            for (int j = 0; j <= xSize; j++)
            {
                mypos = new Vector3(initialPosition.x + (j * wallLength) - wallLength / 2, 0.5f, initialPosition.z + (i * wallLength) - wallLength / 2);
                templWall = Instantiate(wall, mypos, Quaternion.identity) as GameObject;
                templWall.transform.parent = wallHolder.transform;
            }
        }


        //For y axis
        for (int i = 0; i <= ySize; i++)
        {
            for (int j = 0; j <= xSize + 1; j++)
            {
                mypos = new Vector3(initialPosition.x + (j * wallLength) - wallLength, 0.5f, initialPosition.z + (i * wallLength) - wallLength);
                templWall = Instantiate(wall, mypos, Quaternion.Euler(0.0f,90.0f,0.0f)) as GameObject;
                templWall.transform.parent = wallHolder.transform;
            }
        }

        CreateCells();

    }

    void CreateCells()
    {

        lastCells = new List<int>();
        lastCells.Clear();
         
        totalCells = (xSize + 1) * (ySize + 1);

        int childrenCount = wallHolder.transform.childCount;
        GameObject[] allWalls = new GameObject[childrenCount];
        cells = new Cell[(xSize + 1) * (ySize + 1)];
        int eastWestProcess = 0;
        int childProcess = 0;
        int termcount = 0;

        //Get All the children
        for (int i = 0; i < childrenCount; i++)
        {
            allWalls[i] = wallHolder.transform.GetChild(i).gameObject;
        }

        //Assign walls to the cells
        for (int cellProcess = 0; cellProcess < cells.Length; cellProcess++)
        {
            cells[cellProcess] = new Cell();
            cells[cellProcess].east = allWalls[eastWestProcess];
            cells[cellProcess].south = allWalls[childProcess + (xSize + 2) * ySize + 1];

            if (termcount == xSize + 1)
            {
                eastWestProcess += 2;
                termcount = 0;
            }
            else
            {
                eastWestProcess++;
            }

            termcount++;
            childProcess++;
            cells[cellProcess].west = allWalls[eastWestProcess];
            cells[cellProcess].north = allWalls[(childProcess + (xSize + 2) * ySize + 1) + xSize];
        }

        CreateMaze();

    }

    void CreateMaze()
    {
        while(visitedCells < totalCells)
        {
            if (startedBuilding)
            {
                GiveMeNeighbour();
                if (cells[currentNeighbour].visited == false && cells[currentCell].visited == true)
                {
                    BreakWall();
                    cells[currentNeighbour].visited = true;
                    visitedCells++;
                    lastCells.Add(currentCell);
                    currentCell = currentNeighbour;
                    if (lastCells.Count > 0)
                    {
                        backingUp = lastCells.Count - 1;
                    }
                }
            }
            else
            {
                currentCell = Random.Range(0, totalCells);
                cells[currentCell].visited = true;
                visitedCells++;
                startedBuilding = true;
            }


        }

        Debug.Log("Finished");

    }

    void BreakWall()
    {
        switch (wallToBrake)
        {
            case 1: Destroy(cells[currentCell].north); break;
            case 2: Destroy(cells[currentCell].east); break;
            case 3: Destroy(cells[currentCell].west); break;
            case 4: Destroy(cells[currentCell].south); break;
        }

    }

    void GiveMeNeighbour()
    {
        
        int length = 0;
        int[] neighbours = new int[4];
        int check = 0;
        int[] connectingWall = new int[4];

        check = ((currentCell + 1) / (xSize + 1));
        check -= 1;
        check *= xSize + 1;
        check += xSize + 1;


        //west wall
        if (currentCell + 1 < totalCells && (currentCell + 1) != check)
        {
            if (cells[currentCell + 1].visited == false)
            {
                neighbours[length] = currentCell + 1;
                connectingWall[length] = 3;
                length++;
            }
        }

        //east wall
        if (currentCell - 1 >= 0 && currentCell != check)
        {
            if (cells[currentCell - 1].visited == false)
            {
                neighbours[length] = currentCell - 1;
                connectingWall[length] = 2;
                length++;
            }
        }

        //north wall
        if (currentCell + (xSize + 1) < totalCells)
        {
            if (cells[currentCell + (xSize + 1)].visited == false)
            {
                neighbours[length] = currentCell + (xSize + 1);
                connectingWall[length] = 1;
                length++;
            }
        }
         
        //south wall
        if (currentCell - (xSize + 1) >= 0)
        {
            if (cells[currentCell - (xSize + 1)].visited == false)
            {
                neighbours[length] = currentCell - (xSize + 1);
                connectingWall[length] = 4;
                length++;
            }
        }

        if (length != 0)
        {
            int theChosenOne = Random.Range(0, length);
            currentNeighbour = neighbours[theChosenOne];
            wallToBrake = connectingWall[theChosenOne];
        }
        else
        {
            if (backingUp > 0)
            {
                currentCell = lastCells[backingUp];
                backingUp--;
            }
        }


    }

	// Update is called once per frame
	void Update () {
		
	}
}
