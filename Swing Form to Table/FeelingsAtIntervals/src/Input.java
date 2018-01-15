import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Input extends JPanel {
    public Input(){
        setLayout(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();

        JLabel outoftentable = new JLabel();
        outoftentable.setText("Emotional Rating");

        JSlider outoften = new JSlider(JSlider.HORIZONTAL, 1,10,5);
        outoften.setMajorTickSpacing(1);
        outoften.setMinorTickSpacing(1);
        outoften.setPaintTicks(true);
        outoften.setPaintLabels(true);

        JLabel description = new JLabel();
        description.setText("Description");

        JTextField descriptionbox = new JTextField();

        JLabel activity = new JLabel();
        activity.setText("Activity");

        JTextField activitybox = new JTextField();

        JButton submit = new JButton();
        submit.setText("Submit!");

        submit.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                Table.addRow(outoften.getValue(),descriptionbox.getText(),activitybox.getText());
                System.out.println("Sent!");
            }
        });


        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 0;
        gbc.gridy = 0;
        add(outoftentable, gbc);

        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 1;
        gbc.gridy = 0;
        add(outoften, gbc);

        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 0;
        gbc.gridy = 1;
        gbc.gridwidth = 3;
        add(new JSeparator(JSeparator.HORIZONTAL),gbc);

        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 0;
        gbc.gridy = 2;
        add(description, gbc);

        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 1;
        gbc.gridy = 2;
        add(descriptionbox, gbc);

        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 0;
        gbc.gridy = 3;
        gbc.gridwidth = 3;
        add(new JSeparator(JSeparator.HORIZONTAL),gbc);

        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 0;
        gbc.gridy = 4;
        add(activity, gbc);

        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 1;
        gbc.gridy = 4;
        add(activitybox, gbc);

        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 1;
        gbc.gridy = 5;

        add(submit, gbc);
    }
}
