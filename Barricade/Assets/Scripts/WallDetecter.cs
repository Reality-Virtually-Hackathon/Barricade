using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetecter : MonoBehaviour {

    bool[,] isClicked;
    bool north = false;
    bool south = false;
    bool east = false;
    bool west = false; 
    private int count = 0; 

    public void FindSelected(float x, float y)
    {
        //print(x + " " + y); 
        bool north = false;
        bool south = false;
        bool east = false;
        bool west = false;
        count = 0; 
        isClicked = new bool[gameObject.GetComponent<Grid>().width, gameObject.GetComponent<Grid>().height];
        for (int i = 0; i < gameObject.GetComponent<Grid>().width; i++)
        {   
            for (int j = 0; j < this.gameObject.GetComponent<Grid>().height; j++)
            {

                GameObject curr = GameObject.Find(i + " " + j);

                isClicked[i, j] = curr.GetComponent<Tile>().isClicked;
            }
        }
        for (int i = 0; i < gameObject.GetComponent<Grid>().width; i++)
        {
            for (int j = 0; j < this.gameObject.GetComponent<Grid>().height; j++)
            {
				print(isClicked[i, j].ToString() + x + " " + y);
            }
        }

		int xPos = (int)x; 
		int yPos = (int)y; 
		for (int i = (int)x + 1; i <= gameObject.GetComponent<Grid> ().width - 1; i++) {
            /*
			GameObject found = GameObject.Find(i + " " + y);
			found.GetComponent<Renderer> ().material.color = Color.green; 
            */
            count = 0; 
            int check = CheckCardinalDirectionsTile(isClicked, (int)i, (int)y); 

            if (isClicked [(int)i, (int)y] == true) {
                break;
			}
			else if (check <=3) {
                print("w");
			} else if (check == 4) { 
				print ("FUCK YEAH"); 
			}
			
		}
		for (int i = (int)x - 1; i >= 0; i--) {
            /*
			GameObject found = GameObject.Find(i + " " + y);
			found.GetComponent<Renderer> ().material.color = Color.green; 
            */
            count = 0; 
            int check = CheckCardinalDirectionsTile(isClicked, (int)i, (int)y); 

            if (isClicked [(int)i, (int)y] == true) {
                break;  
			}
			else if (check <= 3) {
                print("e");
			} else if (check == 4) { 
				print ("FUCK YEAH"); 
			}
			//CheckCardinalDirectionsTile (isClicked, (int)i, (int)y);  
			
		}


		for (int i = (int)y - 1; i >= 0; i--) {
            //print (x + " " + i); 
            count = 0; 
            int check = CheckCardinalDirectionsTile(isClicked, (int) xPos, (int) i);
            /*
			GameObject found = GameObject.Find(xPos + " " + i);
			found.GetComponent<Renderer> ().material.color = Color.green;
			*/
            
            if (isClicked[(int)xPos, (int)i] == true)
                break;
            else if (check <= 3)
            {

            }
            else if (check == 4)
            {
                print("FUCK YEAH");
            }
		

		}
		for (int i = (int)y + 1; i <= gameObject.GetComponent<Grid> ().height - 1; i++) {
            //print (x + " " + i); 
            count = 0; 
            /*
			GameObject found = GameObject.Find(xPos + " " + i);
			found.GetComponent<Renderer> ().material.color = Color.green;
			*/
            int check = CheckCardinalDirectionsTile(isClicked, (int)xPos, (int)i); 

            if (isClicked [(int)xPos, (int)i] == true) {
                break; 
			
			}
			else if ( check<=3) { 

			} else if (check == 4) { 
				print ("FUCK YEAH"); 
			}

		}
    }


    int CheckCardinalDirectionsTile(bool[,] isClicked, int xPos, int yPos)
    {

        print(xPos + " " + yPos); 
        for (int n = yPos-1; n >= 0; n--)
        {
            if (isClicked[xPos, n] == true)
            {
                north = true;
                print("true: " + xPos.ToString() + " " + n);
				count++; 
                break; 
            }
                       
        }
        //print("north: " + north.ToString()); 
        for (int i = yPos +1; i <= gameObject.GetComponent<Grid>().height -1; i++)
        {
            if (isClicked[xPos, i] == true)
            {
                south = true;
                print("true: " + xPos.ToString() + " " + i); 
				count++; 
                break;
            }
			          
        }
        //print("south: " + south.ToString());
        for (int i = xPos + 1; i <= gameObject.GetComponent<Grid>().width-1; i++)
        {
            if (isClicked[i, yPos] == true)
            {
                east = true;
                print("true: " + i + " " + yPos);
				count++; 
                break;
            }
        
        }
        //print("east: " + east.ToString()); 
        for (int i = xPos -1; i >= 0; i--)
        {
           // print(i.ToString()); 
            if (isClicked[i, yPos] == true)
            {
                west = true;
				count++; 
                print("true: " + i + " " + yPos);
                break; 
            }
 
        }

        GameObject found = GameObject.Find(xPos + " " + yPos);
        //print("west : " + west.ToString()); 
       
		print (count.ToString ()); 
		if (count == 0) { 
			found.GetComponent<Renderer> ().material.color = Color.blue;
		}
		else if (count == 1) {
			found.GetComponent<Renderer> ().material.color = Color.green;
		} else if (count == 2) {
			found.GetComponent<Renderer> ().material.color = Color.yellow;
		} else if (count == 3) {
			found.GetComponent<Renderer> ().material.color = Color.gray; 
		} else if (count == 4) { 
			found.GetComponent<Renderer> ().material.color = Color.black; 
		}

		return count;
    }


  

}
