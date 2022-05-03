using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battleloop : MonoBehaviour
{
    public Text PCHealth;
    public Text EnHealth;
    public Text EnTitle;
    public Text MoveTitle;
    public int MaxHealth;
    private int CurrentHealth;
    private int damage;
    private int Def;
    private int EnDamage;
    private int Speed;
    private int heal;
    private int TotalDamage;
    private int turnumber;
    private int RNG;
    private int MoveRNG;    
    private int EnMaxHealth;
    private int ENCurrentHealth;
    private string EnMove; // for the move number
    private string Enmove; // for move name
    private string name;
    public Sprite CommanderCarrot;
    public Sprite RandyRadish;
    public Sprite OlivanderTheOnion;
    private bool next;
    public GameObject Moves;
    public Image EnImage;
   

    // Start is called before the first frame update
    void Start()
    {       
        RNG = Random.Range(1, 4);
        //MoveRNG = Random.Range(1, 11);
        //PCHealth.text = "HP: " + CurrentHealth + "/" + MaxHealth;
        if (RNG == 1)
        {
            name = "Commander Carrot";
            EnTitle.text = name;
            EnMaxHealth = 20;
            Enmove = "Barrage";
            Def = 8;
            EnDamage = 12;
            EnImage.sprite = CommanderCarrot;

         
        }


        if (RNG == 2)
        {
            name = "Olivander The Onion";
            EnTitle.text = name;
            EnMaxHealth = 40;            
            Enmove = "Roll";
            Def = 10;
            EnDamage = 8;
            EnImage.sprite = OlivanderTheOnion;
       
        }


        if (RNG == 3)
        {
            name = "Randy Radish";
            EnTitle.text = name;
            EnMaxHealth = 10;
            Enmove = "Head Butt";
            Def = 5;
            EnDamage = 5;
            EnImage.sprite = RandyRadish;


        }

        CurrentHealth = MaxHealth;
        ENCurrentHealth = EnMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
        
        next = false;
        PCHealth.text = "HP:" + CurrentHealth + "/" + MaxHealth;
        EnHealth.text = "HP: " + ENCurrentHealth + "/" + EnMaxHealth;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            turn(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            turn(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            turn(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            turn(4);
        }
        if (Input.GetKeyDown("space"))
        {

            next = true;
            EnTurn();
        }
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            MoveTitle.text = name + " killed you... you died.";
            StartCoroutine(WaitBeforDeath());
        }
        if (ENCurrentHealth < 0)
        {
            ENCurrentHealth = 0;
            MoveTitle.text = "You killed " + name + " you survived!!";
            StartCoroutine(WaitBeforENDeath());
        }

    }

    public void turn(int move)
    {
        if (move == 1)
        {
            
            Debug.Log("Pitchfork");
            damage = 17;
            GameObject.FindWithTag("Moves").SetActiveRecursively(false);
            MoveTitle.text = "you use your pitchfork";
            TotalDamage = damage - Def;
            ENCurrentHealth = ENCurrentHealth - TotalDamage;



        }

        if (move == 2)
        {
            
            Debug.Log("Fertiliser");
            heal = 17;
            GameObject.FindWithTag("Moves").SetActiveRecursively(false);
            MoveTitle.text = "you use your Fertiliser";
            if (CurrentHealth < 30)
            {
                CurrentHealth = CurrentHealth + heal;
            }
            if (CurrentHealth > 30)
            {
                CurrentHealth = 30;
            }

        }

        if (move == 3)
        {
            
            Debug.Log("Pesticide");
            damage = 15;
            GameObject.FindWithTag("Moves").SetActiveRecursively(false);
            MoveTitle.text = "you use your Pesticide";
            TotalDamage = damage;
            ENCurrentHealth = ENCurrentHealth - TotalDamage;


        }

        if (move == 4)
        {
           
            Debug.Log("Punch");
            damage = 0; // this is show how the death mechanic works change later
            GameObject.FindWithTag("Moves").SetActiveRecursively(false);
            MoveTitle.text = "you use your fist to punch them";
            TotalDamage = damage;
            ENCurrentHealth = ENCurrentHealth - TotalDamage;



        }
    }
        void EnTurn()
        {
            MoveTitle.text = (name + " uses " + Enmove);
            CurrentHealth = CurrentHealth - EnDamage;
            LoopTurn();

        }
        void LoopTurn()
        {

            Moves.SetActive(true);
        }
        IEnumerator WaitBeforNext()
        {
            
            yield return new WaitForSeconds(1);
            MoveRNG = Random.Range(1, 11);
            EnTurn();
        }


        IEnumerator WaitBeforDeath()
        {
            yield return new WaitForSeconds(2);
            death();
        }
        IEnumerator WaitBeforENDeath()
        {
            yield return new WaitForSeconds(2);
            Endeath();
        }

        void death()
        {
            SceneManager.LoadScene("death");
        }
        void Endeath()
        {
            SceneManager.LoadScene("Tutorial Scene");
        }
}   
