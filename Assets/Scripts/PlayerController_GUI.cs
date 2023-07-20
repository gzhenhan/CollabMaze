using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController_GUI : MonoBehaviour
{   
    public Rigidbody2D rb;
    public Animator animator;

    public float speed = 5f;
    public Vector2 uiMovement;
    private Vector2 keyMovement;
    //private bool walking;
    
    private Vector2 lastMoveDirection;

    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    public Transform firePoint;
    public GameObject redBulletPrefab;
    public GameObject blueBulletPrefab;
    public float bulletForce = 20f;
    //public int damage = 10;

    void Start()
    {   
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else{
            Load();
        }
        UpdateCharacter(selectedOption);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        if(selectedOption == 0){
            animator.runtimeAnimatorController = Resources.Load("Hero") as RuntimeAnimatorController;
        }

        if(selectedOption == 1){
            animator.runtimeAnimatorController = Resources.Load("Mole") as RuntimeAnimatorController;
        }

        if(selectedOption == 2){
            animator.runtimeAnimatorController = Resources.Load("Tree") as RuntimeAnimatorController;
        }
    }

    private void UpdateCharacter(int selectedOption){
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    void Animate(){
        animator.SetFloat("Horizontal", uiMovement.x);
        animator.SetFloat("Vertical", uiMovement.y);
        animator.SetFloat("Speed", uiMovement.sqrMagnitude);
        animator.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        animator.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }

    public void shootRed(){

        GameObject redBullet = Instantiate(redBulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb_red = redBullet.GetComponent<Rigidbody2D>();
        // Left
        if(uiMovement.x <0 || lastMoveDirection.x <0){
            rb_red.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        if(uiMovement.x >0 || lastMoveDirection.x >0){
            rb_red.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        if((uiMovement.y <0 || lastMoveDirection.y <0) ||(lastMoveDirection.x == 0 && lastMoveDirection.y ==0)){
            rb_red.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        if(uiMovement.y >0 || lastMoveDirection.y >0){
            rb_red.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void shootBlue(){
        GameObject blueBullet = Instantiate(blueBulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb_blue = blueBullet.GetComponent<Rigidbody2D>();
        if(uiMovement.x <0 || lastMoveDirection.x <0){
            rb_blue.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        if(uiMovement.x >0 || lastMoveDirection.x >0){
            rb_blue.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        if((uiMovement.y <0 || lastMoveDirection.y <0) ||(lastMoveDirection.x == 0 && lastMoveDirection.y ==0)){
            rb_blue.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        if(uiMovement.y >0 || lastMoveDirection.y >0){
            rb_blue.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    void Update() 
    {      
        float moveX = CrossPlatformInputManager.GetAxis("Horizontal"); // left = -1, right = 1
        float moveY = CrossPlatformInputManager.GetAxis("Vertical");
        if((moveX == 0 && moveY == 0) && uiMovement.x != 0 || uiMovement.y != 0){
            lastMoveDirection = uiMovement;
        }
        uiMovement = new Vector2(moveX, moveY);

        Animate();
       
        /*keyMovement.x = Input.GetAxisRaw("Horizontal"); // left = -1, right = 1
        keyMovement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", keyMovement.x);
        animator.SetFloat("Vertical", keyMovement.y);
        animator.SetFloat("speed", keyMovement.sqrMagnitude); */
        
    }

    void FixedUpdate(){
        // Movement
        rb.MovePosition(rb.position + uiMovement * speed * Time.fixedDeltaTime);
        //rb.MovePosition(rb.position + keyMovement * speed * Time.fixedDeltaTime);
    }
    
}
