import java.io.Serializable;

public class NotMerchantable implements Merchantable,Serializable {

	
	
	@Override
	public void Details() {
		throw new IllegalStateException("<PROGRAM TERMINATED> There is no Merchant for this location <PROGRAM TERMINATED>");
	}

	@Override
	public void Sell() {
		throw new IllegalStateException("<PROGRAM TERMINATED> There is no Merchant for this location <PROGRAM TERMINATED>");
	}

	@Override
	public void Buy() {
		throw new IllegalStateException("<PROGRAM TERMINATED> There is no Merchant for this location <PROGRAM TERMINATED>");
	}

}
