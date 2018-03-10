import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.HashMap;

class Window {

    private Collection collection;

    private JFrame window; //The window

    private JPanel mainMenu, addMenu, removeMenu, showAllMenu, searchMenu, searchResultsMenu, saveMenu; //All menu
    private JButton add, remove, showAll, search, load, write; //All main menu buttons
    private JButton xml, json, html; //Save menu buttons
    private JButton back, submit; //Controls
    private JTextField nameBox, genreBox, ageRatingBox, platformBox; //Add menu text fileds
    private JTextField searchBox;
    private Object[][] searchData;//Search menu text fields
    private JTextField removeBox;

    //CONSTRUCTORS
    Window(){
        window = new JFrame("Game Collections");
        window.setSize(300,300);
        collection = new Collection();
        collection.ReadXMLForALLData();

        setMainMenu();

        window.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        window.setVisible(true);
    }
    //CONSTRUCTORS


    //CREATE BUTTONS WITH ACTION LISTENERS
    private void createMainMenuButtonActionListeners(){
        add = new JButton("Add");
        add.addActionListener(e -> addButtonClicked());

        remove = new JButton("Remove");
        remove.addActionListener(e -> removeButtonClicked());

        showAll = new JButton("Show All");
        showAll.addActionListener(e -> showAllButtonClicked());

        search = new JButton("Search");
        search.addActionListener(e -> searchButtonClicked());

        load = new JButton("Load");
        load.addActionListener(e -> loadButtonClicked());

        write = new JButton("Save As");
        write.addActionListener(e -> saveAsButtonClicked());
    }

    private void createSaveMenuButtonActionListeners(){
        xml = new JButton("XML");
        xml.addActionListener(e -> {
            try {
                collection.CreateXMLForALLData();
            } catch (IOException e1) {
                e1.printStackTrace();
            }
        });

        json = new JButton("JSON");
        json.addActionListener(e -> {
            try {
                collection.CreateJSONForALLData();
            } catch (IOException e1) {
                e1.printStackTrace();
            }
        });

        html = new JButton("HTML");
        html.addActionListener(e -> {
            try {
                collection.CreateHTMLForALLData();
            } catch (IOException e1) {
                e1.printStackTrace();
            }
        });

        back = new JButton("Back");
        back.addActionListener(e -> unsetPanel(saveMenu));
    }

    private void createRemoveMenuButtonActionListeners(){
        submit = new JButton("Remove");
        submit.addActionListener(e -> collection.removeGame(removeBox.getText()));

        back = new JButton("Back");
        back.addActionListener(e -> unsetPanel(removeMenu));
    }

    private void createSearchMenuButtonActionListeners(){
        submit = new JButton("Search");
        submit.addActionListener(e -> {
           searchData = collection.searchAllFromForm(searchBox.getText());
           window.remove(searchMenu);
           setSearchResultsMenu();
        });

        back = new JButton("Back");
        back.addActionListener(e -> unsetPanel(searchMenu));
    }
    //CREATE BUTTONS WITH ACTION LISTENERS

    //SET MENU METHODS
    private void setMainMenu(){
        mainMenu = new JPanel();

        createMainMenuButtonActionListeners();

        mainMenu.add(add);
        mainMenu.add(remove);
        mainMenu.add(showAll);
        mainMenu.add(search);
        mainMenu.add(load);
        mainMenu.add(write);

        window.add(mainMenu);
    }

    private void setAddMenu(){
        addMenu = new JPanel();

        nameBox = new JTextField();
        nameBox.setColumns(25);
        genreBox = new JTextField();
        genreBox.setColumns(25);
        ageRatingBox = new JTextField();
        ageRatingBox.setColumns(2);
        platformBox = new JTextField();
        platformBox.setColumns(25);

        JButton submit = new JButton("Submit");
        submit.addActionListener(e -> {
            if(nameBox.getText().length() < 1){
                return;
            }
            if(genreBox.getText().length() < 1){
                return;
            }
            if(ageRatingBox.getText().length() < 1){
                return;
            }
            if(platformBox.getText().length() < 1){
                return;
            }
            collection.addGame(nameBox.getText(),genreBox.getText(),(byte)Integer.parseInt(ageRatingBox.getText()), platformBox.getText());
            nameBox.setText("");
            genreBox.setText("");
            ageRatingBox.setText("");
            platformBox.setText("");
        });

        JButton back = new JButton("Back");
        back.addActionListener(e -> unsetPanel(addMenu));

        addMenu.add(nameBox);
        addMenu.add(genreBox);
        addMenu.add(ageRatingBox);
        addMenu.add(platformBox);
        addMenu.add(submit);
        addMenu.add(back);

        window.add(addMenu);
        window.revalidate();
        window.repaint();
    }

