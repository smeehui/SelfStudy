package test;

import main.GenericBox;

public class TestGeneric {
    public static void main(String[] args) {
        GenericBox<Double> box1 = new GenericBox<>(2.5);
        System.out.println(box1);
        GenericBox<String> box2 = new GenericBox<>("You make me upset");
        System.out.println(box2);
        GenericBox<Integer []> box3 = new GenericBox<>(new Integer[]{1, 2, 3});
        System.out.println(box3);
        /* Generic: Object can be created with different data type for its property*/
    }
}
