import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;

public class Window {

    private Collection collection;

    private JFrame window;
    private JPanel mainMenu, addMenu, removeMenu, showAllMenu, searchMenu, saveMenu;
    private JButton add, remove, showAll, search, load, write;
    private JButton xml, json, html, back;
    private JTextField nameBox, genreBox, ageRatingBox, platformBox;
    private JTextField searchBox;

    //CONSTRUCTORS
    public Window(){
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
        add.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                addButtonClicked();
            }
        });

        remove = new JButton("Remove");
        remove.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                removeButtonClicked();
            }
        });

        showAll = new JButton("Show All");
        showAll.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                showAllButtonClicked();
            }
        });

        search = new JButton("Search");
        search.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                searchButtonClicked();
            }
        });

        load = new JButton("Load");
        load.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                loadButtonClicked();
            }
        });

        write = new JButton("Save As");
        write.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                saveAsButtonClicked();
            }
        });
    }

    private void createSaveMenuButtonActionListeners(){
        xml = new JButton("XML");
        xml.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    collection.CreateXMLForALLData();
                } catch (IOException e1) {
                    e1.printStackTrace();
                }
            }
        });

        json = new JButton("JSON");
        json.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    collection.CreateJSONForALLData();
                } catch (IOException e1) {
                    e1.printStackTrace();
                }
            }
        });

        html = new JButton("HTML");
        html.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    collection.CreateHTMLForALLData();
                } catch (IOException e1) {
                    e1.printStackTrace();
                }
            }
        });

        back = new JButton("Back");
        back.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                unsetSaveMenu();
            }
        });
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

    public void setAddMenu(){
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
        submit.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
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
            }
        });

        JButton back = new JButton("Back");
        back.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                unsetAddMenu();
            }
        });

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

    public void setRemoveMenu(){

    }

    public void setShowAllMenu(){
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
        back.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                unsetShowAllMenu();
            }
        });

        showAllMenu.add(back);

        window.add(showAllMenu);


        window.revalidate();
        window.repaint();
    }

    public void setSearchMenu(){

    }

    public void setSaveMenu(){
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
    }

    private void showAllButtonClicked() {
        unsetMainMenu();
        setShowAllMenu();

    }

    private void searchButtonClicked() {
        unsetMainMenu();

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

    private void unsetAddMenu(){
        window.remove(addMenu);
        window.add(mainMenu);
        window.revalidate();
        window.repaint();
    }

    private void unsetRemoveMenu(){

    }

    private void unsetSaveMenu(){
        window.remove(saveMenu);
        window.add(mainMenu);
        window.revalidate();
        window.repaint();
    }

    private void unsetShowAllMenu(){
        window.remove(showAllMenu);
        window.add(mainMenu);
        window.revalidate();
        window.repaint();
    }
    //UNSET MENU METHODS
}

