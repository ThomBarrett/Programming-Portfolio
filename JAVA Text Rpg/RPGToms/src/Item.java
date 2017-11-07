import java.io.Serializable;

public class Item implements Serializable {
	protected String id;
	protected String name;
	protected int rarity;
	protected int sellValue;
	protected int buyValue;
	protected int ammount;
	
	protected String description;
	
	public Item()  {
		
	}
	
	public Item(String id, String name, int rarity, int sellValue, int buyValue) {
		this.id = id;
		this.name = name;
		this.rarity = rarity;
		this.sellValue = sellValue;
		this.buyValue = buyValue;
		this.ammount = 1;
	}
}
