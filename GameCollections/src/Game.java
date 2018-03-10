
public class Game {
    
    //ATTRIBUTES
    private String name;
    private String genre;
    private byte ageRating;
    private String platform;
    //ATTRIBUTES

    //CONSTRUCTORS
    public Game(String name, String genre, byte ageRating, String platform){
        this.name = name;
        this.genre = genre;
        this.ageRating = ageRating;
        this.platform = platform;
    }
    //CONSTRUCTORS

    //GETTERS
    public String getName () {
        return name;
    }

    public String getGenre () {
        return genre;
    }

    public byte getAgeRating () {
        return ageRating;
    }

    public String getPlatform () {
        return platform;
    }
    //GETTERS

    //OUTPUT METHODS
    public void outputAll () {
        System.out.println(this.name + ", " + this.genre + ", " + this.ageRating + ", " + this.platform);
    }

    public void outputGenre () {
        System.out.println(this.name + ", " + this.genre);
    }

    public void outputAgeRating () {
        System.out.println(this.name + ", " + this.ageRating);
    }

    public void outputPlatform () {
        System.out.println(this.name + ", " + this.platform);
    }
    //OUTPUT METHODS
    
}
