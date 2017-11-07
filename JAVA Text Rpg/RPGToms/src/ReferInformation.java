
public class ReferInformation {
	/*
	 * This class is for any information that may need to be referred to through out game
	 * 
	 * This may be changed to a system to access various text files or databases 
	 * */
	
	private final String[] months = {
		"January","February","March",
		"April","May","June",
		"July","August","September",
		"October","November","December"};
	
	
	/**
	 * @param None
	 * @return String[] months
	 */
	public String[] getMonthsArray(){
		return months;
	}
	
	/**
	 * @param int input
	 * @return String month
	 */
	public String getMonth(int input){
		return months[input-1].toString();
	}
}
