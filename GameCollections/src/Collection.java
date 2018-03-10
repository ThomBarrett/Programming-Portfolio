import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.io.*;
import java.util.HashMap;
import java.util.Scanner;

public class Collection {

    //ATTRIBUTES
    private HashMap<String, Game> gameCollection;
    //ATTRIBUTES

    //CONSTRUCTOR
    public Collection(){
        gameCollection = new HashMap<String, Game>();
    }
    //CONSTRUCTOR

    //GETTERS
    public HashMap<String, Game> getGameCollection(){
        return this.gameCollection;
    }
    //GETTERS

    //ADD METHODS
    public void addGame(){
        Scanner scan;
        Scanner scan2 = new Scanner(System.in);
        System.out.print("Name: ");
        scan = new Scanner(System.in);
        String name = scan.nextLine();;
        System.out.print("Genre: ");
        scan = new Scanner(System.in);
        String genre = scan.nextLine();
        System.out.print("Age Rating: ");
        scan2 = new Scanner(System.in);
        byte ageRating = (byte)Integer.parseInt(scan2.nextLine());
        System.out.print("Platform: ");
        scan = new Scanner(System.in);
        String platform = scan.nextLine();

        this.addGame(name, genre, ageRating, platform);
    }

    public void addGame(String name, String genre, byte ageRating, String platform){
        gameCollection.put(name, new Game(name, genre, ageRating, platform));
    }
    //ADD METHODS

    //REMOVE METHODS
    public void removeGame(){
        Scanner scan = new Scanner(System.in);
        String keyToRemove = scan.nextLine();
        gameCollection.remove(keyToRemove);;
    }

    public void removeGame(String keyToRemove){
        gameCollection.remove(keyToRemove);
    }
    //REMOVE METHODS

    //OUTPUT METHODS
    public void outputALL(){
        for (String key : gameCollection.keySet()) {
            gameCollection.get(key).outputAll();
        }
    }

    public void outputGenre(){
        for (String key : gameCollection.keySet()) {
            gameCollection.get(key).outputGenre();
        }
    }

    public void outputAgeRating(){
        for (String key : gameCollection.keySet()) {
            gameCollection.get(key).outputAgeRating();
        }
    }

    public void outputPlatform(){
        for (String key : gameCollection.keySet()) {
            gameCollection.get(key).outputPlatform();
        }
    }
    //OUTPUT METHODS

    //SEARCH METHODS
    public void searchAll(){
        Scanner scan = new Scanner(System.in);
        String keyToSearch = scan.nextLine();
        boolean resultsPresent = false;
        for (String key : gameCollection.keySet()) {
            if(key.toLowerCase().contains(keyToSearch.toLowerCase())){
                resultsPresent = true;
                gameCollection.get(key).outputAll();
            }
        }
        if(resultsPresent == false){
            searchFailed(keyToSearch);
        }
    }

    public Object[][] searchAllFromForm(String input){
        int elementCount = 0;
        for (String key : gameCollection.keySet()) {
            if(gameCollection.get(key).getName().toLowerCase().contains(input.toLowerCase())){
                elementCount++;
            }
        }

        Object[][] foundGames = new Object[elementCount][4];
        int count = 0;
        for(String key : gameCollection.keySet()){
            if(gameCollection.get(key).getName().toLowerCase().contains(input.toLowerCase())) {
                foundGames[count][0] = gameCollection.get(key).getName();
                foundGames[count][1] = gameCollection.get(key).getGenre();
                foundGames[count][2] = gameCollection.get(key).getAgeRating();
                foundGames[count][3] = gameCollection.get(key).getPlatform();
                count++;
            }
        }
        return foundGames;
    }

    public void searchAll(String keyToSearch){
        boolean resultsPresent = false;
        for (String key : gameCollection.keySet()) {
            if(key.toLowerCase().contains(keyToSearch.toLowerCase())){
                resultsPresent = true;
                gameCollection.get(key).outputAll();
            }
        }
        if(resultsPresent == false){
            searchFailed(keyToSearch);
        }
    }

