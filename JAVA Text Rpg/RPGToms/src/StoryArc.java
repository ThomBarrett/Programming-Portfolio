import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.sql.Date;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Scanner;



 /**
 * @author Thomas Barrett
 *
 */
class StoryArc {
	 
	private PlayerCharacter playercharacter;
	private GameWorld gameworld;
	public StoryArc(){
		RpgGame.GameUtils.AnimateText("<----Tom's Game---->");
	}
	
	/**
	 * @param None
	 * @return None
	 */
	public void Play(){
		boolean loaded = false;
		/*Gives Story beginning and prompts use to create there player Character this function called from the start menu
		 * 
		 *    Methods Called:
		 *        RpgGame.GameUtils.AnimateText()
		 *        PlayerCharacter constructor
		 *        -----
		 *    Attributes Used:
		 *        -----
		 */
		
		
		
		
		File file = new File("src/Files/SaveFile.txt");
		
		//DeleteGame();
		
		FileInputStream fis = null;
		ObjectInputStream ois = null;
		try {
			fis = new FileInputStream(file);
			ois = new ObjectInputStream(fis);
			
			if(file.length() > 4) {
				loaded = true;
			 this.playercharacter = (PlayerCharacter) ois.readObject();
			 
			 
			 
			 
			}
			ois.close();
		}catch(Exception e){
			e.printStackTrace();
			}
		if(loaded == false) {
			RpgGame.GameUtils.AnimateText("You wake up...");
			RpgGame.GameUtils.AnimateText("The Castle guard asks you to identify yourself.");
			
			System.out.println();
			
			RpgGame.GameUtils.AnimateText("Time to create you!");
			playercharacter = new PlayerCharacter();
		}else {
			DateFormat df = new SimpleDateFormat("dd/MM/yy HH:mm:ss");
			Calendar calobj = Calendar.getInstance();
			RpgGame.GameUtils.AnimateText(this.playercharacter.getPlayerName() + " " + df.format(calobj.getTime()) + " Loaded");
		}
		
	}
	
	/**
	 * @param None
	 * @return None
	 */
	public void Quit(){
		RpgGame.GameUtils.AnimateText("Ending Game Session");
		System.exit(0);
	}
	
	public void DeleteGame() {
		File file = new File("src/Files/SaveFile.txt");

		FileOutputStream fos = null;
		ObjectOutputStream out = null;
		try {
			fos = new FileOutputStream(file);
			out = new ObjectOutputStream(fos);

			out.flush();

			out.close();

			DateFormat df = new SimpleDateFormat("dd/MM/yy HH:mm:ss");
			Calendar calobj = Calendar.getInstance();
			System.out.println("Delete worked at" + calobj.getTime());
		} catch (Exception ex) {
			ex.printStackTrace();
		}
	}

	/**
	 * @param None
	 * @return None
	 */
	public void DisplayStartMenu(){

		//Display the Main Game menu giving the player options to play or quit
		/*
		 * Methods:
		 *     RpgGame.GameUtils.AnimateText()
		 *     Play()
		 *     Quit()
		 *     DisplayStartMenu()
		 *     -----
		 *     
		 * Attributes:
		 *     -----
		 */
		System.out.println();
		
		System.out.print("(0) ");
		RpgGame.GameUtils.AnimateText("Play!");
		System.out.print("(1) ");
		RpgGame.GameUtils.AnimateText("Delete Game");
		System.out.print("(2) ");
		RpgGame.GameUtils.AnimateText("Quit");
		Scanner scan = new Scanner(System.in);
		String input = scan.next();

		
		switch(input){
		case "0":
			Play();
			break;
		case "1":
			DeleteGame();
			break;
		case "2":
			Quit();
			break;
		default:
			DisplayStartMenu();
			Quit();
			break;
		}
		
	}
	
	/**
	 * @param None
	 * @return PlayerCharacter
	 */
	public PlayerCharacter getPlayerCharacter(){
		return playercharacter;
	}
	
	/**
	 * @param None
	 * @return None
	 */
	public void CreateTheGameWorld(){
		gameworld = new GameWorld(10,10,this.getPlayerCharacter());
	}
	
	/**
	 * @param None
	 * @return GameWorld
	 */
	public GameWorld getGameWorld(){
		return gameworld;
	}
	
	/**
	 * @param None
	 * @return None
	 */
	public void DisplayGamePlayMenu(){
		/*
		 * This code displays all the users options at the current state of the game
		 * Methods:
		 *     RpgGame.GameUtils.AnimateText()
		 *     gameworld.Move()
		 *     gameworld.getLocation()
		 *     -----
		 * Attributes:
		 *     -----
		 * 
		 * */
		
		switch(gameworld.getLocation().getClass().getName()) {
			case "Path":
				System.out.print("(0) ");
				RpgGame.GameUtils.AnimateText("Move");
				System.out.print("(1) ");
				RpgGame.GameUtils.AnimateText("Explore");
				System.out.print("(2) ");
				RpgGame.GameUtils.AnimateText("Player");
				break;
			
			case "Merchant":
				System.out.print("(0) ");
				RpgGame.GameUtils.AnimateText("Move");
				System.out.print("(1) ");
				RpgGame.GameUtils.AnimateText("Shop");
				System.out.print("(2) ");
				RpgGame.GameUtils.AnimateText("Player");
				break;
				
				
			case "Location":
				throw new IllegalStateException("Location is abstract this location. Use a child class instead");
				
			default:
				throw new IllegalStateException("Unknown Location at this Position");
		}
		
		
		
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		
		
		
		
		switch(gameworld.getLocation().getClass().getName()){
		case "Path":
			if(input.equals("0")) {
				this.gameworld.Move();
			}
			if(input.equals("1")) {
				this.gameworld.getLocation().explorable.Explore();
			}
			if(input.equals("2")) {
				this.playercharacter.DisplayPlayerMenu();
			}
			break;
			
		case "Merchant":
			if(input.equals("0")) {
				this.gameworld.Move();
			}
			if(input.equals("1")) {
				this.merchantShop();
			}
			if(input.equals("2")) {
				this.playercharacter.DisplayPlayerMenu();
			}
		default:
			DisplayGamePlayMenu();
			break;
		}
	}
	private void merchantShop() {
		Scanner scan = new Scanner(System.in);
		//Merchant options BUY,SELL,CANCEL
		System.out.print("(0) ");
		RpgGame.GameUtils.AnimateText("BUY");
		System.out.print("(1) ");
		RpgGame.GameUtils.AnimateText("SELL");
		System.out.print("(-) ");
		RpgGame.GameUtils.AnimateText("CANCEL");
		
		switch(scan.nextLine()) {
			case "0":
				//Allow to select item for merchants array list
				Merchant current = (Merchant)this.getPlayerCharacter().getLocation();
				current.ItemArrayIterator();
				
				break;
			case "1":
				Inventory.InventorySingleton.displayContentsSell();
				break;
			case "-":
				break;
			default:
				merchantShop();
		}
		
		
		
	}
}
