import java.io.Serializable;
import java.util.ArrayList;

public class Merchant extends Location implements Serializable {
	
	private boolean current = false;
	public ArrayList<Item> itemsToSell = new ArrayList<Item>();
	
	public Merchant(boolean up, boolean down, boolean left, boolean right) {
		this.accessTop = up;
		this.accessBottom = down;
		this.accessLeft = left;
		this.accessRight = right;
		Item sword = new Item("Sw1","Wooden Sword,",1,10,10);
		Item chestplate = new Item("Cp1","Leather Chest plate,",1,10,10);
		Item potion = new Item("Po1","Health Potion",1,10,10);
		itemsToSell.add(sword);
		itemsToSell.add(chestplate);
		itemsToSell.add(potion);
		type = 'M';
		explorable = new CannotExplore();
		merchantable = new IsMerchantable();
	}
	
	
	public boolean getCurrent(){
		return current;
	}
	
	public void changeCurrent(){
		if(current == true){
			current = false;
			return;
		}else if(current == false){
			current = true;
			return;
		}
	}
	
	public void ItemArrayIterator() {
		System.out.println("|Number|Name|Rarity|Price|");
		int count = 0;
		for(Item item : itemsToSell){
			System.out.print("("+ count +") ");
			RpgGame.GameUtils.AnimateText(item.name + " " + item.rarity + "★" + " " + item.buyValue + "gcs");
			count++;
			
		}
	}
	
}
