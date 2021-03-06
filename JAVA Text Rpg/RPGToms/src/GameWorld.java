import java.util.Scanner;

public class GameWorld {
	private int capacityX;
	private int capacityY;
	Location[][] map;
	private int posX;
	private int posY;
	private PlayerCharacter currentPlayer;
	Location currentPos;
	
	/**
	 * @Constructor GameWorld
	 * @param int x
	 * @param int y
	 * @param PlayerCharacter player
	 */
	
	public GameWorld(int x, int y,PlayerCharacter player){
		map = new Location[x][y];
		capacityX = (x-1);
		capacityY = (y-1);
		this.currentPlayer = player;
		
		map[4][4] = new Path(true,true,true,true);
		map[5][4] = new Path(false,false,true,true);
		map[3][4] = new Path(false,false,true,true);
		map[4][3] = new Path(true,true,false,false);
		map[4][5] = new Path(true,true,false,false);
		map[4][3] = new Path(false,true,true,false);
		map[3][3] = new Path(true,false,true,true);
		map[2][3] = new Path(false,true,false,true);
		map[2][4] = new Path(true,false,false,true);
		map[4][6] = new Merchant(true,true,true,true);
		
		setLocation(4,4);
	}
	
	/**
	 * @param None
	 * @return Location currentPos
	 */
	public Location getLocation(){
		return currentPos;
	}
	
	/**
	 * @param int x
	 * @param int y
	 * @return None
	 */
	
	public void setLocation(int x, int y){
		if(x < capacityX && y < capacityY){
			posX = x;
			posY = y;
			
			currentPos = map[x][y];
			this.changeLocationChildCurrentPoss(currentPos);
		}
	}
	
	/**
	 * @param None
	 * @return None
	 */
	
	public void setLocation(){
		if(posX < capacityX && posY < capacityY){
			currentPos = map[posX][posY];
			this.changeLocationChildCurrentPoss(currentPos);
			currentPlayer.setLocation(currentPos);
		}
	}
	
	/**
	 * @param None
	 * @return None
	 */
	
	public void DisplayMap(){
		for(int i=0; i<map.length; i++) {
	        for(int j=0; j<map[i].length; j++) {
	            if(map[j][i] == null){
	    			System.out.print(' ');
	    		}else if(this.getLocationChildCurrent(map[j][i]) == true){
	    			System.out.print("☻");
	    		}else{
	    			System.out.print(map[j][i].getType());
	    		}
	        }
	        System.out.println();
	    }
		RpgGame.GameUtils.AnimateText(this.getLocation().getInstantInformation());
	}
	
	/**
	 * @param None
	 * @return None
	 */
	
	public void Move(){
		Scanner scan = new Scanner(System.in);
		if(map[posX][posY - 1] != null && map[posX][posY - 1].accessBottom != false){
			System.out.print("(0) ");
			RpgGame.GameUtils.AnimateText("North");
		}else{
			System.out.print("(0) ");
			RpgGame.GameUtils.AnimateText("-----");
		}
		if(map[posX + 1][posY] != null && map[posX + 1][posY].accessLeft != false){
			System.out.print("(1) ");
			RpgGame.GameUtils.AnimateText("East");
		}else{
			System.out.print("(1) ");
			RpgGame.GameUtils.AnimateText("-----");
		}
		if(map[posX][posY + 1] != null && map[posX][posY + 1].accessTop != false){
			System.out.print("(2) ");
			RpgGame.GameUtils.AnimateText("South");
		}else{
			System.out.print("(2) ");
			RpgGame.GameUtils.AnimateText("-----");
		}
		if(map[posX - 1][posY] != null && map[posX - 1][posY].accessRight != false){
			System.out.print("(3) ");
			RpgGame.GameUtils.AnimateText("West");
		}else{
			System.out.print("(3) ");
			RpgGame.GameUtils.AnimateText("----");
		}
		System.out.print("(-) ");
		RpgGame.GameUtils.AnimateText("Cancel");
		switch(scan.nextLine()){
			case "0":
				if(map[posX][posY - 1] != null){
					MoveNorth();
				}
				break;
			case "1":
				if(map[posX + 1][posY] != null){
					MoveEast();
				}
				break;
			case "2":
				if(map[posX][posY + 1] != null){
					MoveSouth();
				}
				break;
			case "3":
				if(map[posX - 1][posY] != null){
					MoveWest();
				}
				break;
			case "-":
				return;
			default:
				RpgGame.GameUtils.AnimateText("Invaild!");
				Move();
		}
	}
	
