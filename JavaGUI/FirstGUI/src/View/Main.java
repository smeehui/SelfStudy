package View;

import javax.swing.*;

public class Main {
    public static void main(String[] args) {
        Window window = new Window("Hi");
        window.display(500, 600);
        Window window2 = new Window("Hi");
        window2.display(500, 600);
        window2.setLocation(400,400);
    }
}
