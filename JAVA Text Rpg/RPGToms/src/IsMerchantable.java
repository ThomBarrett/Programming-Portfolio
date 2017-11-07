import java.io.Serializable;

public class IsMerchantable implements Merchantable, Serializable{
	@Override
	public void Details() {
	}

	@Override
	public void Sell() {
		Inventory.InventorySingleton.displayContentsSell();
		RpgGame.GameUtils.AnimateText("Select the number of the item you wish to sell");
	}

	@Override
	public void Buy() {
	}
}
