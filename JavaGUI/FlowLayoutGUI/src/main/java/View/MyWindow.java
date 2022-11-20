package View;

import javax.swing.*;
import java.awt.*;

public class MyWindow extends JFrame {
    public MyWindow() {
        this.setTitle("My Window");
        this.setSize(600, 400);
//        Center the window
        this.setLocationRelativeTo(null);

//        Set Layout
        FlowLayout flowLayout = new FlowLayout(FlowLayout.CENTER);

//        Buttons
        JButton btn1 = new JButton("OK");
        JButton btn2 = new JButton("Apply");
        JButton btn3 = new JButton("Cancel");
        this.add(btn1);
        this.add(btn2);
        this.add(btn3);
        this.setLayout(flowLayout);
        this.setVisible(true);
        this.setDefaultCloseOperation(this.EXIT_ON_CLOSE);
    }

    public static void main(String[] args) {
        MyWindow view = new MyWindow();
    }
}