	/**
	 * @param Location input
	 * @return Object
	 */
	
	private Object getLocationChildType(Location input){
		if(input instanceof Path){
			return ((Path) input).getType();
		}else{
			return input;
		}
	}
	
	/**
	 * @param Location input
	 * @return boolean
	 */
	
	private boolean getLocationChildCurrent(Location input){
		if(input instanceof Path){
			return ((Path) input).getCurrent();
		}else if(input instanceof Merchant)
		{
			return ((Merchant) input).getCurrent();
		}else {
			return false;
		}
	}
	
	/**
	 * @param Location input
	 * @return None
	 */
	
	private void changeLocationChildCurrentPoss(Location input){
		if(input instanceof Path){
			((Path) input).changeCurrent();
		}else if(input instanceof Merchant) {
			((Merchant) input).changeCurrent();
		}
	} 
	
	/**
	 * @param None
	 * @return None
	 */
	
	private void MoveNorth(){
		if(map[posX][posY - 1].accessBottom == true){
			posY--;
			this.changeLocationChildCurrentPoss(currentPos);
			currentPos = map[posX][posY - 1]; //[posX][posY - 1]
			this.setLocation();
			this.DisplayMap();		
		}
	}
	
	/**
	 * @param None
	 * @return None
	 */
	
	private void MoveNorthWest(){
		if(map[posX - 1][posY - 1].accessBottomRight == true){
			posX--;
			posY--;
			currentPos = map[posX - 1][posY - 1];
			System.out.println(posX + " " + posY);
		}
	}
	
	/**
	 * @param None
	 * @return None
	 */
	
	private void MoveNorthEast(){
		if(map[posX + 1][posY - 1].accessBottomLeft == true){
			posX++;
			posY--;
			currentPos = map[posX + 1][posY - 1];
			System.out.println(posX + " " + posY);
		}
	}

	/**
	 * @param None
	 * @return None
	 */
	
	private void MoveSouth(){
		if(map[posX][posY + 1].accessTop == true){
			posY++;
			this.changeLocationChildCurrentPoss(currentPos);
			currentPos = map[posX][posY + 1];
			this.setLocation();
			this.DisplayMap();
		}
	}
	
	/**
	 * @param None
	 * @return None
	 */
	
	private void MoveSouthWest(){
		if(map[posX - 1][posY + 1].accessTopLeft == true){
			posX--;
			posY++;
			currentPos = map[posX - 1][posY + 1];
			System.out.println(posX + " " + posY);
		}
	}
	
	/**
	 * @param None
	 * @return None
	 */
	
	private void MoveSouthEast(){
		if(map[posX + 1][posY + 1].accessTopRight == true){
			posX++;
			posY++;
			currentPos = map[posX + 1][posY + 1];
			System.out.println(posX + " " + posY);
		}
	}
		
	/**
	 * @param None
	 * @return None
	 */
	
	private void MoveWest(){
		if(map[posX - 1][posY].accessRight == true){
			posX--;
			this.changeLocationChildCurrentPoss(currentPos);
			currentPos = map[posX - 1][posY];
			this.setLocation();
			this.DisplayMap();
		}
	}
	
	/**
	 * @param None
	 * @return None
	 */
	private void MoveEast(){
		if(map[posX + 1][posY].accessLeft == true){
			posX++;
			this.changeLocationChildCurrentPoss(currentPos);
			currentPos = map[posX + 1][posY];
			this.setLocation();
			this.DisplayMap();
		}
	}
}
