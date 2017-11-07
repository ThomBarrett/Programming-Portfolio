import java.io.BufferedReader;
import java.io.FileReader;
import java.io.Serializable;
import java.util.Random;
import java.util.Scanner;


public class CanExplore implements Exploration , Serializable{

	@Override
	public void Explore() {
		//Explore the location
		Random rand = new Random();
		
		int generated = rand.nextInt(100) + 1;
		RpgGame.GameUtils.AnimateText("Searched the area and found...");
		if(generated <= 25) {
			RpgGame.GameUtils.AnimateText("Nothing");
			return;
		}
		if(generated > 25 && generated <= 50) {
			try {
//				Scanner scan = new Scanner("src/Files/CommonHealthItems.txt");
//				while(scan.hasNext()) {
//					System.out.println(scan.nextInt());
//					System.out.println(scan.next());
//					System.out.println(scan.nextInt());
//					System.out.println(scan.nextInt());
//					System.out.println(scan.nextInt());
//					System.out.println(scan.next());
//				}
//				scan.close();
//				
				System.out.println("Treasure");
				FileReader filereader = new FileReader("src/Files/CommonHealthItems.txt");
				BufferedReader bufferreader = new BufferedReader(filereader);
				String text;
				String temp = bufferreader.readLine();
				while(temp != null) {
					
					
					
					temp = bufferreader.readLine();
					text = temp;
					String id = text.substring(0, 1);
					String name = "";
					String rarity;
					String sellval = "";
					String buyval = "";
					String description;
					
					text = text.substring(2);
					char[] arr = text.toCharArray();
					
					int count = 0;
					int elementcount = 0;
					for(char element : arr) {
						if(element != ' ' && count == 0) {
							name += element;
							elementcount++;
						}else {
							count++;
						}
					}
					
					 
					text = text.substring(elementcount +1);
					rarity = text.substring(0,1);
					
					text = text.substring(2);
					
					count = 0;
					elementcount = 0;
					for(char array : text.toCharArray()) {
						if(array != ' ' && count == 0) {
							sellval += array;
							elementcount++;
						}else {
							count++;
						}
						
					}
					
					text = text.substring(elementcount +1);
					
					count = 0;
					elementcount = 0;
					for(char array : text.toCharArray()) {
						if(array != ' ' && count == 0) {
							buyval += array;
							elementcount++;
						}else {
							count++;
						}
						
					}
					
					description = text.substring(elementcount +1);
					
					

					
					name = name.replace('-', ' ');
					description = description.replace('-', ' ');
					
					Item item = new Item();
					item.id = id;
					item.name = name;
					item.rarity = Integer.parseInt(rarity);
					item.buyValue = Integer.parseInt(buyval);
					item.sellValue = Integer.parseInt(sellval);
					item.description = description;
					
					
					AddFoundItem(item);
					//At this point we would want to write the item into the inventory
					//We can't as we don't have access to the player object
					//The inventory could be a possible singleton
					
					
							
					
					
					
					
					
					
				}
				
				bufferreader.close();
			}catch(Exception e){
				
			}
			
			return;
		}
		if(generated > 50 && generated <= 100) {
			//Enemy Appears
		}
	}
	
	public void AddFoundItem(Item item) {
		RpgGame.GameUtils.AnimateText("Do you want to keep the " + item.name + "?");
		System.out.println("(0) YES");
		System.out.println("(1) NO");
		
		Scanner scan = new Scanner(System.in);
		
		switch(scan.nextLine()) {
			case "0":
				System.out.print("HOS");
				Inventory.InventorySingleton.add(item);
				Inventory.InventorySingleton.displayContentsFull();
				break;
			case "1":
				RpgGame.GameUtils.AnimateText("You left the " + item.name + " on the ground");
				break;
			default:
				AddFoundItem(item);
				break;
		}
		
		
		
		
	}
}
	
