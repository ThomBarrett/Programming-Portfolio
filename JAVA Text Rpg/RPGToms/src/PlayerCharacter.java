import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.LinkedList;
import java.util.Scanner;

/**
 * @author Thomas Barrett
 *
 */
public class PlayerCharacter implements Serializable {
	private String PlayerName;
	private char PlayerGender;
	private int PlayerAge;
	private String PlayerBirthMonth;
	private String PlayerClass;
	
	private Location currentLocation = null;
	
	private int PlayerLevel;
	private int PlayerExpToNext;
	private int PlayerExp;
	
	private int PlayerMoney = 0;
	
		
	private int PlayerMaxHealthPoints;
	private int PlayerHealthPoints;
	
	private int PlayerDefencePoints;
	
	
	private Inventory.InventorySingleton inventory;
	
	
	public PlayerCharacter(){ //param changes
		/*
		 * This Constructor only call objects own functions
		 *  Creation Methods 
		 *    this.MakeName()
		 *    this.MakeGender()
		 *    this.MakeAge()
		 *    this.MakeBirthMonth()
		 *    
		 *  Finalisation Methods
		 *    this.ValidateGeneration()
		 *    
		 * */
			
			
		
		this.PlayerLevel = 1;
		this.PlayerExp = 0;
		this.PlayerExpToNext = 10;
		MakeName();
		MakeGender();
		MakeAge();
		MakeBirthMonth();
		boolean success;
		do{
			success = ValidateGeneration();
		}while(success == false);
	}

////Generation of PCharacter////
	
	/**
	 * @param None
	 * @return None
	 */
	private void MakeName(){
		//Asks user to enter There name then assigns it to PlayerName
		Scanner scan = new Scanner(System.in);
		RpgGame.GameUtils.AnimateText("What is your name?" ,125);
		this.PlayerName = scan.nextLine();
	}
	
	/**
	 * @param None
	 * @return None
	 */
	private void MakeGender(){
		//Prompt user for there Gender and Store Result in PlayerGender if they have selected a valid gender
		Scanner scan = new Scanner(System.in);
		RpgGame.GameUtils.AnimateText("What is your Gender?");
		System.out.print("(0) ");
		RpgGame.GameUtils.AnimateText("MALE");
		System.out.print("(1) ");
		RpgGame.GameUtils.AnimateText("FEMALE");
		
		switch(scan.nextLine()){
		case "0":
			PlayerGender = 'M';
			break;
		case "1":
			PlayerGender = 'F';
			break;
			
		default:
			RpgGame.GameUtils.AnimateText("Invalid!");
			MakeGender();
			break;
		}
	}
	
	
	
	/**
	 * @param None
	 * @return None
	 */
	private void MakeAge(){
		Scanner scan = new Scanner(System.in);
		RpgGame.GameUtils.AnimateText("What is your Age?" ,125);
		try{
		PlayerAge = scan.nextInt();
		}
		catch(Exception e){
			RpgGame.GameUtils.AnimateText("Invalid!",125);
			MakeAge();
		}
	}
	
	/**
	 * @param None
	 * @return None
	 */
	private void MakeBirthMonth(){
		/*
		 * Methods:
		 *     RpgGame.GameUtils.AnimateText()
		 *     ReferInformation.getMonthsArray()
		 *     ReferInformation.getMonth()
		 *     
		 *     MakeBirthMonth();
		 * 
		 */
		Scanner scan = new Scanner(System.in);
		RpgGame.GameUtils.AnimateText("What is your BithMonth?");
		ReferInformation referinfo = new ReferInformation();
		int count = 0;
		for(String element : referinfo.getMonthsArray()){
			count++;
			System.out.print("(" + count + ") ");
			RpgGame.GameUtils.AnimateText(element ,50);
		}
		
		switch(scan.next()){
		case "1":
			PlayerBirthMonth = referinfo.getMonth(1);
			break;
		case "2":
			PlayerBirthMonth = referinfo.getMonth(2);
			break;
		case "3":
			PlayerBirthMonth = referinfo.getMonth(3);
			break;
		case "4":
			PlayerBirthMonth = referinfo.getMonth(4);
			break;
		case "5":
			PlayerBirthMonth = referinfo.getMonth(5);
			break;
		case "6":
			PlayerBirthMonth = referinfo.getMonth(6);
			break;
		case "7":
			PlayerBirthMonth = referinfo.getMonth(7);
			break;
		case "8":
			PlayerBirthMonth = referinfo.getMonth(8);
			break;
		case "9":
			PlayerBirthMonth = referinfo.getMonth(9);
			break;
		case "10":
			PlayerBirthMonth = referinfo.getMonth(10);
			break;
		case "11":
			PlayerBirthMonth = referinfo.getMonth(11);
			break;
		case "12":
			PlayerBirthMonth = referinfo.getMonth(12);
			break;
			
		default:
			RpgGame.GameUtils.AnimateText("Invalid!");
			MakeBirthMonth();
			break;
		}
	}

////Checking correct Data
	
