import java.io.IOException;
import java.util.Scanner;

public class CollectionController {

    //ATTRIBUTES
    Collection collection;
    //ATTRIBUTES

    //CONSTRUCTOR
    public CollectionController(){
        collection = new Collection();
    }
    //CONSTRUCTOR

    public void ShowUserInterface(){
        System.out.println("[1] ADD");
        System.out.println("[2] REMOVE");
        System.out.println();
        System.out.println("[3] OUTPUT ALL INFORMATION");
        System.out.println("[4] OUTPUT GENRE INFORMATION");
        System.out.println("[5] OUTPUT AGE RATING INFORMATION");
        System.out.println("[6] OUTPUT PLATFORM INFORMATION");
        System.out.println();
        System.out.println("[7] SEARCH AND OUTPUT ALL INFORMATION");
        System.out.println("[8] SEARCH AND OUTPUT GENRE INFORMATION");
        System.out.println("[9] SEARCH AND OUTPUT AGE RATING INFORMATION");
        System.out.println("[10] SEARCH AND OUTPUT PLATFORM INFORMATION");
        System.out.println();
        System.out.println("[0] GENERATE XML DATA");
        System.out.println("[99] LOAD FROM XML DATA");
        System.out.println();
        System.out.println("[88] GENERATE JSON DATA");
        System.out.println();
        System.out.println("[999] GENERATE HTML DATA");

            Scanner scannum = new Scanner(System.in);
            int input;
            if(scannum.hasNextInt()){
                input = scannum.nextInt();
            }else{
                Scanner scannum2 = new Scanner(System.in);
                input = scannum2.nextInt();
            }






            switch (input) {

                case 1: //ADD GAME
                    collection.addGame();
                    break;

                case 2: //REMOVE GAME
                    collection.removeGame();
                    break;

                case 3: //OUTPUT ALL
                    collection.outputALL();
                    break;

                case 4: //OUTPUT GENRE
                    collection.outputGenre();
                    break;

                case 5: //OUTPUT AGE RATING
                    collection.outputAgeRating();
                    break;

                case 6: //OUTPUT PLATFORM
                    collection.outputPlatform();
                    break;

                case 7: //SEARCH OUTPUT ALL
                    collection.searchAll();
                    break;

                case 8: //SEARCH OUTPUT GENRE
                    collection.searchGenre();
                    break;

                case 9: //SEARCH OUTPUT AGE RATING
                    collection.searchAgeRating();
                    break;

                case 10: //SEARCH OUTPUT PLATFORM
                    collection.searchPlatform();
                    break;

                case 0: //GENERATE XML ALL DATA
                    try {
                        collection.CreateXMLForALLData();
                    } catch (IOException ioe) {
                        ioe.printStackTrace();
                    }
                    break;

                case 99: //READ XML DATA
                    collection.ReadXMLForALLData();
                    break;

                case 88:
                    try {
                        collection.CreateJSONForALLData();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    break;

                case 999: //GENERATE HTML ALL DATA
                    try {
                        collection.CreateHTMLForALLData();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    break;

                default:
                    break;
            }
            try {
                System.in.read();
            }catch(Exception e){

        }
    }


}
