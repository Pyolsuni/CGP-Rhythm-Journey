using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public GameObject Music;
    public GameObject CubeSpawner_Hard;
    public GameObject CubeSpawner_Easy;
    public GameObject Background;
    public GameObject Score_Gameplay;
    public GameObject Highscore_Board;

    public GameObject Cube_Easy;
    public GameObject Cube_Hard;
    public GameObject TextLvlSelect;

    private GameObject cubehard;
    private GameObject cubeeasy;

    public static GameStatus gameinstance;

    // Start is called before the first frame update
    void Start()
    {
        //Lorsque je suis dans le menu
        Score_Gameplay.SetActive(false);
        Music.SetActive(false);
        CubeSpawner_Hard.SetActive(false);
        CubeSpawner_Easy.SetActive(false);
        Background.SetActive(false);
        Highscore_Board.SetActive(true);
        TextLvlSelect.SetActive(true);

        Spawn(0);

        gameinstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Hard Mode
            Score_Gameplay.SetActive(true);
            Music.SetActive(true);
            CubeSpawner_Hard.SetActive(true);
            CubeSpawner_Easy.SetActive(false);
            Background.SetActive(true);
            Highscore_Board.SetActive(false);
            TextLvlSelect.SetActive(false);

            Destroy(cubehard);
            Destroy(cubeeasy);
            //Cube_Easy.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            // Easy Mode
            Score_Gameplay.SetActive(true);
            Music.SetActive(true);
            CubeSpawner_Hard.SetActive(false);
            CubeSpawner_Easy.SetActive(true);
            Background.SetActive(true);
            Highscore_Board.SetActive(false);
            TextLvlSelect.SetActive(false);

            Destroy(cubehard);
            Destroy(cubeeasy);
            //Cube_Hard.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CleanChildren();
            Score_Gameplay.SetActive(false);
            Music.SetActive(false);
            CubeSpawner_Hard.SetActive(false);
            CubeSpawner_Easy.SetActive(false);
            Background.SetActive(false);
            Highscore_Board.SetActive(true);
            TextLvlSelect.SetActive(true);


            Spawn(0);
        }
    }

    public void Spawn(int number)
    {
        if (number == 1)
        {
            cubehard = Instantiate(Cube_Hard, new Vector3(1, 1, -1), Quaternion.identity);
        }

        if (number == 2)
        {
            cubeeasy = Instantiate(Cube_Easy, new Vector3(-1, 1, -1), Quaternion.identity);
        }
        else
        {
            cubehard = Instantiate(Cube_Hard, new Vector3(1, 1, -1), Quaternion.identity);
            cubeeasy = Instantiate(Cube_Easy, new Vector3(-1, 1, -1), Quaternion.identity);
        }
        
    }

    public void EasyMode()
    {
        Score_Gameplay.SetActive(true);
        Music.SetActive(true);
        CubeSpawner_Hard.SetActive(false);
        CubeSpawner_Easy.SetActive(true);
        Background.SetActive(true);
        Highscore_Board.SetActive(false);
        TextLvlSelect.SetActive(false);

        Destroy(cubehard);
    }

    public void HardMode()
    {
        Score_Gameplay.SetActive(true);
        Music.SetActive(true);
        CubeSpawner_Hard.SetActive(true);
        CubeSpawner_Easy.SetActive(false);
        Background.SetActive(true);
        Highscore_Board.SetActive(false);
        TextLvlSelect.SetActive(false);

        Destroy(cubeeasy);
    }


        public void CleanChildren()
    {
        for (int i = 0; i < CubeSpawner_Hard.transform.childCount; i++)
        {
            Destroy(CubeSpawner_Hard.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < CubeSpawner_Easy.transform.childCount; i++)
        {
            Destroy(CubeSpawner_Easy.transform.GetChild(i).gameObject);
        }
    }
}