import java.io.Serializable;

public class CannotExplore implements Exploration, Serializable {
	public void Explore() {
		throw new IllegalStateException("<PROGRAM TERMINATED> This Should Not Be Explorable And This Function Should Never Have Been Called <PROGRAM TERMINATED>");
	} 
}

