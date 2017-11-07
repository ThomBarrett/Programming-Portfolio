import java.io.Serializable;
import java.util.LinkedList;
import java.util.List;
import java.util.Random;

public abstract class Location implements Serializable {
	protected String id;
	protected int posX;
	protected int posY;
	
	Exploration explorable;
	Merchantable merchantable; 
	
	protected boolean accessTop;
	protected boolean accessTopLeft;
	protected boolean accessTopRight;
	
	protected boolean accessBottom;
	protected boolean accessBottomLeft;
	protected boolean accessBottomRight;
	
	protected boolean accessLeft;
	protected boolean accessRight;
	protected char type = ' ';
	protected String instantInfo = "Information about the place";
	
	
	
	
	/**
	 * @Constructor Location
	 * @param None
	 * @return None
	 */
	public Location(){
		
		
		Random rand = new Random();
		accessTop = rand.nextBoolean();
		accessBottom = rand.nextBoolean();
		accessLeft = rand.nextBoolean();
		accessRight = rand.nextBoolean();
	}
	//ID
	/**
	 * @Param None
	 * @return String id
	 */
	public String getId(){
		return id;
	}
	
	
	/**
	 * @param String input
	 * @return None
	 */
	public void setId(String input){
		this.id = input;
	}
	
	public char getType(){
		
		return type;
		
	}
	
////Attributes///////////////////////////////////////////////////////////////////////////////////
		
	/**
	 * @param None
	 * @return int posX
	 */
	public int getPosX(){
		return posX;
	}
	
	
	/**
	 * @param None
	 * @return int posY
	 */
	public int getPosY(){
		return posY;
	}
	
	/**
	 * @param int input
	 * @return None
	 */
	public void setPosX(int input){
		this.posX = input;
	}
	
	/**
	 * @param int input
	 * @return None
	 */
	public void setPosY(int input){
		this.posY = input;
	}
	
	public String getInstantInformation() {
		return this.instantInfo;
	}	
	public void setInstantInformation(String input) {
		this.instantInfo = input;
	}
}
