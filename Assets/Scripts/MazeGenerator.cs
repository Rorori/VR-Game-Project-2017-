using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

	/******
	 * This class will generate the maze using the maze cell prefab. A grid of maze cells will be created,
	 * and a maze object will be created using kruskal's algorithm (or any other algorithm that randomly 
	 * generates mazes using minimum spanning trees). The maze object will tell which walls in each maze cell
	 * will be hidden from the player such that the sections of the maze can be closed or opened on will by the
	 * player.
	 * 
	 * TO DO:
	 * 1) Connect the maze cell prefab to this script and generate a grid of maze cells
	 * 2) Implement Kruskal's algorithm to create a maze object within the script
	 * 3) Have each cell represent a separate tree and connect each "tree" via the generated maze
	 * 4) Connections between cells will be represented by the corresponding cell walls (North to South, East to west, etc.) 
	 * 		between each cell; two connected cells (or trees) will be represented by adjacent walls being hidden from the game.
	 * 5) Create an area in the maze for the "boss" to spawn. It should be far away from where the player enters the maze.
	 */

	// Use this for initialization
	void Start () {
		//Within the maze, spawn the "boss" at a certain coordinate.
		//Since the maze will not have closed off areas, any place within the maze
		//is a legitimate place to spawn the boss; however, to keep it interesting for the player.
		//the boss will spawn away from the player to lengthen the search.
	}

	void MazeGeneration(){
		//Create 2D array here and populate it with references to the mazecells.
		//Each element in the 2D array can be thought of as an individual tree;
		//these trees will be connected via removal of their walls, not by actual
		//connection of elements within the array.
	}
	
	// Update is called once per frame
	void Update () {
		//Add functionality to respawn walls between cells.
		//Also add a check where if the boss finds itself on a cell that has
		//all walls on it (as in, it is on a smallest tree), it transforms into a chest.
	}
}
