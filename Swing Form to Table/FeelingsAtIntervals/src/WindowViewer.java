import javafx.scene.image.Image;

import javax.swing.*;
import java.awt.*;

public class WindowViewer {
    public static void main(String[] args){
        new WindowViewer();
    }

    public WindowViewer(){
        JFrame jframe = new JFrame();
        jframe.setTitle("Mood Manager!");
        jframe.setSize(500,510);
        jframe.setLayout(new FlowLayout());
        jframe.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JLabel title = new JLabel();

        JTabbedPane jtabbedpane = new JTabbedPane();
        jtabbedpane.addTab("Input", new Input());
        jtabbedpane.addTab("Table", new Table());


        jframe.add(jtabbedpane);
        jframe.setVisible(true);
    }
}
