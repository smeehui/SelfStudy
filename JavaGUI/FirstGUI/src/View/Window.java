package View;

import javax.swing.*;
import java.awt.*;

public class Window extends JFrame {
    public Window(String title) throws HeadlessException {
        super(title);
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);
    }
    public void display(int width, int height) throws HeadlessException {
        this.setSize(width, height);
        this.setVisible(true);
    }
}
