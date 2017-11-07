import java.io.File;
import java.io.FileInputStream;
import java.io.ObjectInputStream;

/**
	 * @author Thomas Barrett
	 *
	 */
public class RpgGame {
	//RpgGame is the Class that contains the main Methods
	public static class GameUtils {
	//Game Utils is a static case functions required across the whole game
		/**
		 * @param String text
		 * @return None
		 */
		public static void AnimateText(String text){
			//Animate out a text using a default delay time
			char[] textani = text.toCharArray();
			for(char element : textani){
				System.out.print(element);
				try {
					Thread.sleep(0);
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
			}
			System.out.println();			
		}
		
		/**
		 * @param String text
		 * @param int input
		 * @return None
		 */
		public static void AnimateText(String text, int input){
			//Animate Text out with more control over the delay time
			char[] textani = text.toCharArray();
			for(char element : textani){
				System.out.print(element);
				try {
					Thread.sleep(input);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
			System.out.println();	
		}

		/**
		 * @param int input
		 * @return None
		 */
		public static void Delay(int input){
			//Call a delay
			try{
				Thread.sleep(input);
			}catch(Exception e){
				e.printStackTrace();
			}
		}
	}

	/*
	 * Ideas and Stretch Goals
	 * 
	 *    Save to a file <Fix>
	 *    Load From file <Fix>
	 *    Create a UI for user to see their Player Stats
	 *    Work with different location types <Continue>
	 * */
	
	public static void main(String[] args) {
		/*
		 * Create a StoryArc object with is used to connect to all other classes
		 * 
		 * Each function documents all external functions used and any external attributes
		 * The goal is to limit the number of attributes used with getters and setters
		 * 
		 * Story Arc main
		 *     Methods:
		 *     	   StoryArc Constructor
		 *         DisplayStartMenu()
		 *         getPlayerCharacter()
		 *         getGameWorld().DisplayMap()
		 *         DisplayGamePlayMenu()
		 *         ----
		 *     Attributes:
		 *     	   ----
		 *     
		 *         */

		
		
		
		StoryArc storyarc = new StoryArc();
		storyarc.DisplayStartMenu();
		storyarc.getPlayerCharacter();
		storyarc.CreateTheGameWorld();
		storyarc.getGameWorld().DisplayMap();
		while(1 == 1){ // Change this while loop to something more fitting that takes into account Game State
		storyarc.DisplayGamePlayMenu();
		storyarc.getPlayerCharacter().saveToFile();
		}
	}
	
	
}
