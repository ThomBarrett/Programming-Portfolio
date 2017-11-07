import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.Serializable;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class Path extends Location implements Serializable {
	
	private boolean current = false;
	
	
	public Path(boolean up, boolean down, boolean left, boolean right){
		explorable = new CanExplore();
		merchantable = new NotMerchantable();
		
		
		this.accessTop = up;
		this.accessBottom = down;
		this.accessLeft = left;
		this.accessRight = right;
		
		if(this.accessBottom == true && this.accessTop == true && this.accessLeft == true && this.accessRight == true){
			type = '╬';
		}else if(this.accessBottom == true && this.accessTop == true && this.accessLeft == false && this.accessRight == false){
			type = '║';
		}else if(this.accessBottom == false && this.accessTop == false && this.accessLeft == true && this.accessRight == true){
			type = '═';
		}else if(this.accessBottom == true && this.accessTop == true && this.accessLeft == true && this.accessRight == false){
			type = '╣';
		}else if(this.accessBottom == true && this.accessTop == true && this.accessLeft == false && this.accessRight == true){
			type = '╠';
		}else if(this.accessBottom == false && this.accessTop == true && this.accessLeft == true && this.accessRight == true){
			type = '╩';
		}else if(this.accessBottom == true && this.accessTop == false && this.accessLeft == true && this.accessRight == true){
			type = '╦';
		}else if(this.accessBottom == true && this.accessTop == false && this.accessLeft == false && this.accessRight == true){
			type = '╔';
		}else if(this.accessBottom == true && this.accessTop == false && this.accessLeft == true && this.accessRight == false){
			type = '╗';
		}else if(this.accessBottom == false && this.accessTop == true && this.accessLeft == true && this.accessRight == false){
			type = '╝';
		}else if(this.accessBottom == false && this.accessTop == true && this.accessLeft == false && this.accessRight == true){
			type = '╚';
		}else{
			type = ' ';
		}
		
		
		
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
	
}