    public void searchGenre(){
        Scanner scan = new Scanner(System.in);
        String keyToSearch = scan.nextLine();
        scan.close();
        boolean resultsPresent = false;
        for (String key : gameCollection.keySet()) {
            if(key.toLowerCase().contains(keyToSearch.toLowerCase())){
                resultsPresent = true;
                gameCollection.get(key).outputGenre();
            }
        }
        if(resultsPresent == false){
            searchFailed(keyToSearch);
        }
    }

    public void searchGenre(String keyToSearch){
        boolean resultsPresent = false;
        for (String key : gameCollection.keySet()) {
            if(key.toLowerCase().contains(keyToSearch.toLowerCase())){
                resultsPresent = true;
                gameCollection.get(key).outputGenre();
            }
        }
        if(resultsPresent == false){
            searchFailed(keyToSearch);
        }
    }

    public void searchAgeRating(){
        Scanner scan = new Scanner(System.in);
        String keyToSearch = scan.nextLine();
        scan.close();
        boolean resultsPresent = false;
        for (String key : gameCollection.keySet()) {
            if(key.toLowerCase().contains(keyToSearch.toLowerCase())){
                resultsPresent = true;
                gameCollection.get(key).outputAgeRating();
            }
        }
        if(resultsPresent == false){
            searchFailed(keyToSearch);
        }
    }

    public void searchAgeRating(String keyToSearch){
        boolean resultsPresent = false;
        for (String key : gameCollection.keySet()) {
            if(key.toLowerCase().contains(keyToSearch.toLowerCase())){
                resultsPresent = true;
                gameCollection.get(key).outputAgeRating();
            }
        }
        if(resultsPresent == false){
            searchFailed(keyToSearch);
        }
    }

    public void searchPlatform(){
        Scanner scan = new Scanner(System.in);
        String keyToSearch = scan.nextLine();
        scan.close();
        boolean resultsPresent = false;
        for (String key : gameCollection.keySet()) {
            if(key.toLowerCase().contains(keyToSearch.toLowerCase())){
                resultsPresent = true;
                gameCollection.get(key).outputPlatform();
            }
        }
        if(resultsPresent == false){
            searchFailed(keyToSearch);
        }
    }

    public void searchPlatform(String keyToSearch){
        boolean resultsPresent = false;
        for (String key : gameCollection.keySet()) {
            if(key.toLowerCase().contains(keyToSearch.toLowerCase())){
                resultsPresent = true;
                gameCollection.get(key).outputPlatform();
            }
        }
        if(resultsPresent == false){
            searchFailed(keyToSearch);
        }
    }

    public void searchFailed(String keyThatFailed){
        System.out.println("The Game \"" + keyThatFailed + "\" Doesn't Exist");
    }
    //SEARCH METHODS

    //XML WRITE METHODS
    public void CreateXMLForALLData() throws IOException {
        File fout = new File("Games.xml");
        if(fout.exists()){
            fout.delete();
        }
        FileOutputStream fos = new FileOutputStream(fout);

        BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(fos));

        bw.write("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        bw.newLine();
        bw.newLine();

        bw.write("<root>");
        bw.newLine();
        bw.newLine();

        for (String key : gameCollection.keySet()) {
            bw.write("  <game name = \"" + gameCollection.get(key).getName() + "\">");
            bw.newLine();
            bw.write("    <name>" + gameCollection.get(key).getName() + "</name>");
            bw.newLine();
            bw.write("    <genre>" + gameCollection.get(key).getGenre() + "</genre>");
            bw.newLine();
            bw.write("    <agerating>" + gameCollection.get(key).getAgeRating() + "</agerating>");
            bw.newLine();
            bw.write("    <platform>" + gameCollection.get(key).getPlatform() + "</platform>");
            bw.newLine();
            bw.write("  </game>");
            bw.newLine();
            bw.newLine();
        }

        bw.write("</root>");
        bw.flush();
        bw.close();
    }
    //XML WRITE METHODS