	/**
	 * @param None
	 * @return Boolean
	 */
	private boolean ValidateGeneration(){
		//Show the user the information regarding the player and ask if this player is ready and Call Check Character 
		Scanner scan = new Scanner(System.in);
		System.out.println("Name: " + PlayerName);
		System.out.println("Gender: " + PlayerGender);
		System.out.println("Age: " + PlayerAge);
		System.out.println("Birth Month: " + PlayerBirthMonth);
		System.out.println();
		
		RpgGame.GameUtils.AnimateText("Is this character ready?");
		System.out.print("(0) ");
		RpgGame.GameUtils.AnimateText("Yes");
		System.out.print("(1) ");
		RpgGame.GameUtils.AnimateText("No");
		
		boolean result = CheckCharacter(scan.next());
		if(result == true) {
			saveToFile();
		}
		return result;
		
		
		
	}
	
	/**
	 * @param String input
	 * @return Boolean
	 */
	private Boolean CheckCharacter(String input){
		// If player is okay with their choices it returns true else it asks them what element they would change 
		// Then Call the function to change their selected choice then ask if there is still anything to change
		Scanner scan = new Scanner(System.in);
		switch(input){
		
		case "0":
			return true;
			
		case "1":
			RpgGame.GameUtils.AnimateText("What would you like to change?");
			System.out.print("(0) ");
			RpgGame.GameUtils.AnimateText("Name");
			
			System.out.print("(1) ");
			RpgGame.GameUtils.AnimateText("Gender");
			
			System.out.print("(2) ");
			RpgGame.GameUtils.AnimateText("Age");
			
			System.out.print("(3) ");
			RpgGame.GameUtils.AnimateText("Birth Month");
			
			switch(scan.next()){
			case "0":
				MakeName();
				return false;
			
			case "1":
				MakeGender();
				return false;
				
			case "2":
				MakeAge();
				return false;
				
			case "3":
				MakeBirthMonth();
				return false;
				
			default:
				return ValidateGeneration();
			}
		}
		return true;
	}
	
	
	//Saving, Deleting Loading
	public void saveToFile() {
		File file = new File("src/Files/SaveFile.txt");
		
		FileOutputStream fos = null;
        ObjectOutputStream out = null;
        try {
            fos = new FileOutputStream(file);
            out = new ObjectOutputStream(fos);
            
            out.writeObject(this);

            out.close();
            DateFormat df = new SimpleDateFormat("dd/MM/yy HH:mm:ss");
            Calendar calobj = Calendar.getInstance();
            
            System.out.println("Save worked " + calobj.getTime());
        } catch (Exception ex) {
            ex.printStackTrace();
        }
		
	
		
	}
	
	public void loadFromFile() {

	}
	
	public void DisplayPlayerMenu() {
		
	}
	
////Getter and Setters
	/**
	 * @param None
	 * @return String PlayerName
	 */
	public String getPlayerName(){
		return PlayerName;
	}
	
	public Location getLocation() {
		return currentLocation;
	}
	
	public void setLocation(Location input) {
		this.currentLocation = input; 
	}
	
	public boolean moneyDeduct(int input) {
		if(input <= this.PlayerMoney) {
			this.PlayerMoney -= input;
			return true;
		}else {
			return false;
		}
	}
	
	public void moneyTake(int input) {
		this.PlayerMoney += input;
	}
	
	
	

}
