import javax.swing.*;
import javax.swing.table.DefaultTableModel;

import java.text.SimpleDateFormat;
import java.util.Date;

public class Table extends JPanel {

    private static DefaultTableModel dtm;

    public static void addRow(int num, String descript, String activity){
        System.out.println(num);
        System.out.println(descript);
        System.out.println(activity);

        String date = new SimpleDateFormat("dd-MM-yyyy").format(new Date());
        SimpleDateFormat sdfTime = new SimpleDateFormat("HH:mm:ss");
        Date current = new Date();
        String time = sdfTime.format(current);

        Object[] input = new Object[5];

        input[0] = date;
        input[1] = time;
        input[2] = num;
        input[3] = descript;
        input[4] = activity;

        dtm.addRow(input);
    }

    public Table(){
        String col[] = {"Date", "Time", "Rating", "Description", "Activity"};
        dtm = new DefaultTableModel(col, 0){
            @Override
            public boolean isCellEditable(int row, int column) {
                return false;
            }
        };
        JTable table = new JTable(dtm);
        add(new JScrollPane(table));



    }

}