    //XML READ METHODS
    public void ReadXMLForALLData(){
        try {
            File inputFileXML = new File("Games.xml");
            DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder documentBuilder = documentBuilderFactory.newDocumentBuilder();
            Document document = documentBuilder.parse(inputFileXML);
            document.getDocumentElement().normalize();

            NodeList nodeList = document.getElementsByTagName("game");

            for(int temp = 0; temp < nodeList.getLength(); temp++){
                Node node = nodeList.item(temp);

                if(node.getNodeType() == Node.ELEMENT_NODE){
                    Element element = (Element) node;

                    String name = element.getElementsByTagName("name").item(0).getTextContent();
                    String genre = element.getElementsByTagName("genre").item(0).getTextContent();
                    byte ageRating = (byte)Integer.parseInt(element.getElementsByTagName("agerating").item(0).getTextContent());
                    String platform = element.getElementsByTagName("platform").item(0).getTextContent();

                    if(!gameCollection.containsKey(name)){
                        gameCollection.put(name, new Game(name, genre, ageRating, platform));
                    }
                }
            }


        }catch(Exception e){
            e.printStackTrace();
        }
    }
    //XML READ METHODS

    //JSON WRITE METHODS
    public void CreateJSONForALLData() throws IOException{
        File fout = new File("Games.json");
        if(fout.exists()){
            fout.delete();
        }
        FileOutputStream fos = new FileOutputStream(fout);

        BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(fos));

        bw.write("{\"games\":[");
        bw.newLine();

        int numberOfGames = gameCollection.size();
        int count = 0;
        for(String key : gameCollection.keySet()){
            count++;
            if(count != numberOfGames) {
                bw.write("    { \"name\":\"" + gameCollection.get(key).getName() + "\", \"genre\":\"" + gameCollection.get(key).getName() + "\", \"agerating\":\"" + gameCollection.get(key).getAgeRating() + "\", \"platform\":\"" + gameCollection.get(key).getPlatform() + "\" },");
            }else{
                bw.write("    { \"name\":\"" + gameCollection.get(key).getName() + "\", \"genre\":\"" + gameCollection.get(key).getName() + "\", \"agerating\":\"" + gameCollection.get(key).getAgeRating() + "\", \"platform\":\"" + gameCollection.get(key).getPlatform() + "\" }");
            }
            bw.newLine();
        }

        bw.write("]}");

        bw.flush();
        bw.close();
    }
    //JSON WRITE METHODS

    //HTML WRITE METHODS
    public void CreateHTMLForALLData() throws IOException{
        File fout = new File("Games.html");
        if(fout.exists()){
            fout.delete();
        }
        FileOutputStream fos = new FileOutputStream(fout);

        BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(fos));

        bw.write("<!DOCTYPE html>");
        bw.newLine();
        bw.write("<html>");
        bw.newLine();
        bw.write("  <head>");
        bw.newLine();
        bw.write("    <meta charset =\"UTF-8\">");
        bw.newLine();
        bw.write("    <title>Game List</title>");
        bw.newLine();
        bw.write("  </head>");
        bw.newLine();

        bw.write("  <body>");
        bw.newLine();
        bw.write("    <h1 style=\"margin-left:50%;\">Game List</h1>");
        bw.newLine();

        for (String key : gameCollection.keySet()) {
            bw.write("    <h2>" +gameCollection.get(key).getName() + "</h2>");
            bw.newLine();
            bw.write("    <ul>");
            bw.newLine();
            bw.write("      <li><strong>Genre:</strong>&nbsp;&nbsp;&nbsp;&nbsp;" + gameCollection.get(key).getGenre() + "</li>");
            bw.newLine();
            bw.write("      <li><strong>Age Rating:</strong>&nbsp;&nbsp;&nbsp;&nbsp;"+ gameCollection.get(key).getAgeRating() + "</li>");
            bw.newLine();
            bw.write("      <li><strong>Platform:</strong>&nbsp;&nbsp;&nbsp;&nbsp;" + gameCollection.get(key).getPlatform() + "</li>");
            bw.newLine();
            bw.write("    </ul>");
            bw.newLine();
            bw.write("    <br>");
            bw.newLine();
        }

        bw.write("  </body>");
        bw.newLine();
        bw.write("</html>");
        bw.flush();
        bw.close();
    }
    //HTML WRITE METHODS

    //MAIN
    public static void main(String[] args){
        CollectionController collectionController = new CollectionController();

        Window window = new Window();

        while(1 == 1) {
            collectionController.ShowUserInterface();
        }
    }
    //MAIN
}


