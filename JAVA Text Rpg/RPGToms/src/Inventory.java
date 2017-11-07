import java.io.Serializable;
import java.util.LinkedList;
import java.util.Optional;

public class Inventory implements Serializable  {
	
	public static class InventorySingleton implements Serializable{
		
		private static LinkedList<Item> inventory = new LinkedList<Item>();
		public InventorySingleton() {
		}
			
		public static void add(Item item) {
			inventory.add(item);
		}
		
		public void delete(Item item) {
			if(item.ammount == 1) {
				inventory.remove(item);
			}
			else {
				inventory.get(inventory.indexOf(item)).ammount--;
			}
			
		} 
		
		public void getItemByID(String id) {
			for(int i = 0; i < inventory.size(); i++) {
				if(inventory.get(i).id == id) {
					returnItem(inventory.get(i));
					break;
				}
			}
			
			
		}
		
		private Item returnItem(Item item) {
			return item;
		}
		
		public static void displayContentsFull() {
			System.out.println("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
			System.out.println("░░╔════╦══════╦═════════╦════════╦══════╦═════╦═════════════╗░░");
			System.out.println("░░║ ID ║ Name ║ Ammount ║ Rarity ║ Sell ║ Buy ║ Description ║░░");
			System.out.println("░░╚════╩══════╩═════════╩════════╩══════╩═════╩═════════════╝░░");
			System.out.println("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
			for(Item element : inventory) {
				
				System.out.println("│ (" + element.id +") │ " + element.name + " │ " + element.ammount + " │ " + element.rarity + " │ " + element.sellValue + " │ " + element.buyValue + " │ " + element.description + " │");
				
			}
		}
		
		public static void displayContentsSell() {
			System.out.println("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
			System.out.println("░░╔════╦══════╦═════════╦══════╦═════════════╗░░");
			System.out.println("░░║ ID ║ Name ║ Ammount ║ Sell ║ Description ║░░");
			System.out.println("░░╚════╩══════╩═════════╩══════╩═════════════╝░░");
			System.out.println("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
			for(Item element : inventory) {
				System.out.println("│ (" + element.id +") │ " + element.name + " │ " + element.ammount + " │ " + element.sellValue + " │ " + element.description + " │");
			}
		}
		
	}
	
}