    private void setRemoveMenu(){
        removeMenu = new JPanel();

        removeBox = new JTextField();
        removeBox.setColumns(25);
        createRemoveMenuButtonActionListeners();

        removeMenu.add(removeBox);
        removeMenu.add(submit);
        removeMenu.add(back);

        window.add(removeMenu);

        window.revalidate();
        window.repaint();
    }

    private void setShowAllMenu(){
        showAllMenu = new JPanel();

        HashMap<String, Game> data = collection.getGameCollection();

        int gameCount = data.size();
        String[] columnNames = {"Name","Genre","Age Rating","Platform"};
        Object[][] allGames = new Object[gameCount][4];
        int count = 0;
        for(String key : data.keySet()){
            allGames[count][0] = data.get(key).getName();
            allGames[count][1] = data.get(key).getGenre();
            allGames[count][2] = data.get(key).getAgeRating();
            allGames[count][3] = data.get(key).getPlatform();
            count++;
        }

        JTable table = new JTable(allGames, columnNames);
        table.setPreferredScrollableViewportSize(new Dimension(250,200));
        table.setFillsViewportHeight(true);

        JScrollPane tableScroller = new JScrollPane(table);

        showAllMenu.add(tableScroller);

        JButton back = new JButton("Back");
        back.addActionListener(e -> unsetPanel(showAllMenu));

        showAllMenu.add(back);

        window.add(showAllMenu);


        window.revalidate();
        window.repaint();
    }

    private void setSearchResultsMenu(){
        searchResultsMenu = new JPanel();

        String[] columnNames = {"Name","Genre","Age Rating","Platform"};


        JTable table = new JTable(searchData, columnNames);
        table.setPreferredScrollableViewportSize(new Dimension(250,200));
        table.setFillsViewportHeight(true);

        JScrollPane tableScroller = new JScrollPane(table);

        searchResultsMenu.add(tableScroller);

        JButton back = new JButton("Back");
        back.addActionListener(e -> unsetPanel(searchResultsMenu));

        searchResultsMenu.add(back);

        window.add(searchResultsMenu);

        window.revalidate();
        window.repaint();
    }

    private void setSearchMenu(){
        searchMenu = new JPanel();

        searchBox = new JTextField();
        searchBox.setColumns(25);
        createSearchMenuButtonActionListeners();

        searchMenu.add(searchBox);
        searchMenu.add(submit);
        searchMenu.add(back);


        window.add(searchMenu);

        window.revalidate();
        window.repaint();
    }

    private void setSaveMenu(){
        saveMenu = new JPanel();

        createSaveMenuButtonActionListeners();

        saveMenu.add(xml);
        saveMenu.add(json);
        saveMenu.add(html);
        saveMenu.add(back);

        window.add(saveMenu);

        window.revalidate();
        window.repaint();
    }
    //SET MENU METHODS

    //BUTTON CLICK METHODS
    private void addButtonClicked(){
        unsetMainMenu();
        setAddMenu();
    }

    private void removeButtonClicked(){
        unsetMainMenu();
        setRemoveMenu();
    }

    private void showAllButtonClicked() {
        unsetMainMenu();
        setShowAllMenu();

    }

    private void searchButtonClicked() {
        unsetMainMenu();
        setSearchMenu();
    }

    private void loadButtonClicked() {
        collection.ReadXMLForALLData();
    }

    private void saveAsButtonClicked() {
        unsetMainMenu();
        setSaveMenu();
    }
    //BUTTON CLICK METHODS

    //UNSET MENU METHODS
    private void unsetMainMenu(){
        window.remove(mainMenu);
        window.revalidate();
        window.repaint();
    }

    private void unsetPanel(JPanel currentPanel){
        window.remove(currentPanel);
        window.add(mainMenu);
        window.revalidate();
        window.repaint();
    }
    //UNSET MENU METHODS
}

